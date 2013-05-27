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
            if (Session["UserNickname"] == null)
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
                UserBE creator = new UserBE(Session["UserName"].ToString(),
                    Session["UserLastname"].ToString(), Session["UserAddress"].ToString(),
                    Session["UserZipcode"].ToString(), Session["UserEmail"].ToString(),
                    Session["UserNickname"].ToString(), "security");
                creator.Password = creator.getUserByNick().Password;
                String code = "111";
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

                sendProject.Text = creator.Credit.ToString();
                //crProject.create();
            }
        }
    }
}