using Militaria.RabbitMQ;
using Militaria.RabbitMQ.ProducerApp;

public class Program
{
    public static void Main(string [] arg)
    {
        SendInLoop();
    }
    public static void SendInLoop()
    {
        var queueName = "Queue_1";
        var hostName = "rabbitServer";

        try
        {
            using (Producer producer = new Producer(queueName, hostName))
            {
                while (true)
                {
                    Console.WriteLine("Write what you want to send");
                    Console.WriteLine("Write nothing to exit.");
                    string usermessage = Console.ReadLine();

                    if (string.IsNullOrEmpty(usermessage))
                        break;

                    var mail1 = new MailCreator().CreateMail("adres@gmial.com", "jasko@gmail.com", "subject", usermessage);
                    var serMail1 = System.Text.Json.JsonSerializer.Serialize(mail1);
                    var transMail1 = new TransferObject()
                    {
                        Content = serMail1,
                        Type = TransferObject.Email   
                    };
                    producer.Publish(transMail1);
                    Console.WriteLine("Mail is sending to queue. ;) ");
                }
            }
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex.Message);
            Console.ForegroundColor = ConsoleColor.Gray;

        }
    }   
}