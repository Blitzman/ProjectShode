using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                DataSet d = new DataSet();
                String s = "data source=.\\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\\ShodeDatabase.mdf;User Instance=true";
                SqlConnection c = new SqlConnection(s);
                SqlDataAdapter da = new SqlDataAdapter("Select title as Tittle, creator as Creator,"+
                    " creation_date as StartedOn, total_bank as Total, state as State from projects", c);
                da.Fill(d, "projects");

                gridResults.DataSource = d;
                gridResults.DataBind();
            }
        }

        protected void startSearch(object sender, EventArgs e)
        {
            String search = searchTextbox.Text;

            if (search.Length == 0 || search.Contains('=') || search.Contains('*') ||
                search.Contains('>') || search.Contains('<'))
            {
                searchError.Visible = true;
            }
            else
            {
                searchError.Visible = false;
            }
        }
    }
}