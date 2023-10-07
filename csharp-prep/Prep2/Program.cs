using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your score");
        string studentScoreStr = Console.ReadLine();
        int studentScoreInt = int.Parse(studentScoreStr);
        string gradeLetter = "";
        // check the score to get the student grade
        
        // A grade
        if (studentScoreInt >= 97)
        {
            gradeLetter = "A+";
        }
        
        else if (studentScoreInt >= 93)
        {
            gradeLetter = "A-";
        }
        
        else if (studentScoreInt >= 90)
        {
            gradeLetter = "A";
        }
        
        // B grade
        else if (studentScoreInt >= 87)
        {
            gradeLetter = "B+";
        }
        
        else if (studentScoreInt >= 83)
        {
            gradeLetter = "B-";
        }
        
        else if (studentScoreInt >= 80)
        {
            gradeLetter = "B";
        }
        
        // C grade
        else if (studentScoreInt >= 77)
        {
            gradeLetter = "C+";
        }
        
        else if (studentScoreInt >= 73)
        {
            gradeLetter = "C-";
        }
        
        else if (studentScoreInt >= 70)
        {
            gradeLetter = "C";
        }
        
        // D grade
        else if (studentScoreInt >= 67)
        {
            gradeLetter = "D+";
        }
        
        else if (studentScoreInt >= 63)
        {
            gradeLetter = "D-";
        }
        
        else if (studentScoreInt > 60)
        {
            gradeLetter = "D";
        }
        
        // F grade
        else
        {
            gradeLetter = "F";
        }
        
        // display result
        Console.Write($"Your grade is: {gradeLetter}");
    }
}