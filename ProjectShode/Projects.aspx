<%@ Page Title="Explore projects" Language="C#" MasterPageFile="~/Project.master" AutoEventWireup="true"
    CodeBehind="Projects.aspx.cs" Inherits="Project_Shode.Projects" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContentProject">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContentProject">
  <section id="searchEngine">
    <asp:Label ID="searchLabelProject" runat="server" Text="Select the categories you want to explore."></asp:Label>
    <section id="searchCategories">
        <asp:TreeView ID="treeviewCategories" runat="server" ShowCheckBoxes=All NodeStyle-HorizontalPadding=5 
        NodeStyle-VerticalPadding=5 ForeColor="#24242C">
            <Nodes>
                <asp:TreeNode SelectAction=None Text="1. Category one"></asp:TreeNode>
                <asp:TreeNode SelectAction=None Text="2. Category two"></asp:TreeNode>
                <asp:TreeNode SelectAction=None Text="3. Category three"></asp:TreeNode>
                <asp:TreeNode SelectAction=None Text="4. Category four"></asp:TreeNode>
                <asp:TreeNode SelectAction=None Text="5. Category five"></asp:TreeNode>
                <asp:TreeNode SelectAction=None Text="6. Category six"></asp:TreeNode>
                <asp:TreeNode SelectAction=None Text="7. Category seven"></asp:TreeNode>
                <asp:TreeNode SelectAction=None Text="8. Category eight"></asp:TreeNode>
            </Nodes>
        </asp:TreeView>
    </section>
     <asp:Button ID="buttonSearchProjects" runat="server" Text="Search"></asp:Button>   
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
