using System;
using System.Collections.Generic;
using static System.Console;

namespace Factory
{
    // ---------------------------------------

    public interface IHotDrink
    {
        void Consume();
    }

    // we are not delivering Tea to the outside client
    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine("Consuming Tea...");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine("Consuming Coffee...");
        }
    }

    // ---------------------------------------

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Put in a tea bag, boil water, pour {amount}, add lemon, enjoy");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine($"Grind beans, boil water, pour {amount}, add cream and sugar, enjoy");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        private List<Tuple<string, IHotDrinkFactory>> factories = new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory", string.Empty),
                        (IHotDrinkFactory)Activator.CreateInstance(t)
                        ));
                }
            }
        }
        public IHotDrink MakeDrink()
        {
            WriteLine("Available drinks:");
            for (int i = 0; i < factories.Count; i++)
            {
                var tuple = factories[i];
                WriteLine($"{i}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()) != null
                    && int.TryParse(s, out int i)
                    && i >= 0
                    && i < factories.Count)
                {
                    Write("Specify amount: ");
                    s = ReadLine();
                    if (s != null
                        && int.TryParse(s, out int amount)
                        && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }

                WriteLine("Incorrect input, try again!");
            }
        }
    }

    public class Example3_AbstractFactory
    {
        static void Main(string[] args)
        {
            var machine = new HotDrinkMachine();
            while (true)
            {
                var drink = machine.MakeDrink();
                drink.Consume();
                WriteLine("... restarting.");
            }
        }
    }
}




