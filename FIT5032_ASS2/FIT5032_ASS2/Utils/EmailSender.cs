using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FIT5032_Week08A.Utils
{
    public class EmailSender
    {
        // Please use your API KEY here.
        private const String API_KEY = "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";

        public void Send(String toEmail, String subject, String contents, HttpPostedFileBase postedFile)
        {
            var client = new SendGridClient(API_KEY);
            var from = new EmailAddress("zwan0348@student.monash.edu", "FIT5032 Assignment3");
            var to = new EmailAddress(toEmail, "");
            var plainTextContent = contents;
            var htmlContent = "<p>" + contents + "</p>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            using (var memoryStream = new MemoryStream())
            {
                // 1. convert attach file to inputStream
                postedFile.InputStream.CopyTo(memoryStream);
                // 2. convert inputstream to byte array
                byte[] bytes = memoryStream.ToArray();
                Attachment attachment = new Attachment();
                // 3. convert to base64 type(String)
                attachment.Content = Convert.ToBase64String(bytes);
                attachment.Filename = postedFile.FileName;
                // 4. add this attachment to email message
                msg.AddAttachment(attachment.Filename, attachment.Content);
            }

            var response = client.SendEmailAsync(msg);
        }

    }
}