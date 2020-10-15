using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTests
{

    class Program
    {

        static void Main()
        {
            //     new Task(
            //() =>
            //{
            //    while (true)
            //    {
            //        Console.Title = DateTime.Now.ToString();
            //        Thread.Sleep(100);
            //    }
            //}).Start();

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        private static void EvalFact(object obj)
        {
            Factorial f = obj as Factorial;
            double res = 1;
            while (f.StartValue <= f.EndValue)
            {
                res *= f.StartValue;
                f.StartValue++;
            }
            f.Result = res;
        }

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

    class MathTask
    {

        private readonly Thread _CalcTread;
        private double _Result;
        private bool _IsCompleted;

        public MathTask(Func<int, double> Calculation, int FinalValue)
        {
            _CalcTread = new Thread(()
                =>
            {
                _Result = Calculation(FinalValue);
                _IsCompleted = true;
            }
            )
            { IsBackground = true };
        }

        public void Start() => _CalcTread.Start();

        public bool IsCompleted => _IsCompleted;

        public double Result
        {
            get
            {
                if (!_IsCompleted)
                    _CalcTread.Join();
                return _Result;
            }
        }
    }
}
