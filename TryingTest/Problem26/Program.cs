using System;
using System.Numerics;

namespace Problem26
{
    class Program
    {
        static void Main(string[] args)
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int[] points = new int[10];
            for (int i = first; i <= second; i++)
            {
                int x = i;
                while (x != 0)
                {
                    int c = x % 10;
                    points[c]++;
                    x = x / 10;
                }
            }
            int biggest = 0;

            foreach (int place in points)
            {
                if (place > biggest)
                {
                    biggest = place;
                }
            }
            int placer = 0;

            for (int i = 0; i < points.Length - 1; i++)
            {
                if (points[i] == biggest)
                {
                    placer = i;
                    break;
                }
            }

            Console.WriteLine($"digit {placer} used {biggest} times");
        }
    }
}