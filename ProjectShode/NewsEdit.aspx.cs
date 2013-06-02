using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ShodeLibrary;

namespace Project_Shode
{
    public partial class NewsEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //We need the title and the code. Otherwise the user must be playing with the URL.
                if (Request.QueryString["code"] != null)
                {
                    NewsBE en = new NewsBE();
                    en = en.getByCode(Int32.Parse(Request.QueryString["code"]));
                    TitleTB.Text = en.Title;
                    ContentTB.Text = en.Content;
                }


                HttpCookie userCookie = Request.Cookies["UserNickname"];

                if (userCookie != null)
                    SiteMaster.loadCookie(userCookie);
            }
        }

        protected void update_News(object sender, EventArgs e)
        {
         
                NewsBE news = new NewsBE();
                news.Title = TitleTB.Text;
                news.Code =  Int32.Parse(Request.QueryString["code"]); 
                news.Content = ContentTB.Text;
                //Update the UserBE credits and also the Sessión value.
             
                news.update();
                Response.Redirect("NewsAdmin.aspx");
        }
    }
}
