namespace Militaria.RabbitMQ
{
    public class Email
    {
        public string EmailSender { get; set; }
        public string EmailReceiver { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
