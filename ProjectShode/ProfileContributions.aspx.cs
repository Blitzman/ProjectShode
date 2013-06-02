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
                DataSet d = new DataSet();
                String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
                SqlConnection c = new SqlConnection(s);
                SqlDataAdapter da = new SqlDataAdapter("Select code, title, date, amount from contributions, projects" +
                    " where projects.code=contributions.project and usr='" + Session["UserEmail"].ToString() +
                    "' order by date DESC", c);
                da.Fill(d, "contributions");

                gridContr.DataSource = d;
                gridContr.DataBind();
            }
        }

        protected void pageChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("Select code, title, date, amount from contributions, projects" +
                " where projects.code=contributions.project and usr='" + Session["UserEmail"].ToString() +
                "' order by date DESC", c);
            da.Fill(d, "contributions");

            gridContr.PageIndex = e.NewPageIndex;
            gridContr.DataSource = d;
            gridContr.DataBind();
        }
    }
}