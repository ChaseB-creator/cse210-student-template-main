namespace MindfulnessApp
{
    class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>()
        {
            "Who are people that you appreciate?",
            "What are your personal strengths?",
            "Who have you helped recently?"
        };

        public ListingActivity()
        {
            _name = "Listing Activity";
            _description = "This activity helps you focus on gratitude by listing positive things in your life.";
        }

        public void Run()
        {
            Start();
            var random = new Random();

            string prompt = _prompts[random.Next(_prompts.Count)];
            Console.WriteLine($"\nList as many responses as you can to this prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine("\nYou have a few seconds to think...");
            Countdown(5);

            List<string> responses = new List<string>();
            DateTime end = DateTime.Now.AddSeconds(_duration);

            while (DateTime.Now < end)
            {
                Console.Write("> ");
                if (Console.KeyAvailable)
                {
                    string? response = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(response))
                        responses.Add(response);
                }
                else
                {
                    Thread.Sleep(100);
                }
            }

            Console.WriteLine($"\nYou listed {responses.Count} items:");
            foreach (var item in responses)
            {
                Console.WriteLine($"- {item}");
            }

            End();
        }
    }
}