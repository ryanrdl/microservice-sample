namespace WebClient
{
    public class WebClientConfiguration
    {
        public static string PingUrl { get; set; } = "http://localhost:19701/api/ping";
        public static string PongUrl { get; set; } = "http://localhost:19702/api/pong";
    }
}
