using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Найти в двумерном массиве сумму элементов в тех столбцах, в которых есть хотя бы 1 отрицательный элемент
namespace Task2
{

    class task
    {

        static void Main()
        {
            int column = 3, str = 5;
            int[] sumNegativeValue;

            matrix Matrix = new matrix(column, str);
            Matrix.randomValueMatrix();
            Matrix.showMatrix();
            sumNegativeValue = Matrix.searchNegativeValue();
            showArraySumNegativeValue(sumNegativeValue);
            Console.ReadKey(true);
        }

        static public void showArraySumNegativeValue(int[] sumArray)
        {
            Console.WriteLine("Сумма элементов в тех столбцах, в которых есть хотя бы 1 отрицательный элемент:");
            foreach (int x in sumArray)
            {
                Console.Write(x + "\t");
            }
            Console.WriteLine();
        }
       #region matrix
        public class matrix
        {
            private int column; 
            private int str;

            private int[,] Matrix;

            public matrix()
            {
                column = 0;
                str = 0;
                Matrix = new int[str, column];
            }

            public matrix(int str_new, int column_new)
            {
                
                if (str_new < 0 || column_new < 0)
                    column = str = 0;

                str = str_new;
                column = column_new;
                Matrix = new int[str, column];
            }
            public void showMatrix()
            {
                

                for (int i = 0; i < str; i++)
                {
                    for (int j = 0; j < column; j++)
                        Console.Write(Matrix[i, j] + "\t");
                    Console.WriteLine();
                }

            }

            public void randomValueMatrix()
            {
                Random random = new Random();
                for (int i = 0; i < str; i++)
                {
                    for (int j = 0; j < column; j++)
                        Matrix[i, j] = random.Next(-2, 18);
                }
            }

            public int[] searchNegativeValue()
            {
                int[] sumNegativrValue = new int[column];
                int indexSum = 0;
                bool flag = false;

                for (int j = 0; j < column; j++)
                {
                    for (int i = 0; i < str; i++)
                    {
                        if (Matrix[i, j] < 0)
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag == true)
                    {
                        for (int x = 0; x < str; x++)
                        {
                            sumNegativrValue[indexSum] += Matrix[x, j];
                        }

                        flag = false;

                    }

                    indexSum++;
                }
                return sumNegativrValue;
            }

        }
       #endregion matrix

    }
}
