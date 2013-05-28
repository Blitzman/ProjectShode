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
            if (Session["UserNickname"] == null)
                Response.Redirect("Login.aspx");
            else
            {
                userFeedback.Visible = false;
                subjectFeedback.Visible = false;
                messageFeedback.Visible = false;
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
            if (correct)
            {
                String subject = textsubject.Text;
                String message = textmessage.Text;
                DateTime date = DateTime.Now;

                UserBE user1 = new UserBE("", "", "", "", "", Session["UserNickname"].ToString(), "");
                UserBE sender1 = new UserBE(user1.getUserByNick());

                user1 = new UserBE("", "", "", "", "", textuserdest.Text, "");
                UserBE addressee = new UserBE(user1.getUserByNick());

                MessageBE sndMessage = new MessageBE(sender1, addressee, date, subject, message);

                sndMessage.sendMessage();
                Response.Redirect("ProfileMessages.aspx");
            }
        }
    }
}