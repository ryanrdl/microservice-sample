namespace PongApi
{
    using SharedKernel;

    public class PongConfiguration
    {
        public static string RabbitMQConnectionString { get; set; } = Env.Get(nameof(RabbitMQConnectionString));
        public static string NServiceBusLicensePath { get; set; } = Env.Get(nameof(NServiceBusLicensePath));
        public static string UseUrls { get; set; } = Env.Get($"{nameof(PongApi)}{nameof(UseUrls)}", "http://*:19702"); 

        public static string[] GetUseUrls()
        {
            return string.IsNullOrEmpty(UseUrls) ? null : UseUrls.Split(',');
        }
    }
}