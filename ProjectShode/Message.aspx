<%@ Page Title="Shode | Message" Language="C#" MasterPageFile="~/Profile.master" AutoEventWireup="true" 
CodeBehind="Message.aspx.cs" Inherits="Project_Shode.Message" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProfile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProfile" runat="server">
<asp:Label ID="AsuntoM" Width="700px" Font-Size="30px" runat="server" BackColor="#F0AA0F" ForeColor="White" Font-Bold="true" CssClass="showMessage"/>
    <section>
        <asp:Label Width="600px" runat="server" Font-Size="18px" Text="Previous Messages in this conversation" ForeColor="Black" CssClass="showMessage"/>
        <asp:GridView ID="gridBefore" runat="server" CellPadding="5" CellSpacing="5" ForeColor="White"
         BackColor="#24242C" Width="700px" AllowPaging="false"
         EmptyDataText="No previous messages" OnRowCommand="gridBefore_RowCommand">
         <Columns>
            <asp:HyperLinkField headertext="Open" ItemStyle-CssClass="inboxList" DataTextField="isRead"
              DataTextFormatString="<img src='Images/Messages/{0}.png'/>" 
              DataNavigateUrlFields="Code" DataNavigateUrlFormatString="~/Message.aspx?ID={0}"/>
            <%-- <asp:ButtonField  HeaderText="View" ItemStyle-CssClass="inboxList" ButtonType="Button" Text="View" CommandName="View"/> --%>
            <asp:ButtonField  HeaderText="Delete" ItemStyle-CssClass="inboxList" ButtonType="Image" ImageUrl="~/Images/Messages/Bin.png" CommandName="Delete"/>
            <%-- <asp:ImageField DataImageUrlField="isRead" DataImageUrlFormatString="~/Images/Messages/{0}.png"></asp:ImageField> --%>
        </Columns>
        </asp:GridView>
    </section>
    <section>
        <asp:Label ID="ErrorM" Width="700px" Font-Size="15px" runat="server" BackColor="White" ForeColor="Black"/>
        <asp:Label ID="Label1" Width="600px" runat="server" Font-Size="18px" Text="Current Message" ForeColor="Black" CssClass="showMessage"/>
        <asp:Label ID="EmisorM" Width="700px" runat="server" Font-Size="18px" BackColor="#24242C" ForeColor="White" CssClass="showMessage"/>
        <asp:Label ID="ReceptorM" Width="330px" runat="server" BackColor="#24242C" ForeColor="White" CssClass="showMessage"/>
        <asp:Label ID="FechaM" Width="335px" runat="server" BackColor="#24242C" ForeColor="White" CssClass="showMessage"/>
        <asp:Label ID="TextoM" Width="700px" runat="server" BackColor="#24242C" ForeColor="White" CssClass="showMessage"/>
    </section>
    <section>
        <asp:Label runat="server" ForeColor="White" BackColor="White" Text="Space"></asp:Label>
    </section>
    <section>
        <asp:Button ID="replyButton" runat="server" Text="Reply" CssClass="ButtonShode" OnClick="openTextBox"></asp:Button>
    </section>
    <section>
        <asp:TextBox ID="textmessage" Visible="false" runat="server" TextMode="MultiLine" Width="700px" Height="200" MaxLength="1000" Font-Names="Segoe UI"></asp:TextBox>
    </section>
    <section>
        <asp:Button ID="sendButton" Visible="false" runat="server" Text="Send" CssClass="ButtonShode" OnClick="reply_Message"></asp:Button>
        <asp:Label ID="messageFeedback" runat="server" ForeColor="Red" Text="You have not written any message!"></asp:Label>
        <asp:Label ID="lengthFeedback" runat="server" ForeColor="Red" Text="The message is too long!"></asp:Label>
    </section>
    <section>
        <asp:Label Width="700px" runat="server" Font-Size="18px" Text="Replies" ForeColor="Black" CssClass="showMessage"/>
        <asp:GridView ID="gridAfter" runat="server" CellPadding="5" CellSpacing="5" ForeColor="White"
         BackColor="#24242C" Width="700px" AllowPaging="false"
         EmptyDataText="No replies" OnRowCommand="gridAfter_RowCommand">
         <Columns>
            <asp:HyperLinkField headertext="Open" ItemStyle-CssClass="inboxList" DataTextField="isRead"
              DataTextFormatString="<img src='Images/Messages/{0}.png'/>" 
              DataNavigateUrlFields="Code" DataNavigateUrlFormatString="~/Message.aspx?ID={0}"/>
            <%-- <asp:ButtonField  HeaderText="View" ItemStyle-CssClass="inboxList" ButtonType="Button" Text="View" CommandName="View"/> --%>
            <asp:ButtonField  HeaderText="Delete" ItemStyle-CssClass="inboxList" ButtonType="Image" ImageUrl="~/Images/Messages/Bin.png" CommandName="Delete"/>
            <%-- <asp:ImageField DataImageUrlField="isRead" DataImageUrlFormatString="~/Images/Messages/{0}.png"></asp:ImageField> --%>
        </Columns>
        </asp:GridView>
    </section>
</asp:Content>
