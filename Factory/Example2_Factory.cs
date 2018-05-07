using System;

namespace Factory.Example2
{
    public class Point
    {
        private double x, y;

        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"{nameof(x)}: {x} | {nameof(y)}: {y}";
        }


        public static Point Origin = new Point(0, 0);

        // inner class of point so it can access private Point constructor
        public static class Factory
        {
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
        }
    }


    class Example2_FactoryMethod
    {
        //static void Main(string[] args)
        //{
        //    Point p = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
        //    Console.WriteLine(p);
        //}
    }
}
