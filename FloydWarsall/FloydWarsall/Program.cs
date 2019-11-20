using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydWarsall
{
  class Program
  {
    static int V = 5;
    const int Inf = 100;

    static void Main(string[] args)
    {
      int[,] graph = {
        { 0,4,2,5,Inf},
        { Inf,0,1,Inf,4},
        { 1,3,0,1,2},
        { -2,Inf,Inf,0,2},
        { Inf,-3,3,1,0}
      };
      PrintGraph(graph, V);
      FloydWarsall(graph, V);
      
    }

    /*
    1. for k = 1 to n
    2.   for i = 1 to n(단, i≠k)
    3.     for j = 1 to n(단, j≠k, j≠i)
    4.       D[i, j] = min{D[i, k]+D[k, j], D[i, j]}
    */

    private static void FloydWarsall(int[,] graph, int v)
    {
      int[,] next = new int[v, v];  // 경로를 추적하기 위한 배열

      for (int i = 0; i < v; i++)
        for (int j = 0; j < v; j++)
          if (i != j)
            next[i, j] = j + 1;

      PrintNext(next, v);

      for (int k = 0; k < v; k++)
      {
        for (int i = 0; i < v; i++)
          for (int j = 0; j < v; j++)
            if (graph[i, k] != Inf && graph[k, j] != Inf)
            {
              if(graph[i, k] + graph[k, j] < graph[i, j])
              {
                graph[i, j] = graph[i, k] + graph[k, j];
                next[i, j] = next[i, k];
              }
            }

        Console.WriteLine("\nGraph({0})", k);
        PrintGraph(graph, v);
        Console.WriteLine("\nNext({0})", k);
        PrintGraph(next, v);

        PrintResult(graph, next);
      }
    }

    private static void PrintResult(int[,] graph, int[,] next)
    {
      Console.WriteLine("Pair  Distance  Path");
      for(int i=0; i<V; i++)
        for(int j=0; j<V; j++)
          if(i!=j)
          {
            int u = i + 1;  // 출발 버텍스 이름: 1,2,3,4,5
            int v = j + 1;  // 도착 버텍스 이름: 1,2,3,4,5
            string path = string.Format("{0}->{1}\t{2}\t{3}",
              u, v, graph[i, j], u);
            do
            {
              u = next[u - 1, v - 1];
              path += "->" + u;
            } while (u != v); // 도착할 때 까지

            Console.WriteLine(path);
          }
    }

    private static void PrintNext(int[,] next, int v)
    {
      Console.WriteLine("\nPrintNext()");
      for (int i = 0; i < v; i++)
      {
        for (int j = 0; j < v; j++)
          Console.Write("{0,8}", next[i, j]);
        Console.WriteLine();
      }
    }

    private static void PrintGraph(int[,] graph, int v)
    {
      for (int i = 0; i < v; i++)
      {
        for (int j = 0; j < v; j++)
          Console.Write("{0,8}", graph[i, j]);
        Console.WriteLine();
      }
    }
  }
}
