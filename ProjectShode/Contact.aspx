<%@ Page Title="Shode | Contact" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Contact.aspx.cs" Inherits="Project_Shode.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <section id="location">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Default.aspx">Shode</asp:HyperLink> > 
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Contact.aspx">Contact</asp:HyperLink>
    </section>
    <hgroup class="title">
        <h2>Do you have any doubt or sugestion?</h2>
    </hgroup>
    You can easily send us your opinion or ideas through these ways:<br />
    <br />
    &nbsp;<asp:Label ID="Compose" runat="server" Text="Contact Form" CssClass="contentTitle"></asp:Label>
    <section id="profileSection">
    <asp:Panel ID="newMessagePanel" runat="server" DefaultButton="sendButton">

    <asp:Table ID="Table1" runat="server">
        <asp:TableRow>
        <%-- Name --%>
            <asp:TableCell>
                <asp:Label ID="name" runat="server" Text="Your name" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textname" runat="server" Width="300px" CssClass="TextBoxLogSign" MaxLength="64" ValidationGroup="contactMail"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
               <asp:RequiredFieldValidator ID="NameRequired" runat="server" ControlToValidate="textname" ValidationGroup="contactMail"
                   ForeColor="#C36464" ErrorMessage="Name is required." ToolTip="Name is required."></asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="NameCorrectness" runat="server" ControlToValidate="textname"
                   ForeColor="#C36464" ErrorMessage="Name format is incorrect." ValidationGroup="contactMail"
                   ValidationExpression="^(?!\s*$)(?![-a-zA-Z0-9,:_-]{20,}$)[a-zA-Z0-9\s]{1,64}"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>

        <%-- Email --%>
            <asp:TableCell>
                <asp:Label ID="email" runat="server" Text="Your email" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textemail" runat="server" Width="300px" CssClass="TextBoxLogSign" ValidationGroup="contactMail"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
               <asp:RequiredFieldValidator ID="emailRequired" runat="server" ControlToValidate="textemail" ValidationGroup="contactMail"
                   ForeColor="#C36464" ErrorMessage="Email is required." ToolTip="Email is required."></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator id="emailCorrectness" ValidationGroup="contactMail"
                    runat="server" ControlToValidate="textemail" 
                    ErrorMessage="You must enter a valid email address" 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        
        <%-- Subject --%>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="SubjectLabel" runat="server" Text="Subject" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textsubject" runat="server" Width="300px" CssClass="TextBoxLogSign" ValidationGroup="contactMail"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
               <asp:RequiredFieldValidator ID="subjectRequired" runat="server" ControlToValidate="textsubject" ValidationGroup="contactMail"
                   ForeColor="#C36464" ErrorMessage="Subject is required." ToolTip="Subject is required."></asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="subjectCorrectness" runat="server" ControlToValidate="textsubject"
                   ForeColor="#C36464" ErrorMessage="Subject format is incorrect." ValidationGroup="contactMail"
                   ValidationExpression="^(?!\s*$)(?![-a-zA-Z0-9,:_-]{20,}$)[a-zA-Z0-9\s]{1,64}"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>

        <%-- Body --%>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="BodyLabel" runat="server" Text="Message" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textmessage" runat="server" TextMode="MultiLine" Width=200% Height="200" CssClass=TextBoxLogSign 
                MaxLength="1000" Font-Names="Segoe UI" ValidationGroup="contactMail"></asp:TextBox>

                <asp:RequiredFieldValidator ID="bodyRequired" runat="server" ControlToValidate="textmessage" ForeColor="#C36464"
                    ErrorMessage="Body is required" ValidationGroup="contactMail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="maxlengthBody" runat="server" ControlToValidate="textmessage"
                    ValidationExpression="^(?!\s*$)(?![-a-zA-Z0-9]{20,}$)[-a-zA-Z0-9_.!:,.\s]{1,1000}" ForeColor="#C36464"
                    ErrorMessage="Body is not correct. Max: 1000." ValidationGroup="contactMail"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="sendButton" runat="server" Text="Send" CssClass="ButtonShode" ValidationGroup="contactMail"
                 OnClick="SendMail"></asp:Button>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="feedback" runat="server" ForeColor="Red" Text="Message sended! Thanks you."></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
        
        </asp:TableRow>
    </asp:Table>

    </asp:Panel>

    </section>
    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            <span class="label">Liesbeth Claessens:</span>
            <span><a href="mailto:lc55@alu.ua.es">lc55@alu.ua.es</a></span>
        </p>
        <p>
            <span class="label">Albert García García:</span>
            <span><a href="mailto:agg180@alu.ua.es">agg180@alu.ua.es</a></span>
        </p>
        <p>
            <span class="label">Pablo Martínez González:</span>
            <span><a href="mailto:pmg66@alu.ua.es">pmg66@alu.ua.es</a></span>
        </p>
        <p>
            <span class="label">Sergiu Ovidiu Oprea:</span>
            <span><a href="mailto:soo6@alu.ua.es">soo6@alu.ua.es</a></span>
        </p>
        <p>
            <span class="label">Brayan Stiven Zapata Impatá:</span>
            <span><a href="mailto:bszi1@alu.ua.es">bszi1@alu.ua.es</a></span>
        </p>
    </section>
    <section class="contact">
        <header>
            <h3>Address:</h3>
        </header>
        <p>
            Universidad de Alicante<br />
            San Vicente del Raspeig
        </p>
    </section>
</asp:Content>
