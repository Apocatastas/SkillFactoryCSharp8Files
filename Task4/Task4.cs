using System;
using System.IO;
namespace Task4
{
    /// <summary>
    /// Ваша программа должна:
    ///
    /// Cчитать данные о студентах из файла;
    /// ✓  Создать на рабочем столе директорию Students.
    /// ✓  Внутри раскидать всех студентов из файла по группам
    /// ✓   (каждая группа-отдельный текстовый файл),
    /// ✓  в файле группы студенты перечислены построчно в формате "Имя, дата рождения, средний балл".
    /// </summary>

    class Program
    {
        static void Main(string[] args)
        {

            DirectoryInfo studDir = new DirectoryInfo(Student.deserializedPath + "Students/");
            studDir.Create();

            List<Student> studentsToRead = ReadStudentsFromBinFile("../../../students.dat");


            foreach (Student studentProp in studentsToRead)
            {
                string filepath = Student.deserializedPath + "Students/" + studentProp.Group + ".txt";

                if (!File.Exists(filepath))
                {
                    using (StreamWriter sw = File.CreateText(filepath)) { }
                    
                }

                using (StreamWriter sw = new StreamWriter(filepath,true))
                    {
                      
                        sw.WriteLine(studentProp.Name + " " + studentProp.DateOfBirth + " " + studentProp.AverageScore);
                        Console.WriteLine(studentProp.Name);
                    }
                
            }
             
            Console.ReadKey();


            static List<Student> ReadStudentsFromBinFile(string fileName)
            {
                List<Student> result = new();
                using FileStream fs = new FileStream(fileName, FileMode.Open);
                using StreamReader sr = new StreamReader(fs, true);

                fs.Position = 0;

                BinaryReader br = new BinaryReader(fs);

                while (fs.Position < fs.Length)
                {
                    Student student = new Student();
                    student.Name = br.ReadString();
                    student.Group = br.ReadString();
                    long dt = br.ReadInt64();
                    student.DateOfBirth = DateTime.FromBinary(dt);
                    student.AverageScore = br.ReadDecimal();

                    result.Add(student);
                }
                sr.Close();
                fs.Close();
                return result;
            }

        }
    }
}