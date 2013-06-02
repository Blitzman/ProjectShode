using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ShodeLibrary;

namespace Project_Shode
{
    public partial class NewsCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void create_News(object sender, EventArgs e)
        {

            NewsBE news = new NewsBE();
            news.Title = TitleTB.Text;
            if (Request.QueryString["code"]!=null) news.Code = Int32.Parse(Request.QueryString["code"]);
            news.Content = ContentTB.Text;
            news.PublicationDate = DateTime.Now;
            UserBE user1 = new UserBE("", 0, "", "", Session["UserNickname"].ToString(), "");
            UserBE author = new UserBE(user1.getUserByNick());
            news.Author = author;

            news.create();
            Response.Redirect("NewsAdmin.aspx");
        }
    }
}