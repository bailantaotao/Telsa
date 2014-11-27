<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QViewStudent.aspx.cs" Inherits="Manager_QViewStudent" %>

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
            margin-top:350px;
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
        .auto-style1 {
            height: 26px;
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
                    <asp:Label ID="LbLocation" runat="server" Text="<%$ Resources:Resource, QStudentManageTip %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Resource, QStudentData %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="QViewStudentList.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, QStudentScore %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="QViewScoreList.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, QDeadline %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="QManage.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                    <table width="739px">
                        <tr>
                            <td align="left">
                                学校: <asp:Label ID="LbSchool" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="left">
                                学年: <asp:Label ID="LbYear" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="left">
                                学期: <asp:Label ID="LbSemester" runat="server" Text=""></asp:Label>
                            </td>
                            <td align="left">
                                学校代号: <asp:Label ID="LbSchoolNo" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="739px" style="margin-top:10px">
                        <tr>
                            <td align="left" colspan="5">
                                <h2>学生基本资料观看</h2>
                            </td>
                        </tr>
                        <tr>
                            <td width="100px" style="padding-left:30px;">学生姓名:</td>
                            <td align="left" width="140px">
                                <asp:TextBox ID="TbStudentName" runat="server" Width="100px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td width="120px" align="left">学籍辅号:</td>
                            <td width="150px" align="left">
                                <asp:TextBox ID="TbIdentifyId" runat="server" Width="100px" Font-Size="14pt"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="BtnStudentSearch" runat="server" Text="查询" OnClick="BtnStudentSearch_Click"  Font-Size="14pt"/>
                            </td>
                        </tr>
                        <tr></tr>
                    </table>
                    <table style="margin-bottom:10px; height:60px">
                        <tr>
                            <td>
                                <asp:Label ID="LbStudentContent" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="739px">
                        <tr>
                            <td align="left" colspan="5">
                                <h2>班级人员观看</h2>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DdlGradeLevel" runat="server" Width="80px" Font-Size="14pt" AutoPostBack="true" OnSelectedIndexChanged="DdlGradeLevel_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="BtnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left">
                            </td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DdlClass" runat="server" Width="80px" Font-Size="14pt" AutoPostBack="true" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="BtnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DdlStudentID" runat="server" Width="80px" Font-Size="14pt" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="BtnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Button ID="BtnSearch" runat="server" Text="查询" OnClick="BtnSearch_Click"  Font-Size="14pt"/>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 735px">
                        <tr>
                            <td align="right">
                                
                                <asp:UpdatePanel ID="UpdatePageSelect" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Label15" runat="server" Font-Size="<%$ Resources:Resource, TextSizeTip %>" Text="<%$ Resources:Resource, TipNo %>"></asp:Label>
                                        &nbsp;<asp:DropDownList ID="DdlPageSelect" runat="server" AutoPostBack="True" 
                                            Font-Size="Small" onselectedindexchanged="PageSelect_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp;<asp:Label ID="Label16" runat="server" Font-Size="<%$ Resources:Resource, TextSizeTip %>" Text="<%$ Resources:Resource, TipPage %>"></asp:Label>
                                    </ContentTemplate>
                                    <%--<Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ImgBtnSearch" EventName="Click" />
                                    </Triggers>--%>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:UpdatePanel ID="UpdateCompleted" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="LbCompleted" runat="server"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="DdlPageSelect" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="center">
                                <asp:UpdatePanel ID="UpdatePageOrder" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Label1" runat="server" Font-Size="<%$ Resources:Resource, TextSizeTip %>" Text="<%$ Resources:Resource, TipNo %>"></asp:Label>
                                        &nbsp;<asp:Label ID="PageOrder" runat="server" Font-Size="Small"></asp:Label>
                                        &nbsp;<asp:Label ID="Label3" runat="server" Font-Size="<%$ Resources:Resource, TextSizeTip %>" Text="<%$ Resources:Resource, TipPage %>"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="LbTotalCount" runat="server" Font-Size="Small"></asp:Label>
                                    </ContentTemplate>
                                    <%--<Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ImgBtnSearch" EventName="Click" />
                                    </Triggers>--%>
                                </asp:UpdatePanel>
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
