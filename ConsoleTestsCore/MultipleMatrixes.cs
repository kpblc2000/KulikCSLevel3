using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleTestsCore
{
    class MultipleMatrixes
    {
        /// <summary>
        /// Перемножение матриц
        /// </summary>
        /// <param name="MatrixA">Первая матрица</param>
        /// <param name="MatrixB">Вторая матрица</param>
        /// <returns></returns>
        public static long[,] MatrixMultiplier(int[,]MatrixA, int[,]MatrixB)
        {
            if (MatrixA.GetLength(1)!=MatrixB.GetLength(0))
            {
                throw new Exception($"Невозможно перемножить матрицы {MatrixA.GetLength(0)}x{MatrixA.GetLength(1)} и {MatrixB.GetLength(0)}x{MatrixB.GetLength(1)}");
            }
            long[,] res = new long[MatrixA.GetLength(0), MatrixB.GetLength(1)];
            Parallel.For(0, MatrixA.GetLength(0), (x) =>
            {
                for (int i = 0; i < MatrixB.GetLength(1); i++)
                {
                    for (int k = 0; k < MatrixB.GetLength(0); k++)
                    {
                        // Console.WriteLine($"ThrId : {Thread.CurrentThread.ManagedThreadId} : res[{i},{k}]={res[i, k]}");
                        res[i, k] += MatrixA[x, k] * MatrixB[k, i];
                    }
                }
            });
            return res;
        }

        /// <summary>
        /// Вывод матрицы в консоль
        /// </summary>
        /// <param name="MatrixToPrint">Матрица для вывода</param>
        public static void PrintMatrix(int[,] MatrixToPrint)
        {
            for (int i = 0; i < MatrixToPrint.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixToPrint.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0,3}", MatrixToPrint[i, j]));
                }
                Console.WriteLine("\n--------------------------------------");
            }
        }

        /// <summary>
        /// Вывод матрицы в консоль
        /// </summary>
        /// <param name="MatrixToPrint">Матрица для вывода</param>
        public static void PrintMatrix(long[,] MatrixToPrint)
        {
            for (int i = 0; i < MatrixToPrint.GetLength(0); i++)
            {
                for (int j = 0; j < MatrixToPrint.GetLength(1); j++)
                {
                    Console.Write(String.Format("{0,10}", MatrixToPrint[i, j]));
                }
                Console.WriteLine("\n--------------------------------------");
            }
        }
    }
}
