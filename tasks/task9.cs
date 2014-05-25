using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
    В одномерном массиве, состоящем из n вещественных элементов,
    вычислить сумму модулей элементов массива, расположенных после первого элемента, равного нулю.
*/
namespace Task2
{

    class task
    {

        static void Main()
        {
            int size = 10;
            int[] array = new int[size];
            int sum = 0;
            Random random = new Random();
            array[0] = 0;

            for (int i = 1; i < array.Length; i++ )
            {
                array[i] = random.Next(-10, 10);
            }

            foreach (int x in array)
                Console.Write(x + " ");
            /*
            foreach(int x in array)
            {
                sum += Math.Abs(x);
            }*/
            for (int i = 1; i < array.Length; i++)
            {
                sum += Math.Abs(array[i]);
            }

            Console.WriteLine("\nСумма по модулю : {0}", sum);
            
            Console.ReadKey(true);
        }
      
    }
}
