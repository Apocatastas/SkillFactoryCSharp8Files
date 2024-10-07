using System;
using System.Reflection;

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

            DirectoryInfo dirInfoNew = new DirectoryInfo(@"/Users/apocatastas/Desktop/testFolder");
            if (!dirInfoNew.Exists)
                dirInfoNew.Create();


            string newPath = "/Users/apocatastas/Library/Mobile Documents/.Trash/";

            if (dirInfoNew.Exists && !Directory.Exists(newPath))
               dirInfoNew.MoveTo(newPath);


           // dirInfoNew.Delete(true); // Удаление со всем содержимым
            Console.WriteLine("Каталог перемещен в корзину");
            
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