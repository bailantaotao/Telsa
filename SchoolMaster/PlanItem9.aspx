<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanItem9.aspx.cs" Inherits="SchoolMaster_PlanItem9" %>

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
            <div class ="Option" style="text-align:left">
                <asp:ImageButton ID="ImgBtnIndex" runat="server" ImageUrl="<%$ Resources:Resource, ImgUrlBackIndex %>" OnClick="ImgBtnIndex_Click"/>
            </div>
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
                <asp:HyperLink ID="HlStudentManage" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/QViewStudentList.aspx" Text="<%$ Resources:Resource, HyStudentManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlQuestinnaire" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/SurveyPreList.aspx" Text="<%$ Resources:Resource, HyQuestionnaire %>"></asp:HyperLink>
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
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="REd" Text="<%$ Resources:Resource, TipPlanDataInput %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="PlanList.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, TipPlanDataView %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
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
                            <td align="left" width="60%" class="empty"> 
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left" class="empty">
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
                                <asp:TextBox ID="TbRC00" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TbRC01" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="TbRC02" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC03" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC04" runat="server" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC05" runat="server" Width="100px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC06" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>                                
                                <asp:TextBox ID="TbRC10" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TbRC11" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="TbRC12" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC13" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC14" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC15" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC16" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>                                
                                <asp:TextBox ID="TbRC20" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TbRC21" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="TbRC22" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC23" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC24" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC25" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC26" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td width="5%" rowspan="3">人格陶冶</td>
                            <td>1</td>
                            <td>                                
                                <asp:TextBox ID="TbRC30" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TbRC31" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="TbRC32" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC33" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC34" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC35" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC36" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>                                
                                <asp:TextBox ID="TbRC40" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TbRC41" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="TbRC42" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC43" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC44" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC45" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC46" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>                                
                                <asp:TextBox ID="TbRC50" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TbRC51" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="TbRC52" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC53" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC54" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC55" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC56" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td width="5%" rowspan="3">学科能力</td>
                            <td>1</td>
                            <td>                                
                                <asp:TextBox ID="TbRC60" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TbRC61" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="TbRC62" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC63" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC64" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC65" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC66" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>2</td>
                            <td>                                
                                <asp:TextBox ID="TbRC70" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TbRC71" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="TbRC72" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC73" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC74" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC75" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC76" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>3</td>
                            <td>                                
                                <asp:TextBox ID="TbRC80" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TbRC81" runat="server" Width="70px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="TbRC82" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC83" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC84" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC85" runat="server" Width="70px"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="TbRC86" runat="server" Width="70px"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    
                </div>
                <table width="739px" class="empty">
                    <tr>
                        <td width="90%" align="right" class="empty">
                            <asp:Button ID="BtnStore" runat="server" Text="<%$ Resources:Resource, BtnPlanStore %>" OnClick="BtnStore_Click"  Font-Size="14pt"/>
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
