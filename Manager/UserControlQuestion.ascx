<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlQuestion.ascx.cs" Inherits="Manager_UserControlQuestion" %>
<table width="1000px" align="left" runat="server" style="border: groove 5px">
    <tr>
        <td colspan="4" style="padding: 5px; height: auto; line-height: 20px;">
            <asp:Label ID="LbQuestionNumber" runat="server" Text="題目: " Font-Size="Larger"></asp:Label>
            <asp:TextBox ID="TbQuestion" runat="server" Width="850px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="padding: 5px; height: auto; line-height: 20px;">
            <asp:RadioButtonList ID="RblQuestionType" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Value="0" Selected="True">單選</asp:ListItem>
                <asp:ListItem Value="1">多選</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        <td style="padding: 5px; height: auto; line-height: 20px;">
            <asp:Label ID="Label1" runat="server" Text="配分"></asp:Label>
            <asp:TextBox ID="TbPassScore" runat="server"></asp:TextBox>
        </td>
        <td style="padding: 5px; height: auto; line-height: 20px;">
            <asp:Label ID="Label2" runat="server" Text="答案"></asp:Label>
            <asp:TextBox ID="TbAnswer" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            1. <asp:TextBox ID="TbQuestionItem1" runat="server" Width="900px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            2. <asp:TextBox ID="TbQuestionItem2" runat="server" Width="900px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            3. <asp:TextBox ID="TbQuestionItem3" runat="server" Width="900px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            4. <asp:TextBox ID="TbQuestionItem4" runat="server" Width="900px"></asp:TextBox>
        </td>
    </tr>
</table>