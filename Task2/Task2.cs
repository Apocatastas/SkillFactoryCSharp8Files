using System;
using System.Reflection;


/// <summary>
/// Напишите программу, которая считает размер папки на диске (вместе со всеми вложенными папками и файлами).
/// На вход метод принимает URL директории, в ответ — размер в байтах.
/// 
/// </summary>
class Program
{
    static long Size = 0;

    static void Main(string[] args)
    {
        string path = GetPath();
        DirectoryInfo dir = new DirectoryInfo(path);
        GetSize(dir);
        Console.WriteLine("Размер этой папки, включая вложенные, составляет {0} байт", Size);
        Console.ReadKey();
    }

    static string GetPath()
    {
        string userPath = "";
        bool itsOK = false;
        do
        {
            Console.WriteLine("Введите путь к папке: ");
            userPath = Console.ReadLine();
            DirectoryInfo testDir = new DirectoryInfo(userPath);
            if (testDir.Exists)
            {
                itsOK = true;
                Console.WriteLine("Папка найдена, приступаем к подсчёту размера");
            }
            else Console.WriteLine("Не удалось найти такую папку, попробуйте другой адрес");
        }
        while (!itsOK);

        return userPath;
    }


    static void GetSize(DirectoryInfo dir)
    {
        
        if (dir.Exists)
        {
            try
            {

                FileInfo[] files = dir.GetFiles();
                Console.WriteLine("/---------------------/");
                Console.WriteLine("Работаем с папкой {0}", dir.Name);
                foreach (FileInfo f in files)
                {
                    Size += f.Length;
                }

                DirectoryInfo[] dirs = dir.GetDirectories();  // Получим все директории внутри папки

                foreach (DirectoryInfo d in dirs)
                {
                    GetSize(d);
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }

}