using System;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Singleton singleton1 = Singleton.GetInstance();
            Console.WriteLine(singleton1.Name);

            Singleton singleton2 = Singleton.GetInstance();
            Console.WriteLine(singleton2.Name);
        }
    }

    public class Singleton
    {
        private static readonly Lazy<Singleton> lazy = new Lazy<Singleton>(() => new Singleton());

        public string Name { get; private set; }

        private Singleton()
        {
            Name = System.Guid.NewGuid().ToString();
        }

        public static Singleton GetInstance()
        {
            return lazy.Value;
        }
    }

}
