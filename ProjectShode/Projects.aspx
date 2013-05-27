﻿<%@ Page Title="Explore projects" Language="C#" MasterPageFile="~/Project.master" AutoEventWireup="true"
    CodeBehind="Projects.aspx.cs" Inherits="Project_Shode.Projects" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContentProject">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContentProject">
  <section id="searchEngine">
    <section id="entrySearch">
        <asp:TextBox ID="searchTextbox" runat="server"></asp:TextBox>
        <asp:Button ID="buttonSearchProjects" runat="server" Text="Search" OnClick="startSearch"></asp:Button>
    </section>
    
    <section id"test">
    <asp:Label ID="searchError" runat="server" ForeColor="Red" Text="Incorrect seaching string" Visible="false"></asp:Label>
    </section>
    <asp:Label ID="searchLabelProject" runat="server" Text="Select the categories you want to explore."></asp:Label>
    
    <section id="searchCategories">
        <section id="categoriesLeft">
        <asp:TreeView ID="treeviewCat1" runat="server" ShowCheckBoxes=All NodeStyle-HorizontalPadding=5 
        NodeStyle-VerticalPadding=5 ForeColor="#24242C">
            <Nodes>
                <asp:TreeNode SelectAction=None Text="Web"></asp:TreeNode>
                <asp:TreeNode SelectAction=None Text="Educational"></asp:TreeNode>
                <asp:TreeNode SelectAction=None Text="Investigation"></asp:TreeNode>
                <asp:TreeNode SelectAction=None Text="Programming Lang"></asp:TreeNode>
                <asp:TreeNode SelectAction=None Text="Algorithms"></asp:TreeNode>
                <asp:TreeNode SelectAction=None Text="Mobile Phones"></asp:TreeNode>
                <asp:TreeNode SelectAction=None Text="Others"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>
        </section>
        <section id="categoriesRight">
        <asp:TreeView ID="treeviewCat2" runat="server" ShowCheckBoxes=All NodeStyle-HorizontalPadding=5 
            NodeStyle-VerticalPadding=5 ForeColor="#24242C">
                <Nodes>
                    <asp:TreeNode SelectAction=None Text="C++"></asp:TreeNode>
                    <asp:TreeNode SelectAction=None Text="Java"></asp:TreeNode>
                    <asp:TreeNode SelectAction=None Text="C#"></asp:TreeNode>
                    <asp:TreeNode SelectAction=None Text="Scala"></asp:TreeNode>
                    <asp:TreeNode SelectAction=None Text="Scheme"></asp:TreeNode>
                    <asp:TreeNode SelectAction=None Text="ASP.NET"></asp:TreeNode>
                    <asp:TreeNode SelectAction=None Text="Ruby"></asp:TreeNode>
                </Nodes>
            </asp:TreeView>
            </section>
            <div class="clear"></div>      
        </section>   
      </section>
  
      <section id="searchResults">
        <section id="searchTopLabels">
            <section id="resultsLabel">
                <asp:Label ID="projectsResultsLabel" runat="server" Text="Results" Font-Bold=true ></asp:Label>
            </section>
            <section id="moreResultsLink">
                <asp:HyperLink ID="projectsMoreResults" runat="server" Font-Bold=true NavigateUrl="~/Projects.aspx"
                 ForeColor="#24242C">More results</asp:HyperLink>
            </section>
            <div class="clear"></div>
        </section>

        <asp:Table ID="searchProjects" runat="server" BackColor="White" CellPadding="5" CellSpacing="5" ForeColor="White">
             <asp:TableRow Width="600px">
                <asp:TableCell BackColor="#24242C" Height="125" Width="125">
                 <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/ProjectProfile.aspx" ForeColor="White">
                    Cientific Calculator
                 </asp:HyperLink> 
                </asp:TableCell>
                <asp:TableCell BackColor="#24242C" Height="125" Width="125">
                    Some other wierd project.
                </asp:TableCell>
                <asp:TableCell BackColor="#24242C" Height="125" Width="125">
                    Some other wierd project.
                </asp:TableCell>
                <asp:TableCell BackColor="#24242C" Height="125" Width="125">
                    Some other wierd project.
                </asp:TableCell>
            </asp:TableRow>
             <asp:TableRow>
                <asp:TableCell BackColor="#24242C" Height="125" Width="125">
                    Some other wierd project.
                </asp:TableCell>
                <asp:TableCell BackColor="#24242C" Height="125" Width="125">
                    Some other wierd project.
                </asp:TableCell>
                <asp:TableCell BackColor="#24242C" Height="125" Width="125">
                    Some other wierd project.
                </asp:TableCell>
                <asp:TableCell BackColor="#24242C" Height="125" Width="125">
                    Some other wierd project.
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
  </section>
  <div class=clear></div>
</asp:Content>
