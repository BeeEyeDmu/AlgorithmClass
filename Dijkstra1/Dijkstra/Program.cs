using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dijkstra
{
    class Program
    {
        static string[] city =
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
            
            //ShortestPath(graph, 0); // 서울출발
            ShortestPath(graph, 5); // 대전출발
        }

        // src는 출발점
        private static void ShortestPath(int[,] graph, int src)
        {
            // 초기화: 1번 라인
            for (int i = 0; i < V; i++)
            {
                D[i] = int.MaxValue;
                spt[i] = false;
            }

            D[src] = 0;

            for (int i = 0; i < V; i++) // 도시수 만큼 반복
            {
                int minIndex = MinDistance();  // 최단경로가 계산된 도시의 인덱스
                spt[minIndex] = true;
                Console.WriteLine("minDistance : {0}", city[minIndex]);

                // update D[] of 인접 버텍스
                // 4번 라인
                // 모든 버텍스 v에 대해서
                for (int v = 0; v < V; v++)
                    if (!spt[v]             // 아직 최단경로가 결정되지 않았고
                     && graph[minIndex, v] != 0    // minIndex와 연결된 버텍스
                     && D[minIndex] + graph[minIndex, v] < D[v])  // 
                    {
                        D[v] = D[minIndex] + graph[minIndex, v];
                    }

                Console.WriteLine("iteration: {0}", i);
                PrintD(src);
            }
        }

        private static void PrintD(int src)
        {
            Console.WriteLine("도시\tDistance from {0}", city[src]);
            for (int i = 0; i < V; i++)
                Console.WriteLine("{0}\t{1}", city[i], D[i]);
        }

        // spt에 속하지 않는 버텍스 중에서 최단거리를 갖는 버텍스를 찾는다.
        // 3번 라인
        private static int MinDistance()
        {
            int min = int.MaxValue;
            int minIndex = -1;

            for (int i = 0; i < V; i++)
            {
                if (spt[i] == false && D[i] <= min)
                {
                    min = D[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
    }
}