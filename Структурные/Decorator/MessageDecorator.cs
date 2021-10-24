namespace Decorator
{
    internal abstract class MessageDecorator : IMessage
    {
        protected Message message;
        public MessageDecorator(Message message)
        {
            this.message = message;
        }

        public abstract void PrintMessage();
    }
}