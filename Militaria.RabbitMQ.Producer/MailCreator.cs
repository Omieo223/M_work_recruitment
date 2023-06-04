
namespace Militaria.RabbitMQ.ProducerApp
{
    public class MailCreator
    {
        public Email CreateMail(string emailSender, string emailReceiver, string subject, string body)
        {
            var email = new Email 
            { 
                Body = body,
                Subject = subject,
                EmailReceiver = emailReceiver,
                EmailSender = emailSender,                   
            };
            return email;
        }
    }
}
