using RabbitMQ.Client;
using System.Text;

namespace Militaria.RabbitMQ
{
    public class Producer : RabbitClientBase
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="queueName"></param>
        /// <param name="hostName"></param>
        /// <exception cref="RabbitMQ.Client.Exception.BrokerUnrechableException"></exception>
        public Producer(string queueName, string hostName): base(queueName, hostName) { }
        
        public void BasicPublish(byte[] body)
        {
            _channel.BasicPublish(
                        exchange: "",
                        routingKey: _queueName,
                        basicProperties: null,
                        body: body);            
        }
        public void BasicPublish(string body) 
        {
            var byteBody = Encoding.UTF8.GetBytes(body);
            BasicPublish(byteBody);
        }

        public void Publish(TransferObject transferObject)
        {
            var transObject = System.Text.Json.JsonSerializer.Serialize(transferObject);
            BasicPublish(transObject);
        }
    }
}
