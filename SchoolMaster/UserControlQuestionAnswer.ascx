<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlQuestionAnswer.ascx.cs" Inherits="SchoolMaster_UserControlQuestionAnswer" %>
<table width="739px" align="left" runat="server" style="border: groove 5px">
    <tr>
        <td colspan="4" style="padding: 5px; height: auto; line-height: 20px;">
            <asp:Label ID="LbQuestionNumber" runat="server" Text="<%$ Resources:Resource, TipQuestion %>" Font-Size="Larger"></asp:Label>
            <asp:Label ID="LbQuestion" runat="server" Text="" style="word-break:break-all"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem1" runat="server" Text=""/>
            1. 
            <asp:Label ID="LbQuestionItem1" runat="server" Text="" style="word-break:break-all"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem2" runat="server" Text=""/>
            2. 
            <asp:Label ID="LbQuestionItem2" runat="server" Text="" style="word-break:break-all"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem3" runat="server" Text=""/>
            3. 
            <asp:Label ID="LbQuestionItem3" runat="server" Text="" style="word-break:break-all"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem4" runat="server" Text=""/>
            4. 
            <asp:Label ID="LbQuestionItem4" runat="server" Text="" style="word-break:break-all"></asp:Label>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 5px; height: auto">
            <asp:CheckBox ID="CbQuestionItem5" runat="server" Text=""/>
            5. 
            <asp:Label ID="LbQuestionItem5" runat="server" Text="" style="word-break:break-all"></asp:Label>
        </td>
    </tr>
</table>