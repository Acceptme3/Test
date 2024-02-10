using Task5.Models.Abstract;

namespace Task5.Models
{
    public class Rectangle : Figure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double Area { get; private set; }
        public double Perimeter { get; private set; }
        public Rectangle(double a, double b) 
        {
            A = a;
            B = b;
            Area = 0;
            Perimeter = 0;
        }
        public override double GetArea()
        {
            return A * B;
        }

        public override void GetInfo()
        {          
            Area = GetArea();
            Perimeter = GetPerimeter();
        }

        public override double GetPerimeter()
        {
            return (A + B) * 2;
        }
    }
}
