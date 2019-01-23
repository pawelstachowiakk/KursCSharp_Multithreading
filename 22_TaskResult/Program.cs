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
            WaitForTasks();
            Console.WriteLine("Koniec, naciśnij dowolny klawisz...");
            Console.ReadKey();
            return;
            //Task<Double>[] taskArray = { Task.Run<double>(() => DoComputation(1.0)),
            //                         Task.Run<double>(() => DoComputation(100.0)),
            //                         Task.Run<double>(() => DoComputation(1000.0)) };

            //var results = new Double[taskArray.Length];
            //Double sum = 0;

            //for (int i = 0; i < taskArray.Length; i++)
            //{
            //    results[i] = taskArray[i].Result;
            //    Console.Write("{0:N1} {1}", results[i],
            //                      i == taskArray.Length - 1 ? "= " : "+ ");
            //    sum += results[i];
            //}
            //Console.WriteLine("{0:N1}", sum);
            //Console.ReadKey();
        }

        private static void WaitForTaskResultUsingWait()
        {
            Task task = Task.Run(() =>
            {
                Console.WriteLine("Begin Task");
                Thread.Sleep(2000);
                Console.WriteLine("End Task");
            });
            Console.WriteLine("Waiting for task...");

            //Wątek jest blokowany do momentu wykonania się zadania
            //Można ustawić timeout lub CancellationToken
            task.Wait();

            Console.WriteLine("Task has finished");
        }

        private static void WaitForTaskResultUsingResult()
        {
            Task<string> task = Task<string>.Run(() =>
            {
                Console.WriteLine("Begin Task");
                Thread.Sleep(2000);
                Console.WriteLine("End Task");
                return "Greetings from the task";
            });
            Console.WriteLine("Waiting for task...");

            //Wątek jest blokowany do momentu wykonania się zadania
            string result = task.Result;

            Console.WriteLine($"Task has finished and say: {result}");
        }

        private static void WaitForTasks()
        {
            Task task1 = Task.Run(() => DoSomeWork(1000, "1"));
            Task task2 = Task.Run(() => DoSomeWork(3000, "2"));
            Task task3 = Task.Run(() => DoSomeWork(5000, "3"));

            Console.WriteLine("Waiting for all tasks");
            Task.WaitAny(new Task[] { task1, task2, task3 });
            Console.WriteLine("All tasks have finished");
        }

        private static void DoSomeWork(int sleep, string taskName)
        {
            Console.WriteLine($"Begin Task {taskName}");
            Thread.Sleep(sleep);
            Console.WriteLine($"End Task {taskName}");
        }
    }
}
