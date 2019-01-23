using System;
using System.Threading;

namespace _03_ThreadSharedData
{
    //TODO współdzielenie zmiennej statycznej
    class Program
    {
        static void Main()
        {
            //Tworzenie instancji obiektu ThreadTest
            ThreadTest tt = new ThreadTest();
            // metoda go zostanie urochomiona wątku pobocznym na rzeczy obiektu tt
            new Thread(tt.Go).Start();
            //wywołanie metody w wątku głównymna rzeczy obiektu tt
            tt.Go();

            Console.ReadKey();
        }
    }

    class ThreadTest
    {
        //pole współdzielone przez wątki
        bool done;

        // Metoda instancyjna
        public void Go()
        {
            if (!done)
            {
                //niby wszystko ok, a co się stanie jak zmienimy kolejność i uruchomimy odpalimy kilkukrotnie
                done = true;
                Console.WriteLine("Done");
            }
        }
    }
}
