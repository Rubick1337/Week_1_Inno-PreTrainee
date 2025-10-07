using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_week_1
{
    public class DataProcessor
    {
        public string ProcessDataSynchronous(string dataName)
        {
            Thread.Sleep(3000);
            return $"Обработка '{dataName}' завершена за 3 секунды";
        }
        public async Task<string> ProcessDataAsync(string dataName)
        {
            await Task.Delay(3000).ConfigureAwait(false);
            return $"Обработка '{dataName}' завершена за 3 секунды (async)";
        }
        public void RunSynchronousOperations()
        {
            string result1 = ProcessDataSynchronous("data1");
            Console.WriteLine(result1);

            string result2 = ProcessDataSynchronous("data2");
            Console.WriteLine(result2);

            string result3 = ProcessDataSynchronous("data3");
            Console.WriteLine(result3);
        }
        public async Task RunAsyncOperations()
        {
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
        }
    }
}
