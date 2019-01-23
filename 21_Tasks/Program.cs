using System;
using System.Threading;
using System.Threading.Tasks;

namespace _21_CreatingTask
{
    class Program
    {
        public static void Main()
        {
            CreateTaskAndStart();
            RunTaks();
            Console.ReadKey();
        }

        private static void CreateTaskAndStart()
        {
            Thread.CurrentThread.Name = "Main";

            //Tworzymy zadanie i dostarczamy delegate w postaci wyrażenia lambda 
            Task taskA = new Task(() => Console.WriteLine("Hello from thread '{0}'.", Thread.CurrentThread.ManagedThreadId));
            // Uruchamiamy zadanie
            taskA.Start();

            // Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'.",
                              Thread.CurrentThread.ManagedThreadId);
            taskA.Wait();
        }

        private static void RunTaks()
        {
            Thread.CurrentThread.Name = "Main";

            //Tworzymy zadanie i uruchamiamy
            Task taskA = Task.Run(() => Console.WriteLine("Hello from thread '{0}'.", Thread.CurrentThread.ManagedThreadId));

            // Output a message from the calling thread.
            Console.WriteLine("Hello from thread '{0}'.",
                              Thread.CurrentThread.ManagedThreadId);
            taskA.Wait();
        }
    }
}