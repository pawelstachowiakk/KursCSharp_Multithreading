using System;
using System.Threading;

namespace _02_ThreadLocalData
{
    class ThreadLocalData
    {
        static void Main()
        {
            //tworzenie wątku, wątek po utworzeniu nie jest uruchomiony
            Thread t = new Thread(Count);
            //uruchamianie wątku (wywołanie metody WriteY z wątku popocznego)
            t.Start();

            //wywołanie metody z wątku głównego
            Count();

            Console.ReadKey();
        }

        static void Count()
        {
            //zmianna i nie jest współdzielona
            //w każdym wątku tworzona jest na stosie niezależna zmianna lokalna 
            int i = 0;
            while (i++ < 10)
                Console.WriteLine(i);
        }
    }
}
