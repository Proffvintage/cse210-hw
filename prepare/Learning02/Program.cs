using System;

class Program
{
    public class Job 
    {
        public string _company;
        public string _jobTitle;
        public int _endYear;
        public int _startYear;
        public void Display()
    {
         Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }
    }

    public class Resume
    {
        public string _name;
        public List<Job> _jobs = new List<Job>();
        public void Display()
        {
            Console.WriteLine(_name);
            Console.WriteLine("Jobs: ");

            foreach (Job item in _jobs)
        {
            item.Display();
        }
    }
    }

    
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._endYear = 2022;
        job1._startYear = 2018;

        Job job2 = new Job();
        job2._company = "Brooks Painting";
        job2._jobTitle = "Painter";
        job2._endYear = 2024;
        job2._startYear = 2022;

        Resume resume1 = new Resume();
        resume1._name = "Jacob Lamb";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.Display();

    }
}
