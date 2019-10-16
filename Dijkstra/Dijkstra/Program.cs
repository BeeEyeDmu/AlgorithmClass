using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
  class Program
  {
    string[] city = 
      { "서울", "천안", "원주", "강릉", "논산",
      "대전", "대구", "포항", "광주", "부산" };
    static int V = 10;        // 도시 갯수
    static bool[] spt = new bool[V]; // shortest path tree, 
                              // true if 버텍스가 spt에 포함되면
    static int[] D = new int[V];     // 각 도시의 최단경로

    static void Main(string[] args)
    {
      int[,] graph = new int[,]
      {
        { 0, 12, 15, 0, 0, 0, 0, 0, 0, 0},
        { 12, 0, 0, 0, 4, 10, 0, 0, 0, 0},
        { 15, 0, 0, 21, 0, 0, 7, 0, 0, 0},
        { 0, 0, 21, 0, 0, 0, 0, 25, 0, 0},
        { 0, 4, 0, 0, 0, 3, 0, 0, 13, 0},
        { 0, 10, 0, 0, 3, 0, 10, 0, 0, 0},
        { 0, 0, 7, 0, 0, 10, 0, 19, 0, 9},
        { 0, 0, 0, 25, 0, 0, 19, 0, 0, 5},
        { 0, 0, 0, 0, 13, 0, 0, 0, 0, 15},
        { 0, 0, 0, 0, 0, 0, 9, 5, 15, 0}
      };

      ShortestPath(graph, 0);
    }

    // src는 출발점
    private static void ShortestPath(int[,] graph, int src)
    {
      // 초기화: 1번 라인
      for(int i=0; i<V; i++)
      {
        D[i] = int.MaxValue;
        spt[i] = false;
      }

      D[src] = 0;

      for(int i=0; i<V-1; i++)
      {
        int min = MinDistance();  // 최단경로가 계산된 도시의 인덱스
        spt[min] = true;
      }
    }

    private static int MinDistance()
    {
      
    }
  }
}
