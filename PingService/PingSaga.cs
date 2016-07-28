namespace PingService
{
    using System;
    using NServiceBus;
    using NServiceBus.Saga;
    using PingMessages.Commands;
    using PingMessages.Events;
    using PongMessages.Events;

    public class PingSaga : Saga<PingSagaData>,
        IAmStartedByMessages<SendPing>,
        IHandleMessages<PongReceived>,
        IHandleMessages<PongTimedOut>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<PingSagaData> mapper)
        {
            mapper.ConfigureMapping<SendPing>(message => message.Relay).ToSaga(saga => saga.Message);
            mapper.ConfigureMapping<PongReceived>(ping => ping.Relay).ToSaga(saga => saga.Message);
            mapper.ConfigureMapping<PongTimedOut>(pong => pong.Relay).ToSaga(saga => saga.Message);
        }

        public void Handle(SendPing message)
        {
            Data.Message = message.Relay;
            Console.WriteLine(message);
            Bus.Publish(new PingReceived {Relay = message.Relay});
        }

        public void Handle(PongReceived message)
        {
            Console.WriteLine(message);
            this.MarkAsComplete();

            Bus.Publish(new PingComplete {Relay = message.Relay});
        }

        public void Handle(PongTimedOut message)
        {
            Console.WriteLine(message);
            this.MarkAsComplete();

            Bus.Publish(new PingFailed { Relay = message.Relay, Reason = "pong timed out"});
        }
    }
}