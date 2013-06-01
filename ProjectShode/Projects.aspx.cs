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
    public partial class Projects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Global.search = "";
                //Maybe you entered the web on 19th 23:59 and you are at Search at 00:01. We must update the day the first time.
                Global.day = DateTime.Today.ToString("dd"); 
                DataSet d = new DataSet();
                String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
                SqlConnection c = new SqlConnection(s);
                SqlDataAdapter da = new SqlDataAdapter("Select code, title, nickname, " +
                    " creation_date, total_bank, state from projects, users where " + "projects.creator=users.email and " + 
                    "creation_date like '" + Global.day.ToString() + "%'", c);
                da.Fill(d, "projects");

                gridResults.DataSource = d;
                gridResults.DataBind();
                projectsResultsLabel.Text = "Most Recent Projects";
            }
        }

        protected void startSearch(object sender, EventArgs e)
        {
            string search = searchTextbox.Text;

            if (search.Length == 0 || search.Contains('=') || search.Contains('*') ||
                search.Contains('>') || search.Contains('<') || search.Contains('$'))
            {
                searchError.Visible = true;
            }
            else
            {
                Global.search = search;
                searchError.Visible = false;

                DataSet d = new DataSet();
                String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
                SqlConnection c = new SqlConnection(s);
                SqlDataAdapter da = new SqlDataAdapter("Select code, title, nickname, " +
                    " creation_date, total_bank, state from projects, users " +
                    " where title like '%" + search + "%' and projects.creator=users.email", c);
                da.Fill(d, "projects");

                gridResults.PageIndex = 0;
                gridResults.DataSource = d;
                gridResults.DataBind();
                projectsResultsLabel.Text = "'" + search + "'";
            }
        }

        protected void resultsPageChanging(object sender, GridViewPageEventArgs e)
        {
            string search = Global.search;
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da;

            if (search.Length == 0)
            {
                da = new SqlDataAdapter("Select code, title, nickname, " +
                    " creation_date, total_bank, state from projects, users where creation_date like '" + Global.day + "%'" +
                " and projects.creator=users.email", c);
            }
            else if (search == "$")
            {
                da = new SqlDataAdapter("Select code, title, nickname, " +
                " creation_date, total_bank, state from projects, users " +
                " where total_bank >=(select 0.9*max(total_bank) from projects) and projects.creator=users.email", c);
            }
            else
            {
                da = new SqlDataAdapter("Select code, title, nickname, " +
                    " creation_date, total_bank, state from projects " +
                    " where title like '%" + Global.search + "%' and projects.creator=users.email", c);
            }

            da.Fill(d, "projects");
            gridResults.PageIndex = e.NewPageIndex;
            gridResults.DataSource = d;
            gridResults.DataBind();
        }

        protected void searchMostPopular(object sender, EventArgs e)
        {
            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("Select code, title, nickname, " +
                " creation_date, total_bank, state from projects, users " +
                " where total_bank >=(select 0.9*max(total_bank) from projects) and projects.creator=users.email", c);
            da.Fill(d, "projects");

            gridResults.PageIndex = 0;
            gridResults.DataSource = d;
            gridResults.DataBind();
            projectsResultsLabel.Text = "Most Populars";
            Global.search = "$";
        }
    }
}