namespace Develop04;

public class BreathingActivity : Activity
{

    public BreathingActivity(string name, string description, int duration) : base(name, description, duration)
    {
        ActivityNameProperty = name;
        ActivityDescriptionProperty = description;
        ActivityDurationProperty = duration;
    }

    public BreathingActivity()
    {
        ActivityNameProperty = "Breathing Activity";
        ActivityDescriptionProperty =
            "This activity will help you relax by walking you through breathing in and out slowly. clear your mind and focus on your breathing";
        ActivityDurationProperty = 20;
    }
    
  public void RunActivity()
    {
        Console.WriteLine();
        Console.Clear();
        DisplayStartMsg();

        string durationStr = Console.ReadLine();
        int durationInt = int.Parse(durationStr);

        ActivityDurationProperty = durationInt;
        Console.WriteLine();
        Console.WriteLine("Get ready....");
        DisplaySpinner();
        Console.WriteLine();
        
        for (int i = 0; CalculateRunCycle() > i; i++)
        {
            Console.Write("Breathe in....");
            DisplayCountDown();
            Console.WriteLine();
            
            Console.Write("Breathe out....");
            DisplayCountDown();
            Console.WriteLine();
            Console.WriteLine();
        }
        
        DisplayEndMsg();
    }
 
}
