<%@ Page Title="" Language="C#" MasterPageFile="~/Profile.master" AutoEventWireup="true" 
CodeBehind="ProfileDevelopments.aspx.cs" Inherits="Project_Shode.ProfileDevelopments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProfile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProfile" runat="server">
    <asp:Label ID="Developments" runat="server" Text="My Developments" CssClass="contentTitle"></asp:Label>
    <section id="profileSection">
        <asp:BulletedList ID="DevelopmentList"
                DisplayMode="Text"
                runat="server" BulletStyle="Disc">
        <%-- The bulleted list items will be introduced by coding, however this is a good example to show. --%>
        <asp:ListItem Value="[dd/mm/yy] [rate %] development xxxxx on project yyyyy"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] [rate %] development xxxxx on project yyyyy"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] [rate %] development xxxxx on project yyyyy"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] [rate %] development xxxxx on project yyyyy"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] [rate %] development xxxxx on project yyyyy"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] [rate %] development xxxxx on project yyyyy"></asp:ListItem>
        </asp:BulletedList>
    </section>
</asp:Content>
