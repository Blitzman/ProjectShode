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
                DataSet d = new DataSet();
                String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
                SqlConnection c = new SqlConnection(s);
                SqlDataAdapter da = new SqlDataAdapter("Select code, title, date, gitbranch, ups from developments, projects" +
                    " where projects.code=developments.project and usr='" + Session["UserEmail"].ToString() +
                    "' order by date DESC", c);
                da.Fill(d, "developments");

                gridDev.DataSource = d;
                gridDev.DataBind();
            }
        }

        protected void pageChanging(object sender, GridViewPageEventArgs e)
        {
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("Select code, title, date, gitbranch, ups from developments, projects" +
                " where projects.code=developments.project and usr='" + Session["UserEmail"].ToString() +
                "' order by date DESC", c);
            da.Fill(d, "contributions");

            gridDev.PageIndex = e.NewPageIndex;
            gridDev.DataSource = d;
            gridDev.DataBind();
        }
    }
}