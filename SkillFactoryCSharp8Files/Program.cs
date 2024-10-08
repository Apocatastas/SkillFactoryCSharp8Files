using System;
using System.IO;
using System.Reflection;

class Program
{
    
    static void Main(string[] args)
    {
        string filePath = @"/Users/apocatastas/Projects/SkillFactoryCSharp8Files/SkillFactoryCSharp8Files/Program.cs"; // Укажем путь

        AddLastRunTimecode(filePath);
        ShowSelfContent(filePath);
        
        Console.ReadKey();
    }

    static void ShowSelfContent(string filePath)
    {

        
        // Откроем файл и прочитаем его содержимое
        using (StreamReader sr = File.OpenText(filePath))
        {
            string str = "";
            while ((str = sr.ReadLine()) != null)
                Console.WriteLine(str);
        }
    }

    static void AddLastRunTimecode(string filePath)
    {

        using (StreamWriter sw = File.AppendText(filePath))

        {
            sw.WriteLine($"// Время запуска: {DateTime.Now}");
        }
    }
          

    
}
