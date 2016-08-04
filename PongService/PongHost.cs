namespace PongService
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Threading;
    using NServiceBus;
    using NServiceBus.Persistence.MongoDB;
    using SharedKernel;

    public class PongHost
    {
        private readonly IStartableBus _bus;

        public PongHost()
        {
            var cfg = new BusConfiguration();
            cfg.EndpointName(nameof(PongService));
            cfg.LicensePath(PongConfiguration.NServiceBusLicensePath);

            cfg.UseTransport<RabbitMQTransport>().ConnectionString(PongConfiguration.RabbitMQConnectionString);
            cfg.UsePersistence<MongoDbPersistence>().SetConnectionString(PongConfiguration.MongoDbConnectionString);
            cfg.UseSerialization<JsonSerializer>();
            cfg.EnableInstallers();

            cfg.Conventions().DefiningCommandsAs(UnobtrusiveConventions.DefiningCommandsAs);
            cfg.Conventions().DefiningEventsAs(UnobtrusiveConventions.DefiningEventsAs);
            cfg.Conventions().DefiningMessagesAs(UnobtrusiveConventions.DefiningMessagesAs);

            cfg.AutoSubscribe();
            this._bus = Bus.Create(cfg);
        }

        public void Start()
        {
            this._bus.Start();
        }

        public void Stop()
        {
            this._bus.Dispose();
        }

        public void Send(object message)
        {
            this._bus.Send(message);
        }

        private static ConcurrentDictionary<int, string> Pings { get; } = new ConcurrentDictionary<int, string>();
        private static int _indexer;
        private static readonly object _lock = new object();

        public static int Add(string relay)
        {
            lock (_lock)
            {
                Interlocked.Increment(ref _indexer);
                Pings.AddOrUpdate(_indexer, relay, (i, s) => s);
                return _indexer;
            }
        }

        public IDictionary<int, string> GetPings()
        {
            return Pings;
        }

        public static void Repond(int index, Action<string> respond)
        {
            string relay;
            if (Pings.TryRemove(index, out relay))
            {
                //this._bus.Send(new SendPong {Relay = relay});
                respond(relay);
            }
            else
            {
                Console.WriteLine($"No relay found at {index}");
            }
        }
    }
}