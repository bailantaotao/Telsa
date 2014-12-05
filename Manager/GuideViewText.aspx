<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuideViewText.aspx.cs" Inherits="Manager_GuideViewText" %>

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
                <asp:HyperLink ID="HlInternetStudy" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/InternetStudyEdit.aspx" Text="<%$ Resources:Resource, HyInternetStudy %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlKPI" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/KPIExamMain.aspx" Text="<%$ Resources:Resource, HyKPI %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlSchoolDevelop" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/PlanViewList.aspx" Text="<%$ Resources:Resource, HySchoolDevelop %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/GuideViewPreList.aspx" Text="<%$ Resources:Resource, HyFollowingMonitor %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/Stage5/MDRegulations_00.aspx" Text="<%$ Resources:Resource, HyRuleManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlStudentManage" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/QManage.aspx" Text="<%$ Resources:Resource, HyStudentManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlQuestinnaire" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/SurveyViewPreList.aspx" Text="<%$ Resources:Resource, HyQuestionnaire %>"></asp:HyperLink>
            </div>
        </div>
        <div id="BlockRight">
            <div id="BlockRightUp">
                <div style="background: url(../Image/zh-TW/TipGary_TipUserLocation.png) no-repeat; text-align:center; width: 175px; height:39px; float: left;  line-height:39px;">
                    <asp:Label ID="LbLocation" runat="server" Text="后期跟踪指导" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Red" Text="执行/监测报告观看" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="GuideViewPreList.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Black" Text="学年新增" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="GuideAdd.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table width="739px">
                       <tr>
                           <td align="center"  colspan="2">
                                &nbsp&nbsp&nbsp<asp:Label ID="LbGuideText" runat="server" Text="执行/监测报告正文"></asp:Label>
                           </td>
                       </tr>
                       <tr>
                           <td>
                               &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideTextUserName" runat="server"></asp:Label>
                           </td>
                           <td>
                               &nbsp;</td>
                       </tr>
                       <tr>
                            <td align="left"  >
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideTextYear" runat="server" Text="学年：" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="LbGuideYear" runat="server" Text=""></asp:Label>
                                
                            &nbsp;

                            </td>
                            <td align="left" width="30%">
                                <asp:Label ID="LbGuideTextSemester" runat="server" Text="学期：" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="LbGuideSemester" runat="server" Text=""></asp:Label>
                                
                            </td>
                            <td align="left" width="30%">
                                <asp:Label ID="LbGuideTextNo" runat="server" Text="项次：" ForeColor="Blue"></asp:Label>
                                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True">
                                    <asp:ListItem>请选择</asp:ListItem>
                                </asp:DropDownList>
                               
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="3"><asp:Button ID="BtnCancel" runat="server" Text="返回" Height="22px" 
                                    Width="58px" onclick="BtnCancel_Click" />
                            </td>
                        </tr>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 735px">
                        <tr>
                            <td align="left" >
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideTextContent" runat="server" Text="一、指导活动的目的和主要活动内容"></asp:Label>   
                            </td>    
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                <asp:TextBox ID="LbGuideViewTextContent" runat="server" BorderStyle="Inset" 
                                    BorderWidth="3px" Width="665px" Font-Size="16px" Height="38px" 
                                    ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" >
                               &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideTextAction" runat="server" Text="（一）指导活动（学校发展计划）"></asp:Label> 
                            </td>    
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideTextSubject" runat="server" Text="1.学科能力："></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                <asp:TextBox ID="LbGuideViewTextSubject" runat="server" BorderStyle="Inset" 
                                    BorderWidth="3px" Width="643px" Font-Size="16px" Height="38px" 
                                    ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideTextPersonality" runat="server" Text="2.人格陶冶："></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                <asp:TextBox ID="LbGuideViewTextPersonality" runat="server" BorderStyle="Inset" 
                                    BorderWidth="3px" Width="643px" Font-Size="16px" Height="38px" 
                                    ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideTextSchoolManagement" runat="server" Text="3.学校管理："></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                <asp:TextBox ID="LbGuideViewTextSchoolManagement" runat="server" BorderStyle="Inset" 
                                    BorderWidth="3px" Width="643px" Height="38px" Font-Size="16px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" >
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideTextProgress" runat="server" Text="二、学校发展计划工作进展"></asp:Label>   
                            </td>    
                        </tr>
                        <tr>
                            <td align="center">
                               &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideTextSDPFormulate" runat="server" Text="（一）学校发展计划的制定"></asp:Label> 
                            </td>    
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                <asp:TextBox ID="LbGuideViewTextSDPFormulate" runat="server" BorderStyle="Inset" 
                                    BorderWidth="3px" Width="643px" ReadOnly="True" TextMode="MultiLine" Height="38px" Font-Size="16px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideTextSDPImplement" runat="server" Text="（二）学校发展计划的实施"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                <asp:TextBox ID="LbGuideViewTextSDPImplement" runat="server" BorderStyle="Inset" 
                                    BorderWidth="3px" Width="643px" Font-Size="16px" Height="38px" ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideTextSDPeffect" runat="server" Text="（三）学校发展计划取得的成效"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                <asp:TextBox ID="LbGuideViewTextSDPeffect" runat="server" BorderStyle="Inset" 
                                    BorderWidth="3px" Width="643px" ReadOnly="True" TextMode="MultiLine" Font-Size="16px" Height="38px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="">
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideTextNextStepSuggest" runat="server" Text="三、下一步工作的改进建议"></asp:Label>   
                            </td>    
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                <asp:TextBox ID="LbGuideViewTextNextStepSuggest" runat="server" BorderStyle="Inset" 
                                    BorderWidth="3px" Width="665px" Font-Size="16px" Height="38px" 
                                    ReadOnly="True" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                </div>
            </div>
        </div>
        <asp:Literal ID="ClientScriptArea" runat="server"></asp:Literal> 
    </div>
    </form>
</body>
</html>
