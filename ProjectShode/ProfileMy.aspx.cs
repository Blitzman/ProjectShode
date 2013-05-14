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
            Username.Text = Session["Username"].ToString();
            userCredits.Text = Session["Credit"].ToString();
        }
    }
}