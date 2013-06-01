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
            HttpCookie userCookie = Request.Cookies["UserNickname"];

            if (userCookie != null)
                SiteMaster.loadCookie(userCookie);

            if (Session["UserNickname"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                orderAddre.Visible = false;
                if (Request.QueryString["Box"] == "Out")
                {
                    Messages.Text = "Outbox";
                    orderAddre.Visible = true;
                    orderSender.Visible = false;
                }
                Cabecera.Visible = false;
                Emisor.Visible = false;
                Fecha.Visible = false;
                Asunto.Visible = false;
                Texto.Visible = false;

                if (!Page.IsPostBack)
                {
                    Load_Grid();
                }
            }
        }

        protected void orderCode(object sender, EventArgs e)
        {
            if (Request.QueryString["Box"] == "Out")
            {
                if (Request.QueryString["Order"] == null)
                    Response.Redirect("ProfileMessages.aspx?Box=Out&Order=code_ASC");
                else
                    Response.Redirect("ProfileMessages.aspx?Box=Out");
            }
            else
            {
                if (Request.QueryString["Order"] == null)
                    Response.Redirect("ProfileMessages.aspx?Box=In&Order=code_ASC");
                else
                    Response.Redirect("ProfileMessages.aspx?Box=In");
            }
        }

        protected void orderSend(object sender, EventArgs e)
        {
            Response.Redirect("ProfileMessages.aspx?Box=In&Order=sender");
        }

        protected void orderAddr(object sender, EventArgs e)
        {
            Response.Redirect("ProfileMessages.aspx?Box=Out&Order=addressee");
        }

        protected void orderRead(object sender, EventArgs e)
        {
            if (Request.QueryString["Box"] == "Out")
                Response.Redirect("ProfileMessages.aspx?Box=Out&Order=isread");
            else
                Response.Redirect("ProfileMessages.aspx?Box=In&Order=isread");
        }

        protected void Load_Grid()
        {
            String order = "code DESC";
            if (Request.QueryString["Order"] == "sender" && Request.QueryString["Box"] == "In")
            {
                order = "sender ASC, code DESC";
            }
            else if (Request.QueryString["Order"] == "addressee" && Request.QueryString["Box"] == "Out")
            {
                order = "addressee ASC, code DESC";
            }
            else if (Request.QueryString["Order"] == "isread")
            {
                order = "isread ASC, code DESC";
            }
            else if (Request.QueryString["Order"] == "code_ASC")
            {
                order = "code ASC";
            }

            UserBE user1 = new UserBE("", "", "", "", "", Session["UserNickname"].ToString(), "");
            UserBE currentUser = new UserBE(user1.getUserByNick());

            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);
            SqlDataAdapter da = new SqlDataAdapter("SELECT nickname as Sender, issue as Subject, date as Date, code as Code, isRead as IsRead FROM message, users WHERE addressee = '" +
                currentUser.Email + "' AND deleted_reader = 0 AND email = sender ORDER BY " + order, c);

            if (Request.QueryString["Box"] == "Out")
            {
                da = new SqlDataAdapter("SELECT nickname as Addressee, issue as Subject, date as Date, code as Code, isRead as IsRead FROM message, users WHERE sender = '" +
                currentUser.Email + "' AND deleted_sender = 0 AND email = addressee ORDER BY " + order, c);
            }
            da.Fill(d, "message");

            gridResults.DataSource = d;
            gridResults.DataBind();
            c.Close();
        }

        protected void resultsPageChanging(object sender, GridViewPageEventArgs e)
        {
            String order = "code DESC";

            if (Request.QueryString["Order"] == "sender" && Request.QueryString["Box"] == "In")
            {
                order = "sender ASC";
            }
            else if (Request.QueryString["Order"] == "addressee" && Request.QueryString["Box"] == "Out")
            {
                order = "addressee DESC";
            }
            else if (Request.QueryString["Order"] == "isread")
            {
                order = "isread ASC";
            }
            else if (Request.QueryString["Order"] == "code_ASC")
            {
                order = "code ASC";
            }

            UserBE user1 = new UserBE("", "", "", "", "", Session["UserNickname"].ToString(), "");
            UserBE currentUser = new UserBE(user1.getUserByNick());

            DataSet d = new DataSet();
            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
            SqlConnection c = new SqlConnection(s);

            SqlDataAdapter da = new SqlDataAdapter("SELECT nickname as Sender, issue as Subject, date as Date, code AS Code, isRead as IsRead FROM message, users WHERE addressee = '" +
                        currentUser.Email + "' AND deleted_reader = 0 AND email = sender ORDER BY " + order, c);

            if (Request.QueryString["Box"] == "Out")
            {
                da = new SqlDataAdapter("SELECT nickname as Addressee, issue as Subject, date as Date, code as Code, isRead as IsRead FROM message, users WHERE sender = '" +
                currentUser.Email + "' AND deleted_sender = 0 AND email = addressee ORDER BY " + order, c);
            }

            da.Fill(d, "message");
            gridResults.PageIndex = e.NewPageIndex;
            gridResults.DataSource = d;
            gridResults.DataBind();
            c.Close();
        }

        protected void gridResults_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            // Convert the row index stored in the CommandArgument
            // property to an Integer.
            int index = Convert.ToInt32(e.CommandArgument);

            // Get the last name of the selected author from the appropriate
            // cell in the GridView control.
            GridViewRow selectedRow = gridResults.Rows[index];
            TableCell codeCell = selectedRow.Cells[6];
            int code = int.Parse(codeCell.Text);

            new MessageDAC();
            MessageBE message = MessageDAC.getMessage(code);

            if (e.CommandName == "View")
            {
                Cabecera.Visible = true;
                Cabecera.Text = "Selected Message Preview:";
                Emisor.Visible = true;

                if (Request.QueryString["Box"] == "Out")
                    Emisor.Text = "To:  " + message.Addressee.Nickname;
                else
                    Emisor.Text = "From:  " + message.Sender.Nickname;

                Fecha.Visible = true;
                Fecha.Text = "Date:  " + message.Date.ToString();
                Asunto.Visible = true;
                Asunto.Text = message.Subject;
                Texto.Visible = true;
                Texto.Text = message.Message;

                if (!message.Read && Request.QueryString["Box"] == "In")
                {
                    message.openMessage();
                    Load_Grid();
                }
            }

            if (e.CommandName == "Delete")
            {
                UserBE user1 = new UserBE("", "", "", "", "", Session["UserNickname"].ToString(), "");
                UserBE currentUser = new UserBE(user1.getUserByNick());
                message.removeMessage(currentUser);

                if (Request.QueryString["Box"] == "Out")
                {
                    Response.Redirect("ProfileMessages.aspx?Box=Out");
                }
                else
                {
                    Response.Redirect("ProfileMessages.aspx?Box=In");
                }
            }
        }
    }
}