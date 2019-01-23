using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _23_CancelationTokenWithTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //CancelBeforeRun();
            CancellationPolling();

            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;

            WebClient wc = new WebClient();
            token.Register(() => wc.CancelAsync());
            wc.DownloadDataAsync("www.wp.pl");
            
            //CancellationTokenSource tokenSource = new CancellationTokenSource();
            //CancellationToken token = tokenSource.Token;

            //Task task = Task.Run(() => DoWork(token), token);

            //Console.WriteLine($"Task status = {task.Status}");

            //try
            //{
            //    task.Wait();
            //}
            //catch (Exception)
            //{
            //}


            //Console.WriteLine($"Task status = {task.Status}");

            Console.ReadKey();
        }

        private static void CancellationPolling()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            Task.Run(() =>
            {
                //Sprawdzanie żądania przerwania
                while (!token.IsCancellationRequested)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("DoWork");
                }
                //Sprzątanie i kończenie pracy
                Console.WriteLine("Cleaning Up and finishing task");
            }, token);
            
            tokenSource.CancelAfter(2000);
        }

        private static void DoWork(CancellationToken token)
        {
            
        }

        private static void CancelBeforeRun()
        {
            CancellationTokenSource tokenSource = new CancellationTokenSource();
            CancellationToken token = tokenSource.Token;
            tokenSource.Cancel();

            //Task task = new Task(() => Console.WriteLine("Hello from Task"), token);
            //task.Start();
            Task task = Task.Run(() => Console.WriteLine("Hello from Task"), token);

            Console.WriteLine($"Task status = {task.Status}");

            try
            {
                task.Wait();
            }
            catch (Exception)
            {
            }

            Console.WriteLine($"Task status = {task.Status}");
        }
    }
}
