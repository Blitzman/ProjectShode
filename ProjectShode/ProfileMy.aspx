<%@ Page Title="" Language="C#" MasterPageFile="~/Profile.master" AutoEventWireup="true" CodeBehind="ProfileMy.aspx.cs" Inherits="Project_Shode.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProfile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProfile" runat="server">
    <asp:Label ID="Username" runat="server" Text="Username" CssClass="contentTitle"></asp:Label>

    <section id="profileResume">
        <section id="profileResumeImage">
            <asp:Image ID="ProfileImage" runat="server"></asp:Image>
        </section>
        <section id="profileResumeFacts">
        <section class = "profileResumeFactsObj">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/usercontributed.png"></asp:Image>
        </section>
        <section class = "profileResumeFactsObj">
            <asp:Label ID="userCredits" runat="server" Text="xxxxxx"></asp:Label> credits
         </section>
        <section class = "profileResumeFactsObj">
            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/userdevelopments.png"></asp:Image>
        </section>
        <section class = "profileResumeFactsObj">
            <asp:Label ID="userDevelopments" runat="server" Text="xxxxxx"></asp:Label> developments
        </section>
        <section class = "profileResumeFactsObj">
            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/usercontributions.png"></asp:Image>
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
            <asp:BulletedList ID="TopContributionsList"
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
        <section id="profileDataTopDevelopments">
            <asp:Label ID="topdevel" runat="server" Text="Top Developments" CssClass="contentTitle"></asp:Label>
             <asp:BulletedList ID="TopDevelopmentList"
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
        <div class="clear"></div>
    </section>
</asp:Content>
