using System;

class Program
{
    static void Main(string[] args)
    {
        ObjectCounter();
        

    }

    static void ObjectCounter()
    {
        try
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"/Users/apocatastas" /* Или С:\\ для Windows */ );
            if (dirInfo.Exists)
            {
                Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
            }
            DirectoryInfo dirInfoNew = new DirectoryInfo(@"/Users/apocatastas/NewFolder");
            if (!dirInfoNew.Exists)
                dirInfoNew.Create();

            Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);


            dirInfoNew.Delete(true); // Удаление со всем содержимым
            Console.WriteLine("Каталог удален");
            Console.WriteLine(dirInfo.GetDirectories().Length + dirInfo.GetFiles().Length);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

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