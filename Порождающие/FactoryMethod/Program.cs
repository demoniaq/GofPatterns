using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            BrickDeveloper brickDeveloper = new();
            WoodDeveloper woodDeveloper = new();

            House house1 = brickDeveloper.Create();
            House house2 = woodDeveloper.Create();
            House house3 = woodDeveloper.Create();

            Console.WriteLine(house1.Name);
            Console.WriteLine(house2.Name);
            Console.WriteLine(house3.Name);
        }
    }

    internal abstract class House
    {
        public string Name { get; set; }


    }

    internal class BrickHouse : House
    {
        public BrickHouse()
        {
            Name = "Кирпичный дом";
        }
    }

    internal class WoodHouse : House
    {
        public WoodHouse()
        {
            Name = "Деревянный дом";
        }
    }

    internal abstract class Developer
    {
        public abstract House Create();
    }

    internal class BrickDeveloper : Developer
    {
        public override House Create()
        {
            return new BrickHouse();
        }
    }

    internal class WoodDeveloper : Developer
    {
        public override House Create()
        {
            return new WoodHouse();
        }
    }

}
