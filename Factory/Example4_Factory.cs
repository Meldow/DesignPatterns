using System;

namespace Factory
{
    // A component responsible solely for the wholesale (not piecewise) creation of objects
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
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }

        public static class Factory
        {
            public static Point NewCartesianPoint(double x, double y)
            {
                return new Point(x, y);
            }

            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }

        //Extra
        public static Point Origin => new Point(0, 0);  //property, always executed, always new object
        public static Point Origin2 = new Point(0, 0); //field that gets initialized once, singleton
    }



    public class Example4_Factory
    {
        //static void Main(string[] args)
        //{
        //    //var p = new Point(0, 0);    // this must not be possible

        //    var point = Point.Factory.NewPolarPoint(1.0, Math.PI / 2);
        //    Console.WriteLine(point);

        //    var p1 = Point.Origin;
        //    var p2 = Point.Origin2;
        //}
    }
}




