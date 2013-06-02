using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ShodeLibrary;

namespace Project_Shode
{
    public partial class ProfileCompose : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserNickname"];

            if (userCookie != null)
                SiteMaster.loadCookie(userCookie);

            if (Session["UserNickname"] == null)
                Response.Redirect("Login.aspx");
            else
            {
                userFeedback.Visible = false;
                existsFeedback.Visible = false;
                subjectFeedback.Visible = false;
                messageFeedback.Visible = false;
                lengthFeedback.Visible = false;
            }
        }

        protected void send_Message(object sender, EventArgs e)
        {
            bool correct = true;

            if (textuserdest.Text.Length == 0)
            {
                userFeedback.Visible = true;
                correct = false;
            }
            else
            {
                UserBE user1 = new UserBE("", 0, "", "", textuserdest.Text, "");
                UserBE dest = new UserBE(user1.getUserByNick());

                if (dest.Email == "")
                {
                    correct = false;
                    existsFeedback.Visible = true;
                }
            }

            if (textsubject.Text.Length == 0)
            {
                subjectFeedback.Visible = true;
                correct = false;
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
                String subject = textsubject.Text;
                String message = textmessage.Text;
                DateTime date = DateTime.Now;

                UserBE user1 = new UserBE("", 0, "", "", Session["UserNickname"].ToString(), "");
                UserBE sender1 = new UserBE(user1.getUserByNick());

                user1 = new UserBE("", 0, "", "", textuserdest.Text, "");
                UserBE addressee = new UserBE(user1.getUserByNick());

                MessageBE sndMessage = new MessageBE(sender1, addressee, date, subject, message);

                sndMessage.sendMessage();
                Response.Redirect("ProfileMessages.aspx?Box=Out");
            }
        }
    }
}