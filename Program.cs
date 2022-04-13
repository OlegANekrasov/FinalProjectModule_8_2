using System;
using System.IO;

namespace FinalProjectModule_8_2
{
    class Program
    {
        // Напишите программу, которая считает размер папки на диске
        // (вместе со всеми вложенными папками и файлами).
        // На вход метод принимает URL директории, в ответ — размер в байтах.
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Не задан путь до папки!");
                Console.ReadLine();
                return;
            }

            var path = args[0];
            var directory = new DirectoryInfo(path);
            if (directory.Exists) // предусмотрена проверка на наличие папки по заданному пути
            {
                Console.WriteLine($"Папка: {path}\n");
                try // предусмотрена обработка исключений при доступе к папке
                {
                    Console.WriteLine($"Размер папки: {GetSize(directory)} байт");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка чтения папки: " + ex); // логирует исключение в консоль
                }
            }
            else
            {
                Console.WriteLine("Заданой папки не существует!");
            }

            Console.ReadLine();
        }

        static long GetSize(DirectoryInfo directory)
        {
            long size = 0;

            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                size += file.Length;
            }

            DirectoryInfo[] dirs = directory.GetDirectories();
            foreach (DirectoryInfo dir in dirs)
            {
                size += GetSize(dir);
            }

            return size;
        }
    }
}
