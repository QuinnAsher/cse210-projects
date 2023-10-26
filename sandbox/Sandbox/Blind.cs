// namespace sandbox;
//
//
// public class Program
// {
//     static void Main(string[] args)
//     {
//         Blind kitchen = new Blind();
//
//         kitchen._height = 50;
//         kitchen._width = 50;
//         // Console.WriteLine(kitchen.GetArea());
//
//         House johnsonHome = new House();
//         johnsonHome._blind.Add(kitchen);
//         double amount = johnsonHome._blind[0].GetArea();
//         Console.WriteLine(amount);
//     }
// }
//
//
// public class Blind
// {
//     public double _width;
//     public double _height;
//     public string _color;
//
//     public double GetArea()
//     {
//         return _width * _height;
//     }
//     
//    
// }
//
// public class House
// {
//     public string _owner;
//     public List<Blind> _blind = new List<Blind>();
// }