using System;
using System.Collections.Generic;

namespace JournalApp
{
    public class PromptGenerator
    {
        private List<string> _prompts = new List<string>() {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What is something new I learned today?",
            "What made me laugh or smile today?",
            "What is one thing I am grateful for today?"
        };

        private Random _rand = new Random();

        public string GetRandomPrompt() {
            int index = _rand.Next(_prompts.Count);
            return _prompts[index];
        }
    }
}
