using System;
using System.Reflection;


/// <summary>
/// В папке проекта есть папка Resources со старыми файлами, на ней будем проверять работу программы.
/// Если что-то пойдёт не так - есть бэкап этой папки, чтобы не искать старые файлы каждый раз
/// path = @"/Users/apocatastas/Projects/SkillFactoryCSharp8Files/Task1/Resources"
///
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
        Console.WriteLine("Удаление файлов старше 30 минут закончено");
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
                Console.WriteLine("Папка найдена, приступаем к очистке файлов старше 30 минут");
            }
            else Console.WriteLine("Не удалось найти такую папку, попробуйте другой адрес");
        }
        while (!itsOK);

        return userPath;
    }


    static void RemoveOldFiles(DirectoryInfo dir)
    {
        try
        {

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo f in files)
            {
                if (f.CreationTime < DateTime.Now.Add(new TimeSpan(0, 0, -30, 0)))
                {
                    f.Delete();
                }
            }

            DirectoryInfo[] dirs = dir.GetDirectories();  // Получим все директории внутри папки

            foreach (DirectoryInfo d in dirs)
            {
                RemoveOldFiles(d);
            }

        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }



    }

}