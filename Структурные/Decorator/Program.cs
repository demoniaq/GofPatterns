using System;
using System.Collections.Generic;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza1 = new ItalianPizza(); // итальянская пицца
            Console.WriteLine("Название: {0}", pizza1.Name);
            Console.WriteLine("Цена: {0}", pizza1.GetCost());

            Pizza pizza2 = new ItalianPizza();
            pizza2 = new TomatoPizza(pizza2); // итальянская пицца с томатами
            Console.WriteLine("Название: {0}", pizza2.Name);
            Console.WriteLine("Цена: {0}", pizza2.GetCost());

            Pizza pizza3 = new ItalianPizza();
            pizza3 = new CheesePizza(pizza3);// итальянская пиццы с сыром
            Console.WriteLine("Название: {0}", pizza3.Name);
            Console.WriteLine("Цена: {0}", pizza3.GetCost());

            Pizza pizza4 = new BulgerianPizza();
            pizza4 = new TomatoPizza(pizza4);
            pizza4 = new CheesePizza(pizza4);// болгарская пиццы с томатами и сыром
            Console.WriteLine("Название: {0}", pizza4.Name);
            Console.WriteLine("Цена: {0}", pizza4.GetCost());

            Console.ReadLine();
        }
    }

    abstract class Pizza
    {
        public string Name { get; protected set; }

        public Pizza(string name)
        {
            this.Name = name;
        }

        public abstract int GetCost();
    }

    class ItalianPizza : Pizza
    {
        public ItalianPizza() : base("Итальянская пицца") { }

        public override int GetCost()
        {
            return 10;
        }
    }
    class BulgerianPizza : Pizza
    {
        public BulgerianPizza() : base("Болгарская пицца") { }

        public override int GetCost()
        {
            return 8;
        }
    }

    abstract class PizzaDecorator : Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(string name, Pizza pizza) : base(name)
        {
            this.pizza = pizza;
        }
    }

    class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza pizza) : base(pizza.Name + ", с томатами", pizza) { }

        public override int GetCost()
        {
            return pizza.GetCost() + 3;
        }
    }

    class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza pizza) : base(pizza.Name + ", с сыром", pizza) { }

        public override int GetCost()
        {
            return pizza.GetCost() + 5;
        }
    }

}
