using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer
{
    public class LogWriter : ILogWriter, IDisposable
    {
        private TextWriter writer;

        private readonly ConcurrentQueue<Tuple<DateTime, string, string>> queue = new ConcurrentQueue<Tuple<DateTime, string, string>>();

        private readonly AutoResetEvent queueEvent = new AutoResetEvent(false);

        public LogWriter(TextWriter writer)
        {
            this.writer = writer;
            new Thread(LogWorker).Start();
        }

        private void LogWorker()
        {
            var w = writer;
            while (writer != null)
            {
                Tuple<DateTime, string, string> entry;
                var written = false;
                while (queue.TryDequeue(out entry))
                {
                    try
                    {
                        w.WriteLine("[{0:yyyy-MM-dd HH-mm-ss}] {1}: {2}",
                            entry.Item1, entry.Item2, entry.Item3);
                        written = true;
                    }
                    catch (ObjectDisposedException) { }
                }
                if (written)
                {
                    try
                    {
                        w.Flush();
                    }
                    catch (ObjectDisposedException) { }
                }
                queueEvent.WaitOne();
            }
        }

        public void Log(string tool, string line)
        {
            queue.Enqueue(Tuple.Create(DateTime.Now, tool, line));
            queueEvent.Set();
        }

        public void Dispose()
        {
            if (writer == null) return;
            var w = writer;
            while (queue.Count > 0)
            {
                queueEvent.Set();
                Thread.Sleep(10);
            }
            writer = null;
            w.Flush();
            w.Dispose();
            queueEvent.Set();
        }
    }
}
