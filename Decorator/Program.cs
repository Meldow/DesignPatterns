using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Beverage beverage = new HouseBlend();
            Console.WriteLine(beverage.ToString());

            // dark roast with double mocha and whip
            Beverage beverage2 = new DarkRoast();
            beverage2 = new Mocha(beverage2);
            beverage2 = new Mocha(beverage2);
            beverage2 = new Milk(beverage2);
            Console.WriteLine(beverage2.ToString());

            // espresso with milk
            Beverage beverage3 = new Espresso();
            beverage3 = new Milk(beverage3);
            Console.WriteLine(beverage3.ToString());
        }

        // Beverages
        public abstract class Beverage
        {
            protected string description;

            public abstract string getDescription();
            public abstract float cost();
            public override string ToString()
            {
                return getDescription() + " $" + cost();
            }
        }

        public class HouseBlend : Beverage
        {
            public override float cost() { return .89f; }
            public override string getDescription() { return "House Blend"; }
        }

        public class DarkRoast : Beverage
        {
            public override float cost() { return .99f; }
            public override string getDescription() { return "Dark Roast"; }
        }

        public class Decaf : Beverage
        {
            public override float cost() { return 1.05f; }
            public override string getDescription() { return "Decaf"; }
        }

        public class Espresso : Beverage
        {
            public override float cost() { return 1.99f; }
            public override string getDescription() { return "Espresso"; }
        }

        // Decorators
        public abstract class CondimentDecorator : Beverage { }

        public class Milk : CondimentDecorator
        {
            Beverage beverage;

            public Milk(Beverage beverage)
            {
                this.beverage = beverage;
            }

            public override float cost() { return beverage.cost() + 0.1f; }
            public override string getDescription() { return beverage.getDescription() + ", milk"; }
        }

        public class Mocha : CondimentDecorator
        {
            Beverage beverage;

            public Mocha(Beverage beverage)
            {
                this.beverage = beverage;
            }

            public override float cost() { return beverage.cost() + 0.20f; }
            public override string getDescription() { return beverage.getDescription() + ", mocha"; }
        }
    }
}
