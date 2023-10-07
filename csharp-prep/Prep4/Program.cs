using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        // create a list object
        List<int> numberSeries = new List<int>();
        
        // ask the user for input for a series of number
        Console.WriteLine("Enter a series of numbers. Enter 0 to exit");
        
        
        // use a while loop to ask the user for a number til they enter 0
        while (true)
        {
            string userInput = Console.ReadLine();
            int userInputInt = int.Parse(userInput);
            
            // add the user inputs to the number series list
            if (userInputInt != 0) // making sure that 0 is not added
            {
                numberSeries.Add(userInputInt);
            }
            
            // if the user enters 0 exit the loop
            if (userInputInt == 0)
            {
                break;  // to exit the loop
            }
        }
        
        // calculate the sum of the user input from the number series list
        int sum = 0;
        foreach (int number in numberSeries)
        {
            sum += number;
        }
        
        // display the sum to the user
        Console.WriteLine($"The sum of your input is {sum}");
        
        // calculate the average of the user inputs
        int lengthOfNumberSeries = numberSeries.Count;

        double average = (double)sum / lengthOfNumberSeries;
        
        // display the average result to the user
        Console.WriteLine($"The average of your inputs is {average}");
        
        // calculate the maximum number from user input
        int maxNum = 0;

        foreach (int number in numberSeries)
        {
            if (number > maxNum)
            {
                maxNum = number;
            }
        }
        
        // display the max number to the user
        Console.WriteLine($"The maximum number from your input is {maxNum}");
        
        // calculate the smallest positive number
        int leastPositiveNumber = numberSeries[0];

        foreach (int number in numberSeries)
        {
            if (number < leastPositiveNumber & number >= 0)
            {
                leastPositiveNumber = number;
            }
        }
        
        // display the least positive integer
    
        Console.WriteLine($"The least positive integer is {leastPositiveNumber}");

        List<int> sortedNumberSeries = new List<int>();
        // sort the list
        numberSeries.Sort();
        
        // display the sorted number series
        foreach (int number in numberSeries)
        {
            Console.WriteLine(number);
        }
    }
}