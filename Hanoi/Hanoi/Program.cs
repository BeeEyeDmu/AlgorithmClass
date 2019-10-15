using System;

namespace Hanoi
{
    class Program
    {
        static void Main(string[] args)
        {
            Hanoi(4, 'A', 'C', 'B'); // A에서 B를 이용해 C로 이동

        }

        private static void Hanoi(int n, char from, char to, char by)
        {
            if (n == 1)
                Console.WriteLine("Move : {0} -> {1}", from, to);
            else
            {
                Hanoi(n - 1, from, by, to);
                Console.WriteLine("Move : {0} -> {1}", from, to);
                Hanoi(n - 1, by, to, from);
            }
        }
    }
}
