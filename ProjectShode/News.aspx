<%@ Page Title="News" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Project_Shode.News" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section id="location">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Shode</asp:HyperLink> > 
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Contact.aspx">Contact</asp:HyperLink>
    </section>
    <hgroup class="title">
        <h2>News</h2>
    </hgroup>

    <asp:Table ID="favouriteProjects" runat="server" BackColor="White" CellPadding="5" CellSpacing="5" ForeColor="" Width="80%">
         <asp:TableRow>
            <asp:TableCell BackColor="White">
                <section class="news_item">
                    <section class ="news_item_title">
                       Title 1
                    </section>
                    <section class ="news_item_date">
                        02-01-2013
                    </section>
                    <div class="clear"></div>
                    <section class ="news_item_content">
                    <p class="news_content_text">Bruselas. (EFE).- La economía de la zona del euro ha cumplido en el primer trimestre de 2013 un año y medio en recesión, lastrada por la contracción de Francia, Italia y España y por un aumento insuficiente de Alemania, según la primera estimación del ... </p>
                    </section> 
                </section>
            </asp:TableCell>
         </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell BackColor="White">
                <section class="news_item">
                    <section class ="news_item_title">
                       Title 1
                    </section>
                    <section class ="news_item_date">
                        02-01-2013
                    </section>
                    <div class="clear"></div>
                    <section class ="news_item_content">
                    <p class="news_content_text">Bruselas. (EFE).- La economía de la zona del euro ha cumplido en el primer trimestre de 2013 un año y medio en recesión, lastrada por la contracción de Francia, Italia y España y por un aumento insuficiente de Alemania, según la primera estimación del ... </p>
                    </section> 
                </section>
            </asp:TableCell>
         </asp:TableRow>
      </asp:Table>
       </section>
</asp:Content>
