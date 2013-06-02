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
            feedback.Visible = false;
        }

        protected void SendMail(object sender, EventArgs e)
        {
            MailMessage mm = new MailMessage("remitente@gmail.com", "projectshode@gmail.com");
            mm.Subject = textsubject.Text.ToString();
            mm.Body = "Name: " + textname.Text.ToString() + "<br /><br />Email: " + textemail.Text.ToString() +
                "<br /><br />Subject: " + textsubject.Text.ToString() + "<br /><br />Body: " + textmessage.Text.ToString();

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
                feedback.Visible = true;
            }
            catch (Exception ex)
            {
                feedback.Text = "Message not sended. Try again, please.";
            }

        }
    }
}
