﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuideViewSDPEvaluateResult.aspx.cs" Inherits="Expert_GuideViewSDPEvaluateResult" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

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
            height: 22px;
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
            width: 14%;
        }
        .style11
        {
            width: 64px;
        }
        .style12
        {
            width: 80px;
        }
        .style13
        {
            width: 71px;
        }
        .style16
        {
            width: 56px;
        }
        .style17
        {
            width: 77px;
        }
        .style18
        {
            width: 60px;
        }
        .style20
        {
            width: 383px;
        }
        .style22
        {
            height: 65px;
        }
        .style23
        {
            height: 65px;
            width: 61px;
        }
        .style25
        {
            width: 64px;
            height: 72px;
        }
        .style27
        {
            height: 72px;
            width: 53px;
        }
        .style28
        {
            width: 56px;
            height: 72px;
        }
        .style29
        {
            width: 77px;
            height: 72px;
        }
        .style30
        {
            width: 60px;
            height: 72px;
        }
        .style32
        {
            height: 26px;
            width: 53px;
        }
        .style33
        {
            width: 56px;
            height: 26px;
        }
        .style34
        {
            width: 77px;
            height: 26px;
        }
        .style35
        {
            width: 60px;
            height: 26px;
        }
        .style36
        {
            width: 53px;
        }
        .style37
        {
            width: 61px;
            height: 26px;
        }
        .style38
        {
            width: 61px;
        }
        .style39
        {
            width: 61px;
            height: 72px;
        }
        .style41
        {
            width: 129px;
        }
        .style42
        {
            width: 131px;
        }
    </style>
</head>
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(../<%= backgroundImage %>) no-repeat center top;" background="../Image/zh-CN/Background.png">
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
                    <asp:Label ID="LbLocation" runat="server" Text="后期跟踪指导" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:Image ID="img" runat="server" src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Black" Text="执行/监测报告输入" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="GuidePreList.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Red" Text="执行/监测报告观看" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="GuideViewPreList.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table width="739px">
                       <tr>
                           <td align="left" class="style1">
                                <asp:Label ID="LbGuideResult" runat="server" Text="学校发展计划执行成效的内外部评估结果汇整表"></asp:Label>
                           </td>
                       </tr>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 735px">
                        <tr>
                            <td align="left" class="style41">
                                <asp:Label ID="LbGuideResultYear" runat="server" Text="学年:" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="LbGuideYear" runat="server" Text=""></asp:Label>
                                <asp:DropDownList ID="DlGuideViewResultYear" runat="server" Width="75px">
                                    <asp:ListItem Selected="True" Value="0">请选择</asp:ListItem>
                                    <asp:ListItem>2013</asp:ListItem>
                                    <asp:ListItem>2014</asp:ListItem>
                                    <asp:ListItem>2015</asp:ListItem>
                                    <asp:ListItem>2016</asp:ListItem>
                                    <asp:ListItem>2017</asp:ListItem>
                                    <asp:ListItem>2018</asp:ListItem>
                                    <asp:ListItem>2019</asp:ListItem>
                                    <asp:ListItem>2020</asp:ListItem>
                                    <asp:ListItem>2021</asp:ListItem>
                                    <asp:ListItem>2022</asp:ListItem>
                                    <asp:ListItem>2023</asp:ListItem>
                                </asp:DropDownList>
                                <%-- <asp:Label ID="LbGuideViewResultYear" runat="server" Text=""></asp:Label>--%>
                            </td>
                            <td align="left" class="style42">
                                <asp:Label ID="LbGuideResultSemester" runat="server" Text="学期:" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="LbGuideSemester" runat="server" Text=""></asp:Label>
                                <asp:DropDownList ID="DlGuideViewResultSemester" runat="server" Width="75px">
                                    <asp:ListItem Selected="True" Value="0">请选择</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                </asp:DropDownList>
                                <%--<asp:Label ID="LbGuideViewResultSemester" runat="server" Text=""></asp:Label>--%>
                            </td> 
                            
                            <td align="left">
                                <asp:Label ID="GuideResultTargetSchoolComplete" runat="server" Text="已评分学校:" ForeColor="Blue"></asp:Label>
                                <asp:DropDownList ID="DlGuideViewResultTargetSchoolComplete" runat="server" 
                                    Width="80px" AutoPostBack="True" 
                                    onselectedindexchanged="DlGuideViewResultTargetSchoolComplete_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:Label ID="GuideResultTargetSchool" runat="server" Text="未评分学校:" ForeColor="Blue"></asp:Label>
                                <asp:DropDownList ID="DlGuideViewResultTargetSchool" runat="server" 
                                    Width="80px" AutoPostBack="True" 
                                    onselectedindexchanged="DlGuideViewResultTargetSchool_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="查询" onclick="Button1_Click" 
                                    style="margin-left: 0px" />
                            </td>
                        </tr>
                    </table>
                    <table style="width: 735px">
                        <tr>
                            <td class="style20">
                                <asp:HyperLink ID="HlGuideResultIndicator" runat="server" Text="‧学校发展计划的关注点及评估监测指标(说明)" NavigateUrl="~/Expert/GuideViewSDPIndicator.aspx"></asp:HyperLink>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 735px">
                        <tr>
                            <td align="center" colspan="3" rowspan="2" style="border: thin Ridge black" >
                                <asp:Label ID="Label1" runat="server" Text="评估范围/分值" ></asp:Label>
                            </td>
                            <td align="center" colspan="3" rowspan="1" style="border: thin Ridge black" >
                                <asp:Label ID="Label2" runat="server" Text="内部、外部评估等级标准" ></asp:Label>
                            </td>
                            <td align="center" colspan="2" rowspan="1" style="border: thin Ridge black" >
                                <asp:Label ID="Label3" runat="server" Text="评估等级得分" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style37" >
                                <asp:Label ID="Label4" runat="server" Text="A" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style32" >
                                <asp:Label ID="Label5" runat="server" Text="B" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style33" >
                                <asp:Label ID="Label6" runat="server" Text="C" Width="40px" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style34" >
                                <asp:Label ID="Label7" runat="server" Text="学校" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style35" >
                                <asp:Label ID="Label8" runat="server" Text="专家组" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="4" style="border: thin Ridge black" 
                                class="style12" >
                                <asp:Label ID="Label9" runat="server" Text="学校发展计划的制定(40分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="2" style="border: thin Ridge black" 
                                class="style13" >
                                <asp:Label ID="Label10" runat="server" Text="制定的规范性(25分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style11" >
                                <asp:Label ID="Label11" runat="server" Text="组织建设(5分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style38" >
                                <asp:Label ID="Label12" runat="server" Text="4分以上" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style36" >
                                <asp:Label ID="Label13" runat="server" Text="2-3分" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style16" >
                                <asp:Label ID="Label14" runat="server" Text="2分以下" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style17" >
                                <asp:Label ID="LbShlScore1" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style18" >
                                <asp:Label ID="LbProvinceScore1" runat="server" Text="" ForeColor="Blue"></asp:Label> 
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style11" >
                                <asp:Label ID="Label16" runat="server" Text="工具使用(20分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style38" >
                                <asp:Label ID="Label17" runat="server" Text="18分以上" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style36" >
                                <asp:Label ID="Label18" runat="server" Text="13-17分" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style16" >
                                <asp:Label ID="Label19" runat="server" Text="12分以下" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style17" >
                                <asp:Label ID="LbShlScore2" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style18" >            
                                <asp:Label ID="LbProvinceScore2" runat="server" Text="" ForeColor="Blue"></asp:Label> 
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="2" style="border: thin Ridge black" 
                                class="style13" >
                                <asp:Label ID="Label21" runat="server" Text="文本的合理性(15分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style25" >
                                <asp:Label ID="Label22" runat="server" Text="文本撰寫(5分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style39" >
                                <asp:Label ID="Label23" runat="server" Text="4分以上" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style27" >
                                <asp:Label ID="Label24" runat="server" Text="2-3分" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style28" >
                                <asp:Label ID="Label25" runat="server" Text="2分以下" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style29" >
                                <asp:Label ID="LbShlScore3" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style30" >                               
                                <asp:Label ID="LbProvinceScore3" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style11" >
                                <asp:Label ID="Label27" runat="server" Text="文本質量(10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style38" >
                                <asp:Label ID="Label28" runat="server" Text="9分以上" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style36" >
                                <asp:Label ID="Label29" runat="server" Text="7-8分" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black"" 
                                class="style16" >
                                <asp:Label ID="Label30" runat="server" Text="6分以下" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style17" >
                                <asp:Label ID="LbShlScore4" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style18" >                                
                                <asp:Label ID="LbProvinceScore4" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                            <td align="center" colspan="1" rowspan="3" style="border: thin Ridge black" 
                            class="style12">
                                <asp:Label ID="Label32" runat="server" Text="学校发展计划的实施(30分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="3" style="border: thin Ridge black" 
                            class="style13" >
                                <asp:Label ID="Label33" runat="server" Text="实施的规范性(30分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                            class="style11">
                                <asp:Label ID="Label34" runat="server" Text="履行职责(13分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                            class="style38" >
                                <asp:Label ID="Label35" runat="server" Text="11分以上" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" 
                            style="border: thin Ridge black" class="style36" >
                                <asp:Label ID="Label36" runat="server" Text="8-10分" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                            class="style16" >
                                <asp:Label ID="Label37" runat="server" Text="7分以下" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                            class="style17" >
                                <asp:Label ID="LbShlScore5" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                            class="style18" >                                
                                <asp:Label ID="LbProvinceScore5" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                             <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style11" >
                                <asp:Label ID="Label39" runat="server" Text="自评调整(7分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style38" >
                                <asp:Label ID="Label40" runat="server" Text="5分以上" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style36" >
                                <asp:Label ID="Label41" runat="server" Text="5-6分" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style16" >
                                <asp:Label ID="Label42" runat="server" Text="4分以下" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style17" >
                                <asp:Label ID="LbShlScore6" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style18" >                               
                                <asp:Label ID="LbProvinceScore6" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style11" >
                                <asp:Label ID="Label44" runat="server" Text="合作互动 (10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style38" >
                                <asp:Label ID="Label46" runat="server" Text="9分以上" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style36" >
                                <asp:Label ID="Label47" runat="server" Text="7-8分" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style16" >
                                <asp:Label ID="Label48" runat="server" Text="6分以下" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style17" >
                                <asp:Label ID="LbShlScore7" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style18" >                               
                                <asp:Label ID="LbProvinceScore7" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="5" style="border: thin Ridge black" 
                                class="style12" >
                                <asp:Label ID="Label45" runat="server" Text="学校发展计划的成效(30+20分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="3" style="border: thin Ridge black" 
                                class="style13" >
                                <asp:Label ID="Label50" runat="server" Text="自主目标实现(30分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style11" >
                                <asp:Label ID="Label51" runat="server" Text="学科能力(10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style38" >
                                <asp:Label ID="Label52" runat="server" Text="9分以上" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style36" >
                                <asp:Label ID="Label53" runat="server" Text="7-8分" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style16" >
                                <asp:Label ID="Label54" runat="server" Text="6分以下" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style17" >
                                <asp:Label ID="LbShlScore8" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style18" >                               
                                <asp:Label ID="LbProvinceScore8" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                             <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style11" >
                                <asp:Label ID="Label56" runat="server" Text="人格陶冶(10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style38" >
                                <asp:Label ID="Label57" runat="server" Text="9分以上" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style36" >
                                <asp:Label ID="Label58" runat="server" Text="7-8分" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style16" >
                                <asp:Label ID="Label59" runat="server" Text="6分以下" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style17" >
                                <asp:Label ID="LbShlScore9" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style18" >                               
                                <asp:Label ID="LbProvinceScore9" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                             <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style11" >
                                <asp:Label ID="Label67" runat="server" Text="学校管理(10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style38" >
                                <asp:Label ID="Label72" runat="server" Text="9分以上" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style36" >
                                <asp:Label ID="Label73" runat="server" Text="6-8分" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style16" >
                                <asp:Label ID="Label74" runat="server" Text="5分以下" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style17" >
                                <asp:Label ID="LbShlScore10" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style18" >                                
                                <asp:Label ID="LbProvinceScore10" runat="server" Text="" ForeColor="Blue"></asp:Label>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="2" style="border: thin Ridge black" 
                                class="style13" >
                                <asp:Label ID="Label61" runat="server" Text="预期目标实现(20分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style11" >
                                <asp:Label ID="Label62" runat="server" Text="获奖情况(10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="3" rowspan="1" style="border: thin Ridge black" >
                                <asp:Label ID="Label63" runat="server" Text="" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style17" >
                                <asp:Label ID="LbShlScore11" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style18" >                                
                                <asp:Label ID="LbProvinceScore11" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style11" >
                                <asp:Label ID="Label64" runat="server" Text="特色创新(10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="3" rowspan="1" style="border: thin Ridge black" >
                                <asp:Label ID="Label68" runat="server" Text="" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style17" >
                                <asp:Label ID="LbShlScore12" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style18" >                                
                                <asp:Label ID="LbProvinceScore12" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" rowspan="1" style="border: thin Ridge black">
                                <asp:Label ID="LbGuideResultAssessment" runat="server" Text="总体评估(100分+20分)"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style38" >
                                <asp:Label ID="Label65" runat="server" Text="85分以上" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style36" >
                                <asp:Label ID="Label69" runat="server" Text="61-84分" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                <asp:Label ID="Label70" runat="server" Text="60分以下" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                <asp:Label ID="LbShlScoreLevel" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                <asp:Label ID="LbProvinceScoreLevel" runat="server" Text="" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="3" rowspan="1" style="border: thin Ridge black" 
                                class="style22">
                                <asp:Label ID="Label15" runat="server" Text="等级判定(根据评估等级得分)"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style23">
                                <asp:Label ID="Label150" runat="server" Text="学校" ></asp:Label>
                            </td>
                            <td align="center" colspan="2" rowspan="1" style="border: thin Ridge black" class="style36" 
                                >
                                <asp:Label ID="LbScoreLevelSchool" runat="server" ForeColor="Blue"></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style22">
                                <asp:Label ID="Label20" runat="server" Text="专家组" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style22">
                                <asp:Label ID="LbScoreLevelExpert" runat="server" ForeColor="Blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" height="150px" style="border: thin Ridge black">
                                <asp:Label ID="LbDescription" runat="server" Text="说明"></asp:Label>
                            </td>
                            <td align="left" colspan="7" height="150px" style="border: thin Ridge black">
                                <asp:Label ID="LbDescriptionContent" runat="server" Text="评估等级A、B、C三个等级，A为好（主要为优点，虽然有一些不足，但优点多于不足），B为中（有一些主要的不足，应该引起学校的高度关注，做为下一年改进的重点），C为差（存在大量的不足，这些不足严重影响学校的发展，学校应该着手进行改变）。"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="8">
                                <asp:Button ID="BtnCancel" runat="server" Text="返回" Height="22px" 
                                    Width="58px" onclick="BtnCancel_Click"  />
                            </td>
                        </tr>
                </table>
    </div>
    </form>
</body>
</html>
