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
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lengthFeedback.Visible = false;
            messageFeedback.Visible = false;

            HttpCookie userCookie = Request.Cookies["UserNickname"];

            if (userCookie != null)
                SiteMaster.loadCookie(userCookie);

            if (Session["UserNickname"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if(!Page.IsPostBack)
            {
                if (Request.QueryString["ID"] != null)
                {
                    new MessageDAC();
                    MessageBE message = MessageDAC.getMessage(int.Parse(Request.QueryString["ID"]));

                    UserBE user1 = new UserBE("", 0, "", "", Session["UserNickname"].ToString(), "");
                    UserBE currentUser = new UserBE(user1.getUserByNick());

                    if (currentUser.Email != "" && currentUser.Email != null && message.Sender != null && message.Addressee != null)
                    {
                        if (message.Sender.Email == currentUser.Email || message.Addressee.Email == currentUser.Email)
                        {
                            DataSet d = new DataSet();
                            String s = ConfigurationManager.ConnectionStrings["ShodeDDBB"].ToString();
                            SqlConnection c = new SqlConnection(s);
                            SqlDataAdapter da = new SqlDataAdapter("SELECT u1.nickname AS Sender, u2.nickname as Addressee, SUBSTRING(body, 1, 30) as Body, date as Date, code as Code, isRead as IsRead " +
                                "FROM message, users u1, users u2 WHERE convers_code = " + message.ConversCode.ToString() + "AND code < " + message.code.ToString() +
                                " AND u1.email = sender AND u2.email = addressee ORDER BY code ASC", c);
                            da.Fill(d, "message");

                            gridBefore.DataSource = d;
                            gridBefore.DataBind();

                            d = new DataSet();
                            da = new SqlDataAdapter("SELECT u1.nickname AS Sender, u2.nickname as Addressee, SUBSTRING(body, 1, 30) as Body, date as Date, code as Code, isRead as IsRead " +
                                "FROM message, users u1, users u2 WHERE convers_code = " + message.ConversCode.ToString() + "AND code > " + message.code.ToString() +
                                " AND u1.email = sender AND u2.email = addressee ORDER BY code ASC", c);
                            da.Fill(d, "message");

                            gridAfter.DataSource = d;
                            gridAfter.DataBind();

                            c.Close();

                            EmisorM.Text = "From:  " + message.Sender.Nickname;
                            ReceptorM.Text = "To:  " + message.Addressee.Nickname;
                            FechaM.Text = "Date:  " + message.Date.ToString();
                            AsuntoM.Text = message.Subject;
                            TextoM.Text = message.Message;

                            if (message.Addressee.Email != currentUser.Email)
                                replyButton.Visible = false;
                            else
                                message.openMessage();
                        }
                        else
                        {
                            ErrorM.Visible = true;
                            ErrorM.Text = "This one is not one of your messages. You shouldn't be here.";
                            hideElements();
                        }
                    }
                    else
                    {
                        ErrorM.Visible = true;
                        ErrorM.Text = "This message doesn't exist. You shouldn't be here.";
                        hideElements();
                    }
                }
                else
                {
                    hideElements();
                }
            }
        }

        protected void hideElements()
        {
            ErrorM.Visible = false;
            EmisorM.Visible = false;
            ReceptorM.Visible = false;
            FechaM.Visible = false;
            AsuntoM.Visible = false;
            TextoM.Visible = false;
            replyButton.Visible = false;
            textmessage.Visible = false;
            sendButton.Visible = false;
            messageFeedback.Visible = false;
            lengthFeedback.Visible = false;
            gridAfter.Visible = false;
            gridBefore.Visible = false;
        }

        protected void grid_RowCommand(int code)
        {
            new MessageDAC();
            MessageBE message = MessageDAC.getMessage(code);

            UserBE user1 = new UserBE("", 0, "", "", Session["UserNickname"].ToString(), "");
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

        protected void gridBefore_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            // Convert the row index stored in the CommandArgument
            // property to an Integer.
            int index = Convert.ToInt32(e.CommandArgument);

            // Get the last name of the selected author from the appropriate
            // cell in the GridView control.
            GridViewRow selectedRow = gridBefore.Rows[index];
            TableCell codeCell = selectedRow.Cells[5];
            int code = int.Parse(codeCell.Text);
            grid_RowCommand(code);
        }

        protected void gridAfter_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            // Convert the row index stored in the CommandArgument
            // property to an Integer.
            int index = Convert.ToInt32(e.CommandArgument);

            // Get the last name of the selected author from the appropriate
            // cell in the GridView control.
            GridViewRow selectedRow = gridAfter.Rows[index];
            TableCell codeCell = selectedRow.Cells[5];
            int code = int.Parse(codeCell.Text);
            grid_RowCommand(code);
        }

        protected void reply_Message(object sender, EventArgs e)
        {
            bool correct = true;

            new MessageDAC();
            MessageBE message = MessageDAC.getMessage(int.Parse(Request.QueryString["ID"]));
            if (message.Sender == null || message.Addressee == null)
            {
                correct = false;
            }

            if (textmessage.Text.Length == 0)
            {
                messageFeedback.Visible = true;
                correct = false;
            }
            else if (textmessage.Text.Length > 1000)
            {
                lengthFeedback.Visible = true;
                lengthFeedback.Text = "The message is too long! Delete " + (textmessage.Text.Length - 1000).ToString() + " characters.";
                correct = false;
            }
            if (correct)
            {
                String subject = message.Subject;
                String body = textmessage.Text;
                DateTime date = DateTime.Now;

                UserBE sender1 = message.Addressee;
                UserBE addressee = message.Sender;

                MessageBE sndMessage = new MessageBE(sender1, addressee, date, subject, body);

                sndMessage.replyMessage(message);
                Response.Redirect("ProfileMessages.aspx?Box=Out");
            }
        }

        protected void openTextBox(object sender, EventArgs e)
        {
            if (!textmessage.Visible)
            {
                textmessage.Visible = true;
                sendButton.Visible = true;
            }
            else
            {
                textmessage.Visible = false;
                sendButton.Visible = false;
            }
        }
    }
}