using System;
using System.Threading;

namespace _11_Deadlock
{
    class Program
    {
        static object _lokcer1 = new object();
        static object _lokcer2 = new object();

        static void Main(string[] args)
        {
            new Thread(DeadlockMethod).Start();

            lock (_lokcer2)
            {
                Console.WriteLine("Wątek główny po zablokowaniu locker2");
                Thread.Sleep(100);
                Console.WriteLine("Wątek główny obudził się i czeka na zwolnienie locker1");
                lock (_lokcer1)
                    Console.WriteLine("Not reached section 1");
            }
        }

        static void DeadlockMethod()
        {
            lock (_lokcer1)
            {
                Console.WriteLine("Wątek poboczny po zablokowaniu locker1");
                Thread.Sleep(100);
                Console.WriteLine("Wątek poboczny obudził się i czeka na zwolnienie locker2");
                lock (_lokcer2)
                    Console.WriteLine("Not reached section 2");
            }
        }
    }
}
