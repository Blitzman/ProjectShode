using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Shode
{
    public partial class ProjectProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                GiveLabel.Visible = false;
                creditsBox.Visible = false;
                FeedbackCredit.Visible = false;
                sendCredits.Visible = false;
                checkCredtisProfile.Visible = false;
                developLinkImage.Visible = false;
                developLink.Visible = false;
            }
        }

        protected void contribute(object sender, EventArgs e)
        {
            if (creditsBox.Text.Length > 2)
            {
                if (Int32.Parse(creditsBox.Text) <= Int32.Parse(Session["Credit"].ToString()))
                {
                    FeedbackCredit.Text = "Done!";
                    FeedbackCredit.Visible = true;
                }
                else
                {
                    FeedbackCredit.Text = "Wrong number";
                    FeedbackCredit.Visible = true;
                }
            }
        }
    }
}