<%@ Page Title="Shode | User Description" Language="C#" MasterPageFile="~/Profile.master" AutoEventWireup="true" 
CodeBehind="ProfileMy.aspx.cs" Inherits="Project_Shode.ProfileMy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProfile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProfile" runat="server">
    <asp:Label ID="Username" runat="server" Text="Username" CssClass="contentTitle"></asp:Label>

    <section id="profileResume">
        <section id="profileResumeImage">
            <asp:Image ID="ProfileImage" runat="server" Height=100px Width=100px></asp:Image>
        </section>
        <section id="profileResumeFacts">
        <section class = "profileResumeFactsObj">
            <asp:Image ID="CreditImage" runat="server" ImageUrl="~/Images/usercontributed.png"></asp:Image>
        </section>
        <section class = "profileResumeFactsObj">
            <asp:Label ID="userCredits" runat="server"></asp:Label> credits
         </section>
        <section class = "profileResumeFactsObj">
            <asp:Image ID="DevelopImage" runat="server" ImageUrl="~/Images/userdevelopments.png"></asp:Image>
        </section>
        <section class = "profileResumeFactsObj">
            <asp:Label ID="userDevelopments" runat="server" Text="xxxxxx"></asp:Label> developments
        </section>
        <section class = "profileResumeFactsObj">
            <asp:Image ID="ContrImage" runat="server" ImageUrl="~/Images/usercontributions.png"></asp:Image>
        </section>
        <section class = "profileResumeFactsObj">
            <asp:Label ID="userContributions" runat="server" Text="xxxxxx"></asp:Label> contributions
         </section>
        <div class="clear"></div>
        </section>
    </section>
    <section id="profileData">
        <section id="profileDataTopContributions">
            <asp:Label ID="topcontrib" runat="server" Text="Top Contributions" CssClass="contentTitle"></asp:Label>

            <asp:GridView ID="gridContr" runat="server" CellPadding="5" CellSpacing="5" ForeColor="White" RowStyle-HorizontalAlign=Center
                BackColor="#24242C" Width="400px" EmptyDataText="You have not contributed to any project yet!" 
                AutoGenerateColumns="false">

            <Columns>
                <asp:BoundField DataField="code" HeaderText="Code" />
                <asp:HyperLinkField DataTextField="title" HeaderText="Project" Target="_self"
                  DataNavigateUrlFields="title, code" ItemStyle-ForeColor="White" ControlStyle-ForeColor="White"
                  DataNavigateUrlFormatString="~/ProjectProfile.aspx?ProTitle={0}&Code={1}"/>
                <asp:BoundField DataField="date" HeaderText="On" />                
                <asp:BoundField DataField="amount" HeaderText="Contribution" />
            </Columns>

         </asp:GridView>
 
        </section>
        <section id="profileDataTopDevelopments">
            <asp:Label ID="topdevel" runat="server" Text="Top Developments" CssClass="contentTitle"></asp:Label>
            <asp:GridView ID="gridDev" runat="server" CellPadding="5" CellSpacing="5" ForeColor="White" RowStyle-HorizontalAlign=Center
                BackColor="#24242C" Width="400px" EmptyDataText="You have not started developing any project yet!" 
                AutoGenerateColumns="false">

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
        <div class="clear"></div>
    </section>
</asp:Content>
