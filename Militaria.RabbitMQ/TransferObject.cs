namespace Militaria.RabbitMQ
{
    public class TransferObject
    {
        public string Type { get; set; }
        public string Content { get; set; }

        public const string Email = "email";

    }
}
