using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using de.fhb.oll.mediacategorizer.model;

namespace de.fhb.oll.mediacategorizer.processing
{
    class CategoryResourceDownloadProcess : MultiTaskProcessBase
    {
        public CategoryResourceDownloadProcess(ProcessChain chain, params IProcess[] dependencies)
            : base(chain, "Kategorieressourcen downloaden", dependencies)
        {
            ProgressWeight = 3;
        }

        protected override void Work()
        {
            var tasks =
                from c in Project.Categories
                from sr in (c.Resources.Select((r, i) => new { Ressource = r, Index = i }))
                select (ProcessTask)((pH, eH) => ProcessMedia(c, sr.Ressource, sr.Index, pH, eH));
            RunTasks(tasks.ToArray());
        }

        private static string BuildUriHash(string uri)
        {
            return uri.Aggregate(0L, (current, c) => current ^ c * 397).ToString("x8");
        }

        private static string BuildResourceFileExtension(CategoryResource r)
        {
            return r.Type == CategoryResourceType.Html || r.Type == CategoryResourceType.Wikipedia 
                ? ".html" 
                : ".txt";
        }
        
        private void ProcessMedia(Category c, CategoryResource r, int index, Action<float> progressHandler,
            Action<string> errorHandler)
        {
            var uri = new Uri(r.Url);
            if (uri.Scheme == "file") return;

            if (uri.Host.EndsWith(".wikipedia.org"))
            {
                uri = new Uri(r.Url + (r.Url.Contains("?") ? "&" : "?") + "action=render");
            }

            var workingDir = Project.GetWorkingDirectory();
            var ext = BuildResourceFileExtension(r);
            var hash = BuildUriHash(r.Url);
            r.CachedFile = Path.Combine(workingDir, string.Format("{0}_{1:D6}_{2}{3}", c.Id, index, hash, ext));

            if (File.Exists(r.CachedFile)) return;

            var timeout = Setup.DownloadTimeout*1000;

            using (var wc = new CustomWebClient(timeout))
            {
                wc.DownloadProgressChanged += (sender, args) => progressHandler(args.ProgressPercentage/100f);
                var downloadTask = wc.DownloadFileTaskAsync(uri, r.CachedFile);
                downloadTask.Wait();
                if (downloadTask.IsFaulted)
                {
                    errorHandler(downloadTask.Exception != null
                        ? downloadTask.Exception.Message
                        : "Unbekannter Fehler beim Download");
                }
            }
        }

        private class CustomWebClient : WebClient
        {
            public CustomWebClient(int timeout = 60000)
            {
                Timeout = timeout;
            }

            private int Timeout { get; set; }

            protected override WebRequest GetWebRequest(Uri address)
            {
                var request = base.GetWebRequest(address);
                if (request != null)
                {
                    request.Timeout = Timeout;
                }
                return request;
            }
        }
    }
}
