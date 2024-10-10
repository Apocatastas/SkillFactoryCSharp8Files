using System;
using System.Text.Json;
using static System.Formats.Asn1.AsnWriter;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;

namespace Task4
{
    [Serializable]
    public class Student
    {
        public static string serializedPath = "/Users/apocatastas/Projects/SkillFactoryCSharp8Files/Task4/Resources/students.dat";
        public static string deserializedPath = "/Users/apocatastas/Desktop/";

        public string Name { get; set; }
        public string Group { get; set; }
        public DateTime DateOfBirth { get; set; }
        public decimal AverageScore { get; set; }

        public Student(string name, string group, DateTime date, decimal score)
        {
            Name = name;
            Group = group;
            DateOfBirth = date;
            AverageScore = score;
        }

        public Student()
        {
            Name = "";
            Group = "";
            DateOfBirth = DateTime.Now;
            AverageScore = 0;
        }

        public void Serialize(string path)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(this, options);
            File.WriteAllText(path, jsonString);
        }

        public void Deserialize(string path)
        {
            var jsonString = File.ReadAllText(path);
            var studentList = JsonSerializer.Deserialize<Student>(jsonString);

        }
    }
}

