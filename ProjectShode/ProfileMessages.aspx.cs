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
    public partial class ProfileMessages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserNickname"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else 
            {
                if (!Page.IsPostBack)
                {
                    UserBE user1 = new UserBE("", "", "", "", "", Session["UserNickname"].ToString(), "");
                    UserBE addressee = new UserBE(user1.getUserByNick());

                    DataSet d = new DataSet();
                    String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
                    SqlConnection c = new SqlConnection(s);
                    SqlDataAdapter da = new SqlDataAdapter("SELECT sender as Sender, issue as Subject, date as Date, isRead as IsRead FROM message WHERE addressee = '" +
                        addressee.Email + "' AND deleted_reader = 0", c);
                    da.Fill(d, "message");

                    gridResults.DataSource = d;
                    gridResults.DataBind();
                }
            }
        }

        protected void resultsPageChanging(object sender, GridViewPageEventArgs e)
        {
            UserBE user1 = new UserBE("", "", "", "", "", Session["UserNickname"].ToString(), "");
            UserBE addressee = new UserBE(user1.getUserByNick());

            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);

            SqlDataAdapter da = new SqlDataAdapter("SELECT sender as Sender, issue as Subject, date as Date, isRead as IsRead FROM message WHERE addressee = '" +
                        addressee.Nickname + "' AND deleted_reader = 0", c);

            da.Fill(d, "message");
            gridResults.PageIndex = e.NewPageIndex;
            gridResults.DataSource = d;
            gridResults.DataBind();
        }
    }
}