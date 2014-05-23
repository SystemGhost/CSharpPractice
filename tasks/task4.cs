using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Дана матрица А(20) найти максимальный и минимальный элемент массива и его порядковый номер
namespace Task2
{

    class task
    {
       
        static void Main()
        {
            int row = 10, column = 10;
            int[,] matrix = new int[row,column];
            int[] maxElement = new int[3];
            int[] minElement = new int[3];

            Random rand = new Random();

            for(int i = 0; i< row; i++)
                for(int j = 0; j < column; j++)
                    matrix[i,j] = rand.Next(0,100);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                    Console.Write(matrix[i, j] + " ");

                Console.WriteLine();
            }

            maxElement[1] = maxElement[2] = 0;
            maxElement[0] = matrix[maxElement[1], maxElement[2]];
            minElement[1] = minElement[2] = 0;
            minElement[0] = matrix[minElement[1], minElement[2]];
            
            for(int i = 0; i < row; i++)
                for (int j = 0; j < column; j++)
                {
                    if (maxElement[0] < matrix[i, j])
                    {
                        maxElement[0] = matrix[i, j];
                        maxElement[1] = i;
                        maxElement[2] = j;
                    }
                    if (minElement[0] > matrix[i, j])
                    {
                        minElement[0] = matrix[i, j];
                        minElement[1] = i;
                        minElement[2] = j;
                    }
                }

            Console.WriteLine("Max Element {0} на позиции ({1},{2})", maxElement[0], maxElement[1]+1, maxElement[2]+1);
            Console.WriteLine("Min Element {0} на позиции ({1},{2})", minElement[0], minElement[1]+1, minElement[2]+1);
            Console.ReadKey(true);
        }
    }
}
