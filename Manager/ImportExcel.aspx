<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImportExcel.aspx.cs" Inherits="Manager_ImportExcel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="DdlProvince" runat="server">

                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="DdlYear" runat="server">

                    </asp:DropDownList>
                </td>
            </tr>
             <tr>
                <td>上传档案</td>
                <td class="auto-style1">
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="2" class="auto-style1">
                    <asp:Button ID="BtnUpload" runat="server" Text="<%$ Resources:Resource, TipPlanUploadAttachment %>" OnClick="BtnUpload_Click" />
                </td>
            </tr>
                       <tr>
                <td colspan="3" align="center">
                    <asp:Label ID="LbStatus" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
