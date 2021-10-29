using System;
using System.Collections;
using System.Collections.Generic;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Пример с кофе без интерфейсов
            // Создать объект кофе, все виды кофе может со сливками, с шоколадом, корицей - разная цена
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
            #endregion Пример с кофе без интерфейсов

            #region Пример с IList
            // Создать List, с переопределенным методом добавления

            OddIntList list1 = new(new List<int>());

            list1.Add(1);
            list1.Add(3);
            list1.Add(5);
            list1.Add(7);
            list1.Add(9);

            foreach (var item in list1)
            {
                Console.WriteLine(item);
            }

            #endregion Пример с IList

            Console.ReadLine();
        }
    }

    #region Классы для кофе
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
    #endregion Классы для кофе


    #region Классы для IList
    public class OddIntList : IList<int>
    {
        public IList<int> List { get; set; }

        public OddIntList(IList<int> list)
        {
            List = list;
        }

        public int this[int index] { get => List[index]; set => List[index] = value; }

        public int Count => List.Count;

        public bool IsReadOnly => List.IsReadOnly;

        public void Add(int item)
        {
            if (item % 2 == 0)
            {
                throw new ArgumentException($"Число {item} должно быть нечетным!");
            }
            else
            {
                List.Add(item);
            }
        }

        public void Clear() => List.Clear();

        public bool Contains(int item) => List.Contains(item);

        public void CopyTo(int[] array, int arrayIndex) => List.CopyTo(array, arrayIndex);

        public int IndexOf(int item) => List.IndexOf(item);

        public void Insert(int index, int item) => List.Insert(index, item);

        public bool Remove(int item) => List.Remove(item);

        public void RemoveAt(int index) => List.RemoveAt(index);

        IEnumerator IEnumerable.GetEnumerator() => List.GetEnumerator();

        public IEnumerator<int> GetEnumerator() => List.GetEnumerator();
    }
    #endregion Классы для IList

}
