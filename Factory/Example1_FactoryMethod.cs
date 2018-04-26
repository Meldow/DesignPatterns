using System;

namespace Factory.Example1
{
    public class Point
    {
        private double x, y;

        // factory method
        public static Point NewCartesianPoint(double x, double y)
        {
            return new Point(x, y);
        }

        // factory method
        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"x: {x} | y: {y}";
        }
    }


    class Example1_FactoryMethod
    {
        //static void Main(string[] args)
        //{
        //    Point p = Point.NewPolarPoint(1.0, Math.PI / 2);
        //    Console.WriteLine(p);
        //}
    }
}
