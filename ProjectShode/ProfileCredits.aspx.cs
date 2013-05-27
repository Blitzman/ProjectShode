using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ShodeLibrary;

namespace Project_Shode
{
    public partial class ProfileCredits : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserNickname"] == null)
                Response.Redirect("Login.aspx");
        }

        protected void addCredits(object sender, EventArgs e)
        {
            Button b = sender as Button;
            float credits = float.Parse(b.CommandArgument.ToString());

            UserBE user = new UserBE();
            user.Nickname = Session["UserNickname"].ToString();
            user = user.getUserByNick();

            user.Credit += credits;
            user.update();

            user = user.getUserByNick();
            labelCredits.Text = credits.ToString() + " Credits Added! Now you have " + user.Credit.ToString() + " credits!";
        }
    }
}