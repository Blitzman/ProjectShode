﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

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

            HttpCookie userCookie = Request.Cookies["UserNickname"];

            if (userCookie != null)
                SiteMaster.loadCookie(userCookie);

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
            Session["ProjectTitle"] = projectTitle;
            int projectCode = Int32.Parse(Request.QueryString["Code"].ToString());
            Session["ProjectCode"] = projectCode;

            //Create a project and look for the one we are being asked.
            ProjectBE project = new ProjectBE();
            project.Code = projectCode;
            project = project.getByCode();

            //If we get something different from the database, or nothing: error.
            //The code and the title must match. Otherwise, the user is playing with the URL.
            if (project.Code != projectCode || project.Title != projectTitle)
            {
                Session["ProjectTitle"] = null;
                Session["ProjectCode"] = null;
                Response.Redirect("Default.aspx");
            }

            //We need this so we get the nickname and we do not show the user's email to the public.
            UserBE usuario = new UserBE();
            usuario.Email = project.Creator.Email;
            usuario = usuario.getUserByEmail();

            profileTittleLabel.Text = project.Title;
            projectProfileDescription.Text = project.Description;
            projectProfileLabelUser.Text = usuario.Nickname;
            projectProfileLabelDate.Text = project.CreationDate.ToString();
            projectProfileLabelState.Text = project.State.ToString();
            projectProfileLabelCredits.Text = project.Credit.ToString();

            //Project comments
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("Select nickname, date, comment from users, comments" +
                " where project=" + project.Code + " and comments.usr=users.email", c);
            da.Fill(d, "comments");

            gridComments.DataSource = d;
            gridComments.DataBind();

            Page.Title = project.Title;
        }

        protected void contribute(object sender, EventArgs e)
        {
            if (creditsBox.Text.Length > 2)
            {
                if (float.Parse(creditsBox.Text) <= float.Parse(Session["USerCredit"].ToString()))
                {
                    //Get the query string parameters.
                    string projectTitle = Session["ProjectTitle"].ToString();
                    int projectCode = Int32.Parse(Session["ProjectCode"].ToString());

                    //Create a project and look for the one we are being asked.
                    ProjectBE project = new ProjectBE();
                    project.Code = projectCode;
                    project = project.getByCode();

                    project.Credit = project.Credit + Int32.Parse(creditsBox.Text);

                    project.update();

                    //We need the user, so we update its credits.
                    UserBE usuario = new UserBE();
                    usuario.Email = project.Creator.Email;
                    usuario = usuario.getUserByEmail();
                    usuario.Credit = usuario.Credit - Int32.Parse(creditsBox.Text);
                    usuario.update();
                    Session["UserCredit"] = usuario.Credit;

                    //And we must also create the contribution entry.
                    ContributionBE contr = new ContributionBE(usuario, project, Int32.Parse(creditsBox.Text), DateTime.Now);
                    contr.create();

                    FeedbackCredit.Text = "Done!";
                    projectProfileLabelCredits.Text = project.Credit.ToString();
                    FeedbackCredit.Visible = true;
                }
                else
                {
                    FeedbackCredit.Text = "Wrong quantity.";
                    FeedbackCredit.Visible = true;
                }
            }
        }
        protected void pageChanging(object sender, GridViewPageEventArgs e)
        {
            //Get the query string parameters.
            string projectTitle = Session["ProjectTitle"].ToString();
            int projectCode = Int32.Parse(Session["ProjectCode"].ToString());

            //Create a project and look for the one we are being asked.
            ProjectBE project = new ProjectBE();
            project.Code = projectCode;
            project = project.getByCode();

            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("Select nickname, date, comment from users, comments" +
                " where project=" + project.Code + " and comments.usr=users.email", c);
            da.Fill(d, "comments");

            gridComments.PageIndex = e.NewPageIndex;
            gridComments.DataSource = d;
            gridComments.DataBind();
        }

        protected void uploadComment(object sender, EventArgs e)
        {
            //Get the query string parameters.
            string projectTitle = Session["ProjectTitle"].ToString();
            int projectCode = Int32.Parse(Session["ProjectCode"].ToString());

            //Create a project and look for the one we are being asked.
            ProjectBE project = new ProjectBE();
            project.Code = projectCode;
            project = project.getByCode();

            //If we get something different from the database, or nothing: error.
            //They could have change since we opened the page.
            if(project.Code!=projectCode || project.Title!=projectTitle)
                Response.Redirect("Default.aspx");

            //We need this so we get the nickname and we do not show the user's email to the public.
            UserBE writer = new UserBE();
            writer.Email = Session["UserEmail"].ToString();
            writer = writer.getUserByEmail();

            //Now we get the dateTime
            DateTime creationDate = DateTime.Now;

            //And the message content.
            String message = commentProjectText.Text;
  
            //Comment creation
            CommentBE crComment = new CommentBE(writer, project, creationDate, message);

            crComment.create();

            //Reload the page with the added comment.
            Response.Redirect(Request.RawUrl);
        }
    }
}