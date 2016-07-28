namespace PingService
{
    using System;
    using NServiceBus.Saga;

    public class SagaNotFoundHandler :
        IHandleSagaNotFound
    {
        public void Handle(object message)
        {
            var o = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(message);
            Console.ForegroundColor = o;
        }
    }
}