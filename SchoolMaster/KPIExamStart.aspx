<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KPIExamStart.aspx.cs" Inherits="SchoolMaster_KPIExamStart" %>
<%@ Register Src="UserControlKPIAnswer.ascx" TagName="SchoolMaster_UserControlKPIAnswer" TagPrefix="SchoolMaster_UserControlKPIAnswer" %>
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
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(../Image/zh-CN/Background.png) no-repeat center top;">
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
                <asp:HyperLink ID="HlInternetStudy" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="javascript:window.alert('请完成试题再做点选');" Text="<%$ Resources:Resource, HyInternetStudy %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlKPI" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="javascript:window.alert('请完成试题再做点选');" Text="<%$ Resources:Resource, HyKPI %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlSchoolDevelop" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="javascript:window.alert('请完成试题再做点选');" Text="<%$ Resources:Resource, HySchoolDevelop %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="javascript:window.alert('请完成试题再做点选');" Text="<%$ Resources:Resource, HyFollowingMonitor %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="javascript:window.alert('请完成试题再做点选');" Text="<%$ Resources:Resource, HyRuleManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlStudentManage" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="javascript:window.alert('请完成试题再做点选');" Text="<%$ Resources:Resource, HyStudentManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlQuestinnaire" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="javascript:window.alert('请完成试题再做点选');" Text="<%$ Resources:Resource, HyQuestionnaire %>"></asp:HyperLink>
            </div>
        </div>
        <div id="BlockRight">
            <div id="BlockRightUp">
                <div style="background: url(../Image/zh-TW/TipGary_TipUserLocation.png) no-repeat; text-align:center; width: 175px; height:39px; float: left;  line-height:39px;">
                    <asp:Label ID="LbLocation" runat="server" Text="<%$ Resources:Resource, TipKpiManage %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyBtnStudy" runat="server" Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Resource, TipKpiAnswer %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="javascript:window.alert('请完成试题再做点选');"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, TipKpiScoreSearch %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="javascript:window.alert('请完成试题再做点选');"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <div style="float:left; padding-left:30px">
                        <asp:DropDownList ID="DdlDimension" runat="server" Width="120px"  AutoPostBack="true" OnSelectedIndexChanged="DdlDimension_SelectedIndexChanged">
                            <asp:ListItem Text="<%$ Resources:Resource, TipPlzChoose %>"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="float:left; padding-left:30px">
                        <asp:DropDownList ID="DdlDomain" runat="server" Width="170px" OnSelectedIndexChanged="DdlDomain_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="<%$ Resources:Resource, TipPlzChoose %>"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div style="float:left; padding-left:30px">
                        <asp:Button ID="BtnStartInput" runat="server" Text="<%$ Resources:Resource, ButtonStartInput %>" Enabled="false" />
                    </div>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>--%>
                            <asp:Panel ID="PnMain" runat="server" Width="739px" Height="600px">
                        
                            </asp:Panel>
                        <%--</ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="BtnStartInput" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                    <div style="float:left; padding-left:30px">
                        <asp:Button ID="BtnSubmit" runat="server" Text="<%$ Resources:Resource, BtnSubmit %>" OnClick="Btn_Click" />
                    </div>
                    <div style="float:left; padding-left:30px">
                        <asp:Button ID="BtnCancel" runat="server" Text="<%$ Resources:Resource, BtnCancel %>" OnClick="Btn_Click" OnClientClick="return confirm('你确定真的要取消吗?')"/>
                    </div>
                </div>
            </div>
        </div>
        <asp:Literal ID="ClientScriptArea" runat="server"></asp:Literal> 
    </div>
    </form>
</body>
</html>
