using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ShodeLibrary;

namespace Project_Shode
{
    public partial class ProfileMy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserNickname"];

            if (userCookie != null)
                SiteMaster.loadCookie(userCookie);

            if (Session["UserName"] == null)
                Response.Redirect("Default.aspx");

            //If there is a cookie, the user can access to the profile.
            Username.Text = Session["UserNickname"].ToString();
            userCredits.Text = Session["UserCredit"].ToString();

            //Load the user profile picture.
            ProfileImage.ImageUrl = "/Uploads/" + Session["UserNickname"].ToString() + "_pict.jpg";

            //Load the amount of developments and contributions.
            userDevelopments.Text = DevelopmentDAC.getTotalUserDevelopments(Session["UserEmail"].ToString()).ToString();
            userContributions.Text = ContributionDAC.getTotalUserContributions(Session["UserEmail"].ToString()).ToString();

            //Load the top contributions: high amount.
            gridContr.DataSource = ContributionDAC.getUserTopContributions(Session["UserEmail"].ToString());
            gridContr.DataBind();

            //Load the top developments: high positive votes.
            gridDev.DataSource = DevelopmentDAC.getUserTopDevelopments(Session["UserEmail"].ToString());
            gridDev.DataBind();
        }
    }
}