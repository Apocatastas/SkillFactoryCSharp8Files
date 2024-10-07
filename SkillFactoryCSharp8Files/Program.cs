using System;

class Program
{
    static void Main(string[] args)
    {
        ObjectCounter();
        

    }

    static void ObjectCounter()
    {
        string dirName = @"/";
        string[] dirs = Directory.GetDirectories(dirName);
        string[] files = Directory.GetFiles(dirName);
        int totalDirs = dirs.Length;
        int totalFiles = files.Length;
        Console.WriteLine("Папок: {0}, файлов: {1}, всего объектов: {2}",totalDirs,totalFiles,totalDirs+totalFiles);
        Console.ReadKey();

    }


    static void GetCatalogs()
    {
        string dirName = @"/"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
        if (Directory.Exists(dirName)) // Проверим, что директория существует
        {
            Console.WriteLine("Папки:");
            string[] dirs = Directory.GetDirectories(dirName);  // Получим все директории корневого каталога

            foreach (string d in dirs) // Выведем их все
                Console.WriteLine(d);

            Console.WriteLine();
            Console.WriteLine("Файлы:");
            string[] files = Directory.GetFiles(dirName);// Получим все файлы корневого каталога

            foreach (string s in files)   // Выведем их все
                Console.WriteLine(s);

            Console.ReadKey();
        }
    }

    
}