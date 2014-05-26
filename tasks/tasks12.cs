using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Проверить, все ли строки матрицы упорядочены по убыванию. Если нет, найти первую неупорядоченную строку и упорядочить.
namespace Task2
{

    class task
    {
        static void Main()
        {
            int column = 3, str = 5;
            matrix Matrix = new matrix(str, column);
            Matrix.randomValue();
            Matrix.showMatrix();
            Matrix.sortMatrix();
            Console.WriteLine("---Sort--");
            Matrix.showMatrix();
            Console.ReadKey(true);
        }

        #region matrix
        public class matrix
        {
            private int str;
            private int column;
            private int[][] Matrix;

            public matrix()
            {
                str = 0;
                column = 0;

                Matrix = new int[str][];
                for (int i = 0; i < str; i++)
                {
                    Matrix[i] = new int[column];
                }
            }
            public matrix(int str_new, int column_new)
            {
                if (str_new < 0)
                    str_new = 0;
                if (column < 0)
                    column_new = 0;

                str = str_new;
                column = column_new;

                Matrix = new int[str][];
                for (int i = 0; i < str; i++)
                {
                    Matrix[i] = new int[column];
                }
            }
            public void randomValue()
            {
                Random random = new Random();
                for (int i = 0; i < str; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        Matrix[i][j] = random.Next(0, 10);
                    }
                }
            }
            public void showMatrix()
            {
                for (int i = 0; i < str; i++)
                {

                    for (int j = 0; j < column; j++)
                    {
                        Console.Write(Matrix[i][j] + " ");
                    }
                    Console.WriteLine();

                    
                }
            }
            public void sortMatrix()
            {
                bool flagNotSort = false;
                int notSort;
                int pastArrayValue;

                for (notSort = 0; notSort < str; notSort++)
                {
                    pastArrayValue = Matrix[notSort][0];
                    for (int j = 1; j < column; j++)
                    {
                        if (pastArrayValue > Matrix[notSort][ j])
                        {
                            flagNotSort = true;
                            break;
                        }
                    }
                    if (flagNotSort == true)
                    {
                        break;
                    }
                }
                if (flagNotSort == true)
                {
                    Array.Sort(Matrix[notSort]);
                }
                //for (int i = 0; i < str; i++)
                //{
                //    Array.Sort(Matrix[i]);
                //}
            }
        }
        #endregion matrix

    }
}
