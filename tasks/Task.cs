using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Given: integer matrix of n rows and m columns.
// Find : a maximum of the smallest elements of columns.


// Algorithm for solving the problem :
// The approximate solution algorithm 1.
// See each column . The smallest element of each column to preserve the one-dimensional array.
// Find the maximum value in the one-dimensional array.
namespace Task1
{
    class Program
    {
        
        
        static void Main(string[] args)
        {
            mas massiv = new mas();

            massiv.fillingRandValue();
            massiv.ShowMassive();
            Console.WriteLine();
            Console.WriteLine(massiv.maxElemetsOfMinCollumns());
            Console.ReadKey();
        }

        public class mas
        {
            private int flagMaxValue = 11;
            private Random rand = new Random();
            private int n, m;
            private int[,] massiv; // = new int[n,m]; 
            

            public mas()
            {
                n = 5;
                m = 4;
                massiv = new int[n,m];   
            }

            public mas(int n1, int m1)
            {
                n = n1;
                m = m1;
                massiv = new int[n, m];
            }

            public void fillingRandValue()
            {
                for(int i = 0; i < n; i++)
                    for (int j = 0; j < m; j++)
                    {
                        massiv[i, j] = rand.Next(0, flagMaxValue - 1);
                    }
            }

            public void ShowMassive()
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                        Console.Write(massiv[i, j] + " ");
                    Console.WriteLine();
                }

            }

            public int maxElemetsOfMinCollumns()
            {
                int minElemetOfCollumn = flagMaxValue;
                int maxElementOfOtherCollumn = flagMaxValue;

                for (int i = 0; i < m; i++)
                {
                    for (int j =  n - 1; j != 0; j--)
                    {
                        if (minElemetOfCollumn == flagMaxValue)
                        {
                            minElemetOfCollumn = massiv[n-1 , i];
                        }

                        if (minElemetOfCollumn >= massiv[j, i])
                            minElemetOfCollumn = massiv[j, i];
                    }

                    if (maxElementOfOtherCollumn == flagMaxValue)
                    {
                        maxElementOfOtherCollumn = minElemetOfCollumn;
                    }

                    if (maxElementOfOtherCollumn <= minElemetOfCollumn)
                        maxElementOfOtherCollumn = minElemetOfCollumn;

                    minElemetOfCollumn = flagMaxValue;
                }

                return maxElementOfOtherCollumn;
            }

        }

    }
}
