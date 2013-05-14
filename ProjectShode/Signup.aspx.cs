using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using ShodeLibrary;

namespace Project_Shode
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
                Response.Redirect("Profiles.aspx");     
        }

        protected void createUserClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            String name="", lastName="", userName="", password="", email="";

            name = Name.Text;
            lastName = LastName.Text;
            userName = UserNameBox.Text;
            password = Password.Text;
            email = Email.Text;

            UserBE usuario = new UserBE(name, lastName, "", "", email, userName, password);
            resultLabel.Text = usuario.create();
        }
    }
}