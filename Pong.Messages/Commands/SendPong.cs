namespace Pong.Messages.Commands
{
    public class SendPong
    {
        public string Relay { get; set; }

        public override string ToString()
        {
            return $"{this.Relay} pong sent";
        }
    }
}
