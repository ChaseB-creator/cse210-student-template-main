namespace MindfulnessApp
{
    class Activity
    {
        protected string _name = "";
        protected string _description = "";
        protected int _duration;
        private static string _logFile = "activity_log.txt";

        public void Start()
        {
            Console.Clear();
            Console.WriteLine($"--- {_name} ---");
            Console.WriteLine(_description);
            Console.Write("\nHow long (in seconds) would you like this activity to last? ");
            string input = Console.ReadLine() ?? "30";
            while (!int.TryParse(input, out _duration) || _duration <= 0)
            {
                Console.Write("Please enter a valid positive number of seconds: ");
                input = Console.ReadLine();
            }

            Console.WriteLine("\nGet ready...");
            ShowSpinner(3);
        }

        public void End()
        {
            Console.WriteLine("\nWell done!");
            ShowSpinner(2);
            Console.WriteLine($"You completed the {_name} for {_duration} seconds!");
            ShowSpinner(3);

            LogActivity();
        }

        protected void ShowSpinner(int seconds)
        {
            string[] spinner = { "|", "/", "-", "\\" };
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            int i = 0;
            while (DateTime.Now < endTime)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(200);
                Console.Write("\b");
                i++;
            }
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        private void LogActivity()
        {
            try
            {
                string entry = $"{DateTime.Now:G} - {_name} for {_duration} seconds";
                File.AppendAllText(_logFile, entry + Environment.NewLine);
            }
            catch
            {
                Console.WriteLine("Could not write to log file.");
            }
        }

        public static void ShowLog()
        {
            Console.Clear();
            Console.WriteLine("--- Activity Log ---");
            Console.WriteLine();

            if (File.Exists(_logFile))
            {
                string[] lines = File.ReadAllLines(_logFile);
                if (lines.Length == 0)
                {
                    Console.WriteLine("No activities logged yet.");
                }
                else
                {
                    foreach (var line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("No log file found yet.");
            }

            Console.WriteLine("\nPress ENTER to return to the menu.");
            Console.ReadLine();
        }
    }
}