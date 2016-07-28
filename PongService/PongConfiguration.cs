namespace PongService
{
    public class PongConfiguration
    {
        public static string RabbitMQConnectionString { get; set; }
        public static string MongoDbConnectionString { get; set; }
        public static string NServiceBusLicensePath { get; set; }
        public static int TimeoutThresholdSeconds { get; set; } = 60;
    }
}