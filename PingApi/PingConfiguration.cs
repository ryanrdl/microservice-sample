namespace PingApi
{
    public class PingConfiguration
    {
        public string RabbitMQConnectionString { get; set; } 
        public string NServiceBusLicensePath { get; set; }
        public string UseUrls { get; set; } = "http://*:19701";

        public string[] GetUseUrls()
        {
            return string.IsNullOrEmpty(this.UseUrls) ? null : this.UseUrls.Split(',');
        }
    }
}