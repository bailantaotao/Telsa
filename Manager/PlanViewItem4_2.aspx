<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanViewItem4_2.aspx.cs" Inherits="SchoolMaster_PlanViewItem4" %>

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
        .table {
            border: 1px solid black;
            border-collapse: collapse;
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
                <asp:HyperLink ID="HlInternetStudy" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/InternetStudyEdit.aspx" Text="<%$ Resources:Resource, HyInternetStudy %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlKPI" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/KPIExamMain.aspx" Text="<%$ Resources:Resource, HyKPI %>"></asp:HyperLink>
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
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Resource, TipPlanDataView %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="PlanList.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, TipPlanDataAdd %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="PlanItemAdd.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table width="739px">
                        <tr>
                            <td colspan="1" align="left">
                                <asp:Label ID="LbTipProvince" runat="server" Text="<%$ Resources:Resource, TipPlanTitle4 %>"></asp:Label> 
                                                               
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="BlockRightDownDataDisplay">
                                        <table width="739px" class="table">
                        <tr>
                            <td width="25%" class="table">维度</td">
                            <td width="70%" align="left" class="table">
                                问题
                            </td>
                            <td width="5%">
                            </td>
                        </tr>
                        <tr >
                            <td width="25%" rowspan="6" class="table">学科能力：</td">
                            <td width="70%" align="left" class="table">
                                问题一<asp:Label ID="TbQuestion1" runat="server" Width="450px"></asp:Label>
                            </td>
                            <td width="5%" class="table">
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table" align="top">
                                <asp:Label ID="LbTarget1" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                                <asp:Button ID="Button9" runat="server" Text="<%$ Resources:Resource, BtnPlanView %>" OnClick="btnView1_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                问题二<asp:Label ID="TbQuestion2" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                <asp:Label ID="LbTarget2" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                                <asp:Button ID="Button10" runat="server" Text="<%$ Resources:Resource, BtnPlanView %>" OnClick="btnView2_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                问题三<asp:Label ID="TbQuestion3" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                <asp:Label ID="LbTarget3" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                                <asp:Button ID="Button11" runat="server" Text="<%$ Resources:Resource, BtnPlanView %>" OnClick="btnView3_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="25%" rowspan="6" class="table">人格陶冶：</td">
                            <td width="70%" align="left" class="table">
                                问题一<asp:Label ID="TbQuestion4" runat="server" Width="450px"></asp:Label>
                            </td>
                            <td width="5%" class="table">
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                <asp:Label ID="LbTarget4" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                                <asp:Button ID="Button12" runat="server" Text="<%$ Resources:Resource, BtnPlanView %>" OnClick="btnView4_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                问题二<asp:Label ID="TbQuestion5" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                <asp:Label ID="LbTarget5" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                                <asp:Button ID="Button13" runat="server" Text="<%$ Resources:Resource, BtnPlanView %>" OnClick="btnView5_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                问题三<asp:Label ID="TbQuestion6" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                <asp:Label ID="LbTarget6" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                                <asp:Button ID="Button14" runat="server" Text="<%$ Resources:Resource, BtnPlanView %>" OnClick="btnView6_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="25%" rowspan="6" class="table">学校管理：</td>
                            <td width="70%" align="left" class="table">
                                问题一<asp:Label ID="TbQuestion7" runat="server" Width="450px"></asp:Label>
                            </td>
                            <td width="5%" class="table">
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                <asp:Label ID="LbTarget7" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                                <asp:Button ID="Button15" runat="server" Text="<%$ Resources:Resource, BtnPlanView %>" OnClick="btnView7_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                问题二<asp:Label ID="TbQuestion8" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                <asp:Label ID="LbTarget8" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                                <asp:Button ID="Button16" runat="server" Text="<%$ Resources:Resource, BtnPlanView %>" OnClick="btnView8_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                问题三<asp:Label ID="TbQuestion9" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                            </td>
                        </tr>
                        <tr>
                            <td width="70%" align="left" class="table">
                                <asp:Label ID="LbTarget9" runat="server" Width="450px"></asp:Label>
                            </td>
                           <td width="5%" class="table">
                                <asp:Button ID="Button17" runat="server" Text="<%$ Resources:Resource, BtnPlanView %>" OnClick="btnView9_Click" />
                            </td>
                        </tr>
                    </table>
                    
                </div>
                <table width="739px">
                    <tr>
                        <td width="80%">
                            注：发生的变化栏中应着重描述本学年与上学年相比发生的变化
                        </td>
                        <td width="90%" align="right" style="margin-right=20px;">
                            <asp:Button ID="BtnCancel" runat="server" Text="<%$ Resources:Resource, BtnBack %>" OnClick="BtnCancel_Click" />
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
