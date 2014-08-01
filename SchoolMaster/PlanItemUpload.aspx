<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanItemUpload.aspx.cs" Inherits="SchoolMaster_PlanItemUpload" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 80%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="500px">
            <tr>
                <td width="20%">
                    上传项目:
                </td>                
                <td colspan="2" class="auto-style1">
                    <asp:DropDownList ID="DdlUploadFile" runat="server">
                        <asp:ListItem Value="0">学校基本情况统计表和相关讯息表</asp:ListItem>
                        <asp:ListItem Value="1">本学年学校发展计画财务预算与支出情况统计表</asp:ListItem>
                        <asp:ListItem Value="2">本学年学校财务收支情况统计表</asp:ListItem>
                        <asp:ListItem Value="3">本年流动学生登记表</asp:ListItem>
                        <asp:ListItem Value="4">本学年教职工培训情况登记表</asp:ListItem>
                        <asp:ListItem Value="5">本学年贫困学生救助情况统计表</asp:ListItem>
                        <asp:ListItem Value="6">本学年学校发展计画实施情况自评表</asp:ListItem>
                        <asp:ListItem Value="7">本学年制定和实施学校发展计画进程表</asp:ListItem>                        
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
