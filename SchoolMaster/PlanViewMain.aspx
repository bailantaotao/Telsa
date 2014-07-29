<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanViewMain.aspx.cs" Inherits="SchoolMaster_PlanViewMain" %>

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
            padding-top:50px;
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
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(../<%= backgroundImage %>) no-repeat center top;">
    <form id="form1" runat="server">
    <div align="center" style="width: 1024px; margin: 0px auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
        </asp:ScriptManager>
        <div id="BlockLeft">
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInternetStudy" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/InternetStudy.aspx" Text="<%$ Resources:Resource, HyInternetStudy %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlKPI" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/KPIExamMain.aspx" Text="<%$ Resources:Resource, HyKPI %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlSchoolDevelop" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/PlanList.aspx" Text="<%$ Resources:Resource, HySchoolDevelop %>"></asp:HyperLink>
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
                    <asp:Label ID="LbLocation" runat="server" Text="<%$ Resources:Resource, TipPlanSDP %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, TipPlanDataInput %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="#"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Resource, TipPlanDataView %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="PlanViewList.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table align="left" width="739px">
                        <tr>
                            
                            <td align="left">
                                <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:Resource, TipPlanBack %>" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table width="739px">
                        <tr>
                            <td>
                                <asp:LinkButton ID="LkbPlanItem1" runat="server" Text="<%$ Resources:Resource, LkbPlanItem1 %>" PostBackUrl="~/SchoolMaster/PlanItem1.aspx"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LkbPlanItem2" runat="server" Text="<%$ Resources:Resource, LkbPlanItem2 %>">></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LkbPlanItem3" runat="server" Text="<%$ Resources:Resource, LkbPlanItem3 %>">></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LkbPlanItem4" runat="server" Text="<%$ Resources:Resource, LkbPlanItem4 %>">></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LkbPlanItem5" runat="server" Text="<%$ Resources:Resource, LkbPlanItem5 %>" OnClick="LkbPlanItem5_Click">></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LkbPlanItem6" runat="server" Text="<%$ Resources:Resource, LkbPlanItem6 %>">></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LkbPlanItem7" runat="server" Text="<%$ Resources:Resource, LkbPlanItem7 %>">></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LkbPlanItem8" runat="server" Text="<%$ Resources:Resource, LkbPlanItem8 %>">></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LkbPlanItem9" runat="server" Text="<%$ Resources:Resource, LkbPlanItem9 %>">></asp:LinkButton>
                            </td>
                            <td>
                                
                            </td>
                        </tr>
                    </table>
                    <table width="739px">
                        <tr>
                            <td align="left" width="10%">
                                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, TipPlanAttachment %>"></asp:Label>
                            </td>
                            <td align="left" width="90%">
                                <%--<asp:Button ID="btnUpload" runat="server" Text="<%$ Resources:Resource, TipPlanUploadAttachment %>" OnClick="btnUpload_Click" />--%>
                            </td>
                        </tr>
                    </table>
                    <table width="739px">
                        <tr>
                            <td>
                                <asp:LinkButton ID="LkbDownloadItem1" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem1 %>" OnClick="LkbDownloadItem1_Click"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LkbDownloadItem2" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem2 %>" OnClick="LkbDownloadItem2_Click">></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LkbDownloadItem3" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem3 %>" OnClick="LkbDownloadItem3_Click"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LkbDownloadItem4" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem4 %>" OnClick="LkbDownloadItem4_Click">></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LkbDownloadItem5" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem5 %>" OnClick="LkbDownloadItem5_Click"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LkbDownloadItem6" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem6 %>" OnClick="LkbDownloadItem6_Click">></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:LinkButton ID="LkbDownloadItem7" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem7 %>" OnClick="LkbDownloadItem7_Click"></asp:LinkButton>
                            </td>
                            <td>
                                <asp:LinkButton ID="LkbDownloadItem8" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem8 %>" OnClick="LkbDownloadItem8_Click">></asp:LinkButton>
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
