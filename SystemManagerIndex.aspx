<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemManagerIndex.aspx.cs" Inherits="SystemManagerIndex" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        #BlockLeft {
            float: left;
            padding-top: 235px;
            width: 285px;
        }
        #BlockRight {
            float: left;
            padding-top: 210px;
            width: 739px;
        }
        #BlockRightUp {
            height: 40px;
            padding-left:25px;
        }
        #BlockRightDown {
            padding-top: 10px;
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
        .paneltop
        {
            border:1px solid black;
        }
    </style>
</head>
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(<%= backgroundImage %>) no-repeat center top;">
    <form id="form1" runat="server">
    <div align="center" style="width: 1024px; margin: 0px auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
        </asp:ScriptManager>
        <div id="BlockLeft">
            <div class ="Option">
                <img src="Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInternetStudy" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/InternetStudyEdit.aspx" Text="<%$ Resources:Resource, HyInternetStudy %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlKPI" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/KPIExamMain.aspx" Text="<%$ Resources:Resource, HyKPI %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlSchoolDevelop" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/PlanViewList.aspx" Text="<%$ Resources:Resource, HySchoolDevelop %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="#" Text="<%$ Resources:Resource, HyFollowingMonitor %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="#" Text="<%$ Resources:Resource, HyRuleManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlStudentManage" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="#" Text="<%$ Resources:Resource, HyStudentManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlQuestinnaire" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="#" Text="<%$ Resources:Resource, HyQuestionnaire %>"></asp:HyperLink>
            </div>
        </div>
        <div id="BlockRight">
            <div style="text-align:right; height:37px">
                <div style="float:right;">
                    <asp:ImageButton ID="ImgBtnLogout" runat="server"  ImageUrl="<%$ Resources:Resource, ImgIndexUrlLogout%>" OnClick="ImgBtnLogout_Click"/>
                </div>
                <div style="float:right; vertical-align:central; line-height:37px; padding-right: 30px">
                    <asp:Button ID="BtnSendMsg" runat="server" Text="<%$ Resources:Resource, TipSendMsg%>" OnClick="BtnSendMsg_Click" />
                </div>
                <div style="float:right; vertical-align:central; line-height:37px; padding-right: 30px">
                    <asp:Button ID="BtnSendAnnocement" runat="server" Text="<%$ Resources:Resource, BtnSendAnnocement%>" OnClick="BtnSendAnnocement_Click" />
                </div>
                <div style="float:right; vertical-align:central; line-height:37px; padding-right: 260px">
                    <asp:Button ID="BtnImportProvinceData" runat="server" Text="导入项目省校" OnClick="BtnImportProvinceData_Click"  />
                </div>
            </div>
            <div id="BlockRightUp">
                <div style="text-align:center; width: 175px; height:39px; float: left;  line-height:39px;">
                    <asp:Label ID="LbWelcome" runat="server" Text="" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSize12pt %>"></asp:Label>
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:Label ID="LbLastLogin" runat="server" Text="" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSize12pt %>"></asp:Label>
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:Label ID="LbOpenPermission" runat="server" Text="" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSize12pt %>"></asp:Label>
                </div>
            </div>
            <div>
                <hr />
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 735px">
                        <tr>
                            <td colspan="2" align="left" style="vertical-align:top;">
                                公佈欄
                            </td>                            
                        </tr>
                        <tr>
                            <td colspan="2" style="height=200px;">
                                <asp:Panel ID="PnSystem" runat="server" ScrollBars="Auto"  Height="200px" CssClass="paneltop">

                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" colspan="2" style="width: 33%">
                                <asp:Panel ID="PnMingde" runat="server" ScrollBars="Auto"  Height="200px" CssClass="paneltop">

                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <asp:Literal ID="ClientScriptArea" runat="server"></asp:Literal> 
    </div>
    </form>
</body>
</html>
