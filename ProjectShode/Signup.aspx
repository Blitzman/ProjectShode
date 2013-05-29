<%@ Page Title="Shode | Sign Up" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Signup.aspx.cs" Inherits="Project_Shode.Signup" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <section id="location">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Shode</asp:HyperLink> > 
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Signup.aspx">Sign Up</asp:HyperLink>
    </section>
    <h2>
        Sign Up to join our comunity and enjoy proposing and developing code!
    </h2>
    <p>
        <table border="0" style="font-size: 100%; font-family: Segoe UI; margin-left: 20px">
            <%--Title--%>
            <tr>
                <td align="center" colspan="2" style="font-weight: bold; color: #24242C">
                    Sign Up for Your New Account
                </td>
            </tr>
            <%--Name--%>
            <tr>
                <td align="right">
                    <asp:Label ID="NameLabel" runat="server" Text="Name:" AssociatedControlID="Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Name" runat="server" CssClass="TextBoxLogSign" MaxLength="32"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="Name"
                        ForeColor="#C36464" ErrorMessage="Name is required." ToolTip="Name is required."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="NameCorrectness" runat="server" ControlToValidate="Name"
                        ForeColor="#C36464" ErrorMessage="Name format is incorrect." ValidationExpression="\S[A-z]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <%--Last Name--%>
            <tr>
                <td align="right">
                    <asp:Label ID="LastNameLabel" runat="server" Text="Last Name:" AssociatedControlID="LastName"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="LastName" runat="server" CssClass="TextBoxLogSign" MaxLength="32"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" ControlToValidate="LastName"
                        ForeColor="#C36464" ErrorMessage="Last Name is required." ToolTip="Last Name is required."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="LastNameCorrectness" runat="server" ControlToValidate="LastName"
                        ForeColor="#C36464" ErrorMessage="Last Name format is incorrect." ValidationExpression="\S[A-z]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <%--User Name--%>
            <tr>
                <td align="right">
                    <asp:Label ID="UserNameLabel" runat="server" Text="User Name:" AssociatedControlID="UserNameBox"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="UserNameBox" runat="server" CssClass="TextBoxLogSign" MaxLength="32"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserNameBox"
                        ForeColor="#C36464" ErrorMessage="User Name is required." ToolTip="User Name is required."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="UserNameCorrectness" runat="server" ControlToValidate="UserNameBox"
                        ForeColor="#C36464" ErrorMessage="User Name format is incorrect." ValidationExpression="\w[0-9A-z]+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <%--Password--%>
            <tr>
                <td align="right">
                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" Text="Password"></asp:Label>
                </td>
                <td>
                   <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
                    <asp:TextBox ID="Password" runat="server" CssClass="TextBoxLogSign" TextMode="Password" MaxLength="16"></asp:TextBox>
                    <asp:PasswordStrength ID="PasswordStrength1" 
                    runat="server" 
                    TargetControlID="Password" 
                    RequiresUpperAndLowerCaseCharacters="true"
                    MinimumNumericCharacters="1" 
                    MinimumSymbolCharacters="1" 
                    MinimumUpperCaseCharacters="1" 
                    PreferredPasswordLength="8"
                    DisplayPosition="RightSide" 
                    StrengthIndicatorType="Text"
                    TextStrengthDescriptions="Very Poor;Weak;Average;Strong;Excellent"
                     TextStrengthDescriptionStyles="colorPass1;colorPass2;colorPass3;colorPass4;colorPass5"
                    CalculationWeightings="50;15;15;20" ></asp:PasswordStrength>
                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                        ForeColor="#C36464" ErrorMessage="Password is required." ToolTip="Password is required."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--Confirm Password--%>
            <tr>
                <td align="right">
                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword"
                     Text="Confirm Password"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ConfirmPassword" runat="server" CssClass="TextBoxLogSign" TextMode="Password" MaxLength="16"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword"
                        ForeColor="#C36464" ErrorMessage="Confirm Password is required." ToolTip="Confirm Password is required."></asp:RequiredFieldValidator>
                </td>
            </tr>
            <%--Email--%>
            <tr>
                <td align="right">
                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email" Text="Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Email" runat="server" CssClass="TextBoxLogSign" MaxLength="64"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                        ForeColor="#C36464" ErrorMessage="E-mail is required." ToolTip="E-mail is required."></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="EmailCorrect" runat="server" ControlToValidate="Email"
                        ForeColor="#C36464" ErrorMessage="Incorrect Email Format: user@comp.dom" 
                        ValidationExpression="\S+@\S+\.\S+"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <%--Man or Woman--%>
            <tr>
                <td align="right">
                    <asp:Label ID="LabelGender" runat="server" Text="Male/Female"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="MaleFemale" Font-Names="Segoe UI" AutoPostBack="False" runat="server">
                        <asp:ListItem Selected="True" Value="--Select--">--Select--</asp:ListItem>
                        <asp:ListItem Value="Female" Text="Female"></asp:ListItem>
                        <asp:ListItem Value="Male" Text="Male"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="GenderRquired" runat="server" InitialValue="--Select--" ForeColor="#C36464"
                     ControlToValidate="MaleFemale" ErrorMessage="Select one please."></asp:RequiredFieldValidator>
                </td>
            </tr>

            <script type = "text/javascript">
                function uploadComplete(sender) {
                    $get("<%=lblMesg.ClientID%>").style.color = "green";
                    $get("<%=lblMesg.ClientID%>").innerHTML = "File Uploaded Successfully";
                }

                function uploadError(sender) {
                    $get("<%=lblMesg.ClientID%>").style.color = "red";
                    $get("<%=lblMesg.ClientID%>").innerHTML = "File upload failed.";
                }
            </script>
            <%--File Upload--%>
            <tr>
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="Photo"></asp:Label>
                </td>
                <td>
                

                <asp:AsyncFileUpload OnClientUploadError="uploadError" runat="server"
                                    ID="AsyncFileUpload1" Width="400px" UploaderStyle="Modern"
                                    CompleteBackColor = "White"
                                    UploadingBackColor="#CCFFFF" ThrobberID="imgLoader" />
                </td>
                <td>
                <asp:Label ID="lblMesg" runat="server" Text=""></asp:Label>
                </td>
                 
            </tr>
            <%--Password checker--%>
            <tr>
                <td align="center" colspan="2">
                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                        ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match."
                        ForeColor="#C36464"></asp:CompareValidator>
                </td>
            </tr>
            <%--Error message if passwords don't match--%>
            <tr>
                <td align="center" colspan="2" style="color: red">
                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                    <asp:Label ID="resultLabel" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </p>
        <asp:Button ID="createButton" runat="server" CssClass="ButtonShode" Text="Create User" OnClick="createUserClick" />
</asp:Content>
