<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SurveyViewQuestionnaire.aspx.cs" Inherits="Expert_SurveyViewQuestionnaire" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            height: 41px;
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
        .style1
        {
            height: 78px;
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
                    <asp:Label ID="LbLocation" runat="server" Text="调查问卷管理" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Red" Text="调查问卷观看" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="SurveyViewPreList.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table width="739px">
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="学年:" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="LbSurveyYear" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="学校:" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="LbSurveySchool" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="学校代号:" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="LbSurveySchoolID" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 735px">
                        <tr>
                            <td >
                                <asp:Label ID="Label7" runat="server" Text="明德品牌建设工程--明德特色办学首期校长研修班后期调查问卷" Font-Size="Large" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="请问本次研修班您最感兴趣的课程是那些?" ForeColor="Green"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ1A1" runat="server" Enabled="False" />
                                <asp:Label ID="Label8" runat="server" Text="明德教育公益项目办学理念及推动状况"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ1A2" runat="server" Enabled="False" />
                                <asp:Label ID="Label2" runat="server" Text="学科能力提升(明德小学语文、数学、英语教学精进项目)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ1A3" runat="server" Enabled="False" />
                                <asp:Label ID="Label3" runat="server" Text="全人教育"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ1A4" runat="server" Enabled="False" />
                                <asp:Label ID="Label9" runat="server" Text="教育教学改革--校长的责任"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ1A5" runat="server" Enabled="False" />
                                <asp:Label ID="Label10" runat="server" Text="明德小学管理经验"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ1A6" runat="server" Enabled="False" />
                                <asp:Label ID="Label11" runat="server" Text="明德特色辦學典型案例觀摩-洛陽明德小學"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ1A7" runat="server" Enabled="False" />
                                <asp:Label ID="Label12" runat="server" Text="SDP部分"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ1A8" runat="server" Enabled="False" />
                                <asp:Label ID="Label13" runat="server" Text="河南省明德小学校长联谊会事宜"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ1A9" runat="server" Enabled="False" />
                                <asp:Label ID="Label14" runat="server" Text="校外教育资源的开发与利用--小学生科技意识的培养"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ1A10" runat="server" Enabled="False" />
                                <asp:Label ID="Label15" runat="server" Text="明德小学规范管理模式--制度建设与责任落实"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label16" runat="server" Text="请问本次研修班对您帮助最大的课程是那些?" ForeColor="Green"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ2A1" runat="server" Enabled="False" />
                                <asp:Label ID="Label17" runat="server" Text="明德教育公益项目办学理念及推动状况"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ2A2" runat="server" Enabled="False" />
                                <asp:Label ID="Label18" runat="server" Text="学科能力提升(明德小学语文、数学、英语教学精进项目)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ2A3" runat="server" Enabled="False" />
                                <asp:Label ID="Label19" runat="server" Text="全人教育"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ2A4" runat="server" Enabled="False" />
                                <asp:Label ID="Label20" runat="server" Text="教育教学改革--校长的责任"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ2A5" runat="server" Enabled="False" />
                                <asp:Label ID="Label21" runat="server" Text="明德小学管理经验"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ2A6" runat="server" Enabled="False" />
                                <asp:Label ID="Label22" runat="server" Text="明德特色辦學典型案例觀摩-洛陽明德小學"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ2A7" runat="server" Enabled="False" />
                                <asp:Label ID="Label23" runat="server" Text="SDP部分"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ2A8" runat="server" Enabled="False" />
                                <asp:Label ID="Label24" runat="server" Text="河南省明德小学校长联谊会事宜"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ2A9" runat="server" Enabled="False" />
                                <asp:Label ID="Label25" runat="server" Text="校外教育资源的开发与利用--小学生科技意识的培养"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID="CbQ2A10" runat="server" Enabled="False" />
                                <asp:Label ID="Label26" runat="server" Text="明德小学规范管理模式--制度建设与责任落实"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label27" runat="server" Text="请您说出您最需要得到的内容，我们会在以后的培训中加入这些。" ForeColor="Green"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:TextBox ID="TbRequest" runat="server" Width="720px"  Height="100px" 
                                    TextMode="MultiLine" Font-Size="14pt" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label28" runat="server" Text="我对师院有话说：" ForeColor="Green"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TbComment1" runat="server" Width="720px" Height="100px" 
                                    TextMode="MultiLine" Font-Size="14pt" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label29" runat="server" Text="我对明德项目小组有话说：" ForeColor="Green"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TbComment2" runat="server" Width="720px" Height="100px" 
                                    TextMode="MultiLine" Font-Size="14pt" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label30" runat="server" Text="我对此次培训的建议：" ForeColor="Green"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="TbProposal" runat="server" Width="720px" Height="75px" 
                                    TextMode="MultiLine" Font-Size="16pt" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style2">
                                <asp:Button ID="Button1" runat="server" Text="返回" onclick="Button1_Click" />
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
