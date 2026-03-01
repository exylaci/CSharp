using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeresoAlgoritmusok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int current = random.Next(0, 7);
            int[] data = Enumerable
                            .Range(0, int.MaxValue / 10)
                            .Select(_ =>
                            {
                                current += random.Next(1, 10);
                                return current;
                            })
                            .ToArray();
            Console.WriteLine($"A generált tömb elemeinek száma:                  {data.Length}");

            int findThis = data[0] - 1;
            Console.WriteLine($"\nKeresem a 1. elemet.                 {findThis}   0");
            LinearisKereses(findThis, data);
            BinarisKereses(findThis, data);

            findThis = data[1] + 1;
            Console.WriteLine($"\nKeresem a 2. elemet.                 {findThis}   1");
            LinearisKereses(findThis, data);
            BinarisKereses(findThis, data);

            findThis = data[data.Length / 2] + 1;
            Console.WriteLine($"\nKeresem az középsőt.                 {findThis}   {data.Length / 2}");
            LinearisKereses(findThis, data);
            BinarisKereses(findThis, data);

            findThis = data[data.Length - 2] - 1;
            Console.WriteLine($"\nKeresem az utolsó előttit.           {findThis}   {data.Length - 2}");
            LinearisKereses(findThis, data);
            BinarisKereses(findThis, data);

            findThis = data[data.Length - 1] + 1;
            Console.WriteLine($"\nKeresem az utolsó.                   {findThis}   {data.Length - 1}");
            LinearisKereses(findThis, data);
            BinarisKereses(findThis, data);
        }

        private static void LinearisKereses(int findThis, int[] data)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            int steps = 0;
            int position = 0;

            while (position < data.Length && data[position] < findThis)
            {
                ++position;
                ++steps;
            }

            clock.Stop();
            Console.WriteLine($"Lineárisan keresve, a megtalált elem {(position >= data.Length ? -1 : data[position])} a {position}. helyen van. {clock.Elapsed} alatt lett meg, {steps} lépésből.");
        }

        private static void BinarisKereses(int findThis, int[] data)
        {
            Stopwatch clock = new Stopwatch();
            clock.Start();
            int steps = 0;

            int first = 0;
            int last = data.Length - 1;
            int current = 0;

            do
            {
                current = (first + last) / 2;
                if (data[current] < findThis)
                {
                    first = current + 1;
                }
                else
                {
                    last = current - 1;
                }
                ++steps;
            } while (first < last && data[current] != findThis);

            clock.Stop();
            Console.WriteLine($"Binárisan  keresve, a megtalált elem {data[current]} a {current}. helyen van. {clock.Elapsed} alatt lett meg, {steps} lépésből.");
        }
    }
}
