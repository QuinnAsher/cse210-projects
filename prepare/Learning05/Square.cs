namespace Learning05;

public class Square : Shape
{
    private double _side;

    public Square(string color, double side) : base(color)
    {
        _side = side;
        ColorProperty = color;
    }

    public override double GetArea()
    {
        double squareArea = Math.Pow(_side, 2);
        return squareArea;
    }
}