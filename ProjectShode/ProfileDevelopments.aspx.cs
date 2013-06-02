using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;

using ShodeLibrary;

namespace Project_Shode
{
    public partial class ProfileDevelopments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserNickname"];

            if (userCookie != null)
                SiteMaster.loadCookie(userCookie);

            if (Session["UserNickname"] != null)
            {
                gridDev.DataSource = DevelopmentDAC.getUserDevelopments(Session["UserEmail"].ToString());
                gridDev.DataBind();
            }
        }

        protected void pageChanging(object sender, GridViewPageEventArgs e)
        {
            gridDev.PageIndex = e.NewPageIndex;
            gridDev.DataSource = DevelopmentDAC.getUserDevelopments(Session["UserEmail"].ToString());
            gridDev.DataBind();
        }
    }
}