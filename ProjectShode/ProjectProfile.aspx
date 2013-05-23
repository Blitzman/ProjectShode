<%@ Page Title="PROJECT: " Language="C#" MasterPageFile="~/Project.master" AutoEventWireup="true" 
CodeBehind="ProjectProfile.aspx.cs" Inherits="Project_Shode.ProjectProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProject" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProject" runat="server">
    <section id="projectProfile">
        <section id="projectProfileTittle"
            <asp:Label ID="profileTittleLabel" runat="server" Text="Cientific Calculator" 
            Font-Size=X-Large Font-Underline=true Height=50></asp:Label>
        </section>

        <section id="project
            <asp:Label ID="projectProfileDescription" runat="server" Text="Lorem ipsum dolor sit amet, consectetur adipiscing elit. 
            Phasellus interdum sagittis auctor. Nunc bibendum nisl vitae massa sagittis consectetur. 
            Aliquam vitae lorem sit amet eros dictum gravida suscipit vitae sem. 
            Vestibulum dictum lectus a felis pharetra vehicula. Proin ac justo id est mattis placerat vitae sed metus.
            Nulla gravida cursus dolor, vel ornare magna commodo vitae. Maecenas quis arcu at tortor fringilla laoreet. 
            Donec lectus tortor, fermentum et tristique sit amet, feugiat aliquet nisi. 
            Aliquam convallis mollis mi, at vulputate felis mattis at. Proin aliquam suscipit nunc, 
            porta tempus neque facilisis sit amet."></asp:Label>
        </section>

        <section id="projectProfileStatistics">
            <h4>Project statistics</h4>

            <section class="projectProfileStat">
                Idea by
                <asp:Label ID="projectProfileLabelUser" runat="server" Text="Yayan"></asp:Label>
            </section>
            <section class="projectProfileStat">
                Started on
                <asp:Label ID="projectProfileLabelDate" runat="server" Text="May 24th, 2105"></asp:Label>
            </section>
            <section class="projectProfileStat">
                <asp:Label ID="projectProfileLabelState" runat="server" Text="Under development"></asp:Label>
            </section>
            <section class="projectProfileStat">
                <asp:Label ID="projectProfileLabelCredits" runat="server" Text="3150"></asp:Label>
                 credits have been acumulated
            </section>
            <div class=clear></div>
        </section>

        <section id="projectOptionsHelp">
            <asp:Label ID="GiveLabel" runat="server" Text="Give some credits:"></asp:Label> 
            <asp:TextBox ID="creditsBox" runat="server" Width="50px"></asp:TextBox>

            <asp:Button ID="sendCredits" runat="server" Text="Contribute!" OnClick="contribute"></asp:Button>
            <asp:Label ID="FeedbackCredit" runat="server" ForeColor=Red></asp:Label>

            <asp:RegularExpressionValidator ID="checkCredtisProfile" runat="server" Display=Static 
            ErrorMessage="At least 100 credits." ControlToValidate="creditsBox" 
            ValidationExpression="\d{2}\d+"></asp:RegularExpressionValidator>
            
            <asp:Image ID="developLinkImage" runat="server" ImageUrl="/Images/bullet.png" /> 
            <asp:HyperLink id="developLink" runat="server" NavigateUrl="~/ProjectProfile.aspx" Text="Develop">
            </asp:HyperLink>

        </section>
    </section>

    <section id="projectComments">
        <h3>Project comments</h3>
    
        <section class="projectComment">
            <asp:Label ID="Label1" class="authorName" runat="server" Text="Pepito" Font-Italic=true></asp:Label>
            <section id="oneProjectText">
                <asp:Label ID="Label2" class="authorContent" runat="server" Text="Text Text Text Text Text Text Text"></asp:Label>
            </section>
        </section>
        <section class="projectComment">
            <asp:Label ID="Label3" class="authorName" runat="server" Text="Leti" Font-Italic=true></asp:Label>
            <section id="twoProjectText">
                <asp:Label ID="Label4" class="authorContent" runat="server" Text="Text Text Text Text Text Text Text Text Text Text"></asp:Label>
            </section>
        </section>
        <section class="projectComment">
            <asp:Label ID="Label5" class="authorName" runat="server" Text="Andres" Font-Italic=true></asp:Label>
            <section id="threeProjectText">
                <asp:Label ID="Label6" class="authorContent" runat="server" Text="Text :D"></asp:Label>
            </section>
        </section>
        <section class="projectComment">
            <asp:Label ID="Label7" class="authorName" runat="server" Text="Odersky" Font-Italic=true></asp:Label>
            <section id="fourProjectText">
                <asp:Label ID="Label8" class="authorContent" runat="server" Text="Donec lectus tortor, fermentum et tristique sit amet, feugiat aliquet nisi. 
                Aliquam convallis mollis mi, at vulputate felis mattis at. Proin aliquam suscipit nunc, 
                porta tempus neque facilisis sit amet"></asp:Label>
            </section>
        </section>
        <section class="projectComment">
            <asp:Label ID="Label9" class="authorName" runat="server" Text="Petro" Font-Italic=true></asp:Label>
            <section id="fiveProjectText">
                <asp:Label ID="Label10" class="authorContent" runat="server" Text="Donec lectus tortor, fermentum et tristique sit amet, feugiat aliquet nisi. 
                Aliquam convallis mollis mi, at vulputate felis mattis at. Proin aliquam suscipit nunc, 
                porta tempus neque facilisis sit amet"></asp:Label>
            </section>
        </section>
        <section class="projectComment">
            <asp:Label ID="Label11" class="authorName" runat="server" Text="Andrea" Font-Italic=true></asp:Label>
            <section id="sixProjectText">
                <asp:Label ID="Label12" class="authorContent" runat="server" Text="Donec lectus tortor, fermentum et tristique sit amet, feugiat aliquet nisi. 
                Aliquam convallis mollis mi, at vulputate felis mattis at. Proin aliquam suscipit nunc, 
                porta tempus neque facilisis sit amet"></asp:Label>
            </section>
        </section>
        <section class="projectComment">
            <asp:Label ID="Label13" class="authorName" runat="server" Text="Murk" Font-Italic=true></asp:Label>
            <section id="sevenProjectText">
                <asp:Label ID="Label14" class="authorContent" runat="server" Text="Donec lectus tortor, fermentum et tristique sit amet, feugiat aliquet nisi. 
                Aliquam convallis mollis mi, at vulputate felis mattis at."></asp:Label>
            </section>
        </section>
        <section class="projectComment">
            <asp:Label ID="Label15" class="authorName" runat="server" Text="Yu" Font-Italic=true></asp:Label>
            <section id="eightProjectText">
                <asp:Label ID="Label16" class="authorContent" runat="server" Text="Donec lectus tortor, fermentum et tristique sit amet, feugiat aliquet nisi. 
                Aliquam convallis mollis mi, at vulputate felis mattis at."></asp:Label>
            </section>
        </section>
        <section class="projectComment">
            <asp:Label ID="Label17" class="authorName" runat="server" Text="Niko" Font-Italic=true></asp:Label>
            <section id="nineProjectText">
                <asp:Label ID="Label18" class="authorContent" runat="server" Text="Text Text Text Text."></asp:Label>
            </section>
        </section>
        <section class="projectComment">
            <asp:Label ID="Label19" class="authorName" runat="server" Text="Heio" Font-Italic=true></asp:Label>
            <section id="tenProjectText">
                <asp:Label ID="Label20" class="authorContent" runat="server" Text="Text Text Text Text."></asp:Label>
            </section>
        </section>
    </section>
    <section id="writeProjectComment">
        <asp:Label id="commentProjectLabel" runat="server" Text="Write a comment."></asp:Label>
        <section id="commentProjectContent">
            <asp:TextBox ID="commentProjectText" runat="server" TextMode="MultiLine" Width="800" Height="200" MaxLength="500"></asp:TextBox>
            <asp:Button ID="sendCommentProject" runat="server" Text="Send"></asp:Button>
        </section>
    </section>
</asp:Content>
