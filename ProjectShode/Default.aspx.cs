using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project_Shode
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void TimerTweet_Tick(object sender, EventArgs e)
        {
            try
            {
                DateTime.Now.ToLongTimeString();
            }
            catch (Exception)
            {

            }
        }
    }
}
