using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15_AutoResetEvent
{
    class Program
    {
        private static AutoResetEvent event_1 = new AutoResetEvent(true);
        private static AutoResetEvent event_2 = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Console.WriteLine("Naciśnij Enter aby stworzyć trzy wątki i uruchomić je.\r\n" +
                              "Wątki czekają na bramce (AutoResetEvent) #1, która został stworzona\r\n" +
                              "jako otwata (signaled state), więc pierwszy wątek zostanie wpuszczony.\r\n" +
                              "To spowoduje zamknięcie (unsignaled state) bramki.");
            Console.ReadLine();

            for (int i = 1; i < 4; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Wątek_" + i;
                t.Start();
            }
            Thread.Sleep(250);

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Naciśnij Enter, aby otworzyć bramkę #1 dla kolejnego wątku.");
                Console.ReadLine();
                event_1.Set();
                Thread.Sleep(250);
            }

            Console.WriteLine("\r\nTeraz wszystkie wątki czekają na bramce #2,\r\n" + 
                              "która został stowrzona jako zamknięta.");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Naciśnij Enter, aby otworzyć bramkę #2 dla kolejnego wątku.");
                Console.ReadLine();
                event_2.Set();
                Thread.Sleep(250);
            }
            Console.WriteLine("Wszystkie wątki dotarły do celu.");
            Console.WriteLine("Naciśnij Enter aby zakończyć...");
            Console.ReadLine();
        }

        static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Console.WriteLine("{0} czeka przed bramką #1.", name);
            event_1.WaitOne();
            Console.WriteLine("{0} przeszedł przez bramkę #1.", name);

            Console.WriteLine("{0} czeka przed bramką #2.", name);
            event_2.WaitOne();
            Console.WriteLine("{0} przeszedł przez bramkę #2.", name);
        }
    }
}
