namespace Pong.Messages.Events
{
    public class PongTimedOut
    {
        public string Relay { get; set; }

        public override string ToString()
        {
            return $"{this.Relay} pong timed out";
        }
    }
}