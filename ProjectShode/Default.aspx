<%@ Page Title="Página principal" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Project_Shode._Default" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section id="location">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Shode</asp:HyperLink>
    </section>
    <section class="featured">
        <div class="content-wrapper">            
        </div>
            <div class="clear"></div>
    </section>
    <asp:Image ID="Banner1" runat="server" Width="100%" ImageUrl="~/Images/Banner1.png"></asp:Image>
    <hgroup class="title">
        <h2>First time here?</h2>
    </hgroup>
    <p>
        Don't be shy and help us to spread open source programs and code, but recognising their creators.
    </p>
    <hgroup class="title">
        <h3>What can I do here?</h3>
    </hgroup>
    <p>
        Once registered, you can porpose the development of a concrete program or algorithm that you need or would like to see in some specific language. For doing that, you must leave
        a minimum amount of Shode Credits in order to atract developers to take the project and start developing.
    </p>
    <p>
        Other people interested in the project can add more credits and atract other developers, who will going share the benefits of the project depending on the valoration of each
        version.
    </p>
    <p>
        Simply signing up, you can also start taking projects and earn credits as a developer.
    </p>

    <hgroup class="title">
        <h2>News</h2>
    </hgroup>

</asp:Content>
