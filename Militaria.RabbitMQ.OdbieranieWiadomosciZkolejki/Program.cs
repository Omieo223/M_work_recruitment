using Militaria.RabbitMQ;
using Militaria.RabbitMQ.OdbieranieWiadomosciZkolejki;
using System.Text;


public class Program
{
    public static void Main(string[] arg)
    {

        var queueName = "Queue_1";
        var hostName = "rabbitServer";

        using (Consumer consumer = new Consumer(queueName, hostName))
        {

            Console.WriteLine("Waiting for massage");

            var consumer1 = consumer.CreateEventingConsumer();
            consumer1.Received += (model, ea) =>

            {
                try
                {
                    var massage = Encoding.UTF8.GetString(ea.Body.ToArray());
                    var transferObject = System.Text.Json.JsonSerializer.Deserialize<TransferObject>(massage);
                    ProcessMessage(transferObject);
                }
                catch (Exception ex) { Console.WriteLine(ex.ToString()); }

            };

            consumer.BasicConsume(consumer1);

            char key = 'z';
            while (key != 'q' && key != 'Q')
            {
                Console.WriteLine("Press [q] or [Q] to exit");
                key = Console.ReadKey().KeyChar;
            }
        }
    }
    private static void ProcessMessage(TransferObject transferObject)
    {
        switch (transferObject.Type)
        {
            case TransferObject.Email:
                try
                {

                    var email = System.Text.Json.JsonSerializer.Deserialize<Militaria.RabbitMQ.Email>(transferObject.Content);

                    if(email is { })
                    { 
                        SendEmail(email);
                    }
                    
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                break;
        }
    }
    private static void SendEmail(Militaria.RabbitMQ.Email email)
    {
        Console.WriteLine($"{email.Body}");
    }
}