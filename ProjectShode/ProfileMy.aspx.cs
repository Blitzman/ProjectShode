using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Shode
{
    public partial class ProfileMy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserNickname"] != null)
            {
                Username.Text = Session["UserNickname"].ToString();
                userCredits.Text = Session["UserCredit"].ToString();

                ProfileImage.ImageUrl = "/Uploads/" + Session["UserNickname"].ToString() + "_pict.jpg";
            }
        }
    }
}