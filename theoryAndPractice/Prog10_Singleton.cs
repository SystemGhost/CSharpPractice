using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Класс Singleton. Особенностью этого класса является то, что в при-
ложении можно создать только один объект данного класса.
 */
namespace PracticCSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton A = Singleton.Create();
            Singleton D = Singleton.Create();

            A.info = "information";
            Console.WriteLine(D.info);
           
            Console.ReadKey(true);
        }
        class Singleton
        {
            static Singleton Instance;      //поле Instance хранит ссылку на объект и описано как статическое.
                                            // Это сделано для того, чтобы с ним
                                            //можно было работать в статическом методе Create().
            public string info;
            private Singleton() { }

            public static Singleton Create()            //Create() всегда возвращает ссылку на один и тот же объект.
            {
                if (Instance == null) Instance = new Singleton();
                return Instance;
            }

        }
    }
}
