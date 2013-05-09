﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Profile.master" AutoEventWireup="true" CodeBehind="ProfileFavourites.aspx.cs" Inherits="Project_Shode.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProfile" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProfile" runat="server">
<asp:Label ID="Favourites" runat="server" Text="Favourite Projects" CssClass="contentTitle"></asp:Label>
    <section id="profileSection">
        <asp:Table ID="favouriteProjects" runat="server" BackColor="White" CellPadding="5" CellSpacing="5" ForeColor="White">
            <asp:TableRow Width="800">
                <asp:TableCell BackColor="#24242C" Height="150" Width="150">
                    Project1
                </asp:TableCell>
                <asp:TableCell BackColor="#24242C" Height="150" Width="150">
                    Project2
                </asp:TableCell>
                <asp:TableCell BackColor="#24242C" Height="150" Width="150">
                    Project 3
                </asp:TableCell>
                <asp:TableCell BackColor="#24242C" Height="150" Width="150">
                    Project 4
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell BackColor="#24242C" Height="150" Width="150">
                    Project1
                </asp:TableCell>
                <asp:TableCell BackColor="#24242C" Height="150" Width="150">
                    Project2
                </asp:TableCell>
                <asp:TableCell BackColor="#24242C" Height="150" Width="150">
                    Project 3
                </asp:TableCell>
                <asp:TableCell BackColor="#24242C" Height="150" Width="150">
                    Project 4
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </section>
</asp:Content>
