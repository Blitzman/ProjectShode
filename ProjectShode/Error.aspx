<%@ Page Title="Shode | Error" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" 
CodeBehind="Error.aspx.cs" Inherits="Project_Shode.Error" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section id="Error">
        <asp:Label ID="Main" Width="700px" Font-Size="50px" runat="server" BackColor="White" ForeColor="#F0AA0F" 
            Font-Names="Segoe UI" Text="Sorry, something went wrong!" CssClass="showMessage"/>
        <asp:Label ID="Label1" Width="700px" Font-Size="17px" runat="server" BackColor="White" ForeColor="Black"
            Font-Names="Segoe UI" Text="A team of highly trained monkeys has been dispatched to deal with this situation." 
            CssClass="showMessage"/>
    </section>
        <asp:Image ID="monkeys" runat="server" ImageUrl="~/Images/infinitos_monos.jpg" CssClass="showMessage"/>
</asp:Content>

