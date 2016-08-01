namespace PongApi
{
    using SharedKernel;

    public class PongConfiguration
    {
        public string RabbitMQConnectionString { get; set; } = Env.Get(nameof(RabbitMQConnectionString));
        public string NServiceBusLicensePath { get; set; } = Env.Get(nameof(NServiceBusLicensePath));
        public string UseUrls { get; set; } = Env.Get($"{nameof(PongApi)}{nameof(UseUrls)}", "http://*:19702"); 

        public string[] GetUseUrls()
        {
            return string.IsNullOrEmpty(this.UseUrls) ? null : this.UseUrls.Split(',');
        }
    }
}