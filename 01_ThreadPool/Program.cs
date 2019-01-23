using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _01_ThreadPool
{
    class Program
    {
        public static void Main()
        {
            for (int i = 0; i < 100; i++)
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                ThreadPool.QueueUserWorkItem(Run, stopwatch);
            }
            Console.ReadLine();
        }
        private static void Run(object state)
        {
            Stopwatch stopwatch = (Stopwatch)state;

            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Thread.Sleep(100000);
        }
    }
}
