<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanViewItem9.aspx.cs" Inherits="SchoolMaster_PlanViewItem9" %>

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
                table, td, tr{
            border: 1px solid black;
            border-collapse: collapse;
            word-break:break-all;word-wrap:break-word;
        }
        .empty {
            border: 1px solid white;
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
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/GuideSDPEvaluateResult.aspx" Text="<%$ Resources:Resource, HyFollowingMonitor %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/Stage5/MDRegulations_00.aspx" Text="<%$ Resources:Resource, HyRuleManage %>"></asp:HyperLink>
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
                         NavigateUrl="PlanList.aspx"></asp:HyperLink>
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
                    <table width="739px" class="empty">
                         <tr>
                            <td align="left" width="20%" class="empty">
                                年分：<asp:Label ID="LbYear" runat="server" Text=""></asp:Label>   
                            </td>
                            <%-- <td align="left" width="60%" class="empty">
                                学期：<asp:Label ID="LbNO" runat="server" Text=""></asp:Label>   
                            </td>--%>
                        </tr>
                        <tr>
                            <td colspan="1" align="left">
                                <asp:Label ID="LbTipProvince" runat="server" Text="<%$ Resources:Resource, TipPlanTitle9 %>"></asp:Label> 
                                                               
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table width="750px">
                        <tr>
                            <td width="7%" rowspan="2">问题维度</td>
                            <td width="7%" rowspan="2">问题序号</td>
                            <td colspan="2" width="30%">内部评估</td>
                            <td colspan="5" width="50%">外部评估</td>
                        </tr>
                        <tr>
                            <td width="15%">解决及效果</td>
                            <td width="15%" align="left">
                                未解决原因
                            </td>
                            <td width="10%">检测者姓名</td>
                            <td width="10%">职务及单位</td>
                            <td width="10%">开始时间</td>
                            <td width="10%">结束时间</td>
                            <td width="10%">需要支持</td>
                        </tr>
                        <tr>
                            <td width="5%" rowspan="3">学科能力</td>
                            <td>1</td>
                            <td>    
                                <asp:Label ID="LbRC00" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC01" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC02" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC03" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC04" runat="server" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC05" runat="server" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC06" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>                                
                                <asp:Label ID="LbRC10" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC11" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC12" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC13" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC14" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC15" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC16" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>                                
                                <asp:Label ID="LbRC20" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC21" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC22" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC23" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC24" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC25" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC26" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td width="5%" rowspan="3">人格陶冶</td>
                            <td>1</td>
                            <td>                                
                                <asp:Label ID="LbRC30" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC31" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC32" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC33" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC34" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC35" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC36" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>                                
                                <asp:Label ID="LbRC40" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC41" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC42" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC43" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC44" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC45" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC46" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>                                
                                <asp:Label ID="LbRC50" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC51" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC52" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC53" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC54" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC55" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC56" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td width="5%" rowspan="3">学科能力</td>
                            <td>1</td>
                            <td>                                
                                <asp:Label ID="LbRC60" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC61" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC62" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC63" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC64" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC65" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC66" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>                                
                                <asp:Label ID="LbRC70" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC71" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC72" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC73" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC74" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC75" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC76" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>                                
                                <asp:Label ID="LbRC80" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC81" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC82" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC83" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC84" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC85" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="LbRC86" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    
                </div>
                <table width="739px" class="empty">
                    <tr>
                        <td width="90%" align="right" style="margin-right=20px;">
                            <asp:Button ID="BtnCancel" runat="server" Text="<%$ Resources:Resource, BtnBack %>" OnClick="BtnCancel_Click" Font-Size="14pt" />
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
