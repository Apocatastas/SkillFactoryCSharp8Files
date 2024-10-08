using System;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        ShowSelfContent();

        Console.ReadKey();
    }

    static void ShowSelfContent()
    {

        string filePath = @"/Users/apocatastas/Projects/SkillFactoryCSharp8Files/SkillFactoryCSharp8Files/Program.cs"; // Укажем путь

        // Откроем файл и прочитаем его содержимое
        using (StreamReader sr = File.OpenText(filePath))
        {
            string str = "";
            while ((str = sr.ReadLine()) != null)
                Console.WriteLine(str);
        }
    }
          

    
}