using API.Contracts;
using System.Net.Mail;

namespace API.Utilities.Handler
{
    public class EmailHandler : IEmailHandler
    {
        private string _server;
        private int _port;
        private string _fromEmailAdress;

        public EmailHandler(string server, int port, string fromEmailAdress)
        {
            _server = server;
            _port = port;
            _fromEmailAdress = fromEmailAdress;
        }
        public void Send(string subject, string body, string toEmail)
        {
            var message = new MailMessage()
            {
                From = new MailAddress(_fromEmailAdress),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            message.To.Add(new MailAddress(toEmail));
            // Send message
            using var smtpClient = new SmtpClient(_server, _port);
            smtpClient.Send(message);
        }
    }
}
