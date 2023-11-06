namespace Develop04;

public class ReflectiveActivity : Activity
{
    private List<string> _promptList;
    private List<string> _questions;

    public ReflectiveActivity(string name, string description, int duration) :
        base(name, description, duration)
    {
        ActivityNameProperty = name;
        ActivityDescriptionProperty = description;
        ActivityDurationProperty = duration;

        _questions = new List<string>();
        _promptList = new List<string>();
        AddPrompts();
        AddQuestions();
    }
    
    public ReflectiveActivity()
    {
        ActivityNameProperty = "Reflection Activity";
        ActivityDescriptionProperty = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will hlp you " +
                                      "recognize the power you have and how you can use it in other aspects of your life.";
        ActivityDurationProperty = 40;
        
        _questions = new List<string>();
        _promptList = new List<string>();
        AddPrompts();
        AddQuestions();

    }


    private void AddPrompts()
    {
        _promptList.Add("Think of a time when you stood up for someone.");
        _promptList.Add("Think of a time when you did something really difficult.");
        _promptList.Add("Think of a time when you helped someone in need.");
        _promptList.Add("Think of a time when you did something truly selfless.");
    }

    private void AddQuestions()
    {
        _questions.Add("Why was this experience meaningful to you?"); 
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What was your favorite thing about the experience?");
        _questions.Add("What did you learn about yourself through this experience?");
    }


    private string GetPrompt()
    {
        string prompt = $"----- {_promptList[UniqueIndex(_promptList, true)]} -----";
        return prompt;
    }

    //TODO: understand why when you stored both prompt and question in one variable, you don't get uniques questions anymore 
    private string GetQuestion()
    {
        string question = $"> {_questions[UniqueIndex(_questions, false)]}";
        return question;
    }
    public void RunActivity()
    {
        DisplayStartMsg();
        Console.WriteLine("Get ready...");
        DisplaySpinner();
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine();


        for (var i = 0; i < 4; i++)
        {
            Console.WriteLine(GetPrompt());
            Console.WriteLine(GetQuestion());
        }
    }
    
    
}   