namespace Learning05;

public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        ColorProperty = color;
        _radius = radius;
    }

    public override double GetArea()
    {
        double circleArea = Math.Round(Math.PI * Math.Pow(_radius, 2), 2);
        return circleArea;
    }
}