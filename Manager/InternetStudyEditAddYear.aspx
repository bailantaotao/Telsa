<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InternetStudyEditAddYear.aspx.cs" Inherits="Manager_InternetStudyEditAddYear" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script language="javascript" type="text/javascript">
        function Conversion2() {
            var year = parseInt(document.getElementById('ToDay').value.substr(0, 4)) - 1911;
            document.getElementById('ToDay').value = year + document.getElementById('ToDay').value.substr(4, 8);
        }
    </script>
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
    <script language="javascript" type="text/javascript">
        function Conversion2() {
            var year = parseInt(document.getElementById('ViewDay').value.substr(0, 4)) - 1911;
            document.getElementById('ViewDay').value = year + document.getElementById('ViewDay').value.substr(4, 8);
        }
    </script>
</head>
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(../<%= backgroundImage %>) no-repeat center top;">
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ToolkitScriptManager1" CombineScripts="false" />
    <div align="center" style="width: 1024px; margin: 0px auto;">
        <div id="BlockLeft">
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
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="#" Text="<%$ Resources:Resource, HyFollowingMonitor %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="#" Text="<%$ Resources:Resource, HyRuleManage %>"></asp:HyperLink>
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
                    <asp:Label ID="LbLocation" runat="server" Text="<%$ Resources:Resource, TipInternetStudy %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyBtnStudy" runat="server" Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Resource, TipTeachContent %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyBtnScore" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, TipSearchScore %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                        NavigateUrl="~/Manager/InternetStudyScore.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <div style="text-align:center; height:39px;  line-height:39px; margin-left: 20px;text-align:left">
                        <asp:Label ID="LbYear" runat="server" Text="新增100年度：" Font-Bold="true" Font-Size="22pt"></asp:Label>
                    </div>
                    
                    <div style="text-align:center; width: 739px; height:50px;  line-height:55px; vertical-align:middle; text-align:right;">
                        <asp:Button ID="BtnBack" runat="server" Text="<%$ Resources:Resource, BtnBackPage %>" OnClick="Btn_Click" />
                        <asp:Button ID="BtnCancel" runat="server" Text="<%$ Resources:Resource, BtnCancelAdd %>" OnClick="Btn_Click" />
                    </div>
                </div>
                <div style="text-align:center; height:39px; line-height:50px; margin-left: 30px; text-align:left">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, TipStage1 %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeH3Title %>"></asp:Label>
                </div>
                <div align="left" style="text-align:center; height:39px; margin-left: 60px; text-align:left;margin-top:20px">
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Resource, TipInputDeadline %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeH4Title %>"></asp:Label>
                    <asp:TextBox ID="TbToday" runat="server" Width="300px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="TbToday"
                                    Enabled="True" TargetControlID="TbToday" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                </div>
                <div style="margin-left: 30px">
                    <hr />
                </div>
                <div style="text-align:center; height:39px; line-height:39px; margin-left: 30px; text-align:left">
                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Resource, TipStage2 %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeH3Title %>"></asp:Label>
                </div>
                <div align="left" style="text-align:center; height:39px; line-height:39px; margin-left: 60px; text-align:left; ">
                    <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Resource, TipInputQuestions %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeH4Title %>"></asp:Label>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 739px">
                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label ID="LbCompleted" runat="server"></asp:Label>         
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="margin-left: 30px">
                    <hr />
                </div>
                <div style="text-align:center; height:39px; line-height:39px; margin-left: 30px; text-align:left">
                    <asp:Label ID="Label6" runat="server" Text="<%$ Resources:Resource, TipStage3 %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeH3Title %>"></asp:Label>
                </div>
                <div align="left" style="text-align:center; height:39px; line-height:39px; margin-left: 60px; text-align:left; ">
                    <asp:Button ID="BtnCompleted" runat="server" Text="<%$ Resources:Resource, BtnPlzFinishQuestionnaire %>" OnClick="Btn_Click" Enabled="False" />
                </div>
            </div>
        </div>
        <asp:Literal ID="ClientScriptArea" runat="server"></asp:Literal> 
    </div>
    </form>
</body>
</html>
