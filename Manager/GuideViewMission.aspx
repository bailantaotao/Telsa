<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuideViewMission.aspx.cs" Inherits="Manager_GuideViewMission" %>

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
            height: 21px;
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
            width: 93%;
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
                    <table width="739px" style="height: 18px">
                       <tr>
                           <td align="center" class="style1">
                                <asp:Label ID="LbGuideSummary" runat="server" Text="跟踪指导专家任务书"></asp:Label>
                           </td>
                           <td align="right">
                                 <asp:Button ID="BtnCancel" runat="server" Text="返回" style="height: 21px" onclick="BtnCancel_Click"  />
                            </td>
                       </tr>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 735px">
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="Label2" runat="server" Text="年月:" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="LbGuideViewMissionTime" runat="server" Text="" BorderStyle="Inset" BorderWidth="3px"></asp:Label>
                                
                            </td>
                            
                        </tr>
                        <tr>
                            <td> 
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="Label3" runat="server" Text="1.项目组委托成专家小组成员"></asp:Label>  
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                                <asp:Label ID="LbGuideViewMissionMember" runat="server" Text="" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="Label4" runat="server" Text="于"></asp:Label>
                                <asp:Label ID="LbGuideViewMissionStartTime" runat="server" Text="" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="Label5" runat="server" Text="至"></asp:Label>
                                <asp:Label ID="LbGuideViewMissionEndTime" runat="server" Text="" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="Label6" runat="server" Text="，实地指导目标学校"></asp:Label>
                                <asp:Label ID="LbGuideViewMissionTargetSchool" runat="server" Text="" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="Label7" runat="server" Text="，了解"></asp:Label>
                                <asp:Label ID="LbGuideViewMissionSchoolNum" runat="server" Text="" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="Label8" runat="server" Text="所明德小学在教学、管理等方面出现的困惑和问题，关注学校发展计划在执行中存在的问题并给予帮助支持。"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="Label9" runat="server" Text="2.重点关注这几所目标学校在学校发展计画执行中的情况， 完成执行/监测报告，分"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="Label12" runat="server" Text="析总结经验，便于交流推广。"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="Label10" runat="server" Text="3.注意对全程活动进行文字和图片(照相)资料的收集;"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="Label11" runat="server" Text="4.在跟蹤指導結束一周內，完成一個配有照片的總結，用於宣傳及監測評估。"></asp:Label>
                                </td>
                            </tr>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                        </tr>
                     </table>
          </div>
    </form>
</body>
</html>
