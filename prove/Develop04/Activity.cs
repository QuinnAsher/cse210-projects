namespace Develop04;

public class Activity
{
    private string _activiyName;
    private string _activityDescription;
    private int _activityDuration;


    public Activity(string name, string description, int duration)
    {
        _activiyName = name;
        _activityDescription = description;
        _activityDuration = duration;
    }


    public string GetActivityName
    {
        get
        {
            return _activiyName;
        }
    }

    public string GetActivityDescription
    {
        get
        {
            return _activityDescription;
        }
    }

    public int GetActivityDuration
    {
        get
        {
            return _activityDuration;
        }
    }


    public void StartMsg()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activiyName}");
        Console.WriteLine();
        Console.WriteLine(_activityDescription);
        Console.WriteLine();
        Console.WriteLine("How long, in seconds, would you like for your session?");
    }

    public void PauseForSpinner()
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("-");
        animationStrings.Add("\\");
        
        
        DateTime currentDateTime = DateTime.Now;
        DateTime futureDatetime = currentDateTime.AddSeconds(_activityDuration);

        // int countDown = 

        foreach (string animation in animationStrings)
        {
            Console.Write(animation);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

    }
}