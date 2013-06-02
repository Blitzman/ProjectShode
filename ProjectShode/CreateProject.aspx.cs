using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ShodeLibrary;

namespace Project_Shode
{
    public partial class CreateProject : System.Web.UI.Page
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
                creditsFeedback.Visible = false;
            }
        }

        protected void create_Project(object sender, EventArgs e)
        {
            bool correct = true;

            if (creditsTextboxProject.Text.Length == 0 ||
                Int32.Parse(creditsTextboxProject.Text) > Int32.Parse(Session["UserCredit"].ToString()))
            {
                creditsFeedback.Visible = true;
                correct = false;
            }
            else
                creditsFeedback.Text = "";

            if (correct)
            {
                //Project information.
                String tittle = tittleProjectTextbox.Text;
                String description = descriptionTextbox.Text;
                UserBE user1 = new UserBE("", 0, "", "", Session["UserNickname"].ToString(), "");
                UserBE creator = new UserBE(user1.getUserByNick());
                int code = -1;
                DateTime creation = DateTime.Now;
                DateTime expires = DateTime.MinValue;
                int credit = Int32.Parse(creditsTextboxProject.Text);
                DateTime version = DateTime.Now;
                String gitDir = "There";

                //Update the UserBE credits and also the Sessión value.
                String currentCredits = Session["UserCredit"].ToString();
                Session["UserCredit"] = Int32.Parse(currentCredits) - credit;
                creator.Credit = Int32.Parse(currentCredits) - credit;
                creator.update();

                //Project creation.
                ProjectBE crProject = new ProjectBE(tittle, description, creator, code,
                    creation, expires, credit, credit, version, gitDir);
                crProject.create();
                crProject.Code = crProject.getLastCode();

                //When you create a project, you are contributing to it.
                ContributionBE contribution = new ContributionBE(creator, crProject, credit, DateTime.Now);
                contribution.create();

                creationFeedback.Text = "Project created successfully!";
                creationFeedback.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}