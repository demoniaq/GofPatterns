using System;
using System.Collections.Generic;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            var subject = new Subject();

            var greenObserver = new Observer(ConsoleColor.Green);
            var redObserver = new Observer(ConsoleColor.Red);
            var yellowObserver = new Observer(ConsoleColor.Yellow);

            subject.OnQuantityUpdated += greenObserver.ObserverQuantity;
            subject.OnQuantityUpdated += redObserver.ObserverQuantity;
            subject.OnQuantityUpdated += yellowObserver.ObserverQuantity;

            subject.UpdateQuantity(12);
            subject.UpdateQuantity(5);
        }
    }



    // Издатель
    class Subject
    {
        public event Action<int> OnQuantityUpdated;

        private int _quantity = 0;
        public void UpdateQuantity(int value)
        {
            _quantity += value;
            // оповещение наблюдателей
            OnQuantityUpdated?.Invoke(_quantity);
        }
    }

    // Подписчик
    class Observer
    {
        ConsoleColor _color;
        public Observer(ConsoleColor color)
        {
            _color = color;
        }

        internal void ObserverQuantity(int quantity)
        {
            Console.ForegroundColor = _color;
            Console.WriteLine($"I observer the new quantity value of {quantity}.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

}
