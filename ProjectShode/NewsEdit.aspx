<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="Project_Shode.NewsEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<section class="edit_news">
    <asp:Label ID="createProjectTittle" runat="server" Text="Edit news item" 
       Font-Size=X-Large Font-Underline=true Height=75></asp:Label>
       <asp:Panel>
            <div class="clear"></div>    
            <asp:Label>Title:</asp:Label>
            <div class="clear"></div>
            <asp:TextBox ID="TitleTB" runat="server" MaxLength=64 
            Width=400px CssClass=TextBoxLogSign></asp:TextBox>
            <div class="clear"></div>
            <asp:Label>Content:</asp:Label>
            <div class="clear"></div><asp:TextBox ID="ContentTB" runat="server" MaxLength=1000 
             TextMode="MultiLine" Font-Names="Segoe UI" CssClass=TextBoxLogSign
             Wrap=true Width=600px Height=300px></asp:TextBox>
            <div class="clear"></div>
            <asp:Button runat="server" Text="Send" CssClass="ButtonShode" OnClick="update_News"></asp:Button>
            <div class="clear"></div>
        </asp:Panel>
    </section>
</asp:Content>
