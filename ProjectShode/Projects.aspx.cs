using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Shode
{
    public partial class Projects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void startSearch(object sender, EventArgs e)
        {
            String search = searchTextbox.Text;

            if (search.Length == 0 || search.Contains('='))
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