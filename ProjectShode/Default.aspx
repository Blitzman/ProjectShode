﻿<%@ Page Title="Shode | Home" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Project_Shode.Default" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

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

    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" >
                    <ContentTemplate>

                   <table border ="0" width="80%">
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
                          </table>

                    <asp:Timer ID="TimerTweet" runat="server" Interval="10000" ontick="TimerTweet_Tick"></asp:Timer>
                    <div id = "prueba" style= "overflow: auto; max-width: 18%" >
                          <table border="0" cellpadding="2" cellspacing="2" width="20%" align="left">
                                  <tr>
                                    <td>
                                        <asp:Twitter ID="TwitterProfile" runat="server" Mode="Profile" Width="200"  
                                            ScreenName="ProjectShode" IsLiveContentOnDesignMode="True" Count="15">
                                        </asp:Twitter>
                                    </td>
                               </tr>  
                            </table>
                   </div>
                   </ContentTemplate>
                   <Triggers><asp:AsyncPostBackTrigger ControlID="TimerTweet" EventName="Tick" /></Triggers>
              </asp:UpdatePanel>
</asp:Content>
