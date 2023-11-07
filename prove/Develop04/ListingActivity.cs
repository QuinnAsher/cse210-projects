namespace Develop04;

public class ListingActivity : Activity
{
    private List<string> _promptList;
    private List<string> _userEntries;

    public ListingActivity()
    {
        ActivityNameProperty = "Listening Activity";
        ActivityDescriptionProperty = "This activity will help you reflect on the good things in your life by having " +
                                      "you list as many things as you can in a certain area.";
        ActivityDurationProperty = 30;

        _promptList = new List<string>();
        _userEntries = new List<string>();
        
        // call the add method
        AddPrompt();
    }

    public ListingActivity(string name, string description, int duration) : base(name, description, duration)
    {
        ActivityNameProperty = name;
        ActivityDescriptionProperty = description;
        ActivityDurationProperty = duration;

        _promptList = new List<string>();
        _userEntries = new List<string>();
        
        AddPrompt();
    }


    private void AddPrompt()
    {
        _promptList.Add("Who are people that you appreciate?");
        _promptList.Add("What are personal strengths of yours?");
        _promptList.Add("Who are people that you have helped this week?");
        _promptList.Add("When have you felt the Holy Ghost this month?");
        _promptList.Add("Who are some of your personal heroes?");
    }

    private string GetPrompt()
    {
        string prompt = $"----{_promptList[UniqueIndex(_promptList, true)]}----";
        return prompt;
    }

    public void RunActivity()
    {
        DisplayStartMsg();
        
        string durationStr = Console.ReadLine();
        int durationInt = int.Parse(durationStr);
        ActivityDurationProperty = durationInt;
        
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        DisplaySpinner();
        Console.WriteLine();
        Console.Clear();
        
        for (int i = 0; i < RunCycle(); i ++)
        {
            
        }

        
        Console.WriteLine("List as many responses you can to the following prompt");
        GetPrompt();
        Console.Write("You may begin in:");
        DisplayCountDown();
        Console.WriteLine();
        
        int runCycle = RunCycle();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(durationInt);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string userResponse = Console.ReadLine();
            _userEntries.Add(userResponse);
        }

    }
}