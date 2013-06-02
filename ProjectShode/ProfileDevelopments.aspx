<%@ Page Title="Shode | User Developments" Language="C#" MasterPageFile="~/Profile.master" AutoEventWireup="true" 
CodeBehind="ProfileDevelopments.aspx.cs" Inherits="Project_Shode.ProfileDevelopments" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProfile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProfile" runat="server">
    <asp:Label ID="Developments" runat="server" Text="My Developments" CssClass="contentTitle"></asp:Label>
    <section id="profileSection">
        <asp:GridView ID="gridDev" runat="server" CellPadding="5" CellSpacing="5" ForeColor="White" RowStyle-HorizontalAlign=Center
         BackColor="#24242C" Width="600px" AllowPaging="true" PageSize="5" PagerSettings-Mode="NumericFirstLast"
         OnPageIndexChanging="pageChanging"  EmptyDataText="You have not contributed to any project yet!" AutoGenerateColumns="false">

            <Columns>
                <asp:BoundField DataField="code" HeaderText="Code" />
                <asp:HyperLinkField DataTextField="title" HeaderText="Project" Target="_self"
                  DataNavigateUrlFields="title, code" ItemStyle-ForeColor="White" ControlStyle-ForeColor="White"
                  DataNavigateUrlFormatString="~/ProjectProfile.aspx?ProTitle={0}&Code={1}"/>
                <asp:BoundField DataField="date" HeaderText="Started On" />                
                <asp:BoundField DataField="gitbranch" HeaderText="GitHub" /> 
                <asp:BoundField DataField="ups" HeaderText="Votes" />
            </Columns>

         </asp:GridView>
    </section>
</asp:Content>
