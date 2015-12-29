<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanViewItem4.aspx.cs" Inherits="SchoolMaster_PlanViewItem4" %>

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
            padding-top:10px;
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
        .table {
            border: 1px solid black;
            border-collapse: collapse;
        }
        .style1
        {
            width: 96%;
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
                <asp:ImageButton ID="ImgBtnIndex" runat="server" ImageUrl="<%$ Resources:Resource, ImgUrlBackIndex %>" OnClick="ImgBtnIndex_Click"/>
            </div>
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
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Expert/GuidePreList.aspx" Text="<%$ Resources:Resource, HyFollowingMonitor %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Expert/Stage5/MDRegulations_00.aspx" Text="<%$ Resources:Resource, HyRuleManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlStudentManage" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Expert/QViewStudentList.aspx" Text="<%$ Resources:Resource, HyStudentManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlQuestinnaire" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Expert/SurveyViewPreList.aspx" Text="<%$ Resources:Resource, HyQuestionnaire %>"></asp:HyperLink>
            </div>
        </div>
        <div id="BlockRight">
            <div id="BlockRightUp">
                                <div style="background: url(../Image/zh-TW/TipGary_TipUserLocation.png) no-repeat; text-align:center; width: 175px; height:39px; float: left;  line-height:39px;">
                    <asp:Label ID="LbLocation" runat="server" Text="<%$ Resources:Resource, TipPlanSDP %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Resource, TipPlanDataView %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="PlanList.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table width="739px">
                        <tr>
                            <td align="left" class="style1">
                                年分：<asp:Label ID="LbYear" runat="server" Text=""></asp:Label>   
                            </td>
                            <td align="left" width="60%">
                                   
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1" align="left" class="style1">
                                <asp:Label ID="LbTipProvince" runat="server" Text="<%$ Resources:Resource, TipPlanTitle4 %>"></asp:Label> 
                                                               
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table width="739px" class="table">
                        <tr>
                            <td width="25%" class="table">维度</td">
                            <td width="75%" align="left" class="table" colspan="2">
                                问题
                            </td>
                        </tr>
                        <tr >
                            <td width="25%" rowspan="3" class="table">学科能力：</td">
                            <td align="left" class="table">
                                问题一
                            </td>
                            <td class="table">
                                <asp:Label ID="LbQuestion1" runat="server" Width="450px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="table">
                                问题二
                            </td>
                            <td class="table"><asp:Label ID="LbQuestion2" runat="server" Width="450px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="table">
                                问题三
                            </td>
                            <td class="table"><asp:Label ID="LbQuestion3" runat="server" Width="450px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="25%" rowspan="3" class="table">人格陶冶：</td">
                            <td align="left" class="table">
                                问题一
                            </td>
                            <td><asp:Label ID="LbQuestion4" runat="server" Width="450px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="table">
                                问题二
                            </td>
                            <td class="table"><asp:Label ID="LbQuestion5" runat="server" Width="450px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="table">
                                问题三
                            </td>
                            <td class="table"><asp:Label ID="LbQuestion6" runat="server" Width="450px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td width="25%" rowspan="3" class="table">学校管理：</td>
                            <td align="left" class="table">
                                问题一
                            </td>
                            <td class="table"><asp:Label ID="LbQuestion7" runat="server" Width="450px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="table">
                                问题二
                            </td>
                            <td class="table"><asp:Label ID="LbQuestion8" runat="server" Width="450px"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="left" class="table">
                                问题三
                            </td>
                            <td class="table"><asp:Label ID="LbQuestion9" runat="server" Width="450px"></asp:Label></td>
                        </tr>
                    </table>
                    
                </div>
                <table width="739px">
                    <tr>
                        <td width="80%">
                            注：发生的变化栏中应着重描述本学年与上学年相比发生的变化
                        </td>
                        <td width="90%" align="right" style="margin-right=20px;">
                            <asp:Button ID="BtnCancel" runat="server" Text="<%$ Resources:Resource, BtnBack %>" OnClick="BtnCancel_Click"  Font-Size="14pt"/>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <asp:Literal ID="ClientScriptArea" runat="server"></asp:Literal> 
    </div>
    </form>
</body>
</html>
