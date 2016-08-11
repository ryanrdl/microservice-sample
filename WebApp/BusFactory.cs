namespace WebApp
{
    using System.Collections.Generic;
    using System.Reflection;
    using NServiceBus;
    using NServiceBus.Logging;
    using NServiceBus.Persistence.MongoDB;
    using SharedKernel;

    public class BusFactory
    {
        public static void Init()
        { 
            LogManager.Use<NLogFactory>();

            var cfg = new BusConfiguration();
            cfg.EndpointName("PingPongClient"); 
            cfg.LicensePath(WebClientConfiguration.NServiceBusLicensePath);

            cfg.UseTransport<RabbitMQTransport>().ConnectionString(WebClientConfiguration.RabbitMQConnectionString);
            cfg.UsePersistence<MongoDbPersistence>().SetConnectionString(WebClientConfiguration.MongoDbConnectionString);
            cfg.UseSerialization<JsonSerializer>();
            cfg.EnableInstallers();

            cfg.Conventions().DefiningCommandsAs(UnobtrusiveConventions.DefiningCommandsAs);
            cfg.Conventions().DefiningEventsAs(UnobtrusiveConventions.DefiningEventsAs);
            cfg.Conventions().DefiningMessagesAs(UnobtrusiveConventions.DefiningMessagesAs);

            cfg.AssembliesToScan(GetAssemblesToScan());
            cfg.AutoSubscribe();

            Current = Bus.Create(cfg).Start();
        } 

        public static IBus Current { get; private set; }

        private static IEnumerable<Assembly> GetAssemblesToScan()
        {
            IIncludesBuilder includesBuilder = AllAssemblies
                .Matching("NServiceBus");

            var assemblies = new List<Assembly>
            {
                Assembly.Load("PongMessages"),
                Assembly.Load("PingMessages"),
                Assembly.GetExecutingAssembly()
            };

            assemblies.AddRange(includesBuilder);

            return assemblies;
        }
    }
}