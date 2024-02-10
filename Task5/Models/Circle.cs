using System.Reflection.Metadata;
using Task5.Models.Abstract;

namespace Task5.Models
{
    public class Circle : Figure
    {
        const double pi = Math.PI;
        public double R {get; set;}
        public double Area { get; private set;}
        public double Perimeter { get; private set; }
        public Circle(double r) 
        {
            R = r;
        }

        public override double GetArea()
        {
            return pi * R * R;
        }

        public override void GetInfo()
        {
            Area = GetArea();
            Perimeter = GetPerimeter();
        }

        public override double GetPerimeter()
        {
            return 2 * pi * R;
        }
    }
}
