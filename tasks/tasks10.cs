using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//    Найти 20 первых пифагоровых чисел, то есть целых k, l, m таких, что k2 + l2 = m2
namespace Task2
{

    class task
    {

        static void Main()
        {
            int flag = 20;
            
                for(int k = 1; k < 30 ; k++)
                    for(int l = 1; l < 30 ; l++)
                        for (int m = 1; m < 30 ; m++)
                        {
                            if (flag == 0)
                            {
                                Console.ReadKey(true);
                                return;
                            }
                            if( (k*k + l*l) == m*m)
                            {
                                Console.WriteLine("k = {0}, l = {1}, m = {2}", k, l, m);
                                flag--;
                            }
                        }
            
            
            Console.ReadKey(true);
        }
      
    }
}
