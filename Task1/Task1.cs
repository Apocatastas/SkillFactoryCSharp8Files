using System;
using System.Reflection;


/// <summary>
/// Напишите программу, которая чистит нужную нам папку от файлов  и папок,
/// которые не использовались более 30 минут 
/// На вход программа принимает путь до папки. 
/// При разработке постарайтесь предусмотреть возможные ошибки (нет прав доступа,
/// папка по заданному адресу не существует, передан некорректный путь)
/// и уведомить об этом пользователя.
///
/// ✓ код должен удалять папки рекурсивно (если в нашей папке лежит папка со вложенными файлами,
///   не должно возникнуть проблем с её удалением).
/// ✓ предусмотрена проверка на наличие папки по заданному пути
///   (строчка if directory.Exists);
/// ✓ предусмотрена обработка исключений
///   при доступе к папке (блок try-catch, а также логирует исключение в консоль).
/// 
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        string path = GetPath();
        DirectoryInfo dir = new DirectoryInfo(path);
        RemoveOldFiles(dir);
        Console.WriteLine("Удаление файлов и папок старше 30 минут закончено");
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

}