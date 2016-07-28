namespace PongService
{
    using NServiceBus.Persistence.MongoDB;
    using NServiceBus.Saga;

    public class PongSagaData : ContainSagaData
    {
        [Unique]
        public string Message { get; set; }

        [DocumentVersion]
        public int Version { get; set; }
    }
}