namespace PongService
{
    using System;
    using NServiceBus;
    using NServiceBus.Saga;
    using PingMessages.Events;
    using PongMessages.Commands;
    using PongMessages.Events;

    public class PongSaga : Saga<PongSagaData>,
        IAmStartedByMessages<PingReceived>,
        IHandleMessages<SendPong>,
        IHandleTimeouts<PongSaga.PongTimeout>
    {
        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<PongSagaData> mapper)
        {
            mapper.ConfigureMapping<PingReceived>(message => message.Relay).ToSaga(saga => saga.Message);
            mapper.ConfigureMapping<SendPong>(ping => ping.Relay).ToSaga(saga => saga.Message);
        }

        public void Handle(PingReceived message)
        {
            Data.Message = message.Relay;
            Console.WriteLine(message);
            RequestTimeout(TimeSpan.FromSeconds(PongConfiguration.TimeoutThresholdSeconds), new PongTimeout {Message = message.Relay});

            PongHost.Add(message.Relay);
        }

        public void Handle(SendPong message)
        {
            Console.WriteLine(message);
            Bus.Publish(new PongReceived {Relay = message.Relay});
            this.MarkAsComplete();
        }

        public void Timeout(PongTimeout state)
        {
            Console.WriteLine(state);
            Bus.Publish(new PongTimedOut {Relay = state.Message});
        }

        public class PongTimeout
        {
            public string Message { get; set; }

            public override string ToString()
            {
                return $"{this.Message} pong timed out";
            }
        }
    }
}