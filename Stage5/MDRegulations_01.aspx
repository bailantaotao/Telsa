<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MDRegulations_01.aspx.cs" Inherits="Stage5_MDRegulations_01" %>

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
　                        <td colspan="5" height="50" bgcolor="#eebb95">党支部制度</td>
　                      </tr>
　                      <tr align="center" height="120">
　                       <td width="20%"><a href="./党支部制度（20）/“不作为党员”告诫制度.WPS"><img src="./icon_download.png"><br><br>“不作为党员”告诫制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/公章（介绍信）使用管理制度.WPS"><img src="./icon_download.png"><br><br>公章（介绍信）使用管理制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/计划和总结工作制度.WPS"><img src="./icon_download.png"><br><br>计划和总结工作制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/民主评议党员制度.WPS"><img src="./icon_download.png"><br><br>民主评议党员制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/保密工作制度.WPS"><img src="./icon_download.png"><br><br>保密工作制度</a></td>
　                      </tr>
　                      <tr align="center" height="120">
　                       <td width="20%"><a href="./党支部制度（20）/思想政治工作制度.WPS"><img src="./icon_download.png"><br><br>思想政治工作制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/政治学习制度.WPS"><img src="./icon_download.png"><br><br>政治学习制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/党内监督制度.WPS"><img src="./icon_download.png"><br><br>党内监督制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/党员大会制度.WPS"><img src="./icon_download.png"><br><br>党员大会制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/党员民主生活会制度.WPS"><img src="./icon_download.png"><br><br>党员民主生活会制度</a></td>
　                      </tr>
　                      <tr align="center" height="120">
　                       <td width="20%"><a href="./党支部制度（20）/党员汇报制度.WPS"><img src="./icon_download.png"><br><br>党员汇报制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/党员组织关系接转制度.WPS"><img src="./icon_download.png"><br><br>党员组织关系接转制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/党员活动制度.WPS"><img src="./icon_download.png"><br><br>党员活动制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/党员联系制度.WPS"><img src="./icon_download.png"><br><br>党员联系制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/党员群众评议支部制度.WPS"><img src="./icon_download.png"><br><br>党员群众评议支部制度</a></td>
　                      </tr>
　                      <tr align="center" height="120">
　                        <td width="20%"><a href="./党支部制度（20）/党费缴纳管理制度.WPS"><img src="./icon_download.png"><br><br>党费缴纳管理制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/党积极分子培养教育管理制度.WPS"><img src="./icon_download.png"><br><br>党积极分子培养教育管理制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/党课制度.WPS"><img src="./icon_download.png"><br><br>党课制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/班子民主生活会制度.WPS"><img src="./icon_download.png"><br><br>班子民主生活会制度</a></td>
                         <td width="20%"><a href="./党支部制度（20）/请示报告制度.WPS"><img src="./icon_download.png"><br><br>请示报告制度</a></td>
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
