using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
   Дана действительная квадратная матрица порядка N.
   Рассмотрим те элементы, которые расположены в строках, начинающихся с отрицательного элемента.
   Найти сумму тех из них, которые расположены соответственно ниже, выше и на главной диагонали матрицы.
*/
namespace Task2
{

    class task
    {

        static void Main()
        {
            matrix Matrix = new matrix(4);
            int[] sum = new int[3];

            Matrix.randomMartrix();
            Matrix.showMatrix();
            Matrix.Sum(ref sum);

            Console.WriteLine("Сумма ниже диогонали: {0}", sum[0]);
            Console.WriteLine("Сумма главной диогонали: {0}", sum[1]);
            Console.WriteLine("Сумма выше диогонали: {0}", sum[2]);
            Matrix.showNegtiveValueString();
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
                matr = new int[size, size];
            }

            public matrix(int size_new)
            {
                if (size_new > 0)
                    size = size_new;
                else size = 0;

                matr = new int[size, size];
            }

            public void showMatrix()
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(matr[i, j] + "  ");
                    }
                    Console.WriteLine();
                }
            }

            public void randomMartrix()
            {
                Random random = new Random();

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        matr[i, j] = random.Next(-2, 10);
                    }
                }
            }

            public void Sum(ref int[] sum)
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (j < i)
                        {
                            sum[0] += matr[i, j];
                        }
                        else if (j == i)
                        {
                            sum[1] += matr[i, j];
                        }
                        else if (j > i)
                        {
                            sum[2] += matr[i, j];
                        }
                    }
                }
            }

            public void showNegtiveValueString()
            {
                for (int i = 0; i < size; i++)
                {
                    if (matr[i, 0] < 0)
                    {
                        for (int j = 0; j < size; j++)
                        {
                            Console.Write(matr[i,j] + " ");
                        }
                        Console.WriteLine();
                    }
                }
            }

        }
#endregion matrix
    }
}
