namespace PingService
{
    using NServiceBus;
    using NServiceBus.Persistence.MongoDB;
    using PingMessages.Commands;
    using SharedKernel;

    public class PingHost
    { 
        private readonly IStartableBus _bus;

        public PingHost(PingConfiguration configuration)
        { 
            var cfg = new BusConfiguration();
            cfg.EndpointName(nameof(PingService));
            cfg.LicensePath(configuration.NServiceBusLicensePath);

            cfg.UseTransport<RabbitMQTransport>().ConnectionString(configuration.RabbitMQConnectionString);
            cfg.UsePersistence<MongoDbPersistence>().SetConnectionString(configuration.MongoDbConnectionString);
            cfg.UseSerialization<JsonSerializer>();

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

        public void Send(string id)
        {
            this._bus.Send(new SendPing {Relay = id});
        }
    }
}