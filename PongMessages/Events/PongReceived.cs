namespace PongMessages.Events
{
    public class PongReceived
    {
        public string Relay { get; set; }

        public override string ToString()
        {
            return $"{this.Relay} pong received";
        }
    }
}
