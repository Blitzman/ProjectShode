<%@ Page Title="Acerca de nosotros" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="About.aspx.cs" Inherits="Project_Shode.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section id="location">
        <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx">Shode</asp:HyperLink> > 
        <asp:HyperLink runat="server" NavigateUrl="~/Contact.aspx">Contact</asp:HyperLink>
    </section>
    <hgroup class="title">
        <h2>Do you have any doubt or sugestion?</h2>
    </hgroup>

        You can easily send us your opinion or ideas through these ways:
    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">Liesbeth Claessens:</span>
            <span><a href="mailto:lc55@alu.ua.es">lc55@alu.ua.es</a></span>
        </p>
        <p>
            <span class="label">Albert García García:</span>
            <span><a href="mailto:agg180@alu.ua.es">agg180@alu.ua.es</a></span>
        </p>
        <p>
            <span class="label">Pablo Martínez González:</span>
            <span><a href="mailto:pmg66@alu.ua.es">pmg66@alu.ua.es</a></span>
        </p>
        <p>
            <span class="label">Sergiu Ovidiu Oprea:</span>
            <span><a href="mailto:soo6@alu.ua.es">soo6@alu.ua.es</a></span>
        </p>
        <p>
            <span class="label">Brayan Stiven Zapata Impatá:</span>
            <span><a href="mailto:bszi1@alu.ua.es">bszi1@alu.ua.es</a></span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Address:</h3>
        </header>
        <p>
            Universidad de Alicante<br />
            San Vicente del Raspeig
        </p>
    </section>
</asp:Content>
