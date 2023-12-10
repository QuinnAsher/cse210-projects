using MailKit.Net.Smtp;
using MimeKit;

namespace FinalProject;

public class EmailMaker
{
        private string _senderEmail;
        private string _recipientEmail;
        private string _emailSubject;
        private string _emailBody;
        private string _smtpHost;
        private int _smptPort;
        private string _password;

        public EmailMaker(string senderEmail, string recipientEmail, string emailSubject, string emailBody, string smtpHost, int smtpPort, string password)
        {
            _senderEmail = senderEmail;
            _recipientEmail = recipientEmail;
            _emailSubject = emailSubject;
            _emailBody = emailBody;
            _smtpHost = smtpHost;
            _smptPort = smtpPort;
            _password = password;
        }

        // Method to send an email
        public   async Task  SendMail(string senderName, string recipientName)
        {
            // Create a new MimeMessage object to represent the email message
            MimeMessage email = new MimeMessage();

            // Set the sender information
            email.From.Add(new MailboxAddress(senderName, _senderEmail));

            // Set the recipient information
            email.To.Add(new MailboxAddress(recipientName, _recipientEmail));

            // Set the email subject
            email.Subject = _emailSubject;

            // Create a BodyBuilder object to build the email body
            BodyBuilder bodyBuilder = new BodyBuilder();

            // Set the email body in HTML format
            bodyBuilder.HtmlBody = _emailBody;

            // Convert the BodyBuilder object to a MessagePart object
            email.Body = bodyBuilder.ToMessageBody();

            // Create a SmtpClient object to connect to the SMTP server
            using SmtpClient smtp = new SmtpClient();

            try
            {
                // Connect to the SMTP server
                await smtp.ConnectAsync(_smtpHost, _smptPort, false);

                // Authenticate with the sender's email address and password
                await smtp.AuthenticateAsync(_senderEmail, _password);

                // Send the email message
                await smtp.SendAsync(email);

                // Disconnect from the SMTP server
                await smtp.DisconnectAsync(true);

                // Display a success message if the email was sent successfully
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the email sending process
                Console.WriteLine("Email sending failed: " + ex.Message);
            }
        }
}