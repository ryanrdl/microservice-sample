namespace PingService
{
    public class PingConfiguration
    {
        public string RabbitMQConnectionString { get; set; }
        public string MongoDbConnectionString { get; set; }
        public string NServiceBusLicensePath { get; set; }
    }
}