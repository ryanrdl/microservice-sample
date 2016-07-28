namespace PingService
{
    using NServiceBus.Persistence.MongoDB;
    using NServiceBus.Saga;

    public class PingSagaData : ContainSagaData
    {
        [Unique]
        public string Message { get; set; }

        [DocumentVersion]
        public int Version { get; set; }
    }
}