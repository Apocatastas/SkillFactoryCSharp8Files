using System;
namespace SkillFactoryCSharp8Files
{
    public class Disc
    {
        public enum DriveType 
        {
            USB,
            HDD,
            CD
        }

    public string Name { get; }
        public long Volume { get; }
        public long FreeSpace { get; }

        public Disc(string discName, long discVolume, long discFreeSpace)
        {
            Name = discName;
            Volume = discVolume;
            FreeSpace = discFreeSpace;
        }

        Dictionary<string, Folder> Folders = new Dictionary<string, Folder>();

        public void CreateFolder(string name)
        {
            Folders.Add(name, new Folder());
        }

    }
}

