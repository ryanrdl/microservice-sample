namespace WebApp
{
    using SharedKernel;

    public class WebClientConfiguration
    {
        public static string PingUrl { get; } = Env.Get($"{nameof(WebApp)}{nameof(PingUrl)}");
        public static string PongUrl { get; } = Env.Get($"{nameof(WebApp)}{nameof(PongUrl)}");
        public static string RabbitMQConnectionString { get; } = Env.Get(nameof(RabbitMQConnectionString));
        public static string NServiceBusLicensePath { get; } = Env.Get(nameof(NServiceBusLicensePath));
        public static string MongoDbConnectionString { get; } = Env.Get(nameof(MongoDbConnectionString));
    }
}