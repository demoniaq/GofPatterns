using System;

namespace Decorator
{
    internal class ErrorDecorator : MessageDecorator
    {
        public ErrorDecorator(Message message) : base(message) { }

        public override void PrintMessage()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            message.PrintMessage();
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}