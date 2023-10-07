using System;

class Program
{
    static void Main(string[] args)
    {
        Job firstJob = new Job();
        firstJob._companyName = "Microsoft";
        firstJob._jobTitle = "Software Engineer";
        firstJob._startYear = 2015;
        firstJob._endYear = 2022;
        
        firstJob.Display();

        Job secondJob = new Job();
        secondJob._companyName = "nHub";
        secondJob._jobTitle = "Software Instructor";
        secondJob._startYear = 2022;
        secondJob._endYear = 2023;
        
        // resume object
        Resume resume = new Resume();
        resume._Jobs.Add(firstJob);
        resume._Jobs.Add(secondJob);
        resume.Display();
    }
}


class Job
{
    public string _companyName = "";
    public string _jobTitle = "";
    public int _startYear = 0;
    public int _endYear = 0;

    public void Display()
    {
        Console.WriteLine($"{_jobTitle} ({_companyName}) {_startYear}-{_endYear}");
    }
    
}

class Resume
{
    public string _name = "";
    public List<Job> _Jobs = new List<Job>();

    public void Display()
    {
        Console.WriteLine(_name);
        
        // loop through the job list and display them on the console
        foreach (Job job in _Jobs)
        {
            job.Display();
        }
    }
}