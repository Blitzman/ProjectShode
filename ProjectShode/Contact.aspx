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
            <asp:TableCell>
                <asp:Label ID="name" runat="server" Text="Your name" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textname" runat="server" Width="300px" CssClass="TextBoxLogSign"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="nameFeedback" runat="server" ForeColor="Red" Text="Introduce your name please!"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="email" runat="server" Text="Your email" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textemail" runat="server" Width="300px" CssClass="TextBoxLogSign"></asp:TextBox>
                <asp:RegularExpressionValidator id="RegularExpressionValidator1" 
                    runat="server" ControlToValidate="textemail" 
                    ErrorMessage="You must enter a valid email address" 
                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="emailFeedback" runat="server" ForeColor="Red" Text="Enter an email!"></asp:Label>
                <asp:Label ID="correctEmail" runat="server" ForeColor="Red" Text="The email is not correct!"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="SubjectLabel" runat="server" Text="Subject" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textsubject" runat="server" Width="300px" CssClass="TextBoxLogSign"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="subjectFeedback" runat="server" ForeColor="Red" Text="Subject missing!"></asp:Label>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="BodyLabel" runat="server" Text="Message" CssClass="formLabel"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="textmessage" runat="server" TextMode="MultiLine" Width=200% Height="200" CssClass=TextBoxLogSign 
                MaxLength="1000" Font-Names="Segoe UI"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
         <asp:TableRow>
            <asp:TableCell>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="sendButton" runat="server" Text="Send" CssClass="ButtonShode" OnClick="contact"></asp:Button>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Label ID="messageFeedback" runat="server" ForeColor="Red" Text="You have not written any message!"></asp:Label>
                <asp:Label ID="lengthFeedback" runat="server" ForeColor="Red" Text="The message is too long!"></asp:Label>
                <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Message sended! Thanks you."></asp:Label>
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

