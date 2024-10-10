using System;
using System.Reflection;


/// <summary>
/// Доработайте программу из задания 1, используя ваш метод из задания 2.
///
/// При запуске программа должна:
///
/// ✓ Показать, сколько весит папка до очистки. Использовать метод из задания 2. 
/// ✓ Выполнить очистку.
/// ✓ Показать сколько файлов удалено и сколько места освобождено.
/// ✓ Показать, сколько папка весит после очистки.
///

/// </summary>
class Program
{
    static long Size = 0; //Размер до очистки
    static long ClearedSize = 0; //Размер после очистки

    static void Main(string[] args)
    {
        string path = GetPath();
        DirectoryInfo dir = new DirectoryInfo(path);
        GetSize(dir);
        ClearedSize += Size;
        Console.WriteLine();
        Console.ForegroundColor =ConsoleColor.Green ;
        Console.WriteLine("Размер до очистки {0} байт", Size);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();

        RemoveOldFiles(dir);
        Size = 0;
        GetSize(dir);
        ClearedSize -= Size;
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Размер после очистки {0} байт", Size);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Очистка завешена, освободили {0} байт", ClearedSize);
        Console.ForegroundColor = ConsoleColor.White;
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
                Console.WriteLine("Папка найдена, приступаем к очистке файлов и папок старше 30 минут");
            }
            else Console.WriteLine("Не удалось найти такую папку, попробуйте другой адрес");
        }
        while (!itsOK);

        return userPath;
    }


    static void RemoveOldFiles(DirectoryInfo dir)
    {
        if (dir.Exists)
        {
            try
            {

                FileInfo[] files = dir.GetFiles();
                Console.WriteLine("/---------------------/");
                Console.WriteLine("Работаем с папкой {0}, доступ {1}", dir.Name, dir.LastAccessTime);
                foreach (FileInfo f in files)
                {

                    if (f.LastAccessTime < DateTime.Now.Add(new TimeSpan(0, 0, -30, 0)))
                    {
                        Console.WriteLine("Файл {0} удалён - доступ {1}, сейчас {2}", f.Name, f.LastAccessTime, DateTime.Now.Add(new TimeSpan(0, 0, -30, 0)));
                        f.Delete();
                    }
                    else
                    {
                        Console.WriteLine("Файл {0} оставили - доступ {1}, он новый", f.Name, f.LastAccessTime);

                    }
                }

                DirectoryInfo[] dirs = dir.GetDirectories();  // Получим все директории внутри папки

                foreach (DirectoryInfo d in dirs)
                {
                    if (d.LastAccessTime < DateTime.Now.Add(new TimeSpan(0, 0, -30, 0)))
                    {
                        d.Delete(true);
                        Console.WriteLine("Папка {0} удалена", d.Name);

                    }

                    else
                        Console.WriteLine("Папку {0} оставили, она новая, доступ {1}", d.Name, d.LastAccessTime);
                    RemoveOldFiles(d);


                }
            }



            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

    }

    static void GetSize(DirectoryInfo dir)
    {

        if (dir.Exists)
        {
            try
            {

                FileInfo[] files = dir.GetFiles();
               // Console.WriteLine("/---------------------/");
               // Console.WriteLine("Работаем с папкой {0}", dir.Name);
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