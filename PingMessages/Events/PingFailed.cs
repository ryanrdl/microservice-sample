namespace PingMessages.Events
{
    public class PingFailed
    {
        public string Relay { get; set; }
        public string Reason { get; set; }
        

        public override string ToString()
        {
            return $"{this.Relay} ping failed";
        }
    }
}