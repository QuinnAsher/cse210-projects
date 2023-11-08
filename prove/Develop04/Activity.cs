namespace Develop04;

public class Activity
{
    private string _activityName;
    private string _activityDescription;
    private int _activityDuration;
    private List<int> _assignedIndex1 = new List<int>();  // This list will store unique indices for one type of data.
    private List<int> _assignedIndex2 = new List<int>();  // This list will store unique indices for another type of data.




    protected Activity(string name, string description, int duration)
    {
        _activityName = name;
        _activityDescription = description;
        _activityDuration= duration;
    }


    protected Activity()
    {
        
    }

    public string ActivityNameProperty
    {
        get {return _activityName;}
        set {_activityName = value;}
    }

    public string ActivityDescriptionProperty
    {
        get { return _activityDescription; }
        set { _activityDescription = value;}

    }
    
    public int ActivityDurationProperty
    {
        get {return _activityDuration;}
        set {_activityDuration = value;}

    }

    protected int RunCycle(bool doubleCycle=false )
    {
        int runDuration = _activityDuration / 5;  // Calculate the duration of a cycle 
        if (doubleCycle)
        {
            // TODO: find a way to round this number to the nearest integer
            int totalCycles = runDuration / 2; // Calculate the duration of a cylce / by 2
            return totalCycles;
        }

        return runDuration;
    }

    protected int UniqueIndex(List<string> iterable, bool forType1)
    {
        if (forType1)
        {
            Random random1 = new Random();
            if (_assignedIndex1.Count == iterable.Count)
            {
                _assignedIndex1 = new List<int>();  // clean slate the assigned index when all index have been assigned in a session
            }

            int index1;
            do
            {
                index1 = random1.Next(iterable.Count);
            } while (_assignedIndex1.Contains(index1));
        
            // update the assigned index list with the new assigned index
            _assignedIndex1.Add(index1);

            return index1;
        }
        
        Random random = new Random();
        if (_assignedIndex2.Count == iterable.Count)
        {
            _assignedIndex2 = new List<int>();  // clean slate the assigned index when all index have been assigned in a session
        }

        int index;
        do
        {
            index = random.Next(iterable.Count);
        } while (_assignedIndex2.Contains(index));
        
        // update the assigned index list with the new assigned index
        _assignedIndex2.Add(index);

        return index;
       
    }

    protected void DisplayStartMsg()
    {
        Console.WriteLine($"Welcome to the {_activityName}");
        Console.WriteLine();
        Console.WriteLine(_activityDescription);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
    }
    
   
    protected void DisplaySpinner()
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
        DateTime endTime = startTime.AddSeconds(5);

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


    protected void DisplayCountDown()
    {
        for (int i = 5; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }


    protected void DisplayEndMsg()
    {
        Console.WriteLine("Well done!!");
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_activityDuration} seconds of the {_activityName}");
        DisplaySpinner();
    }
}