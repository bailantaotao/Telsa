<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanViewItem9.aspx.cs" Inherits="SchoolMaster_PlanViewItem9" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script language="javascript" type="text/javascript">
        function Conversion2() {
            //var year = parseInt(document.getElementById('column3').value.substr(0, 4)) - 1911;
            //document.getElementById('column3').value = year + document.getElementById('column3').value.substr(4, 8);
        }
    </script>
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
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table width="739px" class="empty">
                        <tr>
                            <td align="left" width="20%" class="empty">
                                年分：<asp:Label ID="LbYear" runat="server" Text=""></asp:Label>   
                            </td>
                            <td align="left" width="60%" class="empty">
                                学期：<asp:Label ID="LbNO" runat="server" Text=""></asp:Label>   
                            </td>
                        </tr>
                        <tr>
                            <td colspan="1" align="left" class="empty">
                                <asp:Label ID="LbTipProvince" runat="server" Text="<%$ Resources:Resource, TipPlanTitle9 %>"></asp:Label> 
                                                               
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <asp:Panel ID="Panel1" runat="server">
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
                                <asp:Label ID="LbRC021" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:DropDownList ID="LbRC02" runat="server" Width="70px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LbRC031" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC03" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LbRC041" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC04" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="LbRC04"
                                    Enabled="True" TargetControlID="LbRC04" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC051" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC05" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="LbRC05"
                                    Enabled="True" TargetControlID="LbRC05" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC061" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC06" runat="server" Width="70px"></asp:TextBox>
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
                                <asp:Label ID="LbRC121" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:DropDownList ID="LbRC12" runat="server" Width="70px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LbRC131" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC13" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LbRC141" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC14" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="LbRC14"
                                    Enabled="True" TargetControlID="LbRC14" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC151" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC15" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" PopupButtonID="LbRC15"
                                    Enabled="True" TargetControlID="LbRC15" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC161" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC16" runat="server" Width="70px"></asp:TextBox>
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
                                <asp:Label ID="LbRC221" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:DropDownList ID="LbRC22" runat="server" Width="70px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LbRC231" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC23" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LbRC241" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC24" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" PopupButtonID="LbRC24"
                                    Enabled="True" TargetControlID="LbRC24" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC251" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC25" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" PopupButtonID="LbRC25"
                                    Enabled="True" TargetControlID="LbRC25" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC261" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC26" runat="server" Width="70px"></asp:TextBox>
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
                                <asp:Label ID="LbRC321" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:DropDownList ID="LbRC32" runat="server" Width="70px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LbRC331" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC33" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LbRC341" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC34" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender7" runat="server" PopupButtonID="LbRC34"
                                    Enabled="True" TargetControlID="LbRC34" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC351" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC35" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender8" runat="server" PopupButtonID="LbRC35"
                                    Enabled="True" TargetControlID="LbRC35" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC361" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC36" runat="server" Width="70px"></asp:TextBox>
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
                                <asp:Label ID="LbRC421" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:DropDownList ID="LbRC42" runat="server" Width="70px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LbRC431" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC43" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LbRC441" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC44" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender9" runat="server" PopupButtonID="LbRC44"
                                    Enabled="True" TargetControlID="LbRC44" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC451" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC45" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender10" runat="server" PopupButtonID="LbRC45"
                                    Enabled="True" TargetControlID="LbRC45" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC461" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC46" runat="server" Width="70px"></asp:TextBox>
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
                                <asp:Label ID="LbRC521" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:DropDownList ID="LbRC52" runat="server" Width="70px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LbRC531" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC53" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LbRC541" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC54" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender11" runat="server" PopupButtonID="LbRC54"
                                    Enabled="True" TargetControlID="LbRC54" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC551" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC55" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender12" runat="server" PopupButtonID="LbRC55"
                                    Enabled="True" TargetControlID="LbRC55" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC561" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC56" runat="server" Width="70px"></asp:TextBox>
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
                                <asp:Label ID="LbRC621" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:DropDownList ID="LbRC62" runat="server" Width="70px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LbRC631" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC63" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LbRC641" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC64" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender13" runat="server" PopupButtonID="LbRC64"
                                    Enabled="True" TargetControlID="LbRC64" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC651" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC65" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender14" runat="server" PopupButtonID="LbRC65"
                                    Enabled="True" TargetControlID="LbRC65" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC661" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC66" runat="server" Width="70px"></asp:TextBox>
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
                                <asp:Label ID="LbRC721" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:DropDownList ID="LbRC72" runat="server" Width="70px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LbRC731" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC73" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LbRC741" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC74" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender15" runat="server" PopupButtonID="LbRC74"
                                    Enabled="True" TargetControlID="LbRC74" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC751" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC75" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender16" runat="server" PopupButtonID="LbRC75"
                                    Enabled="True" TargetControlID="LbRC75" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC761" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC76" runat="server" Width="70px"></asp:TextBox>
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
                                <asp:Label ID="LbRC821" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:DropDownList ID="LbRC82" runat="server" Width="70px"></asp:DropDownList>
                            </td>
                            <td>
                                <asp:Label ID="LbRC831" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC83" runat="server" Width="70px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="LbRC841" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC84" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender17" runat="server" PopupButtonID="LbRC84"
                                    Enabled="True" TargetControlID="LbRC84" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC851" runat="server" Width="100px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC85" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender18" runat="server" PopupButtonID="LbRC85"
                                    Enabled="True" TargetControlID="LbRC85" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                            </td>
                            <td>
                                <asp:Label ID="LbRC861" runat="server" Width="70px" Visible="false"></asp:Label>
                                <asp:TextBox ID="LbRC86" runat="server" Width="70px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    </asp:Panel>
                </div>
                <table width="739px" class="empty">
                    <tr>
                        <td width="90%" align="right" class="empty">
                            <asp:Button ID="BtnStore" runat="server" Text="<%$ Resources:Resource, BtnPlanStore %>" OnClick="BtnStore_Click" Font-Size="14pt" />
                        </td>
                        <td width="10%" align="left" style="margin-left=20px;" class="empty">
                            <asp:Button ID="BtnCancel" runat="server" Text="<%$ Resources:Resource, BtnPlanCancel %>" OnClick="BtnCancel_Click"  Font-Size="14pt"/>
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
