using System;
using System.Net;
using System.Net.Mail;

namespace SpaceShuttle
{
    class EmailSender
    {
        public string SenderAddress { get; set; } = "";
        public string SenderPswd { get; set; } = "";
        public string ReceiverAddress { get; set; } = "";
        public string FilePath { get; set; } = "";
        public int BestLaunchDate { get; set; } = 0;
        public EmailSender(string senderAddress, string senderPswd, string receiverAddres, string filePath, int bestLaunchDate)
        {
            SenderAddress = senderAddress;
            SenderPswd = senderPswd;
            ReceiverAddress = receiverAddres;
            FilePath = filePath;
            BestLaunchDate = bestLaunchDate;
        }

        public void Send()
        {

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(SenderAddress);
            mailMessage.To.Add(new MailAddress(ReceiverAddress));
            mailMessage.Subject = "Weather report for rocket launch!";
            mailMessage.Body = "Best Launch day is : " + BestLaunchDate.ToString();

            Attachment attachment = new Attachment(FilePath);
            mailMessage.Attachments.Add(attachment);

            try
            {
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(SenderAddress, SenderPswd);
                smtp.Send(mailMessage);
                Console.WriteLine("Email Sent!");
            }
            catch (Exception)
            {
                Console.WriteLine("Error while sending the email!");
                return;
            }
        }
    }
}
