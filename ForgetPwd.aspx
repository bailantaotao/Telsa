<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPwd.aspx.cs" Inherits="ForgetPwd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
    </style>
</head>
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(<%= backgroundImage %>) no-repeat center top;">
    
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <div align="center">
        <div style="height: 270px"></div>
        <table style="width: 750px; height:291px; padding-left:50px ">
            <tr style="height:auto;">
                <td align="center" style="vertical-align: top">
                    <table>
                        <tr>
                            <td style="width:500px; line-height:50px; text-align:left">
                                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, TipGetPWD%>"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width:500px; line-height:50px; text-align:left">
                                <asp:Label ID="Label2" runat="server" Text="管理者Email：koutamaishi@fpg.com.tw"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="float:left; padding-left:30px;">
                                <asp:ImageButton ID="ImgBtn_Return" runat="server" 
                                    ImageUrl="<%$ Resources:Resource, ImgUrlReturn%>" OnClick="ImgBtn_Click"/>
                            </td>
                        </tr> 
                    </table>
                </td>
            </tr>
        </table>
        <asp:Literal ID="ClientScriptArea" runat="server"></asp:Literal>    
        
    </div>
    </form>
</body>
</html>
