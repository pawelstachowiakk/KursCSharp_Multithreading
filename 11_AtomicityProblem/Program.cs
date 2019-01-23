using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _11_AtomicityProblem
{
    class Program
    {
        static int counter = 0;

        static void Main(string[] args)
        {
            List<Thread> threads = new List<Thread>();

            for (int i = 0; i < 1000; i++)
            {
                Thread thread = new Thread(Count);
                thread.Start();
                threads.Add(thread);
            }

            foreach (var th in threads)
            {
                th.Join();
            }
            Console.WriteLine($"counter = {counter}");
            Console.ReadKey();
        }

        private static void Count()
        {
            for (int i = 0; i < 10; i++)
            {
                counter++;
                Interlocked.Add(ref value, 5);
                Interlocked.Increment(ref value);
                Interlocked.Exchange(value, 10);
                Interlocked.CompareExchange(ref value, 20, 10);
            }
        }
    }
}
