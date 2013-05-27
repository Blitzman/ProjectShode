using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Shode
{
    public partial class CreateProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
                Response.Redirect("Login.aspx");
            else
            {
                tittleFeedback.Visible = false;
                descriptionFeedback.Visible = false;
                creditsFeedback.Visible = false;
            }
        }

        protected void create_Project(object sender, EventArgs e)
        {
            bool correct = true;

            if (tittleProjectTextbox.Text.Length == 0)
            {
                tittleFeedback.Visible = true;
                correct = false;
            }

            if (descriptionTextbox.Text.Length == 0)
            {
                descriptionFeedback.Visible = true;
                correct = false;
            }
            else
                descriptionFeedback.Text = "";

            if (creditsTextboxProject.Text.Length == 0 ||
                Int32.Parse(creditsTextboxProject.Text) > Int32.Parse(Session["Credit"].ToString()))
            {
                creditsFeedback.Visible = true;
                correct = false;
            }
            else
                creditsFeedback.Text = "";

            if (correct)
                creditsFeedback.Text = "Everything ok";
        }
    }
}