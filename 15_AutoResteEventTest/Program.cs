using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15_AutoResteEventTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread th1 = new Thread(Thread1Work);
            Thread th2 = new Thread(Thread2Work);
            th1.Start();
            th2.Start();
            Console.ReadLine();
        }

        private static void Thread1Work()
        {
            Console.WriteLine("Wątek 1 wykonuje prace");
            Thread.Sleep(2000);
            Console.WriteLine("Wątek 1 zakończył prace");
            //TODO otworzyć bramkę
        }

        private static void Thread2Work()
        {
            Console.WriteLine("Wątek 2 czeka na wątek 1");
            //TODO czekamy na otwarcie bramki
            Console.WriteLine("Wątek 2 wykonuje prace");
            Thread.Sleep(2000);
            Console.WriteLine("Wątek 2 zakończył prace");
        }
    }
}
