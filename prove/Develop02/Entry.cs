using System;

namespace JournalApp
{
    public class Entry
    {
        public string Date { get; private set; }
        public string Prompt { get; private set; }
        public string Response { get; private set; }

        public Entry(string date, string prompt, string response) {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        public override string ToString() {
            return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
        }

       
        public string ToFileString() {
            return $"{Date}|{Prompt}|{Response}";
        }

        
        public static Entry FromFileString(string line) {
            string[] parts = line.Split('|');
            if (parts.Length == 3) {
                return new Entry(parts[0], parts[1], parts[2]);
            }
            else {
                throw new FormatException("Invalid journal entry format.");
            }
        }
    }
}
