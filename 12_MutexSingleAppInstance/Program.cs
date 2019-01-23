using System;
using System.Threading;

namespace _12_MutexSingleAppInstance
{
    class OneAtATimePlease
    {
        static void Main()
        {
            // Nazwany Mutex jest widoczny przez inne procesy.
            // Nazwa musi być unikalna
            using (var mutex = new Mutex(false, "balluf.com OneAtATimeDemo"))
            {
                // Czekamy na wypadek, jakby inna instancja była w stanie zamykania
                if (!mutex.WaitOne(TimeSpan.FromSeconds(3), false))
                {
                    Console.WriteLine("Another app instance is running. Bye!");
                    return;
                }
                RunProgram();
            }
        }

        static void RunProgram()
        {
            Console.WriteLine("Running. Press Enter to exit");
            Console.ReadLine();
        }
    }
}
