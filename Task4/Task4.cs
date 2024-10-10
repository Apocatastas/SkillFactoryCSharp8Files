using System;
using System.IO;
using System.Text.Json;
namespace Task4
{
    /// <summary>
    /// Ваша программа должна:
    ///
    /// Cчитать данные о студентах из файла;
    /// ✓  Создать на рабочем столе директорию Students.
    /// Внутри раскидать всех студентов из файла по группам
    ///   (каждая группа-отдельный текстовый файл), в файле группы студенты
    ///   перечислены построчно в формате "Имя, дата рождения, средний балл".
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {
            // Объект для сериализации
            Student student = new Student("","",DateTime.Now, 12345);
            DirectoryInfo studDir = new DirectoryInfo(Student.deserializedPath + "Students/");
            Console.ReadKey();



        }
    }
}