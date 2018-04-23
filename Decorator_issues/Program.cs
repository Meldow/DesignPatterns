using System;
using System.Collections.Generic;

namespace Decorator_issues
{
    class Program
    {
        static void Main(string[] args)
        {
            var beverageLst = new List<Beverage>();

            beverageLst.Add(new HouseBlend());
            beverageLst.Add(new HouseBlend() { Milk = true });
            beverageLst.Add(new HouseBlend() { Soy = true, Mocha = true });
            beverageLst.Add(new HouseBlend() { Milk = true, Whip = true });
            beverageLst.Add(new DarkRoast() { Whip = true });
            beverageLst.Add(new Decaf());

            foreach (var beverage in beverageLst)
            {
                var extras = string.Empty;
                if (beverage.Milk) extras += " +Milk";
                if (beverage.Soy) extras += " +Soy";
                if (beverage.Mocha) extras += " +Mocha";
                if (beverage.Whip) extras += " +Whip";
                Console.WriteLine("Order :: {0} :: {1} :: {2}", beverage.Description, extras, beverage.Cost());
            }
        }


        /*
         * Sample output
         * 
         * Order :: House Blend finest! ::  :: 10
         * Order :: House Blend finest! ::  +Milk :: 11
         * Order :: House Blend finest! ::  +Soy +Mocha :: 14,5
         * Order :: House Blend finest! ::  +Milk +Whip :: 11,5
         * Order :: Dark roast something ::  +Whip :: 20,5
         * Order :: A coffee for who can't have caffeine! ::  :: 5
         */

        public abstract class Beverage
        {
            public abstract string Description { get; }
            public bool Milk { get; set; }
            public bool Soy { get; set; }
            public bool Mocha { get; set; }
            public bool Whip { get; set; }

            public virtual float Cost()
            {
                var cost = 0.0f;
                if (Milk) cost += 1;
                if (Soy) cost += 2;
                if (Mocha) cost += 2.5f;
                if (Whip) cost += 0.5f;
                return cost;
            }
        }

        public class HouseBlend : Beverage
        {
            public override string Description => "House Blend finest!";

            public override float Cost()
            {
                return base.Cost() + 10f;
            }
        }

        public class DarkRoast : Beverage
        {
            public override string Description => "Dark roast something";

            public override float Cost()
            {
                return base.Cost() + 20f;
            }
        }

        public class Decaf : Beverage
        {
            public override string Description => "A coffee for who can't have caffeine!";

            public override float Cost()
            {
                return base.Cost() + 5f;
            }
        }
    }
}
