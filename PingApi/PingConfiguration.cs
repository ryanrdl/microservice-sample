namespace PingApi
{
    using SharedKernel;

    public class PingConfiguration
    {
        public static string RabbitMQConnectionString { get; } = Env.Get(nameof(RabbitMQConnectionString));
        public static string NServiceBusLicensePath { get; } = Env.Get(nameof(NServiceBusLicensePath));
        public static string UseUrls { get; } = Env.Get($"{nameof(PingApi)}{nameof(UseUrls)}", "http://*:19701");

        public static string[] GetUseUrls()
        {
            return string.IsNullOrEmpty(UseUrls) ? null : UseUrls.Split(',');
        }
    }
}