<%@ Page Title="Shode | Add funds" Language="C#" MasterPageFile="~/Profile.master" AutoEventWireup="true" CodeBehind="ProfileCredits.aspx.cs" Inherits="Project_Shode.ProfileCredits" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProfile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProfile" runat="server">
    <asp:Label ID="GetCredits" runat="server" Text="Get More Credits!" CssClass="contentTitle"></asp:Label>
    <section id="profileSection">
        <asp:Label ID="labelCredits" runat="server" Text="Choose the amount of credits that you want!" ForeColor="#009900"></asp:Label>
        <br />
        <asp:Button ID="button100" Text="Get 100 More Credits!" CssClass="ButtonShode" OnClick="addCredits" CommandArgument="100" CommandName="100" runat="server" /> 
        <asp:Button ID="button1" Text="Get 500 More Credits!" CssClass="ButtonShode" OnClick="addCredits" CommandArgument="500" CommandName="500" runat="server" /> 
        <asp:Button ID="button2" Text="Get 1000 More Credits!" CssClass="ButtonShode" OnClick="addCredits" CommandArgument="1000" CommandName="1000" runat="server" /> 
    </section>
</asp:Content>
