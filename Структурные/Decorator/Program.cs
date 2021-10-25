using System;
using System.Collections.Generic;

// Создать объект кофе, все виды кофе может со сливками, с шоколадом, корицей - разная цена

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var americano = new Americano();
            Console.WriteLine(americano.GetCoffeeWithPrice());

            var espresso = new Espresso();
            Console.WriteLine(espresso.GetCoffeeWithPrice());

            var americanoWithMilk = new CoffeeWithMilk(americano);
            Console.WriteLine(americanoWithMilk.GetCoffeeWithPrice());

            var americanoWithMilkWithSugar = new CoffeeWithSugar(americanoWithMilk);
            Console.WriteLine(americanoWithMilkWithSugar.GetCoffeeWithPrice());

            var espressoWithSugar = new CoffeeWithSugar(espresso);
            Console.WriteLine(espressoWithSugar.GetCoffeeWithPrice());

            var espressoWithMilk = new CoffeeWithMilk(espresso);
            Console.WriteLine(espressoWithMilk.GetCoffeeWithPrice());


            Console.ReadLine();
        }
    }

    abstract internal class Coffee
    {
        public Coffee(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual string GetCoffeeWithPrice()
        {
            return $"Кофе {Name}, цена {Price}";
        }
    }

    internal class Americano : Coffee
    {
        public Americano() : base("Американо", 10) { }
    }

    internal class Espresso : Coffee
    {
        public Espresso() : base("Эспрессо", 20) { }
    }

    internal abstract class DecoratedCoffee : Coffee
    {
        protected Coffee coffee;

        public DecoratedCoffee(Coffee coffee, string name, decimal price) : base(name, price)
        {
            this.coffee = coffee;
        }
    }


    internal class CoffeeWithMilk : DecoratedCoffee
    {
        public CoffeeWithMilk(Coffee coffee) : base(coffee, coffee.Name + " со сливками", coffee.Price + 3) { }
    }

    internal class CoffeeWithSugar : DecoratedCoffee
    {
        public CoffeeWithSugar(Coffee coffee) : base(coffee, coffee.Name + " с сахаром", coffee.Price + 1) { }
    }


}
