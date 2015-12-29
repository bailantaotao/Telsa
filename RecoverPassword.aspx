<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecoverPassword.aspx.cs" Inherits="RecoverPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
        .style1
        {
            width: 442px;
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
                            <td class="style1">
                                <asp:Label ID="Label1" runat="server" Text="省分:"></asp:Label>
                                <asp:DropDownList ID="DdlProvince" runat="server" AutoPostBack="True" 
                                    onselectedindexchanged="DdlProvince_SelectedIndexChanged"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Label ID="Label2" runat="server" Text="欲恢复之学校:"></asp:Label>
                                <asp:DropDownList ID="DdlSchool" runat="server" Height="20px" Width="198px"></asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:Button ID="BtnModify" runat="server" Text="确认恢复" 
                                    onclick="BtnModify_Click" />
                                <asp:Button ID="BtnCancel" runat="server" Text="取消恢复" 
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
