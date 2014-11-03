<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuideItemUpload.aspx.cs" Inherits="Expert_GuideItemUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 80%;
        }
        .style1
        {
            height: 20px;
        }
        .style2
        {
            width: 80%;
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="550px">
            <tr>
                <td width="20%" class="style1">
                    上传项目名称:
                </td>                
                <td colspan="2" class="style2">
                    <asp:TextBox ID="TbUploadItemName" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>上传档案</td>
                <td class="auto-style1">
                    <asp:FileUpload ID="FileUpload1" runat="server"  Font-Size="14pt"/>
                </td>
            </tr>
            <tr>
                <td></td>
                <td colspan="2" class="auto-style1">
                    <asp:Button ID="BtnUpload" runat="server" Text="<%$ Resources:Resource, TipPlanUploadAttachment %>" OnClick="BtnUpload_Click"  Font-Size="14pt"/>
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

