using System;
using System.Threading;

/*
 *  Потоки и синхронизация. Часть 1
 */


class Test
{
    static void PrintText(string text)
    {
        /*
         * Язык C# содержит специальный оператор lock, задающий критическую
секцию. Формат данного оператора следующий:
         
lock(<выражение>) { <блок критической секции> }
         
<Выражение> является идентификатором критической секции. В качестве
выражения выступает переменная ссылочного типа. Для lock-секций, разме-
щенных в экземплярных методах класса, выражение обычно равно this, для
критических секций в статических методах в качестве выражения используется
typeof(<имя класса>).
         */

        // Задаем критическую секцию
        lock (typeof(Test))
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(text);
                Thread.Sleep(100);
            }
        }
    }

    static void FirstPrinter()
    {
        while (true) PrintText("x");
    }

    static void SecondPrinter()
    {
        while (true) PrintText("o");
    }
    static void Main()
    {
        Thread th1 = new Thread(new ThreadStart(FirstPrinter));
        Thread th2 = new Thread(new ThreadStart(SecondPrinter));
        th1.Start();
        th2.Start();

        Console.ReadKey(true);
    }


 
}