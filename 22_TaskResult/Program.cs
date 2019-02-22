using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _22_TaskResult
{
    class Program
    {
        public static void Main()
        {
            //WaitForTaskResultUsingWait();
            //WaitForTaskResultUsingResult();
            WaitForAnyTask();
            //WaitForAllTasks();
            Console.WriteLine("Koniec, naciśnij dowolny klawisz...");
            Console.ReadKey();
        }

        private static void WaitForTaskResultUsingWait()
        {
            Task task = Task.Run(() =>
            {
                Console.WriteLine("Początek zadania");
                Thread.Sleep(2000);
                Console.WriteLine("Koniec zadania");
            });
            Console.WriteLine("Oczekiwanie na zakończenie zadania");

            //Wątek jest blokowany do momentu wykonania się zadania
            //Można ustawić timeout lub CancellationToken
            task.Wait();

            Console.WriteLine("Zadanie zakończone");
        }

        private static void WaitForTaskResultUsingResult()
        {
            Task<string> task = Task<string>.Run(() =>
            {
                Console.WriteLine("Początek zadania");
                Thread.Sleep(2000);
                Console.WriteLine("Koniec Zadania");
                return "Pozdrowienia z zadania!";
            });
            Console.WriteLine("Oczekiwanie na zakończenie zadania");

            //Wątek jest blokowany do momentu wykonania się zadania
            string result = task.Result;

            Console.WriteLine($"Zadanie zakończone z rezultatem: {result}");
        }

        private static void WaitForAllTasks()
        {
            Task task1 = Task.Run(() => DoSomeWork(5000, "1"));
            Task task2 = Task.Run(() => DoSomeWork(1000, "2"));
            Task task3 = Task.Run(() => DoSomeWork(3000, "3"));

            Console.WriteLine("Czekaj na wszystkie zadania");
            Task.WaitAll(new Task[] { task1, task2, task3 });
            Console.WriteLine("Wszystkie zadania zostały ukończone");
        }

        private static void WaitForAnyTask()
        {
            Task task1 = Task.Run(() => DoSomeWork(5000, "1"));
            Task task2 = Task.Run(() => DoSomeWork(1000, "2"));
            Task task3 = Task.Run(() => DoSomeWork(3000, "3"));

            Console.WriteLine("Czekaj na pierwsze zadanie");
            int taskIndex = Task.WaitAny(new Task[] { task1, task2, task3 });
            Console.WriteLine($"Jako pierwsze zakończyło się zadanie {taskIndex + 1}");
        }

        private static void DoSomeWork(int sleep, string taskName)
        {
            Console.WriteLine($"Początek zadania {taskName}");
            Thread.Sleep(sleep);
            Console.WriteLine($"Koniec zadania {taskName}");
        }
    }
}
