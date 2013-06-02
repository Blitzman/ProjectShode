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
    public partial class ProfileContributions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie userCookie = Request.Cookies["UserNickname"];

            if (userCookie != null)
                SiteMaster.loadCookie(userCookie);

            if (Session["UserNickname"] != null)
            {
                gridContr.DataSource = ContributionDAC.getUserContributions(Session["UserEmail"].ToString());
                gridContr.DataBind();
            }
        }

        protected void pageChanging(object sender, GridViewPageEventArgs e)
        {
            gridContr.PageIndex = e.NewPageIndex;
            gridContr.DataSource = ContributionDAC.getUserContributions(Session["UserEmail"].ToString()); ;
            gridContr.DataBind();
        }
    }
}