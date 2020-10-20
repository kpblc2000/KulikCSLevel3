using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTestsCore
{
    public static class AsyncAwaitTest
    {
        //public static async void StartAsync()
        //{
        //    await;
        //}

        public static async Task StartAsync()
        {
            Console.WriteLine("Start is sync!");
            var resTask = GetStringResReallyAsync();
            var res = await resTask.ConfigureAwait(false);
            Console.WriteLine($"res = {res}");
        }

        private static void PrintThreadInfo(string Message = "")
        {
            Thread curThr = Thread.CurrentThread;
            Console.WriteLine("ThreadId={0} TaskId={1} {2}", curThr.ManagedThreadId, Task.CurrentId, Message);

        }

        //private static async Task<string> GetStringResAsync()
        //{
        //    PrintThreadInfo("Pseudo async");
        //    return DateTime.Now.ToString();
        //}

        private static Task<string> GetStringResReallyAsync()
        {
            PrintThreadInfo("Start async");
            return Task.Run(
                () =>
                {
                    PrintThreadInfo("Inside task");
                    return DateTime.Now.ToString();
                });
        }

        public static async Task ProcessDataTestAsync()
        {
            Console.WriteLine("Prepare");
            IEnumerable<string> messages = Enumerable.Range(1, 500).Select(i => $"Mess{i}");

            var tasks = messages.Select(msg => Task.Run(() => LowSpeedPrinter(msg)));
            var running_tasks = tasks.ToArray();
            await Task.WhenAll(running_tasks);

            Console.WriteLine("All done");
        }

        private static void LowSpeedPrinter(string msg)
        {
            Console.WriteLine("Id={1}: Message \"{0}\" started", msg, Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(100);
            Console.WriteLine("Id={1}: Message \"{0}\" finalized", msg, Thread.CurrentThread.ManagedThreadId);
        }
    }
}
