public class Program
{
    static void Main(string[] args)
    {
        FractionCalculator fraction1 = new();
        Console.WriteLine($"{fraction1.GetFractionString()}\n{fraction1.GetDecimalValue()}");
        Console.WriteLine();

        FractionCalculator fraction2 = new(3);
        Console.WriteLine($"{fraction2.GetFractionString()}\n{fraction2.GetDecimalValue()}");
        Console.WriteLine();

        FractionCalculator fraction3 = new(6, 3);
        Console.WriteLine($"{fraction3.GetFractionString()}\n{fraction3.GetDecimalValue()}");
        
}
    
    public class FractionCalculator
    {
        private int _top;
        private int _bottom;

        public FractionCalculator()
        {
            // default value
            _top = 1;
            _bottom = 1;
        }

        public FractionCalculator(int wholeNumber)
        {
            _bottom = 1;
        }

        public FractionCalculator(int topNum, int bottomNum)
        {
            _top = topNum;
            _bottom = bottomNum;
        }


        public int GetTop()
        {
            return _top;
        }


        public void SetTop(int top)
        {
            _top = top;
        }


        public int GetBottom()
        {
            return _bottom;
        }


        public void SetBottom(int bottom)
        {
            _bottom = bottom;
        }


        public string GetFractionString()
        {
            return $"{_top} / {_bottom}";
        }


        public double GetDecimalValue()
        {
            double calculateDec = (double) _top / _bottom;
            return calculateDec;
        }
    }
}