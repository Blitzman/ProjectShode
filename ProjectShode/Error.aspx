<%@ Page Title="Shode | Error" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
CodeBehind="Error.aspx.cs" Inherits="Project_Shode.Error" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="Error">
        <asp:Label ID="Main" Width="700px" Font-Size="70px" runat="server" BackColor="White" ForeColor="#F0AA0F" 
            Font-Names="Segoe UI" Text="Error!" CssClass="showMessage"/>
        <asp:Label ID="Label1" Width="700px" Font-Size="35px" runat="server" BackColor="White" ForeColor="Black"
            Font-Names="Segoe UI" Text="What are you doing? Are you trying to break down the application?" CssClass="showMessage"/>
    </section>
</asp:Content>

