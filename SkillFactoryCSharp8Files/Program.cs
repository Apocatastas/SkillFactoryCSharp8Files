
///Придумайте простой класс, который будет предоставлять информацию
///об установленном в системе диске. 
///Нужны свойства, чтобы хранить: имя диска, объём, свободное место.
///Свойства инициализируются при создании нового объекта в методе-конструкторе.
///


using System;

class Program
{
    public class Disc
    {
        public string Name { get; }
        public long Volume { get; }
        public long FreeSpace { get; }

        public Disc(string discName, long discVolume, long discFreeSpace)
        {
            Name = discName;
            Volume = discVolume;
            FreeSpace = discFreeSpace;
        }

    }


    public static void Main(string[] args)
    {

    }
}