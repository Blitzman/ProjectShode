<%@ Page Title="Shode | Project Description" Language="C#" MasterPageFile="~/Project.master" AutoEventWireup="true" 
CodeBehind="ProjectProfile.aspx.cs" Inherits="Project_Shode.ProjectProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentProject" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentProject" runat="server">
    <section id="projectProfile">
        <section id="projectProfileTittle">
            <asp:Label ID="profileTittleLabel" runat="server" Font-Size=X-Large Font-Underline=true Height=50></asp:Label>
        </section>

        <section id="project>
            <asp:Label ID="projectProfileDescription" runat="server"></asp:Label>
        </section>

        <section id="projectProfileStatistics">
            <h4>Project statistics</h4>

            <section class="projectProfileStat">
                Idea by
                <asp:Label ID="projectProfileLabelUser" runat="server"></asp:Label>
            </section>
            <section class="projectProfileStat">
                Started on
                <asp:Label ID="projectProfileLabelDate" runat="server"></asp:Label>
            </section>
            <section class="projectProfileStat">
                <asp:Label ID="projectProfileLabelState" runat="server"></asp:Label>
            </section>
            <section class="projectProfileStat">
                <asp:Label ID="projectProfileLabelCredits" runat="server"></asp:Label>
                 credits have been acumulated
            </section>
            <div class=clear></div>
        </section>

        <section id="projectOptionsHelp">
            <section id="leftOptions">
              <asp:Panel ID="optionsPanel" runat="server" DefaultButton="sendCredits">
                <asp:Label ID="GiveLabel" runat="server" Text="Give some credits:"></asp:Label> 
                <asp:TextBox ID="creditsBox" runat="server" Width="50px" CssClass=TextBoxLogSign
                ValidationGroup="creditsValidation"></asp:TextBox>

                <asp:Button ID="sendCredits" runat="server" Text="Contribute!" OnClick="contribute"
                ValidationGroup="creditsValidation" CssClass=ButtonShode></asp:Button>
                <asp:Label ID="FeedbackCredit" runat="server" ForeColor=Red></asp:Label>

                <asp:RegularExpressionValidator ID="checkCredtisProfile" runat="server" Display=Static 
                ErrorMessage="At least 100 credits." ControlToValidate="creditsBox" 
                ValidationExpression="\d{2}\d+" ValidationGroup="creditsValidation"></asp:RegularExpressionValidator>
              </asp:Panel>
            </section>
            <section id="rightOptions">
                <asp:Image ID="developLinkImage" runat="server" ImageUrl="/Images/bullet.png" /> 
                <asp:HyperLink id="developLink" runat="server" NavigateUrl="~/Default.aspx" Text="Develop">
                </asp:HyperLink>
            </section>
            <div id="clear" class="clear"></div>
        </section>
    </section>

    <section id="projectComments">
        <h3>Project comments</h3>

        <asp:GridView ID="gridComments" runat="server" CellPadding="10" CellSpacing="50" ForeColor="#24242C"
             BackColor="#c0c0c0" Width="900px" AllowPaging="true" PageSize="10" PagerSettings-Mode="NumericFirstLast"
             EmptyDataText="This project has no comments yet." AutoGenerateColumns="false" ShowHeader="false" 
             AlternatingRowStyle-BackColor="#24242C" AlternatingRowStyle-ForeColor="#FFFFFF" 
             AlternatingRowStyle-VerticalAlign="Bottom" GridLines=Horizontal RowStyle-CssClass=projectComment
             OnPageIndexChanging="pageChanging">

                 <Columns>
                    <asp:BoundField DataField="nickname" HeaderText="Author" ItemStyle-Font-Italic="true" 
                    ItemStyle-Width=100px ItemStyle-VerticalAlign="Top" ItemStyle-Font-Underline="true"/>
                    <asp:BoundField DataField="comment" HeaderText="Comment" ItemStyle-Width=720px/>
                    <asp:BoundField DataField="date" HeaderText="Commented On" 
                    ItemStyle-Width=80px/>
                 </Columns>

         </asp:GridView>
     </section>

    <section id="writeProjectComment">
        <asp:Label id="commentProjectLabel" runat="server" Text="Write a comment."></asp:Label>

        <section id="commentProjectContent">
            <asp:TextBox ID="commentProjectText" runat="server" TextMode="MultiLine" Width="835" 
            Height="100" MaxLength="140" CssClass=TextBoxLogSign ValidationGroup="commentValidation"></asp:TextBox>
            <asp:Button ID="sendCommentProject" runat="server" Text="Send" ValidationGroup="commentValidation"
            CssClass=ButtonShode OnClick="uploadComment"></asp:Button>
        </section>

        <asp:RequiredFieldValidator ID="commentTextRequired" runat="server" ControlToValidate="commentProjectText"
        ErrorMessage="Write something!" ValidationGroup="commentValidation"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="commentCorrectness" runat="server" ControlToValidate="commentProjectText"
        ValidationExpression="^(?!\s*$)(?![-a-zA-Z0-9]{20,}$)[-a-zA-Z0-9_.!:,.\s.]{1,140}" 
        ErrorMessage="Message length is not correct. Max: 140." ValidationGroup="commentValidation"></asp:RegularExpressionValidator>
    </section>
</asp:Content>
