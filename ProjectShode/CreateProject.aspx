<%@ Page Title="Shode | Create a new project" Language="C#" MasterPageFile="~/Project.master"
    AutoEventWireup="true" CodeBehind="CreateProject.aspx.cs" Inherits="Project_Shode.CreateProject" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProject" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProject" runat="server">
    <asp:Label ID="createProjectTittle" runat="server" Text="Propose your idea!" Font-Size="X-Large"
        Font-Underline="true" Height="75"></asp:Label>
    <asp:Panel ID="createPanel" runat="server" DefaultButton="sendProject">
        <section class="formNewProject">

    <%-- Project Tittle --%>

    <section class="boxesProject">
        <asp:Label ID="tittleProjectLabel" runat="server" Text="Label">Tittle:</asp:Label>

        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
        <asp:TextBox ID="tittleProjectTextbox" runat="server" MaxLength=64 
            Width=400px CssClass=TextBoxLogSign ValidationGroup="creation"></asp:TextBox>
             <asp:TextBoxWatermarkExtender ID="tittleProjectTextbox_TextBoxWatermarkExtender" 
            runat="server" Enabled="True" TargetControlID="tittleProjectTextbox" 
            WatermarkCssClass="TextBoxLogSign" 
            WatermarkText="Being creative will catch developers attention.">
        </asp:TextBoxWatermarkExtender>

         <asp:RequiredFieldValidator ID="tittleRequired" runat="server" ControlToValidate="tittleProjectTextbox" ForeColor="#C36464"
             ErrorMessage="Tittle is required" ValidationGroup="creation"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="tittleCorrectness" runat="server" ControlToValidate="tittleProjectTextbox"
             ValidationExpression="^(?!\s*$)(?![,.]*$)(?![-a-zA-Z0-9]{20,}$)[a-zA-Z0-9,.\s]{1,64}" ForeColor="#C36464"
             ErrorMessage="Title is not correct. Max: 64" ValidationGroup="creation"></asp:RegularExpressionValidator>
    </section>
    
    <%-- Project Description --%>

    <asp:Label ID="descriptionLabel" runat="server" Text="Label">Description:</asp:Label>
    <section class="boxesProject">
        <asp:TextBox ID="descriptionTextbox" runat="server" MaxLength=1000 
            TextMode="MultiLine" Font-Names="Segoe UI" CssClass=TextBoxLogSign
            Wrap=true Width=600px Height=300px ValidationGroup="creation"></asp:TextBox>

         <asp:TextBoxWatermarkExtender ID="descriptionTextbox_TextBoxWatermarkExtender" 
            runat="server" Enabled="True" TargetControlID="descriptionTextbox" 
            WatermarkCssClass="TextBoxLogSign"
            WatermarkText="Write a description of what the program should do.">
        </asp:TextBoxWatermarkExtender>
        
        <asp:RegularExpressionValidator ID="maxlengthDescription" runat="server" ControlToValidate="descriptionTextbox"
            ValidationExpression="^(?!\s*$)(?![-a-zA-Z0-9]{20,}$)[-a-zA-Z0-9_.!:,.\s]{1,1000}" ForeColor="#C36464"
            ErrorMessage="Description is not correct. Max: 1000." ValidationGroup="creation"></asp:RegularExpressionValidator>
         <asp:RequiredFieldValidator ID="descriptionRequired" runat="server" ControlToValidate="descriptionTextbox" ForeColor="#C36464"
            ErrorMessage="Description is required" ValidationGroup="creation"></asp:RequiredFieldValidator>
    </section>
    
    <%-- Project Categories: not being used right now. --%>

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

    <%-- Credits --%>
    <section class="boxesProject">
        <asp:Label ID="creditsLabelProject" runat="server" Text="Starting credits:"></asp:Label>
        <asp:TextBox ID="creditsTextboxProject" runat="server" CssClass=TextBoxLogSign ValidationGroup="creation"></asp:TextBox>

        <asp:TextBoxWatermarkExtender ID="creditsTextboxProject_TextBoxWatermarkExtender" 
            runat="server" Enabled="True" TargetControlID="creditsTextboxProject" 
            WatermarkText="More than 100 credits">
        </asp:TextBoxWatermarkExtender>

        <asp:RegularExpressionValidator ID="checkCredtis" runat="server" Display=Static  ForeColor="#C36464"
             ErrorMessage="New projects must start with at least 100 credits." ControlToValidate="creditsTextboxProject" 
             ValidationExpression="\d{2}\d+" ValidationGroup="creation"></asp:RegularExpressionValidator>

         <asp:Label ID="creditsFeedback" runat="server" ForeColor="Red" Text="Wrong quantity"></asp:Label>
    </section>

    <%-- Creation Button --%>
    <asp:Button ID="sendProject" runat="server" Text="Send" CssClass="ButtonShode" 
    OnClick="create_Project" ValidationGroup="creation"></asp:Button>
    <asp:Label ID="creationFeedback" runat="server"></asp:Label>
  </section>
    </asp:Panel>
</asp:Content>
