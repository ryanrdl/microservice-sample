namespace PongService
{
    using System;
    using SharedKernel;

    public class PongConfiguration
    {
        public static string RabbitMQConnectionString { get; set; } = Env.Get(nameof(RabbitMQConnectionString));
        public static string NServiceBusLicensePath { get; set; } = Env.Get(nameof(NServiceBusLicensePath));
        public static string MongoDbConnectionString { get; set; } = Env.Get(nameof(MongoDbConnectionString));
        public static int TimeoutThresholdSeconds { get; set; } = GetTimeout();

        private static int GetTimeout()
        {
            int timeout = 60, defaultTimeout = 60;
            var value = Env.Get($"{nameof(PongService)}{nameof(TimeoutThresholdSeconds)}", throwExceptionIfNotFound:false);
            
            if (int.TryParse(value, out timeout))
                return Math.Min(6000, Math.Max(0, timeout));

            return defaultTimeout;
        }
    }
}