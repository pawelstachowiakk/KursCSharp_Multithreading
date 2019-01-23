using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_AutoResteEvent_ProducerConsumer
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ProducerConsumerQueue q = new ProducerConsumerQueue())
            {
                q.EnqueueTask("Hello");
                for (int i = 0; i < 10; i++) q.EnqueueTask("Say " + i);
                q.EnqueueTask("Goodbye!");
            }

            Console.ReadLine();
        }
    }

}