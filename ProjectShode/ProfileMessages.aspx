<%@ Page Title="" Language="C#" MasterPageFile="~/Profile.master" AutoEventWireup="true" CodeBehind="ProfileMessages.aspx.cs" Inherits="Project_Shode.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProfile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProfile" runat="server">
<asp:Label ID="Messages" runat="server" Text="Inbox" CssClass="contentTitle"></asp:Label>
    <section id="profileSection">
        <asp:BulletedList ID="PrivateMessages"
                DisplayMode="Text"
                runat="server" BulletStyle="Disc">
        <%-- The bulleted list items will be introduced by coding, however this is a good example to show. --%>
        <asp:ListItem Value="[NEW] [dd/mm/yy] (xxxxx xxxxxx xxxxx) yyyyy yyyyyy yyyyy [View] [Delete] [Answer]"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] (xxxxx xxxxxx xxxxx) yyyyy yyyyyy yyyyy [View] [Delete] [Answer]"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] (xxxxx xxxxxx xxxxx) yyyyy yyyyyy yyyyy [View] [Delete] [Answer]"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] (xxxxx xxxxxx xxxxx) yyyyy yyyyyy yyyyy [View] [Delete] [Answer]"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] (xxxxx xxxxxx xxxxx) yyyyy yyyyyy yyyyy [View] [Delete] [Answer]"></asp:ListItem>
        <asp:ListItem Value="[dd/mm/yy] (xxxxx xxxxxx xxxxx) yyyyy yyyyyy yyyyy [View] [Delete] [Answer]"></asp:ListItem>
        </asp:BulletedList>
    </section>
</asp:Content>
