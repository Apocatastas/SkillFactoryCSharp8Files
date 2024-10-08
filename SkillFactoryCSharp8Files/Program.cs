using System;
using System.IO;

class BinaryExperiment
{
    const string BinaryFilePath = "/Users/apocatastas/Desktop/BinaryFile.bin";

    static void Main()
    {
        ReadValues();

        Console.ReadKey();
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