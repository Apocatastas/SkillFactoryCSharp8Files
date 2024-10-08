using System;
using System.IO;

class BinaryExperiment
{
    const string BinaryFilePath = "/Users/apocatastas/Desktop/BinaryFile.bin";

    static void Main()
    {
        WriteValues();
        ReadValues();

        Console.ReadKey();
    }

    static void WriteValues()
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(BinaryFilePath, FileMode.Open)))
            writer.Write($"Файл изменен {DateTime.Now} на компьютере c ОС {Environment.OSVersion}");
    }

    static void ReadValues()
    {
     
        string StringValue;
     

        if (File.Exists(BinaryFilePath))
        {
            using (BinaryReader reader = new BinaryReader(File.Open(BinaryFilePath, FileMode.Open)))
            {
                StringValue = reader.ReadString();
            }

            Console.WriteLine(StringValue);
        }
    }
}