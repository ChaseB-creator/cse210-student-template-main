namespace MindfulnessApp
{
    class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "Think of a time when you helped someone in need.",
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult."
        };

        private List<string> _questions = new List<string>()
        {
            "Why was this experience meaningful to you?",
            "How did you feel afterwards?",
            "What did you learn from this?",
            "How could you apply this lesson again?"
        };

        public ReflectionActivity()
        {
            _name = "Reflection Activity";
            _description = "This activity helps you think deeply about your strengths and past experiences.";
        }

        public void Run()
        {
            Start();
            var random = new Random();

            Console.WriteLine();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine($"--- {_prompts[random.Next(_prompts.Count)]} ---");
            Console.WriteLine("\nWhen you’re ready to reflect, press ENTER.");
            Console.ReadLine();

            DateTime end = DateTime.Now.AddSeconds(_duration);
            while (DateTime.Now < end)
            {
                string question = _questions[random.Next(_questions.Count)];
                Console.WriteLine($"\n{question}");
                ShowSpinner(5);
            }
            End();
        }
    }
}