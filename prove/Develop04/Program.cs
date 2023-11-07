using System;
using Develop04;

class Program
{
    static void Main(string[] args)
    {
        // Activity activity = new Activity("Breathing Activity", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus in you breathing", 10);
        


        // BreathingActivity breathing = new BreathingActivity();
        // breathing.RunActivity();

        ReflectiveActivity reflectiveActivity = new();
        // reflectiveActivity.RunActivity();

        Menu menu = new Menu();
        menu.RunMenu();
        ListingActivity listingActivity = new ListingActivity();
        // listingActivity.RunActivity();
    }
}