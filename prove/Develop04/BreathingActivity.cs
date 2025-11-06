namespace MindfulnessApp
{
    class BreathingActivity : Activity
    {
        public BreathingActivity()
        {
            _name = "Breathing Activity";
            _description = "This activity helps you relax by guiding your breathing. Focus on slow, deep breaths.";
        }

        public void Run()
        {
            Start();
            DateTime end = DateTime.Now.AddSeconds(_duration);

            while (DateTime.Now < end)
            {
                Console.Write("\nBreathe in... ");
                Countdown(4);
                Console.Write("\nNow breathe out... ");
                Countdown(6);
                Console.WriteLine();
            }

            End();
        }
    }
}