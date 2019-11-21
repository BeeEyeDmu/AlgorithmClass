using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace HuffmanCoding
{
  internal class HuffmanTree
  {
    private List<Node> nodes = new List<Node>();
    public Node Root { get; set; }
    public Dictionary<char, int> Frequencies = new Dictionary<char, int>();

    // 입력으로 부터 허프만 트리를 만든다
    public void Build(string source)
    {
      // 빈도수 계산하여 Frequencies에 저장
      for (int i = 0; i < source.Length; i++)
      {
        if (!Frequencies.ContainsKey(source[i]))
          Frequencies.Add(source[i], 0);
        Frequencies[source[i]]++;
      }

      // Test Dictionary<char, int> Frequencies
      foreach(var v in Frequencies)
      {
        System.Console.WriteLine(v.Key + "\t" + v.Value);
      }

      // List<Node> nodes를 만든다
      foreach (KeyValuePair<char, int> s in Frequencies)
        nodes.Add(new Node()
        {
          Symbol = s.Key,
          Frequency = s.Value
        });

      while(nodes.Count > 1)
      {
        List<Node> orderedNodes
          = nodes.OrderBy(Node => Node.Frequency).ToList<Node>();

        if(orderedNodes.Count >= 2)
        {
          List<Node> taken = orderedNodes.Take(2).ToList<Node>();

          Node parent = new Node()
          {
            Symbol = '*',
            Frequency = taken[0].Frequency + taken[1].Frequency,
            Left = taken[0],
            Right = taken[1]
          };

          nodes.Remove(taken[0]);
          nodes.Remove(taken[1]);
          nodes.Add(parent);

          this.Root = nodes.FirstOrDefault();
        }
      }
    }

    // 주어진 입력을 코드화하여 비트배열로 리턴한다
    public BitArray Encode(string source)
    {
      List<bool> encodedSource = new List<bool>();

<<<<<<< HEAD
      for(int i=0; i<source.Length; i++)
      {     
=======
      for (int i = 0; i < source.Length; i++)
      {
>>>>>>> d25d2fce30e12885195482ec84338c84bc793f46
        encodedSource.AddRange(symbolCode[source[i]]);
      }
      BitArray bits = new BitArray(encodedSource.ToArray());
      return bits;   
    }

    // 암호로부터 해석된 문자열을 리턴한다
    public string Decode(BitArray bits)
    {
      Node current = this.Root;
      string decoded = "";

      foreach (bool bit in bits)
      {
        if (bit == true)
        {
          if (current.Right != null)
            current = current.Right;
        }
        else
        {
          if (current.Left != null)
            current = current.Left;
        }
        if (IsLeaf(current))
        {
          decoded += current.Symbol;
          current = this.Root;
        }
      }
      return decoded;
    }

    // 단말노드인지 체크
    public bool IsLeaf(Node node)
    {
      //if (node.Left == null && node.Right == null)
      //  return true;
      //else
      //  return false;
      return node.Left == null && node.Right == null;
    }

<<<<<<< HEAD
    Dictionary<char, List<bool>> symbolCode 
      = new Dictionary<char, List<bool>>();
    
    // 허프만 트리의 순회
    // 순회하면서 Dictionary symbolCode를 만든다
    public void InOrder(Node node, List<bool> value)
    {
      if(node != null)
      {
        if (IsLeaf(node)) // 단말
          symbolCode.Add(node.Symbol, value);

        // 왼쪽 자식
=======
    Dictionary<char, List<bool>> symbolCode = new Dictionary<char, List<bool>>();

    // InOrder Traversal을 사용하여 각 단말노드의 코드를 BitArray로 만들어 
    // Dictinary<Symbol, Code>로 저장한다
    public void InOrder(Node node, List<bool> value)
    {
      if (node != null)
      {
        if (IsLeaf(node))
        {
          symbolCode.Add(node.Symbol, value); //new BitArray(value.ToArray()));
        }

>>>>>>> d25d2fce30e12885195482ec84338c84bc793f46
        List<bool> leftPath = new List<bool>();
        leftPath.AddRange(value);
        leftPath.Add(false);
        InOrder(node.Left, leftPath);

<<<<<<< HEAD
        // 오른쪽 자식
        List<bool> rigthPath = new List<bool>();
        rigthPath.AddRange(value);
        rigthPath.Add(true);
        InOrder(node.Right, rigthPath);
      }
    }

    // Print Dictionary symbolCode
    public void PrintSymbolCode()
    {
      System.Console.WriteLine("symbolCode");
      foreach(var v in symbolCode)
      {
        System.Console.Write(v.Key + "\t");
        foreach(bool bit in v.Value)
          System.Console.Write(bit?1:0);
        System.Console.WriteLine();
=======
        List<bool> rightPath = new List<bool>();
        rightPath.AddRange(value);
        rightPath.Add(true);
        InOrder(node.Right, rightPath);
      }
    }

    // Print Dictionary symbolCode<char, BitArray>
    public void PrintSymbolCode()
    {
      Console.WriteLine("Symbol Code");
      foreach(var v in symbolCode)
      {
        Console.Write(v.Key + "\t");
        foreach (bool bit in v.Value)
          Console.Write(bit ? 1 : 0);
        Console.WriteLine();
>>>>>>> d25d2fce30e12885195482ec84338c84bc793f46
      }
    }
  }
}