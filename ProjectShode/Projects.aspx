<%@ Page Title="Shode | Explore projects" Language="C#" MasterPageFile="~/Project.master" AutoEventWireup="true"
    CodeBehind="Projects.aspx.cs" Inherits="Project_Shode.Projects" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContentProject">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContentProject">
  <section id="searchEngine">
    
    <%-- Searching Engine --%>
    <asp:Panel ID="searchsPanel" runat="server" DefaultButton="buttonSearchProjects">
    <section id="entrySearch">
        <asp:TextBox ID="searchTextbox" runat="server" Height="20px" Width="180px" MaxLength=30 CssClass=TextBoxLogSign></asp:TextBox>
        <asp:Button ID="buttonSearchProjects" runat="server" Text="Search" CssClass="ButtonShode" OnClick="startSearch"></asp:Button>

    </section>
    
    <section id"searchLabelHere">           
        <asp:RegularExpressionValidator ID="searchCorrectnes" runat="server" ControlToValidate="searchTextbox"
           ForeColor="#C36464" ErrorMessage="Searching String Incorrect" Display=Dynamic
           ValidationExpression="^(?!\s*$)(?![,.]*$)(?![-a-zA-Z0-9,.]{20,}$)[a-zA-Z0-9,.\s]{1,64}" ></asp:RegularExpressionValidator>
    </section>
    </asp:Panel>

    <asp:Label ID="searchLabelProject" runat="server" Text="Select the categories you want to explore."></asp:Label>
    
    <%-- Searching Categories --%>
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
  
   <%-- Searching Results --%>
   <section id="searchResults">
        <section id="searchTopLabels">
            <section id="resultsLabel">
                <asp:Label ID="projectsResultsLabel" runat="server" Text="Results" Font-Bold=true ></asp:Label>
            </section>
            <section id="mostPopularLink">
                <asp:Image ID="mostStartImage" runat="server" ImageUrl="~/Images/star2.png" ImageAlign=Top />
                <asp:Button ID="searchPopular" runat="server" Font-Bold=true CssClass="ButtonShode"
                 OnClick="searchMostPopular" Text="Most Popular Projects"></asp:button>
            </section>
            <div class="clear"></div>
        </section>

        <asp:GridView ID="gridResults" runat="server" CellPadding="5" CellSpacing="5" ForeColor="White" RowStyle-HorizontalAlign=Center
         BackColor="#24242C" Width="600px" AllowPaging="true" PageSize="7" PagerSettings-Mode="NumericFirstLast"
         OnPageIndexChanging="resultsPageChanging" EmptyDataText="No projects were found" AutoGenerateColumns="false">

             <Columns>
                <asp:BoundField DataField="code" HeaderText="Code" />
                <asp:HyperLinkField DataTextField="title" HeaderText="Title" Target="_self"
                  DataNavigateUrlFields="title, code" ItemStyle-ForeColor="White" ControlStyle-ForeColor="White"
                  DataNavigateUrlFormatString="~/ProjectProfile.aspx?ProTitle={0}&Code={1}"/>
                <asp:BoundField DataField="nickname" HeaderText="User" />
                <asp:BoundField DataField="creation_date" HeaderText="StartedOn" />
                <asp:BoundField DataField="total_bank" HeaderText="Total" />                
                <asp:BoundField DataField="state" HeaderText="State" />
             </Columns>

        </asp:GridView>


  </section>
  <div class=clear></div>
</asp:Content>
