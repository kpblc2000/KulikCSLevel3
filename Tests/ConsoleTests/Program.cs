using System;
using System.Diagnostics;
using System.Threading;

// using System.Net.Http;

namespace ConsoleTests
{

    class Program
    {

        static void Main()
        {

            //Console.Write("Введите число для вычисления факториала : ");
            //int val = int.Parse(Console.ReadLine());

            Thread _mainThread = Thread.CurrentThread;
            int mainThrId = _mainThread.ManagedThreadId;

            Factorial f1 = new Factorial() { StartValue = 1, EndValue = 10 };
            Factorial f2 = new Factorial() { StartValue = 11, EndValue = 20 };
            Factorial f3 = new Factorial() { StartValue = 21, EndValue = 30 };

            Thread _t1 = new Thread(new ParameterizedThreadStart(EvalFact));
            _t1.Start(f1);
            Thread _t2 = new Thread(new ParameterizedThreadStart(EvalFact));
            _t2.Start(f2);
            Thread _t3 = new Thread(new ParameterizedThreadStart(EvalFact));
            _t3.Start(f3);

            _t1.Join();
            _t2.Join();
            _t3.Join();

            double res = f1.Result * f2.Result * f3.Result ;

            Console.WriteLine($"30! = {res}");

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        private static void EvalFact(object obj)
        {
            Factorial f = obj as Factorial;
            double res = 1;
            while(f.StartValue <= f.EndValue)
                {
                res *= f.StartValue;
                f.StartValue++;
            }
            f.Result = res;
        }


    //    private static long EvalFact(long StartValue, long EndValue)
    //    {
    //        long res = 1;
    //        while (StartValue <= EndValue)
    //        {
    //            res *= StartValue;
    //            StartValue++;
    //        }
    //        return res;
    //    }

    //private static long EvalFact(object obj)
    //{
    //    return EvalFact(obj.x)
    //}

        public static void PrintThreadInfo()
        {
            Thread curThread = Thread.CurrentThread;
            Console.WriteLine($"id={curThread.ManagedThreadId}; name={curThread.Name}; prior={curThread.Priority}");
        }
    }

    public class Factorial
    {
        public long StartValue;
        public long EndValue;
        public double Result;
    }
}
