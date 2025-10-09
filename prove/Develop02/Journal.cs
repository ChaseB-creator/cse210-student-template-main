using System;
using System.Collections.Generic;
using System.IO;

namespace JournalApp
{
    public class Journal {
        private List<Entry> _entries = new List<Entry>();

        public void AddEntry(Entry entry) {
            _entries.Add(entry);
        }

        public void DisplayAllEntries() {
            if (_entries.Count == 0) {
                Console.WriteLine("No entries found.");
                return;
            }

            Console.WriteLine("Your Journal Entries:\n");
            foreach (Entry e in _entries) {
                Console.WriteLine(e.ToString());
                Console.WriteLine("---------------------------");
            }
        }

        public void SaveToFile(string filename) {
            using (StreamWriter writer = new StreamWriter(filename)) {
                foreach (Entry e in _entries) {
                    writer.WriteLine(e.ToFileString());
                }
            }
        }

        public void LoadFromFile(string filename) {
            _entries.Clear();

            if (File.Exists(filename)) {
                string[] lines = File.ReadAllLines(filename);
                foreach (string line in lines) {
                    Entry e = Entry.FromFileString(line);
                    _entries.Add(e);
                }
            }
            else {
                Console.WriteLine("File not found. Please check the filename and try again.");
            }
        }
    }
}
