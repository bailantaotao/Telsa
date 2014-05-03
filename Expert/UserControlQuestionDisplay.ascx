<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlQuestionDisplay.ascx.cs" Inherits="Expert_UserControlQuestionDisplay" %>
<table width="739px" align="left" runat="server" style="border: groove 5px">
    <tr>
        <td colspan="4" style="padding: 5px; height: auto; line-height: 20px;">
            <asp:Label ID="LbQuestionNumber" runat="server" Text="<%$ Resources:Resource, TipQuestion %>" Font-Size="Larger"></asp:Label>
            <asp:Label ID="LbQuestion" runat="server" Text="Label" style="word-break:break-all"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="padding: 5px; height: auto; line-height: 20px;">
            <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Resource, TipQuestionType %>"></asp:Label>
            <asp:Label ID="LbQuestionType" runat="server" Text="Label"></asp:Label>
        </td>
        <td style="padding: 5px; height: auto; line-height: 20px;">
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, TipScore %>"></asp:Label>
            <asp:Label ID="LbPassScore" runat="server" Text="Label"></asp:Label>
        </td>
        <td style="padding: 5px; height: auto; line-height: 20px; width: 200px">
            <%--<asp:Label ID="Label2" runat="server" Text="答案"></asp:Label>
            <asp:Label ID="LbAnswer" runat="server" Text="Label"></asp:Label>--%>
        </td>
        <td style="padding: 5px; height: auto; line-height: 20px; width: 200px">

        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem1" runat="server" Text="" Enabled="false"/>
            1. 
            <asp:Label ID="LbQuestionItem1" runat="server" Text="" style="word-break:break-all"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem2" runat="server" Text="" Enabled="false"/>
            2. 
            <asp:Label ID="LbQuestionItem2" runat="server" Text="" style="word-break:break-all"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem3" runat="server" Text="" Enabled="false"/>
            3. 
            <asp:Label ID="LbQuestionItem3" runat="server" Text="" style="word-break:break-all"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem4" runat="server" Text="" Enabled="false"/>
            4. 
            <asp:Label ID="LbQuestionItem4" runat="server" Text="" style="word-break:break-all"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem5" runat="server" Text="" Enabled="false"/>
            5. 
            <asp:Label ID="LbQuestionItem5" runat="server" Text="" style="word-break:break-all"></asp:Label>
        </td>
    </tr>
</table>