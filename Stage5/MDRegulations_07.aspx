<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MDRegulations_07.aspx.cs" Inherits="Stage5_MDRegulations_07" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        #BlockLeft {
            float: left;
            padding-top: 235px;
            width: 285px;
        }
        #BlockRight {
            float: left;
            padding-top: 210px;
            width: 739px;
        }
        #BlockRightUp {
            height: 40px;
            padding-left:25px;
        }
        #BlockRightDown {
            padding-top: 10px;
        }
        #BlockRightDownController {
            height:55px;
        }
        #BlockRightDownDataDisplay {
        
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
        .paneltop
        {
            border:1px solid black;
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
                <asp:HyperLink ID="HlInternetStudy" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="../Expert/ViewInternetStudyScore.aspx" Text="<%$ Resources:Resource, HyInternetStudy %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlKPI" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrL="../Expert/KPIExamMain.aspx" Text="<%$ Resources:Resource, HyKPI %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlSchoolDevelop" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="../Expert/PlanViewList.aspx" Text="<%$ Resources:Resource, HySchoolDevelop %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="../Expert/GuidePreList.aspx" Text="<%$ Resources:Resource, HyFollowingMonitor %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Stage5/MDRegulations_00.aspx" Text="<%$ Resources:Resource, HyRuleManage %>"></asp:HyperLink>
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
                    <asp:Label ID="LbLocation" runat="server" Text="规章制度管理" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownDataDisplay">
                    <table align="center" >
                        <tr>
                        <td>
                        <asp:Label ID="Label1" runat="server" Text="规章制度选单:"></asp:Label>
                        <asp:DropDownList ID="DlRegulationSelect" runat="server" AutoPostBack="true"  Font-Size="14px" Width="177px" Height="30px"
                            onselectedindexchanged="SelectedIndexChanged" >
                            <asp:ListItem Selected="True" Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">党支部制度</asp:ListItem>
                            <asp:ListItem Value="2">少先队工作制度</asp:ListItem>
                            <asp:ListItem Value="3">教师及领导岗位职责</asp:ListItem>
                            <asp:ListItem Value="4">图书室管理制度及细则</asp:ListItem>
                            <asp:ListItem Value="5">管理细则</asp:ListItem>
                            <asp:ListItem Value="6">安全制度</asp:ListItem>
                            <asp:ListItem Value="7">其它管理制度</asp:ListItem>
                        </asp:DropDownList>
                          </td>
                    </tr>
                    </table>
                    <table align="center" width="700">
　                    <tr align="center" align="center">
　                    <td colspan="5" height="50" bgcolor="#eebb95">其它管理制度</td>
　                    </tr>
　                    <tr align="center" height="120">
　                    <td width="20%"><a href="./其它管理制度（30）/三好生等评选制度.WPS"><img src="./icon_download.png"><br><br>三好生等评选制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/卫生工作制度.WPS"><img src="./icon_download.png"><br><br>卫生工作制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/卫生公约.WPS"><img src="./icon_download.png"><br><br>卫生公约</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/小学生日常行为规范.WPS"><img src="./icon_download.png"><br><br>小学生日常行为规范</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/中小学生守则.WPS"><img src="./icon_download.png"><br><br>中小学生守则</a></td>
　                    </tr>
　                    <tr align="center" height="120">
　                    <td width="20%"><a href="./其它管理制度（30）/办学章程.WPS"><img src="./icon_download.png"><br><br>办学章程</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/文体器材管理使用制度.WPS"><img src="./icon_download.png"><br><br>文体器材管理使用制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/文明礼貌公约.WPS"><img src="./icon_download.png"><br><br>文明礼貌公约</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/电教设施管理制度.WPS"><img src="./icon_download.png"><br><br>电教设施管理制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/任课教师常规考核.doc"><img src="./icon_download.png"><br><br>任课教师常规考核</a></td>
　                    </tr>
                    <tr align="center" height="120">
　                    <td width="20%"><a href="./其它管理制度（30）/任课教师常规考核表.doc"><img src="./icon_download.png"><br><br>任课教师常规考核表</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/体育工作制度.WPS"><img src="./icon_download.png"><br><br>体育工作制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/财务管理制度.WPS"><img src="./icon_download.png"><br><br>财务管理制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/学生一日常规.WPS"><img src="./icon_download.png"><br><br>学生一日常规</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/学生学籍管理制度.WPS"><img src="./icon_download.png"><br><br>学生学籍管理制度</a></td>
　                    </tr>
                    <tr align="center" height="120">
　                    <td width="20%"><a href="./其它管理制度（30）/学生常规管理制度.WPS"><img src="./icon_download.png"><br><br>学生常规管理制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/实验室管理制度.WPS"><img src="./icon_download.png"><br><br>实验室管理制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/总则00.WPS"><img src="./icon_download.png"><br><br>总则00</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/家长参与管理制度.docx"><img src="./icon_download.png"><br><br>家长参与管理制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/家校联系制度.WPS"><img src="./icon_download.png"><br><br>家校联系制度</a></td>
　                    </tr>
                    <tr align="center" height="120">
　                    <td width="20%"><a href="./其它管理制度（30）/教师办公室制度.WPS"><img src="./icon_download.png"><br><br>教师办公室制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/教师成长记录袋的实施办法.WPS"><img src="./icon_download.png"><br><br>教师成长记录袋的实施办法</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/教师职业道德建设基本要求.WPS"><img src="./icon_download.png"><br><br>教师职业道德建设基本要求</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/教学工作管理制度.WPS"><img src="./icon_download.png"><br><br>教学工作管理制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/教学常规管理制度.WPS"><img src="./icon_download.png"><br><br>教学常规管理制度</a></td>
　                    </tr>
                    <tr align="center" height="120">
　                    <td width="20%"><a href="./其它管理制度（30）/教学楼楼内规则.bak"><img src="./icon_download.png"><br><br>教学楼楼内规则</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/教职工代表大会制度.WPS"><img src="./icon_download.png"><br><br>教职工代表大会制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/教职工行政管理制度.bak"><img src="./icon_download.png"><br><br>教职工行政管理制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/德育工作制度.WPS"><img src="./icon_download.png"><br><br>德育工作制度</a></td>
                     <td width="20%"><a href="./其它管理制度（30）/德育工作规程.WPS"><img src="./icon_download.png"><br><br>德育工作规程</a></td>
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
