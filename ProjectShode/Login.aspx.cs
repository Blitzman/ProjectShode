using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShodeLibrary;

namespace Project_Shode
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserNickname"];

            if (userCookie != null)
                SiteMaster.loadCookie(userCookie);

            if(Session["UserName"]!=null)
                Response.Redirect("Profiles.aspx");
        }

        protected void logIn(object sender, EventArgs e)
        {
            string nick = Login1.UserName;
            string password = Login1.Password;
            bool exists = false;

            UserBE user = new UserBE();
            user.Nickname = nick;
            user.Password = password;
            exists = user.verifyUser();
            

            if (exists)
            {
                HttpCookie userCookie = new HttpCookie("UserNickname", user.Nickname);
                userCookie.Expires = DateTime.Now.AddMonths(2);
                Response.Cookies.Add(userCookie);

                Response.Redirect("Default.aspx");
            }
            else
            {
                Login1.FailureText = "The user or the password do not match";
            }
        }
    }
}