using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ShodeLibrary;

namespace Project_Shode
{
    public partial class ProjectProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //We need the title and the code. Otherwise the user must be playing with the URL.
            if (Request.QueryString["ProTitle"] == null || Request.QueryString["Code"] == null)
                Response.Redirect("Default.aspx");

            if (Session["UserNickname"] == null)
            {
                GiveLabel.Visible = false;
                creditsBox.Visible = false;
                sendCredits.Visible = false;
                checkCredtisProfile.Visible = false;
                developLinkImage.Visible = false;
                developLink.Visible = false;
            }

            FeedbackCredit.Visible = false;

            //Get the query string parameters.
            string projectTitle = Request.QueryString["ProTitle"].ToString();
            int projectCode = Int32.Parse(Request.QueryString["Code"].ToString());

            //Create a project and look for the one we are being asked.
            ProjectBE project = new ProjectBE();
            project.Code = projectCode;
            project = project.getByCode();

            //If we get something different from the database, or nothing: error.
            //The code and the title must match. Otherwise, the user is playing with the URL.
            if(project.Code!=projectCode || project.Title!=projectTitle)
                Response.Redirect("Default.aspx");

            //We need this so we get the nickname and we do not show the user's email to the public.
            UserBE usuario = new UserBE();
            usuario.Email = project.Creator.Email;
            usuario = usuario.getUserByEmail();

            profileTittleLabel.Text = project.Title;
            projectProfileDescription.Text = project.Description;
            projectProfileLabelUser.Text = usuario.Nickname;
            projectProfileLabelDate.Text = project.CreationDate.ToString();
            projectProfileLabelState.Text = project.State.ToString();
            //projectProfileLabelCredits.Text = project.Credit.toString();
            projectProfileLabelCredits.Text = "TODO";
        }

        protected void contribute(object sender, EventArgs e)
        {
            if (creditsBox.Text.Length > 2)
            {
                if (float.Parse(creditsBox.Text) <= float.Parse(Session["USerCredit"].ToString()))
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