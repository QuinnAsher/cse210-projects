using Learning05;


class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        
        shapes.Add(new Square("red", 20));
        shapes.Add(new Rectangle("green", 30, 15));
        shapes.Add(new Circle("blue", 12));

        foreach (Shape shape in shapes)
        {
            // Console.WriteLine(shape.GetArea());
            // Console.WriteLine(shape.ColorProperty);
            Console.WriteLine();
            string color = shape.ColorProperty;
            double area = shape.GetArea();
            Console.WriteLine($"The {color} shape has an area of {area}");
        }

    }
}
// class Program
// {
//     static void Main(string[] args)
//     {
//         // create a list of Employees
//         List<Employee> employees = new List<Employee>(); 
//         
//         // create different kinds of employees and add them to the same list
//         employees.Add(new Employee());
//         employees.Add(new HourlyEmployee());
//         
//         // get a custom calculation for each one
//         foreach (Employee employee in employees)
//         {
//             float pay = employee.CalculatePay();
//             Console.WriteLine(pay);
//         }
//     }
// }
//
//
// // a parent class
// public class Employee
// {
//     private float salary = 100f;
//
//     public virtual float CalculatePay()
//     {
//         return salary;
//     }
// }
//
// // a child class
// public class HourlyEmployee : Employee
// {
//     private float rate = 9f;
//     private float hours = 100f;
//
//     public override float CalculatePay()
//     {
//         return rate * hours;
//     }
// }
//
// // the parent class showing the 'virtual" keyword included
// public abstract class AbstractEmployee
// {
//     private string _employeeName;
//
//     public abstract float CalculatePay();
// }
//
// // a child class
// public class SalaryEmployee : AbstractEmployee
// {
//     private float salary = 100f;
//
//     public override float CalculatePay()
//     {
//         return salary;
//     }
// }
//
// public class HourlyEmployeee : AbstractEmployee
// {
//     private float rate = 9f;
//     private float hours = 100f;
//
//     public override float CalculatePay()
//     {
//         return rate * hours;
//     }
// }