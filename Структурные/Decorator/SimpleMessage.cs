using System;

namespace Decorator
{
    internal class SimpleMessage : Message
    {
        public SimpleMessage(string text) : base(text) { }

        public override void PrintMessage()
        {
            Console.WriteLine(text);
        }
    }
}