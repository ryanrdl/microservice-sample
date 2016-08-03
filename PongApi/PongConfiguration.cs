namespace PongApi
{
    using SharedKernel;

    public class PongConfiguration
    {
        public static string RabbitMQConnectionString { get; set; } = Env.Get(nameof(RabbitMQConnectionString));
        public static string NServiceBusLicensePath { get; set; } = Env.Get(nameof(NServiceBusLicensePath)); 
    }
}