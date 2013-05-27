<%@ Page Title="Create a new project" Language="C#" MasterPageFile="~/Project.master" AutoEventWireup="true"
 CodeBehind="CreateProject.aspx.cs" Inherits="Project_Shode.CreateProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProject" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProject" runat="server">
  <asp:Label ID="createProjectTittle" runat="server" Text="Propose your idea!" 
   Font-Size=X-Large Font-Underline=true Height=75></asp:Label>

  <section class="formNewProject">
    <section class="boxesProject">
        <asp:Label ID="tittleProjectLabel" runat="server" Text="Label">Tittle:</asp:Label>
        <asp:TextBox ID="tittleProjectTextbox" runat="server" MaxLength=30 Width=400px 
        Text="Being creative will catch developers attention."></asp:TextBox>
         <asp:Label ID="tittleFeedback" runat="server" ForeColor="Red" Text="Give it a name!"></asp:Label>
    </section>
    
    <asp:Label ID="descriptionLabel" runat="server" Text="Label">Description:</asp:Label>
    <section class="boxesProject">
        <asp:TextBox ID="descriptionTextbox" runat="server" MaxLength=1500 TextMode="MultiLine"
        Wrap=true Width=700px Height=300px Text="Write a description of what the program should do."></asp:TextBox>
         <asp:Label ID="descriptionFeedback" runat="server" ForeColor="Red" Text="Describe it!"></asp:Label>
    </section>
    
    <asp:Label ID="categoriesLabel" runat="server" Text="Select the categories your project fits:"></asp:Label>
    <section class="boxesProject">
        <section id="categoriesLeft">
            <asp:CheckBoxList ID="categoriesCheckbox" runat="server" CellSpacing=20>
                <asp:ListItem Text="Category One"></asp:ListItem>
                <asp:ListItem Text="Category Two"></asp:ListItem>
                <asp:ListItem Text="Category Three"></asp:ListItem>
                <asp:ListItem Text="Category Four"></asp:ListItem>
            </asp:CheckBoxList>
        </section>
        <section id="categoriesRight">
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" CellSpacing=20>
                <asp:ListItem Text="Category Five"></asp:ListItem>
                <asp:ListItem Text="Category Six"></asp:ListItem>
                <asp:ListItem Text="Category Seven"></asp:ListItem>
                <asp:ListItem Text="Category Eight"></asp:ListItem>
            </asp:CheckBoxList>
        </section>
        <div class="clear"></div>
    </section>

    <section class="boxesProject">
        <asp:Label ID="creditsLabelProject" runat="server" Text="Starting credits:"></asp:Label>
        <asp:TextBox ID="creditsTextboxProject" runat="server"></asp:TextBox>

        <asp:RegularExpressionValidator ID="checkCredtis" runat="server" Display=Static 
         ErrorMessage="New projects must start with at least 100 credits." ControlToValidate="creditsTextboxProject" 
         ValidationExpression="\d{2}\d+"></asp:RegularExpressionValidator>

         <asp:Label ID="creditsFeedback" runat="server" ForeColor="Red" Text="Wrong cuantity"></asp:Label>
    </section>

    <asp:Button ID="sendProject" runat="server" Text="Send" OnClick="create_Project"></asp:Button>
  </section>
</asp:Content>
