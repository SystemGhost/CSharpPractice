using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Для заданной матрицы размером 8 на 8 найти такие k, что k-я строка матрицы совпадает с k-м столбцом.
// Найти сумму элементов в тех строках, которые содержат хотя бы один отрицательный элемент.
namespace Task2
{

    class task
    {

        static void Main()
        {
            int size = 6;
            matrix matr = new matrix(size);
            int[] summ = new int[size];

            matr.fillingRandom();
            matr.show();

            //Console.WriteLine("похожие строка и столбец: {0}", matr.FindCollumnAndLine());
            Console.ReadKey(true);
        }

        #region matrix
        public class matrix
        {
            private int size;
            private int[,] matr;

            public matrix()
            {
               size = 1;
               matr = new int[size, size];
               // matr[,] = {{1,2,3,4},{2,3,4,5},{1,2,3,4},{1,2,3,4}};
            }

            public matrix(int size_one)
            {
                size = size_one < 0 ? size = 0 : size = size_one;
                matr = new int[size, size];
            }

            public void show()
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        Console.Write(matr[i, j] + "\t");

                    Console.WriteLine();
                }
            }

            public void fillingRandom()
            {
                Random rand = new Random();

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                        matr[i, j] = rand.Next(-2, 30);
                }
            }

            public int FindCollumnAndLine()
            {
                bool flag = false;

                for (int i = 0; i < size ; i++)
                {
                    flag = true;
                    for (int j1 = 0; j1 < size ; j1++ )
                    {
                        if (matr[j1, i] != matr[i, j1])
                            break;
                        else if (flag == true && j1 == (size - 1))
                        {
                            return i + 1;
                        }
                          
                    }

                    if(flag == false)
                        return 0;
                }

                return size;
            }

            public void FindSummOfNegativeElem(ref int[] summ)
            {
                int index = 0;
                bool flag = false;

                for (int i = 0; i < size; i++)
                {
                    flag = false;

                    for (int j = 0; j < size; j++)
                    {
                        if (matr[i, j] < 0)
                        {
                            for (int indexForSum = 0; indexForSum < size; indexForSum++)
                            {
                                if (matr[i, indexForSum] > 0)
                                {
                                    summ[index] += matr[i, indexForSum];
                                    index++;
                                }
                            }
                            flag = true;
                        }
                        if (flag == true)
                            break;
                    }
                }
            }
        }
        #endregion matrix
    }
}
