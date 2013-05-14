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
                Login1.FailureText = "The user exists";
            else
            {
                Login1.FailureText = "The user or the password do not match";
            }
        }
    }
}