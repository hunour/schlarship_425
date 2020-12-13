using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.IO;
namespace scholarship_425.pages
{
    class sendemail
    {
        //required .net objects


    
    //Sample function only that will return an xml in string format
    public string CreateXMLLicenseString()
    {
        return "My sample data";
    }


    //function to send email
    //will return empty string if success otherwise will return error message
    public string SendMail(string emailFrom, string emailTo, string cc, string subject, string body, string host, int port, string username, string password, bool isHTML, bool enableSSL, Attachment attachment)
    {
        //declare objects
        MailMessage message = new MailMessage();
        SmtpClient smtp = new SmtpClient(host, port);

        //add try exception
        try
        {
            //Add email address, cc
            message.From = new MailAddress(emailFrom);
            message.To.Add(new MailAddress(emailTo));
            if (cc != string.Empty)
            {
                message.CC.Add(new MailAddress(cc));
            }

            //Add subject, body and attachment
            message.Subject = subject;
            message.Body = body;
            if (attachment != null)
            {
                message.Attachments.Add(attachment);
            }

            //Email Authentication
            if (username.Trim() != string.Empty && password.Trim() != string.Empty)
            {
                NetworkCredential basicAuthentication = new NetworkCredential(username, password);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = basicAuthentication;
            }

            //enable SSL
            smtp.EnableSsl = enableSSL;

            //smtp port
            if (port > 0) { smtp.Port = port; }

            //check if html format is needed
            if (isHTML) { message.IsBodyHtml = true; } else { message.IsBodyHtml = false; }

            //Send the email
            smtp.Send(message);
        }
        catch (Exception ex)
        {
            return ex.Message.ToString();
        }
        return "";
    }
}
}
