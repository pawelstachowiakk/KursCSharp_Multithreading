using System;
using System.Collections.Generic;
using System.Threading;

namespace _16_AutoResteEvent_ProducerConsumer
{
    class ProducerConsumerQueue : IDisposable
    {
        EventWaitHandle _wh = new AutoResetEvent(false);
        Thread _worker;
        readonly object _locker = new object();
        Queue<string> _tasks = new Queue<string>();

        public ProducerConsumerQueue()
        {
            _worker = new Thread(Work);
            _worker.Start();
        }

        public void EnqueueTask(string task)
        {
            lock (_locker) _tasks.Enqueue(task);
            _wh.Set();
        }

        public void Dispose()
        {
            EnqueueTask(null);     // Powiadomienie konsumenta o zakończeniu pracy
            _worker.Join();         // Oczekiwanie, aż wątek konsumenta zakończy działanie
            _wh.Close();            // Zwalnie zasoby systemowe
        }

        void Work()
        {
            while (true)
            {
                string task = null;
                lock (_locker)
                    if (_tasks.Count > 0)
                    {
                        task = _tasks.Dequeue();
                        if (task == null) return;
                    }
                if (task != null)
                {
                    Console.WriteLine("Performing task: " + task);
                    Thread.Sleep(1000);  // Symulacja pracy
                }
                else
                    _wh.WaitOne();         // Brak zadań - czekamy na sygnał
            }
        }
    }
}
