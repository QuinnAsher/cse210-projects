// using System.Buffers.Text;
//
// class Program
// {
//     static void Main(string[] args)
//     {
//         // The student instance automatically has the GetName() method
//         Student student = new Student("Brigham", "234");
//         string name = student.GetName();
//         string number = student.GetNumber();
//         Console.WriteLine(name);
//         Console.WriteLine(number);
//     }
// }
//
// public class Person
// {
//     private string _name;
//
//     public Person(string name)
//     {
//         _name = name;
//     }
//     public string GetName()
//     {
//         return _name;
//     }
// }
//
// // a class that inherits from the Person
// public class Student : Person
// {
//     private string _number;
//     
//     // Calling the parent constructor using "base"
//     public Student(string name, string number) : base(name)
//     {
//         _number = number;
//     }
//     public string GetNumber()
//     { return _number;
//     }
// }


namespace Learning04;

public class Program
{
    static void Main(string[] args)
    {
        MathAssignment mathAssignment = new MathAssignment("Divine Paul", "Matrix",
            "7.3", "8-19");
        
        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());

        WritingAssignment writingAssignment =
            new WritingAssignment("Divine Paul", "European History", "The Causes of World WAR II");
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GEtWritingInformation());
        Console.WriteLine();
    }
}