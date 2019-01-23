using System;
using System.Threading;

namespace _01_FirstThread
{
    class FirstThread
    {
        static void Main()
        {
            //tworzenie wątku, wątek po utworzeniu nie jest uruchomiony
            Thread t = new Thread(WriteY);
            //uruchamianie wątku
            t.Start();
            t.Join(1000);
            //akcja wykonywana w wątku głównym
            for (int i = 0; i < 100; i++)
                Console.Write("x");

            Console.ReadKey();
        }

        static void WriteY()
        {
            //akcja wykonywana w nowym (pobocznym) wątku 
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write("y");
            }
        }
    }
}
