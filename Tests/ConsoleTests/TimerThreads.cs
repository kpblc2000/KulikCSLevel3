using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTests
{
    class TimerThreads
    {
        public static void TimerThread()
        {
            Thread thMain = Thread.CurrentThread;

            int mainId = thMain.ManagedThreadId;

            thMain.Name = "Main";

            Thread threadTimer = new Thread(UpdateTimer);
            threadTimer.IsBackground = true;
            threadTimer.Name = "\tTime thread";
            threadTimer.Start();

            for (int i = 0; i < 1000; i++)
            {
                // Console.WriteLine($"Main thread {i}");
                Thread.Sleep(10);
            }

        }

        private static void UpdateTimer()
        {
            Program.PrintThreadInfo();
            while (true)
            {
                Console.Title = DateTime.Now.ToString("HH:mm:ss.ff");
                Thread.Sleep(100);
            }
        }
    }
}
