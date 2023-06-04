using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Militaria.RabbitMQ.OdbieranieWiadomosciZkolejki
{
    public class Consumer : RabbitClientBase
    {
        public Consumer(string queueName, string hostName) : base(queueName, hostName) { }

        public void BasicConsume(EventingBasicConsumer consumer)
        {
            _channel.BasicConsume(
                    queue: "Queue_1",
                    autoAck: true, //obsłużenie kolejki
                    consumer: consumer);
        }

        public EventingBasicConsumer CreateEventingConsumer()
        {
            var consumer = new EventingBasicConsumer(_channel);
            return consumer;
        }
         

    }

}
