using System;
using System.Threading;

namespace _13_SemaphoreNightClub
{
    class TheClub
    {
        //Tworzmy semafor o pojemności 3
        static Semaphore _sem = new Semaphore(3,3);

        static void Main()
        {
            for (int i = 1; i <= 5; i++) new Thread(Enter).Start(i);
        }

        static void Enter(object id)
        {
            Console.WriteLine(id + " wants to enter");
            //Tylko 3 wątki mogą być jednocześnie w klubie
            _sem.WaitOne();
            Console.WriteLine(id + " is in!");
            Thread.Sleep(1000 * (int)id);
            Console.WriteLine(id + " is leaving");
            _sem.Release();
        }
    }
}
