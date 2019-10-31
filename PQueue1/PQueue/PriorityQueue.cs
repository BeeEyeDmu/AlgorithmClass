using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PQueue
{
  class PriorityQueue
  {
    public List<int> list;
    public int Count { get { return list.Count; } }

    public PriorityQueue()
    {
      list = new List<int>();
    }

    // 리스트의 맨 뒤에 새로 추가하고
    // upheap 동작을 수행한다
    public void Insert(int x)
    {
      list.Add(x);

      int i = Count - 1;

      // UpHeap
      while(i > 0)
      {
        int p = (i - 1) / 2;  // 부모 인덱스
        if (list[p] <= x)
          break;
        list[i] = list[p];
        i = p;
      }

      //if (Count > 0) // 없어도 될 듯
        list[i] = x;
    }

    // root 값을 리턴하고
    // 맨 뒤의 값을 루트로 가져와서
    // DownHeap
    public int Remove()
    {
      int min = list[0];
      int root = list[Count - 1]; // 맨 뒤의 값 복사
      list.RemoveAt(Count - 1); // 맨 뒤의 값 삭제

      // DownHeap
      int i = 0;
      while(i*2+1 < Count) // 자식이 없을 때까지
      {
        int left = i * 2 + 1;
        int right = i * 2 + 2;
        int c;
        if( list[left] < list[right]) // 왼쪽으로 진행
          c = left;
        else
          c = right;

        if (list[c] < root)
        {
          list[c] = list[i];
          i = c;
        }
      }
      list[i] = root;
      return min;
    }

    public int Find()
    {
      return list[0];
    }
  }
}
