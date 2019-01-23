using System;
using System.Threading;

namespace _17_ManualResetEvent
{
    class Program
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);

        static void Main()
        {
            Console.WriteLine("Uruchamiane są 3 wątki czekające (WaitOne()) na otwarcie szlabanu (ManualResetEvent):\n");

            for (int i = 0; i <= 2; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Wątek_" + i;
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\nNaciśnij Enter aby otworzyć szlaban (Set())");
            Console.ReadLine();

            mre.Set();

            Thread.Sleep(500);
            Console.WriteLine("\nNaciśnij Enter, aby stworzyć kolejne 2 wątki i przekonać się," +
                              "\n że szlaban jest otwarty.\n");
            Console.ReadLine();

            for (int i = 3; i <= 4; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Wątek_" + i;
                t.Start();
            }

            Thread.Sleep(500);
            Console.WriteLine("\nNaciśni Enter aby zamknąć szlaban (Reset()).\n");
            Console.ReadLine();

            mre.Reset();

            Thread.Sleep(500);
            Console.WriteLine("\nNaciśnij Enter aby stworzyć kolejny wątek," +
                              "który zatrzyma się przed szlabanem.\n");

            Thread t5 = new Thread(ThreadProc);
            t5.Name = "Wątek_5";
            t5.Start();

            Thread.Sleep(500);
            Console.WriteLine("\nNaciśni Enter aby otworzyć szlaban.");
            Console.ReadLine();

            mre.Set();

            Console.WriteLine("Naciśnij Enter aby zakończyć program...");
            Console.ReadLine();
        }


        private static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine(name + " został uruchomiony i zbliża się do szlabanu (WaitOne())");

            mre.WaitOne();

            Console.WriteLine(name + " przejechał przez otwarty szlaban.");
        }
    }
}
