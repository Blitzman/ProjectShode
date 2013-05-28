<%@ Page Title="Shode | Inbox Messages" Language="C#" MasterPageFile="~/Profile.master" AutoEventWireup="true" 
CodeBehind="ProfileMessages.aspx.cs" Inherits="Project_Shode.ProfileMessages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProfile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProfile" runat="server">
<asp:Label ID="Messages" runat="server" Text="Inbox" CssClass="contentTitle"></asp:Label>
    <section id="profileSection">
        <asp:GridView ID="gridResults" runat="server" CellPadding="5" CellSpacing="5" ForeColor="White"
         BackColor="#24242C" Width="600px" AllowPaging="true" PageSize="20" PagerSettings-Mode="NumericFirstLast"
         OnPageIndexChanging="resultsPageChanging" EmptyDataText="You don't have received messages!">
        </asp:GridView>
    </section>
</asp:Content>
