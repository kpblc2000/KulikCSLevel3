using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTestsCore
{
    static class TPLOverview
    {
        public static void Start()
        {
            Action<string> printer = str =>
            {
                Console.WriteLine($"ThrId={Thread.CurrentThread.ManagedThreadId} msg={str}");
                Thread.Sleep(50);
            };

            //Parallel.Invoke( //new ParallelOptions { MaxDegreeOfParallelism = 4 },
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    ParallelInvokeMethod,
            //    ()=>Console.WriteLine("Plus")
            //    );

            Parallel.Invoke(new ParallelOptions { MaxDegreeOfParallelism = 2 },
                ParallelInvokeMethod,
                ParallelInvokeMethod,
                ParallelInvokeMethod,
                ParallelInvokeMethod,
                ParallelInvokeMethod,
                ParallelInvokeMethod,
                ParallelInvokeMethod,
                ParallelInvokeMethod,
                ParallelInvokeMethod,
                ParallelInvokeMethod,
                ParallelInvokeMethod,
                () => Console.WriteLine("Plus")
                );

            Parallel.For(0, 100, new ParallelOptions { MaxDegreeOfParallelism = 3 }, i => printer(i.ToString()));


        }

        private static void ParallelInvokeMethod()
        {
            Console.WriteLine($"ThrId:{Thread.CurrentThread.ManagedThreadId} start");
            Thread.Sleep(250);
            Console.WriteLine($"ThrId:{Thread.CurrentThread.ManagedThreadId} end");
        }

        private static void ParallelInvokeMethod(string msg)
        {
            Console.WriteLine($"ThrId:{Thread.CurrentThread.ManagedThreadId} start: {msg}");
            Thread.Sleep(250);
            Console.WriteLine($"ThrId:{Thread.CurrentThread.ManagedThreadId} end: {msg}");
        }
    }
}
