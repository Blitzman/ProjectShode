<%@ Page Title="" Language="C#" MasterPageFile="~/Profile.master" AutoEventWireup="true" CodeBehind="ProfileCompose.aspx.cs" Inherits="Project_Shode.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProfile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProfile" runat="server">
<asp:Label ID="Compose" runat="server" Text="New Private Message" CssClass="contentTitle"></asp:Label>
    <section id="profileSection">
    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="user" runat="server" Text="Username" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                </asp:Label><asp:TextBox ID="textuserdest" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Label1" runat="server" Text="Subject" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                </asp:Label><asp:TextBox ID="textsubject" runat="server"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="Label2" runat="server" Text="Message" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textmessage" runat="server" TextMode="MultiLine" Width="800" Height="200" MaxLength="1000"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Button ID="sendButton" runat="server" Text="Send"></asp:Button>
    </section>
</asp:Content>
