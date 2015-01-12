<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
        .style1
        {
            width: 75px;
        }
        .style2
        {
            width: 484px;
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
                <td align="right" style="vertical-align: top">
                    <table style="margin-right: 0px">
                        <tr>
                            <td style="line-height:50px" class="style1">
                                <asp:Image ID="ImgView_Account" ImageUrl="~/Image/zh-TW/TextViewBlack_Account.png" runat="server" />
                            </td>
                            <td class="style2">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:TextBox ID="Tb_Account" runat="server" Font-Bold="False" Font-Size="Medium" 
                                            Font-Names="Microsoft JhengHei" OnTextChanged="Tb_Account_TextChanged" 
                                            AutoPostBack="true" Height="30px" Width="80px"></asp:TextBox>
                                        <asp:Label ID="LbUserSchool" runat="server" Text=""></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID ="Tb_Account" EventName ="TextChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td style="line-height:50px" class="style1">
                                <asp:Image ID="Img_ViewPwd" ImageUrl="~/Image/zh-TW/TextViewBlack_Pwd.png" runat="server" />
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="Tb_Pwd" runat="server" Font-Bold="False" Font-Size="Medium" 
                                    TextMode="Password" Font-Names="Microsoft JhengHei" Height="30px" 
                                    Width="80px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="line-height:50px" class="style1">
                                <asp:Image ID="Img_ViewVerify" ImageUrl="~/Image/zh-TW/TextViewBlack_Verify.png" runat="server" />
                                <img src="VerificationCode.aspx" />
                            </td>
                            <td class="style2">
                                <asp:TextBox ID="Tb_VerificationCode" runat="server" Font-Bold="False" Font-Size="Medium" 
                                    Font-Names="Microsoft JhengHei" Height="30px" Width="80px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" class="auto-style1">
                                <div style="float:left; padding-left:60px">
                                    <asp:ImageButton ID="ImgBtn_Login" runat="server" ImageUrl="<%$ Resources:Resource, ImgUrlLogin %>" OnClick="ImgBtn_Click"/>
                                </div>
                                <div style="float:left; padding-left:30px;">
                                    <asp:ImageButton ID="ImgBtn_Cancel" runat="server" ImageUrl="<%$ Resources:Resource, ImgUrlCancel %>" OnClick="ImgBtn_Click"/>
                                </div>
                                <div style="float:left; padding-left:30px;">
                                    <asp:ImageButton ID="ImgBtn_Forget" runat="server" ImageUrl="<%$ Resources:Resource, ImgUrlForget %>" OnClick="ImgBtn_Click"/>
                                </div>
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
