using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Task_2_week_1;

class Program
{
    static async Task Main(string[] args)
    {
        var processor = new DataProcessor();
        Console.WriteLine("Cихронная обработка");
        var stopWatch = Stopwatch.StartNew();

        processor.RunSynchronousOperations();

        stopWatch.Stop();
        Console.WriteLine($"Общее время: {stopWatch.Elapsed.TotalSeconds} сек");

        Console.WriteLine("Асихронная обработка");
        stopWatch.Restart();

         await processor.RunAsyncOperations();

        stopWatch.Stop();

        Console.WriteLine($"Общее время: {stopWatch.Elapsed.TotalSeconds} сек");


    }


}