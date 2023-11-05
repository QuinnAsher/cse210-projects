namespace Develop04;

public class Activity
{
    private string _activiyName;
    private string _activityDescription;
    private int _activityDuration;
    List<int> _assignedIndex = new List<int>();  // this list will only store unique index in a session



    public Activity(string name, string description, int duration)
    {
        _activiyName = name;
        _activityDescription = description;
        _activityDuration= duration;
    }


    public Activity()
    {
        
    }

    public string ActivityNameProperty
    {
        get
        {
            return _activiyName;
        }

        set
        {
            _activiyName = value;
        }
    }

    public string ActivityDescriptionProperty
    {
        get
        {
            return _activityDescription;
        }

        set
        {
            _activityDescription = value;
        }
    }
    
    public int ActivityDurationProperty
    {
        get
        {
            return _activityDuration;
        }

        set
        {
            _activityDuration = value;
        }
    }


    public void DisplayStartMsg()
    {
        Console.WriteLine($"Welcome to the {_activiyName}");
        Console.WriteLine();
        Console.WriteLine(_activityDescription);
        Console.WriteLine();
        Console.WriteLine("How long, in seconds, would you like for your session?");
    }

    protected int CalculateRunCycle()
    {
        int breathInAndOutDuration = _activityDuration / 5;  // Calculate the duration for one breath in and out
        int totalCycles = breathInAndOutDuration / 2; // Calculate the total cycles needed
        return totalCycles;
    }

    public int UniqueIndex(List<string> iterable)
    {
        Random random = new Random();
        if (_assignedIndex.Count == iterable.Count)
        {
            _assignedIndex = new List<int>();  // clean slate the assigned index when all index have been assigned in a sessin
        }

        int index;
        do
        {
            index = random.Next(iterable.Count);
        } while (_assignedIndex.Contains(index));
        
        // update the assigned index list with the new assigned index
        _assignedIndex.Add(index);

        return index;
    }


    public void DisplaySpinner()
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
        
        
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(3);

        int index = 0;
        while (DateTime.Now < endTime)
        {
            Console.Write(animationStrings[index]);
            Thread.Sleep(200);
            Console.Write("\b \b");

            index++; // update the index by 1 in each iteration
            
            // make sure that index never goes above the len of the list
            if (index == animationStrings.Count)
            {
                index = 0;
            }
        }
    }


    public void DisplayCountDown()
    {
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }


    public void DisplayEndMsg()
    {   DisplaySpinner();
        Console.WriteLine("Well done!");
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_activityDuration} seconds of the {_activiyName}");
    }
}