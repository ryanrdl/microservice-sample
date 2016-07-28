namespace WebApp
{
    public class WebClientConfiguration
    {
        public static string PingUrl { get; set; } = "http://localhost:19701/api/ping";
        public static string PongUrl { get; set; } = "http://localhost:19702/api/pong";

        public static string RabbitMQConnectionString { get; set; } =
            "host=10.2.17.218;username=test;password=test;VirtualHost=demo";

        public static string NServiceBusLicensePath { get; set; } = "c:\\dev\\NSBLicense.xml";

        public static string MongoDbConnectionString { get; set; }= "mongodb://test:test@ds033015.mlab.com:33015/microservice-demo";
    }
}
