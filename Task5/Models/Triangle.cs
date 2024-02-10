using System.Reflection.Metadata;
using Task5.Models.Abstract;

namespace Task5.Models
{
    public class Triangle : Figure
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double Area { get; private set; }
        public double Perimeter { get; private set; }

        public Triangle(double a, double b, double c) 
        {
            A = a;
            B = b;  
            C = c;
        }
        public override double GetArea()
        {
            double p = (A + B + C) / 2;
            double area = Math.Sqrt(p * (p - A) * (p - B) * (p - C));
            return area;
        }

        public override void GetInfo()
        {
            Area = GetArea();
            Perimeter = GetPerimeter();
        }

        public override double GetPerimeter()
        {
            return A + B + C;
        }
    }
}
