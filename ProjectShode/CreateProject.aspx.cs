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
                float.Parse(creditsTextboxProject.Text) > float.Parse(Session["UserCredit"].ToString()))
            {
                creditsFeedback.Visible = true;
                correct = false;
            }
            else
                creditsFeedback.Text = "";

            if (correct)
            {
                String tittle = tittleProjectTextbox.Text;
                String description = descriptionTextbox.Text;
                UserBE user1 = new UserBE("", "", "", "", "", Session["UserNickname"].ToString(), "");
                UserBE creator = new UserBE(user1.getUserByNick());
                int code = -1;
                DateTime creation = DateTime.Now;
                DateTime expires = DateTime.MinValue;
                float credit = float.Parse(creditsTextboxProject.Text);
                DateTime version = DateTime.Now;
                String gitDir = "There";
                
                //Update the UserBE credits and also the Sessión value.
                String currentCredits = Session["UserCredit"].ToString();
                Session["UserCredit"]=float.Parse(currentCredits)-credit;
                creator.Credit = float.Parse(currentCredits)-credit;
                creator.update();

                ProjectBE crProject = new ProjectBE(tittle, description, creator, code,
                    creation, expires, credit, version, gitDir);

                crProject.create();

                creationFeedback.Text = "Project created successfully!";
                creationFeedback.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}