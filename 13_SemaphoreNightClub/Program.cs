using System;
using System.Collections.Generic;
using System.Threading;

namespace _13_SemaphoreNightClub
{
    class TheClub
    {
        //Tworzmy semafor o liczniku 3 (wszytskie miejsca wolne) i pojemności 3
        static Semaphore _sem = new Semaphore(3,3);

        static void Main()
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 1; i <= 5; i++)
            {
                Thread thread = new Thread(Enter);
                thread.Start(i);
                threads.Add(thread);
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }

            Console.ReadKey();
        }

        static void Enter(object id)
        {
            Console.WriteLine(id + " chce wejść");
            //Tylko 3 wątki mogą być jednocześnie w klubie
            _sem.WaitOne();
            Console.WriteLine(id + " jest w klubie!");
            int timeOfVisit = new Random().Next(1000, 10000);
            Thread.Sleep(timeOfVisit);
            Console.WriteLine(id + " opuszcza klub!");
            _sem.Release();
        }
    }
}
