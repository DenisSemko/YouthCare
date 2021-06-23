using BLL.Services.Abstract;
using CIL.Models;
using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Concrete
{
    public class EmailService : IEmailMessageService
    {
        private readonly EmailConfiguration emailConfig;
        public EmailService(EmailConfiguration emailConfig)
        {
            this.emailConfig = emailConfig;
        }
        public async Task SendEmail(EmailMessage message)
        {
            var emailMessage = CreateEmailMessage(message);
            await Send(emailMessage);
        }

        public async Task SendEmailWhAttachment(EmailMessageAttachment message)
        {
            var emailMessage = CreateEmailMessageWhAttachment(message);
            await Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(EmailMessage message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(emailConfig.From));
            emailMessage.To.Add(new MailboxAddress(message.EmailTo));
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };
            return emailMessage;
        }

        private MimeMessage CreateEmailMessageWhAttachment(EmailMessageAttachment message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(emailConfig.From));
            emailMessage.To.Add(new MailboxAddress(message.EmailTo));
            emailMessage.Subject = message.Subject;


            BodyBuilder emailBodyBuilder = new BodyBuilder();

            if (message.EmailAttachments != null)
            {
                byte[] attachmentFileByteArray;
                foreach (IFormFile attachmentFile in message.EmailAttachments)
                {
                    if (attachmentFile.Length > 0)
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            attachmentFile.CopyTo(memoryStream);
                            attachmentFileByteArray = memoryStream.ToArray();
                        }
                        emailBodyBuilder.Attachments.Add(attachmentFile.FileName, attachmentFileByteArray, ContentType.Parse(attachmentFile.ContentType));
                    }
                }
            }

            emailBodyBuilder.TextBody = message.Content;
            emailMessage.Body = emailBodyBuilder.ToMessageBody();

            return emailMessage;
        }
        private async Task Send(MimeMessage mailMessage)
        {
            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(emailConfig.SmtpServer, emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(emailConfig.UserName, emailConfig.Password);
                    await client.SendAsync(mailMessage);
                }
                catch
                {
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }
    }
}
