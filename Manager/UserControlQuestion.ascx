<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlQuestion.ascx.cs" Inherits="Manager_UserControlQuestion" %>
<table width="1000px" align="left" runat="server">
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:Label ID="LbQuestion" runat="server" Text="Label" Font-Size="Larger"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:RadioButtonList ID="RblQuestionChoose" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="0"></asp:ListItem>
                <asp:ListItem Value="1"></asp:ListItem>
                <asp:ListItem Value="2"></asp:ListItem>
                <asp:ListItem Value="3"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
</table>