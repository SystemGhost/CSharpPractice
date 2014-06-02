using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Для перегрузки операций используется специальный статический метод,
имя которого образовано из ключевого слова operator и знака операции. Ко-
личество формальных параметров метода зависит от типа операции: унарная
операция требует одного параметра, бинарная – двух. Метод обязательно дол-
жен иметь модификатор доступа public.
 */
namespace PracticCSharp
{
    class Program
    {
        static void Main()
        {
            Complex A = new Complex(1, -2);
            Complex B = new Complex(0, 0);
            Console.WriteLine(A);
            Console.WriteLine(B);
            Console.WriteLine(A + B);
            if (B)
                Console.WriteLine("Number B is not zero");
            else Console.WriteLine("Number is = 0.0 + 0.0i");

            Complex C = new Complex(3,4);
            double x;
            Console.WriteLine("C = " + C);
            //Выполняем явное приведение типов
            x = (double)C;
            Console.WriteLine(x);
            double y = 10;
            //Выполняем неявное приведение типов
            C = y;
            Console.WriteLine(C);
            Console.ReadKey(true);
        }
        #region Complex
        class Complex
        {
            public double Re;
            public double Im;

            public Complex(double Re, double Im)
            {
                this.Re = Re;
                this.Im = Im;

            }
            public override string ToString()
            {
                return String.Format("Re = {0}, Im = {1}", Re, Im);
            }
            public static Complex operator +(Complex A, Complex B)
            {
                return new Complex(A.Re+B.Re, A.Im+B.Im);
            }
            public static Complex operator +(Complex A, double B)
            {
                return new Complex(A.Re + B, A.Im + B);
            }
            //            Любой класс может перегрузить операции true и false. Операции пере-
            //гружаются парой, тип возвращаемого значения операций – булевский. Если в
            //классе выполнена подобная перегрузка, объекты класса могут использоваться
            //как условия в операторах условного перехода или циклов. При вычислении ус-
            //ловий используется перегруженная версия операции true.

            public static bool operator true(Complex A)
            {
                return (A.Re > 0) || (A.Im > 0);
            }
            public static bool operator false(Complex A)
            {
                return (A.Re == 0) || (A.Im == 0);
            }
            //            Ключевое слово implicit используется при перегрузке неявного приведе-
            //ния типов, а ключевое слово explicit – при перегрузке операции явного при-
            //ведения. Либо <целевой тип>, либо <приводимый тип> должены совпадать с
            //типом того класса, где выполняется перегрузка операций.
            public static implicit operator Complex(double a)
            {
                return new Complex(a, 0);
            }
            public static explicit operator double(Complex A)
            {
                return Math.Sqrt(A.Re * A.Re + A.Im * A.Im);
            }
        }
        #endregion Complex
    }
}
