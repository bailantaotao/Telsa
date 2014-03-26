<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlQuestionDisplay.ascx.cs" Inherits="Manager_UserControlQuestionDisplay" Debug="true"%>
<table width="1000px" align="left" runat="server" style="border: groove 5px">
    <tr>
        <td colspan="4" style="padding: 5px; height: auto; line-height: 20px;">
            <asp:Label ID="LbQuestionNumber" runat="server" Text="題目: " Font-Size="Larger"></asp:Label>
            <asp:Label ID="LbQuestion" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="padding: 5px; height: auto; line-height: 20px;">
            <asp:Label ID="LbQuestionType" runat="server" Text="Label"></asp:Label>
        </td>
        <td style="padding: 5px; height: auto; line-height: 20px;">
            <asp:Label ID="Label1" runat="server" Text="配分"></asp:Label>
            <asp:Label ID="LbPassScore" runat="server" Text="Label"></asp:Label>
        </td>
        <td style="padding: 5px; height: auto; line-height: 20px;">
            <asp:Label ID="Label2" runat="server" Text="答案"></asp:Label>
            <asp:Label ID="LbAnswer" runat="server" Text="Label"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            1. 
            <asp:Label ID="LbQuestionItem1" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            2. 
            <asp:Label ID="LbQuestionItem2" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            3. 
            <asp:Label ID="LbQuestionItem3" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            4. 
            <asp:Label ID="LbQuestionItem4" runat="server" Text=""></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            5. 
            <asp:Label ID="LbQuestionItem5" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>