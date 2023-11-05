namespace Develop04;

public class ReflectiveActivity : Activity
{
    private List<string> _promptList;
    private List<string> _questions;

    ReflectiveActivity(string name, string description, int duration) :
        base(name, description, duration)
    {
        ActivityNameProperty = name;
        ActivityDescriptionProperty = description;
        ActivityDurationProperty = duration;
        AddPrompts();
        AddQuestions();
    }
    
    ReflectiveActivity()
    {
        ActivityNameProperty = "Reflection Activity";
        ActivityDescriptionProperty = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will hlp you " +
                                      "recognize the power you have and how you can use it in other aspects of your life.";
        ActivityDurationProperty = 40;
        AddPrompts();
        AddQuestions();

    }


    private List<string> AddPrompts()
    {
        _promptList.Add("Think of a time when you stood up for someone.");
        _promptList.Add("Think of a time when you did something really difficult.");
        _promptList.Add("Think of a time when you helped someone in need.");
        _promptList.Add("Think of a time when you did something truly selfless.");
        
        return _promptList;
    }

    private List<string> AddQuestions()
    {
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anyting like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What was your favorite thing about the experience?");
        _questions.Add("What did you learn about yourself through this experience?");

        return _questions;
    }
}   