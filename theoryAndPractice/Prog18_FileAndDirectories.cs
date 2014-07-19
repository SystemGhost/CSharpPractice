using System;
using System.IO;

/*
 * Работа с файлами
 */
delegate double Function(double x);
class Test
{
    static void Main()
    {
        /*Конструктор класса DirectoryInfo принимает в качестве параметра стро-
ку с именем того каталога, с которым будет производиться работа. Для указа-
ния текущего каталога используется точка (строка "."). При попытке работать
с данными несуществующего каталога, генерируется исключительная ситуация.*/
        //Создали обьект для директории
        DirectoryInfo dir = new DirectoryInfo(@"C:\Temp\D");
        // Выводим некоторые свойства директории
        Console.WriteLine("Full Name: {0}", dir.FullName);
        Console.WriteLine("Parent: {0}", dir.Parent);
        Console.WriteLine("Root: {0}", dir.Root);
        Console.WriteLine("Creation: {0}", dir.CreationTime);
        // Создаем новую поддиректорию в нашей
        dir.CreateSubdirectory("Dir2");
        // Создаем еще одну новую поддиректорию
        dir.CreateSubdirectory(@"Dir2\SubDir2");
        // Получаем массив объектов, описывающих поддиректории
        DirectoryInfo[] subdires = dir.GetDirectories();
        // Получаем массив объектов,
        // описывающих все файлы в директории
        FileInfo[] files = dir.GetFiles();
        //Можно использовать маску файлов
        FileInfo[] files1 = dir.GetFiles("*.ex");

        //****************************************************
        Console.WriteLine();
        // Создаем объект
        FileInfo file = new FileInfo(@"C:\Test.txt");
        // Создаем файл (с потоком делать ничего не будем)
        FileStream fs = file.Create();
        // Выводим информацию
        Console.WriteLine("Full Name: {0}", file.FullName);
        Console.WriteLine("Atts: {0}",
        file.Attributes.ToString());
        Console.WriteLine("Press any key to delete file");
        Console.Read();
        // Закрываем поток, удаляем файл
        fs.Close();
        file.Delete();

        // Файл создается (или открывается) для чтения и записи,
        // без возможности совместного использования
        FileInfo file2 = new FileInfo(@"C:\Test.txt");
        FileStream fs2 = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);

        Console.ReadKey();
        fs2.Close();
        file.Delete();

        Console.ReadKey(true);
    }
}