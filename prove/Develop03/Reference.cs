namespace Script_Memorizor {
    public class Reference {
        public string Book { get; private set; }
        public int Chapter { get; private set; }
        public int start_Verse { get; private set; }
        public int? end_Verse { get; private set; }

        public Reference(string book, int chapter, int verse) {
            Book = book;
            Chapter = chapter;
            start_Verse = verse;
        }

        public Reference(string book, int chapter, int startVerse, int endVerse) {
            Book = book;
            Chapter = chapter;
            start_Verse = startVerse;
            end_Verse = endVerse;
        }

        public override string ToString() {
            return end_Verse.HasValue
                ? $"{Book} {Chapter}:{start_Verse}-{end_Verse}"
                : $"{Book} {Chapter}:{start_Verse}";
        }
    }
}