using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace _20_Parallelism
{
    class Program
    {
        static string _iteration = "1";

        static void Test()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Test{_iteration}_1");
            }
        }

        static void Test2()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Test{_iteration}_2");
            }
        }

        static void Test3()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} Test{_iteration}_3");
            }
        }

        static void Main()
        {
            Parallel.Invoke(Test, Test2, Test3);
            Console.WriteLine("[INTERMEDIATE]");
            _iteration = "2";
            Parallel.Invoke(Test, Test2, Test3);
            Console.ReadLine();
            WebClient wc = new WebClient();
            wc.DownloadProgressChanged += Wc_DownloadProgressChanged;
        }

        private static void Wc_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
