namespace PingMessages.Events
{
    public class PingComplete
    {
        public string Relay { get; set; }

        public override string ToString()
        {
            return $"{this.Relay} ping complete";
        }
    }
}