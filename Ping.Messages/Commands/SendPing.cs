namespace Ping.Messages.Commands
{
    public class SendPing
    { 
        public string Relay { get; set; }

        public override string ToString()
        {
            return $"{this.Relay} ping sent";
        }
    }
}
