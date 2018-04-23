using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SingleResponsibilityPrinciple
{
    //A class should only have one reason to change
    //Separation of concerns – different classes handling different, independent tasks/problems

    public class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // This would add to much responsibility to the class Journal
        //public void Save(string filename) { File.WriteAllText(filename, ToString()); }
        //public Journal Load(string filename) { }
        //public Journal Load(Uri uri) { }
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
                File.WriteAllText(filename, j.ToString());
        }
    }

    class Solid
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I'm studying SOLID");
            j.AddEntry("This is very exciting stuff");
            Console.WriteLine(j);

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(j, filename, true);
            Process.Start(filename);
        }
    }
}
