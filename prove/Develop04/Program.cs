using System;
using Develop04;

class Program
{
    static void Main(string[] args)
    {
        Activity activity = new Activity("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus in you breathing", 10);
        // activity.StartMsg();
        

        activity.PauseForSpinner();
    }
    
    
}