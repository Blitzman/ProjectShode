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
            if(Session["Username"]!=null)
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
                Session["Username"] = user.Nickname;
                Session["Name"] = user.Name;
                Session["Lastname"] = user.LastName;
                Session["Address"]=user.Address;
                Session["Zipcode"]=user.Zipcode;
                Session["Email"] = user.Email;
                Session["Credit"] = user.Credit;
                Session["Lastcon"]=user.LastConnection;
                Session["Profpict"]=user.ProfilePicture;

                Session.Timeout = 5;
                Response.Redirect("Default.aspx");
            }
            else
            {
                Login1.FailureText = "The user or the password do not match";
            }
        }
    }
}