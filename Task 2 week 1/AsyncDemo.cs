using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static string ProcessDataSynchronous(string dataName)
    {
        Thread.Sleep(3000);
        string result = $"Обработка '{dataName}' завершена за 3 секунды";
        return result;
    }
    static async Task<string> ProcessDataAsync(string dataName)
    {
        await Task.Delay(3000).ConfigureAwait(false);
        string result = $"Обработка '{dataName}' завершена за 3 секунды (async)";
        return result ;
    }
    
    static async Task Main(string[] args)
    {
        Console.WriteLine("Cихронная обработка");
        var stopWatch = Stopwatch.StartNew();

        string resultTaskSynchronous1 = ProcessDataSynchronous("data1");
        Console.WriteLine(resultTaskSynchronous1);

        string resultTaskSynchronous2 = ProcessDataSynchronous("data2");
        Console.WriteLine(resultTaskSynchronous2);

        string resultTaskSynchronous3 = ProcessDataSynchronous("data3");
        Console.WriteLine(resultTaskSynchronous3);

        stopWatch.Stop();
        Console.WriteLine($"Общее время: {stopWatch.Elapsed.TotalSeconds} сек");

        Console.WriteLine("Асихронная обработка");
        stopWatch.Restart();

        Task<string> resultTaskAsync1 = ProcessDataAsync("data1");

        Task<string> resultTaskAsync2 = ProcessDataAsync("data2");

        Task<string> resultTaskAsync3 = ProcessDataAsync("data3");

        var tasks = new List<Task<string>> { resultTaskAsync1, resultTaskAsync2, resultTaskAsync3 };

        while (tasks.Count > 0)
        {
            Task<string> completedTask = await Task.WhenAny(tasks);
            tasks.Remove(completedTask);
            Console.WriteLine(completedTask.Result);
        }

        stopWatch.Stop();

        Console.WriteLine($"Общее время: {stopWatch.Elapsed.TotalSeconds} сек");


    }


}