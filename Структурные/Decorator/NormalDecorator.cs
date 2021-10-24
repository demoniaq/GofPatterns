using System;

namespace Decorator
{
    internal class NormalDecorator : MessageDecorator
    {
        public NormalDecorator(Message message) : base(message) { }

        public override void PrintMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            message.PrintMessage();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}