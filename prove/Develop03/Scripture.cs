using System;
using System.Collections.Generic;
using System.Linq;

namespace Script_Memorizor {
    public class Scripture {
        private Reference _reference;
        private List<Word> _words;
        private Script_Obscurer _obscurer = new Script_Obscurer();

        private static List<string> _scriptureLibrary = new List<string> {
            "2 Nephi 32:3 - Angels speak by the power of the Holy Ghost; wherefore, they speak the words of Christ. Wherefore, I said unto you, feast upon the words of Christ; for behold, the words of Christ will tell you all things what ye should do.",
            "2 Nephi 2:25 - Adam fell that men might be; and men are, that they might have joy.",
            "1 Nephi 3:7 - I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them.",
            "Moroni 10:21 - And except ye have charity ye can in nowise be saved in the kingdom of God; neither can ye be saved in the kingdom of God if ye have not faith; neither can ye if ye have no hope."
        };

        public Scripture() {
            Random random = new Random();
            string selected_Scripture = _scriptureLibrary[random.Next(_scriptureLibrary.Count)];

            var parts = selected_Scripture.Split(" - ");
            string refString = parts[0];
            string text = parts[1];

            _reference = ParseReference(refString);
            _words = text.Split(' ').Select(w => new Word(w)).ToList();
        }

        private Reference ParseReference(string reference_Text) {
            string[] parts = reference_Text.Split(' ');
            string book = parts[0] + (parts.Length > 2 ? " " + parts[1] : "");
            string chapter_Verse = parts.Last();
            string[] chapter_Parts = chapter_Verse.Split(':');

            int chapter = int.Parse(chapter_Parts[0]);
            string[] verse_Parts = chapter_Parts[1].Split('-');
            int start_Verse = int.Parse(verse_Parts[0]);
            if (verse_Parts.Length > 1)
                return new Reference(book, chapter, start_Verse, int.Parse(verse_Parts[1]));
            else
                return new Reference(book, chapter, start_Verse);
        }

        public void Display() {
            Console.WriteLine(_reference.ToString());
            Console.WriteLine();

            foreach (Word word in _words) {
                Console.Write(word.GetDisplayText() + " ");
            }
            Console.WriteLine();
        }

        public void HideWords() {
            _obscurer.HideRandomWords(_words, 3);
        }

        public bool AllWordsHidden() {
            return _words.All(w => w.IsHidden);
        }
    }
}