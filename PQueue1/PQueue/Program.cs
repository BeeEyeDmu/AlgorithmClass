using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Priority Queue");
            PriorityQueue pq = new PriorityQueue();
            pq.Insert(5);
            pq.Insert(15);
            pq.Insert(35);
            pq.Insert(45);
            pq.Insert(55);
            pq.Insert(6);
            pq.Insert(7);
            pq.Insert(9);
            pq.Insert(12);

            int c = pq.Count;
            for(int i=0; i<c; i++)
                Console.WriteLine(pq.Remove());
        }
    }
}
