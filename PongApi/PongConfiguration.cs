namespace PongApi
{
    public class PongConfiguration
    {
        public string RabbitMQConnectionString { get; set; } 
        public string NServiceBusLicensePath { get; set; }
        public string UseUrls { get; set; } = "http://*:19702";

        public string[] GetUseUrls()
        {
            return string.IsNullOrEmpty(this.UseUrls) ? null : this.UseUrls.Split(',');
        }
    }
}