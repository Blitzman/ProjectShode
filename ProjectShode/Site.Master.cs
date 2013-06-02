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

            totalProjects.Text = StatisticalSingleton.Instance.getTotalProjects().ToString();
            totalCredits.Text = StatisticalSingleton.Instance.getTotalCreditsInProjects().ToString();
            totalDevelopments.Text = StatisticalSingleton.Instance.getTotalDevelopments().ToString();
            totalContributions.Text = StatisticalSingleton.Instance.getTotalContributions().ToString();
        }

       public static void loadCookie(HttpCookie userCookie)
        {
            UserBE user1 = new UserBE("", 0, "", "", userCookie.Value, "");
            UserBE user = new UserBE(user1.getUserByNick());

            HttpContext.Current.Session["UserNickname"] = user.Nickname;
            HttpContext.Current.Session["UserName"] = user.Name;
            HttpContext.Current.Session["UserLastname"] = user.LastName;
            HttpContext.Current.Session["UserEmail"] = user.Email;
            HttpContext.Current.Session["UserCredit"] = user.Credit;
            HttpContext.Current.Session["UserProfpict"] = user.ProfilePicture;
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
