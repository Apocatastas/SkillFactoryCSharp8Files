using System;
namespace SkillFactoryCSharp8Files
{
    public class Folder
    {
        public List<string> Files { get; set; } = new List<string>();

        public Folder(string name)
        {
            Name = name;
        }

        public Folder() { }

        string Name { get; set; }

        void AddFile(string name)
        {
            if (!Files.Contains(name))
                Files.Add(name);
        }
    }
}

