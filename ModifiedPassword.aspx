<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifiedPassword.aspx.cs" Inherits="ModifiedPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="旧密码:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TbOriginCode" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="新密码:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TbNewCode" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="确认新密码:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TbCheckNewCode" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="BtnModify" runat="server" Text="确认修改" 
                                    onclick="BtnModify_Click" />
                            </td>
                            <td>
                                <asp:Button ID="BtnCancel" runat="server" Text="取消修改" 
                                    onclick="BtnCancel_Click" />
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
