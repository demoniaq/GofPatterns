namespace Decorator
{
    internal abstract class Message : IMessage
    {
        protected string text;

        public Message(string text)
        {
            this.text = text;
        }

        abstract public void PrintMessage();
    }
}