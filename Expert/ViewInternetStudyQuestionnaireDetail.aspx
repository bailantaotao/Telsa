<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewInternetStudyQuestionnaireDetail.aspx.cs" Inherits="Expert_ViewInternetStudyQuestionnaireDetail" %>

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
            padding-top: 220px;
            width: 739px;
        }
        #BlockRightUp {
            height: 65px;
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
    </style>
</head>
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(../Image/zh-CN/Background.png) no-repeat center top;">
    <form id="form1" runat="server">
    <div align="center" style="width: 1024px; margin: 0px auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
        </asp:ScriptManager>
        <div id="BlockLeft">
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInternetStudy" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Expert/ViewInternetStudyScore.aspx" Text="<%$ Resources:Resource, HyInternetStudy %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlKPI" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Expert/KPIExamMain.aspx" Text="<%$ Resources:Resource, HyKPI %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlSchoolDevelop" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Expert/PlanViewList.aspx" Text="<%$ Resources:Resource, HySchoolDevelop %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="#" Text="<%$ Resources:Resource, HyFollowingMonitor %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="#" Text="<%$ Resources:Resource, HyRuleManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlStudentManage" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="#" Text="<%$ Resources:Resource, HyStudentManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlQuestinnaire" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="#" Text="<%$ Resources:Resource, HyQuestionnaire %>"></asp:HyperLink>
            </div>
        </div>
        <div id="BlockRight">
            <div id="BlockRightUp">
                <div style="background: url(../Image/zh-TW/TipGary_TipUserLocation.png) no-repeat; text-align:center; width: 175px; height:39px; float: left;  line-height:39px;">
                    <asp:Label ID="LbLocation" runat="server" Text="<%$ Resources:Resource, TipInternetStudy %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyBtnScore" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, TipSearchScore %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="~/Expert/ViewInternetStudyScore.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Resource, TipViewQuestion %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="~/Expert/InternetStudyScore.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table style="border: thin solid Gray; width: 720px; height: 60px; ">
                        <tr>
                            <td style="width: 20%; line-height: 50px; border: thin solid Gray;">
                                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, TipTitle %>" Font-Size="<%$ Resources:Resource, TextSizeTip %>"></asp:Label>
                            </td>
                            <td style="width: 80%; border: thin solid Gray;">
                                <asp:Label ID="LbTitle" runat="server" Text="Label" style="word-break:break-all"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; line-height: 80px; border: thin solid Gray;">
                                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Resource, TipDescription %>" Font-Size="<%$ Resources:Resource, TextSizeTip %>"></asp:Label>
                            </td>
                            <td style="height: 80px: 80%; border: thin solid Gray;">
                                <asp:Label ID="LbDescription" runat="server" Text="Label" style="word-break:break-all"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; line-height: 50px; border: thin solid Gray;">
                                <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Resource, TipPassScore %>" Font-Size="<%$ Resources:Resource, TextSizeTip %>"></asp:Label>
                            </td>
                            <td style="width: 80%; border: thin solid Gray;">
                                <asp:Label ID="LbPassScore" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%; line-height: 50px; border: thin solid Gray;">
                                <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Resource, TipUrl %>" Font-Size="<%$ Resources:Resource, TextSizeTip %>"></asp:Label>
                            </td>
                            <td style="width: 80%; border: thin solid Gray;">
                                <asp:HyperLink ID="HyURL" runat="server" style="word-break:break-all"></asp:HyperLink>
                            </td>
                        </tr>
                        
                        <tr>
                            <td style="width: 20%; line-height: 50px; border: thin solid Gray;">
                                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Resource, TipVideo %>" Font-Size="<%$ Resources:Resource, TextSizeTip %>"></asp:Label>
                            </td>
                            <td style="width: 70%; height: 500px; border: thin solid Gray;">
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
                                            <asp:Button ID="BtnBack" runat="server" Text="<%$ Resources:Resource, BtnBack %>" OnClick="Btn_Click" />
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
