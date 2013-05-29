using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.Security;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

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

        protected void FileUploadComplete(object sender, EventArgs e)
        {
            string filename = System.IO.Path.GetFileName(AsyncFileUpload1.FileName);
            AsyncFileUpload1.SaveAs(Server.MapPath("Uploads/") + filename);
        }

        protected void createUserClick(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            String name = "", lastName = "", userName = "", password = "", email = "", gender = "";

            name = Name.Text;
            lastName = LastName.Text;
            userName = UserNameBox.Text;
            password = Password.Text;
            email = Email.Text;
            gender = MaleFemale.SelectedValue.ToString();

            UserBE usuario = new UserBE(name, lastName, " ", " ", email, userName, password);
            resultLabel.Text = usuario.create();
        }

        
    }
}