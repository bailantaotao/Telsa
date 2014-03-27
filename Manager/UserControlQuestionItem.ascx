<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlQuestionItem.ascx.cs" Inherits="Manager_UserControlQuestionItem" %>
<table width="1000px" align="left" runat="server" style="border: groove 5px">
    <tr>
        <td colspan="4" style="padding: 5px; height: auto; line-height: 20px;">
            <asp:Label ID="LbQuestionNumber" runat="server" Text="<%$ Resources:Resource, TipQuestion %>" Font-Size="Larger"></asp:Label>
            <asp:TextBox ID="TbQuestion" runat="server" Width="850px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="padding: 5px; height: auto; line-height: 20px; width:300px">
            <%--<asp:RadioButtonList ID="RblQuestionType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0" Selected="True">單選</asp:ListItem>
                <asp:ListItem Value="1">多選</asp:ListItem>
            </asp:RadioButtonList>--%>
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Resource, TipQuestionType %>"></asp:Label>
                    <asp:Label ID="LbQuestionType" runat="server" Text="<%$ Resources:Resource, TipSingleQuestion %>"></asp:Label>
                </ContentTemplate>
                <Triggers>
                    <asp:asyncpostbacktrigger controlid="CbQuestionItem1" eventname="CheckedChanged" />
                    <asp:asyncpostbacktrigger controlid="CbQuestionItem2" eventname="CheckedChanged" />
                    <asp:asyncpostbacktrigger controlid="CbQuestionItem3" eventname="CheckedChanged" />
                    <asp:asyncpostbacktrigger controlid="CbQuestionItem4" eventname="CheckedChanged" />
                    <asp:asyncpostbacktrigger controlid="CbQuestionItem5" eventname="CheckedChanged" />
                </Triggers>
            </asp:UpdatePanel>
        </td>
        <td style="padding: 5px; height: auto; line-height: 20px;">
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, TipScore %>"></asp:Label>
            <asp:TextBox ID="TbPassScore" runat="server" Width="40px" MaxLength="2"></asp:TextBox>
        </td>
        <td style="padding: 5px; height: auto; line-height: 20px;">
            <%--<asp:Label ID="Label2" runat="server" Text="答案"></asp:Label>
            <asp:TextBox ID="TbAnswer" runat="server"></asp:TextBox>--%>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem1" runat="server" Text="" OnCheckedChanged="CbQuestionItem_CheckedChanged" AutoPostBack="true" />
            1. <asp:TextBox ID="TbQuestionItem1" runat="server" Width="850px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem2" runat="server" Text="" OnCheckedChanged="CbQuestionItem_CheckedChanged" AutoPostBack="true"  />
            2. <asp:TextBox ID="TbQuestionItem2" runat="server" Width="850px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem3" runat="server" Text="" OnCheckedChanged="CbQuestionItem_CheckedChanged" AutoPostBack="true"  />
            3. <asp:TextBox ID="TbQuestionItem3" runat="server" Width="850px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem4" runat="server" Text="" OnCheckedChanged="CbQuestionItem_CheckedChanged" AutoPostBack="true"  />
            4. <asp:TextBox ID="TbQuestionItem4" runat="server" Width="850px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem5" runat="server" Text="" OnCheckedChanged="CbQuestionItem_CheckedChanged" AutoPostBack="true"  />
            5. <asp:TextBox ID="TbQuestionItem5" runat="server" Width="850px"></asp:TextBox>
        </td>
    </tr>
</table>