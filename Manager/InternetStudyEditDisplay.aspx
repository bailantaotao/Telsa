<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InternetStudyEditDisplay.aspx.cs" Inherits="Manager_InternetStudyEditDisplay" %>
<%@ Register Src="UserControlQuestionDisplay.ascx" TagName="UCQD" TagPrefix="CustomControl" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <style>
        #BlockLeft {
            float: left;
            padding-top: 295px;
            width: 230px;
        }
        #BlockRight {
            float: left;
            padding-top: 270px;
            width: 1070px;
        }
        #BlockRightUp {
            height: 65px;
            padding-left:25px;
        }
        #BlockRightDown {
            padding-top: 30px;
        }
        #BlockRightDownController {
            height:55px;
        }
        #BlockRightDownDataDisplay {
        
        }
        #BlockRightDownDataPageSelect{
            width:50%;
            height:30px;
            float: right;
        }
        .Option {
            height: 50px;
            line-height: 50px;
            margin-left:40px;
            text-align:left;
        }
    </style>
</head>
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(../Image/zh-TW/Background.png) no-repeat center top;">
    <form id="form1" runat="server">
    <div align="center" style="width: 1300px; margin: 0px auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
        </asp:ScriptManager>
        <div id="BlockLeft">
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInternetStudy" runat="server" ForeColor="White" Font-Size="14px">網路自學</asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlKPI" runat="server" ForeColor="White" Font-Size="14px">KPI</asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlSchoolDevelop" runat="server" ForeColor="White" Font-Size="14px">學校發展計畫</asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="14px">後期跟蹤指導執行監測</asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="14px">規章制度管理</asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlStudentManage" runat="server" ForeColor="White" Font-Size="14px">學生資料管理</asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlQuestinnaire" runat="server" ForeColor="White" Font-Size="14px">調查問卷管理</asp:HyperLink>
            </div>
        </div>
        <div id="BlockRight">
            <div id="BlockRightUp">
                <div style="background: url(../Image/zh-TW/TipGary_TipUserLocation.png) no-repeat; text-align:center; width: 175px; height:39px; float: left;  line-height:39px;">
                    <asp:Label ID="LbLocation" runat="server" Text="網路自學" Font-Bold="true"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyBtnStudy" runat="server" Font-Bold="true" ForeColor="Red">自學教材編輯</asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyBtnScore" runat="server" Font-Bold="true" ForeColor="Black">自學成績查詢</asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table style="border: thin solid Gray; width: 1000px; height: 60px; ">
                        <tr>
                            <td style="width: 20%; line-height: 50px; border: thin solid Gray;">
                                標題
                            </td>
                            <td style="width: 80%; border: thin solid Gray;">
                                <asp:Label ID="LbTitle" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; line-height: 80px; border: thin solid Gray;">
                                說明
                            </td>
                            <td style="height: 80px: 80%; border: thin solid Gray;">
                                <asp:Label ID="LbDescription" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; line-height: 50px; border: thin solid Gray;">
                                及格分數
                            </td>
                            <td style="width: 80%; border: thin solid Gray;">
                                <asp:Label ID="LbPassScore" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; line-height: 50px; border: thin solid Gray;">
                                URL
                            </td>
                            <td style="width: 80%; border: thin solid Gray;">
                                <asp:HyperLink ID="HyURL" runat="server"></asp:HyperLink>
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="width: 20%; line-height: 50px; border: thin solid Gray;">
                                視頻
                            </td>
                            <td style="width: 80%; height: 500px; border: thin solid Gray;">
                                <asp:Label ID="LbUrl" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="border: thin solid Gray;">
                                <asp:Panel ID="PnQuestionList" runat="server"></asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <table>
                                    <td style="line-height: 50px;">
                                            <asp:Button ID="BtnBack" runat="server" Text="返回上一頁" OnClick="Btn_Click" />
                                    </td>
                                </table>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="BlockRightDownDataDisplay">
                    
                </div>
            </div>
        </div>
        <asp:Literal ID="ClientScriptArea" runat="server"></asp:Literal> 
    </div>
    </form>
</body>
</html>
