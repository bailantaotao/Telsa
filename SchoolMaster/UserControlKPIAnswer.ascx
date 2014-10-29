<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlKPIAnswer.ascx.cs" Inherits="SchoolMaster_UserControlKPIAnswer" %>
<style type="text/css">
    .style1
    {
        height: 32px;
    }
</style>
<table width="739px" align="left" runat="server" style="border: groove 5px">
    <tr>
        <td colspan="4" style="padding: 5px; line-height: 20px; border-bottom: groove 3px" class="style1">
            <asp:Label ID="LbQuestion" runat="server" Text="" style="word-break:break-all"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 18% ; border-right: groove 3px">
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, TipKPIDescription %>" Font-Size="Larger"></asp:Label>
        </td>
        <td colspan="3" style="padding: 5px; height: auto">
            <asp:Label ID="LbDescription" runat="server" Text="" style="word-break:break-all" Font-Size="Larger"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width: 18% ; border-top: groove 3px ; border-right: groove 3px">
            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Resource, TipKPIAccessmentStandards %>" Font-Size="Larger"></asp:Label>
        </td>
        <td colspan="3" style="padding: 5px; height: auto ; border-top: groove 3px">
            <asp:RadioButtonList ID="RblItem" runat="server">

            </asp:RadioButtonList>
        </td>
    </tr>
</table>