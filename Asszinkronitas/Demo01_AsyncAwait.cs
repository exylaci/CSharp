using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Asszinkronitas
{
    public static class Demo01_AsyncAwait
    {
        public static async Task RunAsync()
        {
            Console.WriteLine("Demo 1 - Konkurencia (nem feltétlenül párhuzamos): _AsyncAwait started.");

            Stopwatch stopwatch = Stopwatch.StartNew();                      // Start measuring time

            Task t1 = SimulateLongRunningOperationAsync("A", 1000);          // Start the asynchronous operation without awaiting
            Task t2 = SimulateLongRunningOperationAsync("B", 2000);          // Start the asynchronous operation without awaiting
            Task t3 = SimulateLongRunningOperationAsync("C", 800);           // Start the asynchronous operation without awaiting

            await Task.WhenAll(t1, t2, t3);                                  // Call the asynchronous methods

            Console.WriteLine($"Result: All operations completed.");
            stopwatch.Stop();
            Console.WriteLine($"Elapsed Time: {stopwatch.ElapsedMilliseconds} ms");
            Console.WriteLine("Demo01_AsyncAwait completed.");
        }
        private static async Task SimulateLongRunningOperationAsync(string name, int delayMS)
        {
            Console.WriteLine($"Starting operation:  {name} Thread ID: {Environment.CurrentManagedThreadId}");
            await Task.Delay(delayMS);                                      // Simulate a long-running operation with x seconds delay
            Console.WriteLine($"Completed operation: {name} Thread ID: {Environment.CurrentManagedThreadId}");

            return;
        }
    }
}
