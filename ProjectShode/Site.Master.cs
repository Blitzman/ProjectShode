using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ShodeLibrary;

namespace Project_Shode
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserNickname"];

            if (userCookie != null)
            {
                if (Session["UserName"] == null)
                    loadCookie(userCookie);

                UserLink.Text = "Welcome, " + Session["UserNickname"].ToString();
                LogOutLink.Text = "Log Out";
                LoginLink.Visible = false;
                SignupLink.Visible = false;
                LogInMotivator.Visible = false;
                OpenCorchete.Visible = false;
                CloseCorchete.Visible = false;
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

        protected void loadCookie(HttpCookie userCookie)
        {
            UserBE user1 = new UserBE("", "", "", "", "", userCookie.Value, "");
            UserBE user = new UserBE(user1.getUserByNick());

            Session["UserNickname"] = user.Nickname;
            Session["UserName"] = user.Name;
            Session["UserLastname"] = user.LastName;
            Session["UserAddress"] = user.Address;
            Session["UserZipcode"] = user.Zipcode;
            Session["UserEmail"] = user.Email;
            Session["UserCredit"] = user.Credit;
            Session["UserLastcon"] = user.LastConnection;
            Session["UserProfpict"] = user.ProfilePicture;
        }

        protected void logOut(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.RemoveAll();
            Session.Clear();

            HttpCookie userOut = new HttpCookie("UserNickname");
            userOut.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(userOut);

            Response.Redirect("Login.aspx");
        }
    }
}
