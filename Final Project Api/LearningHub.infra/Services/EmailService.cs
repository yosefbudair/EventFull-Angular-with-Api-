using Microsoft.Extensions.Configuration;
using MimeKit; // Import MimeKit namespace
using MimeKit.Text;
using MailKit.Net.Smtp;
using System;
using System.IO;
using System.Threading.Tasks;
using LearningHub.Core.Services;
using LearningHub.Core.Data;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace LearningHub.Infra.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(Send send, byte[] attachment = null)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("sanaa", "sanaa.almograby@gmail.com"));
            emailMessage.To.Add(new MailboxAddress("", send.recipientEmail));
            emailMessage.Subject = send.subject;

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = send.message;

            if (attachment != null)
            {
                var attachmentPart = new MimePart()
                {
                    Content = new MimeContent(new MemoryStream(attachment), ContentEncoding.Default),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = "invoice.pdf"
                };

                bodyBuilder.Attachments.Add(attachmentPart);
            }

            emailMessage.Body = bodyBuilder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.gmail.com", 587, false);
                await client.AuthenticateAsync("sanaa.almoghraby@gmail.com", "escfkstvfcsdafpc");
                await client.SendAsync(emailMessage);
                await client.DisconnectAsync(true);
            }
        }
        public byte[] GenerateInvoice(Send send)
        {
            // Implement your invoice generation logic here
            // Return the PDF content as a byte array

            // Example: Generate a sample PDF
            using (var document = new Document())
            {
                using (var memoryStream = new MemoryStream())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, memoryStream);
                    document.Open();

                    // Add invoice details to the PDF
                    document.Add(new Paragraph("You Paid for event " + send.eventname + " for " + send.createdby + " User ."));
                    document.Add(new Paragraph("Your Card has been debtited " + send.price + "$"));
                    // Add more content as needed

                    document.Close();
                    return memoryStream.ToArray();
                }
            }
        }
    }
}