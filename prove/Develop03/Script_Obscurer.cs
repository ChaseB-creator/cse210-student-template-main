
namespace Script_Memorizor {
    public class Script_Obscurer {
        private Random _random = new Random();

        public void HideRandomWords(List<Word> words, int countToHide) {
            var visible_Words = words.Where(w => !w.IsHidden).ToList();

            if (visible_Words.Count == 0)
                return;

            for (int i = 0; i < countToHide && visible_Words.Count > 0; i++) {
                int index = _random.Next(visible_Words.Count);
                visible_Words[index].Hide();
                visible_Words.RemoveAt(index);
            }
        }
    }
}
