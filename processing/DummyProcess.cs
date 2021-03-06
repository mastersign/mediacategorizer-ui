﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace de.fhb.oll.mediacategorizer.processing
{
    class DummyProcess : ProcessBase
    {
        private Random rand = new Random();

        public bool Failing { get; set; }

        public DummyProcess(ProcessChain chain, string name, params IProcess[] dependencies)
            : base(chain, name, dependencies)
        {
            WorkItem = "Initial Work Item";
        }

        protected override void Work()
        {
            var steps = rand.Next(10, 30);
            const int workItems = 3;
            for (var i = 0; i < workItems; i++)
            {
                var time = rand.Next(500, 3000);
                Thread.Sleep(rand.Next(100, 1000));
                WorkItem = string.Format("Work Item {0}", i);
                for (var j = 0; j < steps; j++)
                {
                    Thread.Sleep((int)((float)time / steps));
                    OnProgress(CalculateProgress(workItems, i, (float)j / steps),
                        string.Format("Doing dummy stuff {0}, {1}", i, j));
                    if (Failing && i == workItems / 2 && j == steps / 2)
                    {
                        OnError("Failed.");
                        return;
                    }
                    if (IsCanceled) break;
                }
                if (IsCanceled) break;
            }
            if (IsCanceled)
            {
                OnProgress("Der Vorgang wurde abgebrochen.");
            }
            Thread.Sleep(rand.Next(200, 800));
        }
    }
}
