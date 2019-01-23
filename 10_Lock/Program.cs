using System;
using System.Threading;

namespace _10_Lock
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread thread1 = new Thread(ThreadUnsafe.Go);
                Thread thread2 = new Thread(ThreadUnsafe.Go);
                thread1.Start();
                thread2.Start();
                thread1.Join();
                thread2.Join();
                ThreadUnsafe.val1 = 1;
                ThreadUnsafe.val2 = 1;
            }
            Console.ReadKey();
        }
    }

    class ThreadUnsafe
    {
        public static int val1 = 1, val2 = 1;

        public static void Go()
        {
            if (val2 != 0)
            {
                Console.WriteLine($"val1 = {val1}");
                Console.WriteLine($"val2 = {val2}");
                Console.WriteLine($"{val1}/{val2} = {val1 / val2}");
                val2 = 0;
            }
        }
    }

    class ThreadSafe
    {
        static readonly object _locker = new object();
        public static int val1, val2 = 1;

        public static void Go()
        {
            lock (_locker)
            {
                if (val2 != 0)
                {
                    Console.WriteLine($"val1 = {val1}");
                    Console.WriteLine($"val2 = {val2}");
                    Console.WriteLine($"{val1}/{val2} = {val1 / val2}");
                    val2 = 0;
                }
            }
        }
    }
}