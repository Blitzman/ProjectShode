using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace Project_Shode
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            nameFeedback.Visible = false;
            emailFeedback.Visible = false;
            subjectFeedback.Visible = false;
            messageFeedback.Visible = false;
            lengthFeedback.Visible = false;
            Label1.Visible = false;
            correctEmail.Visible = false;
        }

        protected void contact(object sender, EventArgs e)
        {
            bool correct = true;

            if (textname.Text.Length == 0)
            {
                correct = false;
                nameFeedback.Visible = true;
            }

            if (textemail.Text.Length == 0)
            {
                correct = false;
                emailFeedback.Visible = true;
            }

            if (textsubject.Text.Length == 0)
            {
                correct = false;
                subjectFeedback.Visible = true;
            }

            if (textmessage.Text.Length == 0)
            {
                messageFeedback.Visible = true;
                correct = false;
            }
            else if (textmessage.Text.Length > 1000)
            {
                lengthFeedback.Visible = true;
                lengthFeedback.Text = "The message is too long! Delete " + (textmessage.Text.Length - 1000).ToString() + " characters.";
                correct = false;
            }

            if (correct)
            {
                SendMail();
            }

        }

        protected void SendMail()
        {
            MailMessage mm = new MailMessage("remitente@gmail.com", "projectshode@gmail.com");
            mm.Subject = textmessage.Text;
            mm.Body = "Name: " + textname.Text + "<br /><br />Email: " + textemail.Text + "<br />" + textmessage.Text;

            try
            {
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "projectshode@gmail.com";
                NetworkCred.Password = "IreneChupameElPene";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
                Label1.Visible = true;
            }
            catch (Exception ex)
            {
                Label1.Text = "Message not sended. Try again, please.";
            }

        }
    }
}
