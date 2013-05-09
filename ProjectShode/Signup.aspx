<%@ Page Title="Shode - Sign Up" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Signup.aspx.cs" Inherits="Project_Shode.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <section id="location">
        <asp:HyperLink runat="server" NavigateUrl="~/Default.aspx">Shode</asp:HyperLink> > 
        <asp:HyperLink runat="server" NavigateUrl="~/Signup.aspx">Sign Up</asp:HyperLink>
    </section>
    <h2>
        Sign Up to join our comunity and enjoy proposing and developing code!
    </h2>
    <p>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" BackColor="#24242C" ForeColor="#FFFFFF" Font-Bold="true" CssClass="LoginSignup" Width="600px">

            <TextBoxStyle CssClass="TextBoxLogSign"/>
            <CancelButtonStyle CssClass="ButtonLogSign" Width="100px" Font-Bold="true" Font-Names="Segoe UI"/>
            <ContinueButtonStyle CssClass="ButtonLogSign" Width="100px" Font-Bold="true" Font-Names="Segoe UI"/>
            <CreateUserButtonStyle CssClass="ButtonLogSign" Width="100px" Font-Bold="true" Font-Names="Segoe UI"/>

            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                <ContentTemplate>
                    <table border="0" style="font-size: 100%; font-family: Segoe UI; margin-left:20px">

                        <%--Title--%>
                        <tr>
                            <td align="center" colspan="2" style="font-weight: bold; color: #24242C">
                                Sign Up for Your New Account</td>
                        </tr>

                        <%--Name--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="NameLabel" runat="server">
                                    Name:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="Name" runat="server" CssClass="TextBoxLogSign"></asp:TextBox>
                            </td>
                        </tr>

                         <%--Last Name--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="LastNameLabel" runat="server">
                                    Last Name:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="LastName" runat="server" CssClass="TextBoxLogSign"></asp:TextBox>
                            </td>
                        </tr>

                        <%--User Name--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">
                                    User Name:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server" CssClass="TextBoxLogSign"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ForeColor="#C36464"
                                    ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">User name is required</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <%--Password--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">
                                    Password:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" CssClass="TextBoxLogSign" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ForeColor="#C36464"
                                    ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="CreateUserWizard1">Password is required</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <%--Confirm Password--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">
                                    Confirm Password:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="TextBoxLogSign" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ForeColor="#C36464"
                                    ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."
                                    ValidationGroup="CreateUserWizard1">You must confirm the password</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <%--Email--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">
                                    E-mail:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="Email" runat="server" CssClass="TextBoxLogSign"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ForeColor="#C36464"
                                    ErrorMessage="E-mail is required." ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">Email is required</asp:RequiredFieldValidator>
                            </td>
                        </tr>

                        <%--Suporting Email--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="OpEmailLabel" runat="server">
                                    Additional E-mail:</asp:Label></td>
                            <td>
                                <asp:TextBox ID="OpEmail" runat="server" CssClass="TextBoxLogSign"></asp:TextBox>
                            </td>
                        </tr>

                        <%--Man or Woman--%>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label1" runat="server">
                                    Male/Female:</asp:Label></td>
                            <td>
                                <asp:DropDownList id="MaleFemale" Font-Names="Segoe UI" AutoPostBack="True" runat="server">
                                  <asp:ListItem Selected="True" Value="--"> -- </asp:ListItem>
                                  <asp:ListItem Value="Female"> Female </asp:ListItem>
                                  <asp:ListItem Value="Male"> Male </asp:ListItem>  
                               </asp:DropDownList>
                            </td>
                        </tr>

                         <%--Password checker--%>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                    ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match." ForeColor="#C36464"
                                    ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                            </td>
                        </tr>

                        <%--Error message if passwords don't match--%>
                        <tr>
                            <td align="center" colspan="2" style="color: red">
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        
                    </table>

                    <%--Checkboxes--%>
                    <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" Text="Send me the best news to my email." />
                    <br />
                    <asp:CheckBox ID="CheckBox2" runat="server" Checked="True" Text="Accept conditions." />
                </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </p>
</asp:Content>