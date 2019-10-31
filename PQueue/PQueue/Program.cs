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

      Console.WriteLine("Enter 10 integers: ");
      for(int i=0; i<10; i++)
      {
        int x = int.Parse(Console.ReadLine());
        pq.Insert(x);
      }

      int count = pq.Count;
      for(int i =0; i<count; i++)
        Console.WriteLine(pq.Remove());
    }
  }
}
