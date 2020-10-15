using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTestsCore
{
    class Program
    {
        static void Main()
        {
            // TPLOverview.Start();
            //var task = AsyncAwaitTest.StartAsync();
            //var proc = AsyncAwaitTest.ProcessDataTestAsync();
            ////task.Wait();
            // Task.WaitAll(task, proc);

            int size = 12;

            int[,] a = new int[size, size];
            int[,] b = new int[size, size];
            Random rnd = new Random();

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    a[i, j] = rnd.Next(10);
                }
            }

            for (int i = 0; i < b.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    b[i, j] = rnd.Next(10);
                }
            }

            Console.WriteLine("Первая матрица:");
            MultipleMatrixes.PrintMatrix(a);
            Console.WriteLine("Вторая матрица");
            MultipleMatrixes.PrintMatrix(b);
            long[,] res = MultipleMatrixes.MatrixMultiplier(a, b);
            Console.WriteLine("Результат умножения : ");
            MultipleMatrixes.PrintMatrix(res);

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

    }
}
