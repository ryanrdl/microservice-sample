namespace PingMessages.Events
{
    public class PingReceived
    {
        public string Relay { get; set; }

        public override string ToString()
        {
            return $"{this.Relay} ping recieved";
        }
    }
}
