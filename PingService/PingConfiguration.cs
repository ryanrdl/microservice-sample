namespace PingService
{
    using SharedKernel;

    public class PingConfiguration
    {
        public static string RabbitMQConnectionString { get; } = Env.Get(nameof(RabbitMQConnectionString));
        public static string NServiceBusLicensePath { get; } = Env.Get(nameof(NServiceBusLicensePath));
        public static string MongoDbConnectionString { get; } = Env.Get(nameof(MongoDbConnectionString));
    }
}