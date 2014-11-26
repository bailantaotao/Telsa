<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SurveyListLanguage.aspx.cs" Inherits="SchoolMaster_SurveyListLanguage" %>

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
            padding-left:25px;
        }
        #BlockRightDownController {
            height:55px;
        }
        #BlockRightDownDataDisplay {
            padding-top:20px;
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
            height: 104px;
        }
        .style2
        {
            height: 22px;
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
                    <asp:Label ID="LbLocation" runat="server" Text="调查问卷管理" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="REd" Text="调查问卷填写" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="SurveyPreList.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Black" Text="调查问卷观看" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="SurveyViewPreList.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table width="739px">
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 735px">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label7" runat="server" Text="明德小学教学精进项目(语文教材)使用意见调查表" Font-Size="18pt" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label1" runat="server" Text="学校名称：" ForeColor="#8C4510"></asp:Label>
                                <asp:Label ID="LbSurveySchool" runat="server" Text="" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label2" runat="server" Text="填表人：" ForeColor="#8C4510"></asp:Label>
                                <asp:Label ID="LbSurveyUser" runat="server" Text="" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label4" runat="server" Text="填表日期：" ForeColor="#8C4510"></asp:Label>
                                <asp:TextBox ID="TbSurveyYear" runat="server" Width="50px" Font-Size="14pt"></asp:TextBox>
                                <asp:Label ID="Label3" runat="server" Text="年" ForeColor="#8C4510"></asp:Label>
                                <asp:TextBox ID="TbSurveyMonth" runat="server" Width="25px" Font-Size="14pt"></asp:TextBox>
                                <asp:Label ID="Label5" runat="server" Text="月" ForeColor="#8C4510"></asp:Label>
                                <asp:TextBox ID="TbSurveyDay" runat="server" Width="25px" Font-Size="14pt"></asp:TextBox>
                                <asp:Label ID="Label6" runat="server" Text="日" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr><td></td></tr>
                    </table>
                    <table width="720px" bgcolor="#F7DFB5">
                        <tr align="center">
　                           <td width="720" height="25" align="left">
                                <asp:Label ID="Label8" runat="server" Text="电子平台(PPT教材)" Font-Bold="true"></asp:Label>
                             </td>
　                      </tr>
                        <tr align="center">
                            <td width="720" height="25" align="left">
                                <asp:Label ID="Label84" runat="server" Text="(很满意:100分  满意:80分  基本满意:60分  不满意:40分  很不满意:20分)" Font-Size="12pt"></asp:Label>
                            </td>
                        </tr>   
                    </table>
                    <table width="720px" cellspacing="10">
                        <tr>
                            <td colspan="2" align="left">
                                <asp:Label ID="Label9" runat="server" Text="1.课堂教学的引入" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                <asp:RadioButton ID="RbQ1O1" runat="server" GroupName="RbQ1"/>
                                <asp:Label ID="Label10" runat="server" Text="很满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ1O2" runat="server" GroupName="RbQ1"/>
                                <asp:Label ID="Label11" runat="server" Text="满意"></asp:Label>
                            </td>
                            <td width="100" >
                                <asp:RadioButton ID="RbQ1O3" runat="server" GroupName="RbQ1"/>
                                <asp:Label ID="Label12" runat="server" Text="基本满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ1O4" runat="server" GroupName="RbQ1"/>
                                <asp:Label ID="Label13" runat="server" Text="不满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ1O5" runat="server" GroupName="RbQ1"/>
                                <asp:Label ID="Label14" runat="server" Text="很不满意"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="720px" cellspacing="10">
                        <tr>
                            <td colspan="2" class="style2" align="left">
                                <asp:Label ID="Label15" runat="server" Text="2.新课程内容的教授" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                <asp:RadioButton ID="RbQ2O1" runat="server" GroupName="RbQ2"/>
                                <asp:Label ID="Label16" runat="server" Text="很满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ2O2" runat="server" GroupName="RbQ2"/>
                                <asp:Label ID="Label17" runat="server" Text="满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ2O3" runat="server" GroupName="RbQ2"/>
                                <asp:Label ID="Label18" runat="server" Text="基本满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ2O4" runat="server" GroupName="RbQ2"/>
                                <asp:Label ID="Label19" runat="server" Text="不满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ2O5" runat="server" GroupName="RbQ2"/>
                                <asp:Label ID="Label20" runat="server" Text="很不满意"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="720px" cellspacing="10">
                        <tr>
                            <td colspan="3" align="left">
                                <asp:Label ID="Label21" runat="server" Text="3.基础知识的掌握和基本技能的练习" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                <asp:RadioButton ID="RbQ3O1" runat="server" GroupName="RbQ3"/>
                                <asp:Label ID="Label22" runat="server" Text="很满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ3O2" runat="server" GroupName="RbQ3"/>
                                <asp:Label ID="Label23" runat="server" Text="满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ3O3" runat="server" GroupName="RbQ3"/>
                                <asp:Label ID="Label24" runat="server" Text="基本满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ3O4" runat="server" GroupName="RbQ3"/>
                                <asp:Label ID="Label25" runat="server" Text="不满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ3O5" runat="server" GroupName="RbQ3"/>
                                <asp:Label ID="Label26" runat="server" Text="很不满意"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="720px" cellspacing="10">
                        <tr>
                            <td colspan="3" align="left">
                                <asp:Label ID="Label27" runat="server" Text="4.语文思想方法的指导及小结" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                <asp:RadioButton ID="RbQ4O1" runat="server" GroupName="RbQ4"/>
                                <asp:Label ID="Label28" runat="server" Text="很满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ4O2" runat="server" GroupName="RbQ4"/>
                                <asp:Label ID="Label29" runat="server" Text="满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ4O3" runat="server" GroupName="RbQ4"/>
                                <asp:Label ID="Label30" runat="server" Text="基本满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ4O4" runat="server" GroupName="RbQ4"/>
                                <asp:Label ID="Label31" runat="server" Text="不满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ4O5" runat="server" GroupName="RbQ4"/>
                                <asp:Label ID="Label32" runat="server" Text="很不满意"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="720px" cellspacing="10">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label33" runat="server" Text="5.作业的规定" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                <asp:RadioButton ID="RbQ5O1" runat="server" GroupName="RbQ5"/>
                                <asp:Label ID="Label34" runat="server" Text="很满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ5O2" runat="server" GroupName="RbQ5"/>
                                <asp:Label ID="Label35" runat="server" Text="满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ5O3" runat="server" GroupName="RbQ5"/>
                                <asp:Label ID="Label36" runat="server" Text="基本满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ5O4" runat="server" GroupName="RbQ5"/>
                                <asp:Label ID="Label37" runat="server" Text="不满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ5O5" runat="server" GroupName="RbQ5"/>
                                <asp:Label ID="Label38" runat="server" Text="很不满意"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="720px" bgcolor="#F7DFB5">
                        <tr align="center">
　                          <td width="720" height="25" bgcolor="#F7DFB5" align="left">
                                <asp:Label ID="Label39" runat="server" Text="教案(WORD教材)" Font-Bold="true"></asp:Label>
                            </td>
                        <tr align="center">
                            <td width="720" height="25" bgcolor="#F7DFB5" align="left">
                                <asp:Label ID="Label82" runat="server" Text="(很满意:100分  满意:80分  基本满意:60分  不满意:40分  很不满意:20分)" Font-Size="12pt"></asp:Label>
                            </td>
　                       </tr>
                    </table>
                    <table width="720px" cellspacing="10">
                        <tr>
                            <td colspan="2" align="left">
                                <asp:Label ID="Label40" runat="server" Text="1.课堂教学的引入" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                <asp:RadioButton ID="RbQ6O1" runat="server" GroupName="RbQ6"/>
                                <asp:Label ID="Label41" runat="server" Text="很满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ6O2" runat="server" GroupName="RbQ6"/>
                                <asp:Label ID="Label42" runat="server" Text="满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ6O3" runat="server" GroupName="RbQ6"/>
                                <asp:Label ID="Label43" runat="server" Text="基本满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ6O4" runat="server" GroupName="RbQ6"/>
                                <asp:Label ID="Label44" runat="server" Text="不满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ6O5" runat="server" GroupName="RbQ6"/>
                                <asp:Label ID="Label45" runat="server" Text="很不满意"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="720px" cellspacing="10">
                        <tr>
                            <td colspan="2" align="left">
                                <asp:Label ID="Label46" runat="server" Text="2.新课程内容的教授" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                <asp:RadioButton ID="RbQ7O1" runat="server" GroupName="RbQ7"/>
                                <asp:Label ID="Label47" runat="server" Text="很满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ7O2" runat="server" GroupName="RbQ7"/>
                                <asp:Label ID="Label48" runat="server" Text="满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ7O3" runat="server" GroupName="RbQ7"/>
                                <asp:Label ID="Label49" runat="server" Text="基本满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ7O4" runat="server" GroupName="RbQ7"/>
                                <asp:Label ID="Label50" runat="server" Text="不满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ7O5" runat="server" GroupName="RbQ7"/>
                                <asp:Label ID="Label51" runat="server" Text="很不满意"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="720px" cellspacing="10">
                        <tr>
                            <td colspan="3" align="left">
                                <asp:Label ID="Label52" runat="server" Text="3.基础知识的掌握和基本技能的练习" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                <asp:RadioButton ID="RbQ8O1" runat="server" GroupName="RbQ8"/>
                                <asp:Label ID="Label53" runat="server" Text="很满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ8O2" runat="server" GroupName="RbQ8"/>
                                <asp:Label ID="Label54" runat="server" Text="满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ8O3" runat="server" GroupName="RbQ8"/>
                                <asp:Label ID="Label55" runat="server" Text="基本满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ8O4" runat="server" GroupName="RbQ8"/>
                                <asp:Label ID="Label56" runat="server" Text="不满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ8O5" runat="server" GroupName="RbQ8"/>
                                <asp:Label ID="Label57" runat="server" Text="很不满意"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="720px" cellspacing="10">
                        <tr>
                            <td colspan="3" align="left">
                                <asp:Label ID="Label58" runat="server" Text="4.语文思想方法的指导及小结" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                <asp:RadioButton ID="RbQ9O1" runat="server" GroupName="RbQ9"/>
                                <asp:Label ID="Label59" runat="server" Text="很满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ9O2" runat="server" GroupName="RbQ9"/>
                                <asp:Label ID="Label60" runat="server" Text="满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ9O3" runat="server" GroupName="RbQ9"/>
                                <asp:Label ID="Label61" runat="server" Text="基本满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ9O4" runat="server" GroupName="RbQ9"/>
                                <asp:Label ID="Label62" runat="server" Text="不满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ9O5" runat="server" GroupName="RbQ9"/>
                                <asp:Label ID="Label63" runat="server" Text="很不满意"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="720px" cellspacing="10">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label64" runat="server" Text="5.作业的规定" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                <asp:RadioButton ID="RbQ10O1" runat="server" GroupName="RbQ10"/>
                                <asp:Label ID="Label65" runat="server" Text="很满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ10O2" runat="server" GroupName="RbQ10"/>
                                <asp:Label ID="Label66" runat="server" Text="满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ10O3" runat="server" GroupName="RbQ10"/>
                                <asp:Label ID="Label67" runat="server" Text="基本满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ10O4" runat="server" GroupName="RbQ10"/>
                                <asp:Label ID="Label68" runat="server" Text="不满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ10O5" runat="server" GroupName="RbQ10"/>
                                <asp:Label ID="Label69" runat="server" Text="很不满意"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="720px" bgcolor="#F7DFB5">
                        <tr align="center" align="center">
　                          <td width="720" height="25" bgcolor="#F7DFB5" align="left">
                                <asp:Label ID="Label70" runat="server" Text="契合" Font-Bold="true"></asp:Label>
                            </td>
                        </tr>
                            <td align="left">
                                <asp:Label ID="Label83" runat="server" Text="(很满意:100分   满意:80分   基本满意:60分   不满意:40分   很不满意:20分)" Font-Size="12pt"></asp:Label>
                            </td>
　                      </tr>
                    </table>
                    <table width="720px">
                        <tr>
                            <td colspan="3" align="left">
                                <asp:Label ID="Label71" runat="server" Text="1.PPT教材与WORD教材的匹配" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="100">
                                <asp:RadioButton ID="RbQ11O1" runat="server" GroupName="RbQ11"/>
                                <asp:Label ID="Label72" runat="server" Text="很满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ11O2" runat="server" GroupName="RbQ11"/>
                                <asp:Label ID="Label73" runat="server" Text="满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ11O3" runat="server" GroupName="RbQ11"/>
                                <asp:Label ID="Label74" runat="server" Text="基本满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ11O4" runat="server" GroupName="RbQ11"/>
                                <asp:Label ID="Label75" runat="server" Text="不满意"></asp:Label>
                            </td>
                            <td width="100">
                                <asp:RadioButton ID="RbQ11O5" runat="server" GroupName="RbQ11"/>
                                <asp:Label ID="Label76" runat="server" Text="很不满意"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="720px">
                        <tr align="center" align="center">
　                           <td width="720" height="25" bgcolor="#F7DFB5" align="left">
                                <asp:Label ID="Label77" runat="server" Text="建议事项" Font-Bold="true"></asp:Label>
                                </td>
　                       </tr>
                    </table>
                    <table width="720px">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label78" runat="server" Text="1.PPT教材操作或技术" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style1">
                                <asp:TextBox ID="TbPPT" runat="server" Width="720px" Height="100px" TextMode="MultiLine" Font-Size="14pt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label79" runat="server" Text="2.WORD教材内容及安排" ForeColor="#8C4510"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:TextBox ID="TbWord" runat="server" Width="720px" Height="100px" TextMode="MultiLine" Font-Size="14pt"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label80" runat="server" Text="说明：" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp&nbsp&nbsp<asp:Label ID="Lbdescription1" runat="server" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                &nbsp&nbsp&nbsp<asp:Label ID="Label81" runat="server" Text="2.敬请省教育厅协助汇总学校使用意见调查表，并请以电子邮件寄至(Email:koutamaishi@fpg.com.tw)明德小学工作小组收。" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td align="right">
                                <asp:Button ID="BtnSubmit" runat="server" Text="提交" Width="90px" Height="30px" 
                                    Font-Size="14pt" onclick="BtnSubmit_Click"/>
                            </td>
                            <td align="right">
                                <asp:Button ID="BtnCancel" runat="server" Text="取消提交" Width="90px" 
                                    Height="30px" Font-Size="14pt" onclick="BtnCancel_Click"/>
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
