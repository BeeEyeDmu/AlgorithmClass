using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCoding
{
  class Program
  {
    static void Main(string[] args)
    {
      string input = "Yesterday, all my troubles seemed so far away " +
                "Now it looks as though they're here to stay " +
                "Oh, I believe in yesterday " +
                "Suddenly, I'm not half the man I used to be " +
                "There's a shadow hanging over me " +
                "Oh, yesterday came suddenly " +
                "Why she had to go I don't know she wouldn't say " +
                "I said something wrong, now I long for yesterday " +
                "Yesterday, love was such an easy game to play " +
                "Now I need a place to hide away " +
                "Oh, I believe in yesterday " +
                "Why she had to go I don't know she wouldn't say " +
                "I said something wrong, now I long for yesterday " +
                "Yesterday, love was such an easy game to play " +
                "Now I need a place to hide away " +
                "Oh, I believe in yesterday " +
                "Mm mm mm mm mm mm mm";

      HuffmanTree hTree = new HuffmanTree();
      hTree.Build(input);

      // hTree traveral to make Dictionary symbolCode<char, BitArray>
      hTree.InOrder(hTree.Root, new List<bool>());
      hTree.PrintSymbolCode();


      // Encode
      BitArray encoded = hTree.Encode(input);
      PrintCode(encoded);
      Console.WriteLine("Size of encoded = "+encoded.Length + " bits, " + (encoded.Count/8) +" bytes");


      string decoded = hTree.Decode(encoded);
      Console.WriteLine(decoded);
      Console.WriteLine("Size of decoded = " + decoded.Length + " bytes");

    }

    private static void PrintCode(BitArray encoded)
    {
      Console.WriteLine("Encoded : ");
      foreach (bool bit in encoded)
        Console.Write(bit?1:0);
      Console.WriteLine();
    }
  }
}
