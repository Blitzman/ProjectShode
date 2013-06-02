<%@ Page Title="Shode | New Message" Language="C#" MasterPageFile="~/Profile.master" AutoEventWireup="true" 
CodeBehind="ProfileCompose.aspx.cs" Inherits="Project_Shode.ProfileCompose" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProfile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProfile" runat="server">
<asp:Label ID="Compose" runat="server" Text="New Private Message" CssClass="contentTitle"></asp:Label>
    <section id="profileSection">
    <asp:Panel ID="newMessagePanel" runat="server" DefaultButton=sendButton>

    <asp:Table ID="Table1" runat="server">
        <%-- Destination User --%>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="user" runat="server" Text="Username" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textuserdest" runat="server" Width="300px" CssClass="TextBoxLogSign"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="userFeedback" runat="server" ForeColor="Red" Text="Destination user missing!"></asp:Label>
                <asp:Label ID="existsFeedback" runat="server" ForeColor="Red" Text="Destination user doesn't exist!"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <%-- Subject --%>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="SubjectLabel" runat="server" Text="Subject" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textsubject" runat="server" Width="300px" CssClass="TextBoxLogSign"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="subjectFeedback" runat="server" ForeColor="Red" Text="Subject missing!"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>

        <%-- Body --%>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="BodyLabel" runat="server" Text="Message" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textmessage" runat="server" TextMode="MultiLine" Width=200% Height="200" CssClass=TextBoxLogSign 
                MaxLength="1000" Font-Names="Segoe UI"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        
        <%-- Send Button --%>
         <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="sendButton" runat="server" Text="Send" CssClass="ButtonShode" OnClick="send_Message"></asp:Button>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="messageFeedback" runat="server" ForeColor="Red" Text="You have not written any message!"></asp:Label>
                <asp:Label ID="lengthFeedback" runat="server" ForeColor="Red" Text="The message is too long!"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    </asp:Panel>

    </section>
</asp:Content>
