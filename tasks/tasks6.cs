using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Найти сумму положительных и отрицательных элементов матрицы
namespace Task2
{

    class task
    {

        static void Main()
        {
            int[] sumPositiveAndNegative = new int[2];
            matrix matr = new matrix(6);
            matr.randomArray();
            matr.showMatrix();
            matr.sumPositiveAndNegative(ref sumPositiveAndNegative);

            Console.WriteLine("Сумма положительных: {0}", sumPositiveAndNegative[0]);
            Console.WriteLine("Сумма отрицательных: {0}", sumPositiveAndNegative[1]);
            Console.ReadKey(true);
        }

        #region matrix
        public class matrix
        {
            private int size;
            private int[,] matr;

            public matrix()
            {
                size = 0;
                matr = new int[size,size];
            }
            public matrix(int size_one)
            {
                if (size_one < 0)
                    size = 0;
                size = size_one;

                matr = new int[size, size];

            }

            public void showMatrix()
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(matr[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
            public void randomArray()
            {
                Random rand = new Random();

                for(int i=0; i< size; i++)
                    for (int j = 0; j < size; j++)
                    {
                        matr[i, j] = rand.Next(-2,4);
                    }
            }
            public void sumPositiveAndNegative(ref int[] sum)
            {
                sum[0] = 0;
                sum[0] = 0;
                for (int i = 0; i < size; i++)
                    for (int j = 0; j < size; j++ )
                    {
                        if (matr[i, j] > 0)
                            sum[0] += matr[i, j];
                        if (matr[i, j] < 0)
                            sum[1] += matr[i, j];
                    }
            }
        #endregion matrix

        }
    }
}
