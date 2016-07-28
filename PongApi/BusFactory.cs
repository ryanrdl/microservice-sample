namespace PongApi
{
    using System.Collections.Generic;
    using System.Reflection;
    using NServiceBus;
    using SharedKernel;

    public class BusFactory
    {
        public static void Init(PongConfiguration configuration)
        {
            var cfg = new BusConfiguration();
            cfg.LicensePath(configuration.NServiceBusLicensePath);

            cfg.UseTransport<RabbitMQTransport>().ConnectionString(configuration.RabbitMQConnectionString);
            cfg.UseSerialization<JsonSerializer>();

            cfg.Conventions().DefiningCommandsAs(UnobtrusiveConventions.DefiningCommandsAs);
            cfg.Conventions().DefiningEventsAs(UnobtrusiveConventions.DefiningEventsAs);
            cfg.Conventions().DefiningMessagesAs(UnobtrusiveConventions.DefiningMessagesAs);

            cfg.AssembliesToScan(GetAssemblesToScan());

            Current = Bus.CreateSendOnly(cfg);
        }

        public static ISendOnlyBus Current { get; private set; }

        private static IEnumerable<Assembly> GetAssemblesToScan()
        {
            IIncludesBuilder includesBuilder = AllAssemblies
                .Matching("NServiceBus");

            var assemblies = new List<Assembly> {Assembly.Load("PongMessages")};

            assemblies.AddRange(includesBuilder);

            return assemblies;
        }
    }
}