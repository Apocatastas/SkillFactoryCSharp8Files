using System;
using System.IO;
using System.Text.Json;
namespace Serialization
{


    [Serializable]
    public class Contact
    {
        public string Name { get; set; }
        public long PhoneNumber { get; set; }
        public string Email { get; set; }

        public Contact(string name, long phoneNumber, string email)
        {
            Name = name;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public void Serialize()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            var jsonString = JsonSerializer.Serialize(this, options);
            File.WriteAllText("contact.json", jsonString);
            Console.WriteLine("Объект сериализован");
        }

        public void Deserialize()
        {
            var jsonString = File.ReadAllText("contact.json");
            var newcontact = JsonSerializer.Deserialize<Contact>(jsonString);
            Console.WriteLine("Объект десериализован");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Объект для сериализации
            var contact = new Contact("Vasya", 79992345678, "email@server.ru");
            Console.WriteLine("Объект создан");

            contact.Serialize();
            contact.Deserialize();
            Console.WriteLine(contact.Name);
            Console.WriteLine(contact.PhoneNumber);
            Console.WriteLine(contact.Email);
            Console.ReadKey();



        }
    }
}