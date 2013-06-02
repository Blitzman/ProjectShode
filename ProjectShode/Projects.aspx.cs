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
                Session["Search"] = "";
                //Maybe you entered the web on 19th 23:59 and you are at Search at 00:01. We must update the day the first time.
                Session["SearchDay"] = DateTime.Today.ToString("dd");

                gridResults.DataSource = ProjectDAC.getRecentProjects();
                gridResults.DataBind();
                projectsResultsLabel.Text = "Most Recent Projects";
            }
        }

        protected void startSearch(object sender, EventArgs e)
        {
            string search = searchTextbox.Text;
            Session["Search"] = search;

            gridResults.PageIndex = 0;
            gridResults.DataSource = ProjectDAC.searchProjects(search);
            gridResults.DataBind();
            projectsResultsLabel.Text = "'" + search + "'";
        }

        protected void resultsPageChanging(object sender, GridViewPageEventArgs e)
        {
            string search = Session["Search"].ToString();
            DataSet d;

            if (search.Length == 0)
            {
                d = ProjectDAC.getRecentProjects();
            }
            else if (search == "$")
            {
                d = ProjectDAC.getPopularProjects();
            }
            else
            {
                d = ProjectDAC.searchProjects(search);
            }

            gridResults.PageIndex = e.NewPageIndex;
            gridResults.DataSource = d;
            gridResults.DataBind();
        }

        protected void searchMostPopular(object sender, EventArgs e)
        {
            gridResults.PageIndex = 0;
            gridResults.DataSource = ProjectDAC.getPopularProjects();
            gridResults.DataBind();
            projectsResultsLabel.Text = "Most Populars";
            Session["Search"] = "$";
        }
    }
}