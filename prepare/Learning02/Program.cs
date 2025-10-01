using System;
class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Learning02 world!");

        // Job 1 Creation (branching from Job.cs):
        Job job1 = new Job();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        // Job 2 Creation (branching from Job.cs): 
        Job job2 = new Job();
        job2._jobTitle = "Manager";
        job2._company = "Apple";
        job2._startYear = 2022;
        job2._endYear = 2023;

        // Adding jobs to Resume (branching from Resume.cs):
        Resume myResume = new Resume();
        myResume._name = "Allison Rose";
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Displaying stored jobs from Resume (branching from Resume.cs):
        myResume.Display();
    }
}
