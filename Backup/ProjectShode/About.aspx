<%@ Page Title="Shode | About" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="Project_Shode.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section id="location">
        <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx">Shode</asp:HyperLink> > 
        <asp:HyperLink runat="server" NavigateUrl="~/About.aspx">About</asp:HyperLink>
    </section>

    <hgroup class="title">
        <h2>If you arrived here accidentally, you are probably wondering WTF is Shode.</h2>
    </hgroup>
    <section class="body_custom">
        <p>        
            Shode is a platform created for generating interest in developing open source code. 
        </p>
        <p>
            Shode tries to approach people with wide knowledge on software development and users who want some program/application to be developed.
       </p>
        <p>
            For that, users who demand developments can easily create a project, give a description and add some requirements as languages preferences and dates. They must leave a little contribution (quantified in Shode Credits) in order to atract developers.
        </p>
        <p>
            Developers can then take the project and start developing the project. The control of version will be done through GIT, so that, each developer will have a GIT branch to develop.
        </p>
        <p>
            Users who have contributed to the project with credits will be able to rate the different versions of the project and, depending on that, developers will recieve more or less credits.
        </p>
    </section>

    <aside>
        <h3>About Shode Credits</h3>
        <p>        
            Shode credits is the way we will trait money. When you contribute, it is done through credits. When you develop, you will earn credits.
            You can both add and take credits via PayPal. 
        </p>
        <p>
            The change form other currency to Shode Credits and viceversa will be established.
        </p>
    </aside>
</asp:Content>
