using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Shode
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                UserLink.Text = "Welcome, " + Session["Username"].ToString() + " |";
                LogOutLink.Text = "Log Out";
                LoginLink.Visible = false;
                SignupLink.Visible = false;
                LogInMotivator.Visible = false;
            }
            else
            {
            UserLink.Visible = false;
            LogOutLink.Visible = false;
            SignupLink.Visible = true;
            LoginLink.Visible = true;
            LogInMotivator.Visible = true;
            }
        }

        protected void logOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}
