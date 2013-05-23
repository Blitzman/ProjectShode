<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs" Inherits="Project_Shode.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <section id="location">
        <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx">Shode</asp:HyperLink> > 
        <asp:HyperLink runat="server" NavigateUrl="~/Login.aspx">Log In</asp:HyperLink>
    </section>
    <h2>
        Enter your profile data to logging in:
    </h2>
    <p>
        <asp:Login ID="Login1" runat="server"
            CssClass="LoginSignup"
            BackColor="#24242C"
            PasswordLabelText="Password"
            UserNameLabelText= "User Name"
            Width="350px"
            Font-Bold="True"
            ForeColor= "#FFFFFF"
            LoginButtonText="Log In"
            Font-Names= "Segoe UI" OnLoggingIn="logIn"  
        >
        <LoginButtonStyle CssClass="ButtonLogSign" Width="75px" Font-Bold="True" Font-Names="Segoe UI"/>

        <TextBoxStyle CssClass="TextBoxLogSign"/>
        <TitleTextStyle ForeColor="#24242C" />

        </asp:Login>
    </p>
</asp:Content>