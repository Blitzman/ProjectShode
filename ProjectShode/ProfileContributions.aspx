<%@ Page Title="" Language="C#" MasterPageFile="~/Profile.master" AutoEventWireup="true" 
CodeBehind="ProfileContributions.aspx.cs" Inherits="Project_Shode.ProfileContributions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProfile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProfile" runat="server">
    <asp:Label ID="Contributions" runat="server" Text="My Contributions" CssClass="contentTitle"></asp:Label>
    <section id="profileSection">
        <asp:BulletedList ID="ContributionsList"
                
                DisplayMode="Text"
                runat="server" BulletStyle="Disc">
        <%-- The bulleted list items will be introduced by coding, however this is a good example to show. --%>
        <asp:ListItem Value="[dd/mm/yy] xxxx Credits contributed on yyyyy Project by zzzzzz"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] xxxx Credits contributed on yyyyy Project by zzzzzz"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] xxxx Credits contributed on yyyyy Project by zzzzzz"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] xxxx Credits contributed on yyyyy Project by zzzzzz"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] xxxx Credits contributed on yyyyy Project by zzzzzz"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] xxxx Credits contributed on yyyyy Project by zzzzzz"></asp:ListItem>
        </asp:BulletedList>
    </section>
</asp:Content>
