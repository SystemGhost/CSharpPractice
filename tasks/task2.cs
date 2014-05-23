using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//  Пргорамма пройстой аутентификации, использующая в качестве последней буквы код последней буквы имени
namespace Task2
{

    class task
    {
       
        static void Main()
        {
            string name = string.Empty;
            char password;
            int codePassword;

            Console.WriteLine("Please, input your name: ");
            name = Console.ReadLine();
            password = name[name.Length - 1];
            codePassword = (int)password;

            Console.WriteLine("Your Password: " + codePassword);
            Console.WriteLine("Input your password: ");

            if (codePassword == Int32.Parse(Console.ReadLine()))
            {
                Console.WriteLine("access!");
            }
            else Console.WriteLine("fail!");

            Console.ReadKey(true);
        }
    }
}
