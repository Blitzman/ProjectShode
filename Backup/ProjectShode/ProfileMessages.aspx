<%@ Page Title="Shode | Message Box" Language="C#" MasterPageFile="~/Profile.master" AutoEventWireup="true" 
CodeBehind="ProfileMessages.aspx.cs" Inherits="Project_Shode.ProfileMessages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProfile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProfile" runat="server">
<asp:Label ID="Messages" runat="server" Text="Inbox" CssClass="contentTitle"></asp:Label>
    <section id="orderBy">
        <asp:Label ID="Label1" runat="server" Text="Order By: " Font-Size="15px" CssClass="showMessage" />
        <asp:Button ID="orderDate" runat="server" CssClass="ButtonShode" Text="Date" OnClick="orderCode" />
        <asp:Button ID="orderSender" runat="server" CssClass="ButtonShode" Text="Sender" OnClick="orderSend" />
        <asp:Button ID="orderAddre" runat="server" CssClass="ButtonShode" Text="Addressee" OnClick="orderAddr" />
        <asp:Button ID="orderUnread" runat="server" CssClass="ButtonShode" Text="Unread" OnClick="orderRead" />
    </section>
    <section id="profileSection">
        <asp:GridView ID="gridResults" runat="server" CellPadding="5" CellSpacing="5" ForeColor="White"
         BackColor="#24242C" Width="640px" AllowPaging="true" PageSize="10" PagerSettings-Mode="NumericFirstLast"
         OnPageIndexChanging="resultsPageChanging" EmptyDataText="You don't have received messages!" OnRowCommand="gridResults_RowCommand">
         <Columns>
            <asp:HyperLinkField headertext="Open" ItemStyle-CssClass="inboxList" DataTextField="isRead"
              DataTextFormatString="<img src='Images/Messages/{0}.png'/>" 
              DataNavigateUrlFields="Code" DataNavigateUrlFormatString="~/Message.aspx?ID={0}"/>
            <asp:ButtonField  HeaderText="View" ItemStyle-CssClass="inboxList" ButtonType="Button" Text="View" CommandName="View"/>
            <asp:ButtonField  HeaderText="Delete" ItemStyle-CssClass="inboxList" ButtonType="Image" ImageUrl="~/Images/Messages/Bin.png" CommandName="Delete"/>
            <%-- <asp:ImageField DataImageUrlField="isRead" DataImageUrlFormatString="~/Images/Messages/{0}.png"></asp:ImageField> --%>
        </Columns>
        </asp:GridView>
    </section>
    <section>
        <asp:Label ID="Cabecera" Width="640px" Font-Size="22px" runat="server" BackColor="White" ForeColor="Black" CssClass="showMessage"/>
        <asp:Label ID="Emisor" Width="300px" runat="server" BackColor="#24242C" ForeColor="White" CssClass="showMessage"/>
        <asp:Label ID="Fecha" Width="306px" runat="server" BackColor="#24242C" ForeColor="White" CssClass="showMessage"/>
        <asp:Label ID="Asunto" Font-Bold="true" Font-Size="18px" Width="640px" runat="server" BackColor="#24242C" ForeColor="White" CssClass="showMessage"/>
        <asp:Label ID="Texto" Width="640px" runat="server" BackColor="#24242C" ForeColor="White" CssClass="showMessage"/>
    </section>
</asp:Content>
