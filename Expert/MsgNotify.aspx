<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MsgNotify.aspx.cs" Inherits="Expert_MsgNotify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table style="width: 700px">
            <tr>
                <td style="width: 70px">
                   <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Resource, TipReceiver %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label> 
                </td>
                <td style="width: 300px">
                    <asp:Label ID="LbReceiver" runat="server" Text="" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label> 
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, TipSubject %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label> 
                </td>
                <td>
                    <asp:TextBox ID="TbSubject" runat="server" Width="400px"></asp:TextBox>
                </td>
                
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="TbMsg" runat="server" Height="154px" Width="681px" TextMode="MultiLine" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">             
                    <asp:Button ID="BtnSend" runat="server" Text="<%$ Resources:Resource, BtnSend %>" OnClick="BtnSend_Click" />
                    <asp:Button ID="BtnCancel" Text="<%$ Resources:Resource, BtnCancel %>" runat="server" OnClick="BtnCancel_Click" OnClientClick="return confirm('<%$ Resources:Resource, BtnCloseMsg %>'" />   
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
