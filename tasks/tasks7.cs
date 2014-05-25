using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
  Начав тренировки, лыжник в первый день пробежал 10 км. 
  Каждый следующий день он увеличивал длину пробега на 10 км пробега предыдущего дня.
  Определить в какой день он пробежит больше 20 км;
  в какой день суммарный пробег за все дни превысит 100 км
*/
namespace Task2
{

    class task
    {

        static void Main()
        {
            int length = 10;
            int sum = 10;
            int day = 1;
            bool dayof20 = false;
            bool dayof100 = false;
            Console.WriteLine("lenght: {0}, sum: {1}, day: {2}", length, sum, day);
            for (int i = 0; i < 5; i++)
            {
                if (length > 20 && dayof20 == false)
                {
                    dayof20 = true;
                    Console.WriteLine("Лыжник пробежал больше 20 километров в день: {0}", day);
                }
                if (sum >= 100 && dayof100 == false)
                {
                    dayof100 = true;
                    Console.WriteLine("Лыжник пробежал суммарный пробег в 100 километров в день: {0}", sum);
                }

                iteration(ref length, ref sum, ref day);
                
                Console.WriteLine("lenght: {0}, sum: {1}, day: {2}", length, sum, day);
            }
            Console.ReadKey(true);
        }
        

        static void iteration(ref int length, ref int sum, ref int day)
        {
            sum += length;
            length += 10;
            day++;
        }

        }
    }
