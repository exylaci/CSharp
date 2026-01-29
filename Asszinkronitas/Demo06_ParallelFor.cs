using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asszinkronitas
{
    public static class Demo06_ParallelFor
    {
        public static Task RunAsync()
        {
            Console.WriteLine("Demo 6 - CPU bound-os feladat a parallel és a sima for méréséhez" + Environment.NewLine);
            int iterations = 60000000;
            long seq = MeasureSequential(iterations);
            long par = MeasureParalell(iterations);
            Console.WriteLine("sequentional ms: " + seq);
            Console.WriteLine("parallel     ms: " + par);
            return Task.CompletedTask;
        }

        private static long MeasureParalell(int iterations)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long sum = 0;

            for (int i = 0; i < iterations; i++)
            {
                sum = sum + (i % 7);
            }
            sw.Stop();
            Console.WriteLine("Szekvenciális sum: " + sum);
            return sw.ElapsedMilliseconds;
        }

        private static long MeasureSequential(int iterations)
        {
            Stopwatch sw = Stopwatch.StartNew();
            long sum = 0;
            object sumLock = new object();

            Parallel.For(0, iterations, i =>
            {
                long local = (long)(i % 7);
                lock (sumLock)
                {
                    sum = sum + local;
                }
            });
            sw.Stop();
            Console.WriteLine("Párhuzamos sum: " + sum);
            return sw.ElapsedMilliseconds;
        }
    }
}
