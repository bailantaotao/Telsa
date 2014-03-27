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
            padding-top: 295px;
            width: 230px;
        }
        #BlockRight {
            float: left;
            padding-top: 270px;
            width: 1070px;
        }
        #BlockRightUp {
            height: 65px;
            padding-left:25px;
        }
        #BlockRightDown {
            padding-top: 20px;
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
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(../Image/zh-TW/Background.png) no-repeat center top;">
    <form id="form1" runat="server">
    <div align="center" style="width: 1300px; margin: 0px auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
        </asp:ScriptManager>
        <div id="BlockLeft">
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInternetStudy" runat="server" ForeColor="White" Font-Size="14px" NavigateUrl="#" Text="<%$ Resources:Resource, HyInternetStudy %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlKPI" runat="server" ForeColor="White" Font-Size="14px" NavigateUrl="#" Text="<%$ Resources:Resource, HyKPI %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlSchoolDevelop" runat="server" ForeColor="White" Font-Size="14px" NavigateUrl="#" Text="<%$ Resources:Resource, HySchoolDevelop %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="14px" NavigateUrl="#" Text="<%$ Resources:Resource, HyFollowingMonitor %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="14px" NavigateUrl="#" Text="<%$ Resources:Resource, HyRuleManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlStudentManage" runat="server" ForeColor="White" Font-Size="14px" NavigateUrl="#" Text="<%$ Resources:Resource, HyStudentManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlQuestinnaire" runat="server" ForeColor="White" Font-Size="14px" NavigateUrl="#" Text="<%$ Resources:Resource, HyQuestionnaire %>">></asp:HyperLink>
            </div>
        </div>
        <div id="BlockRight">
            <div id="BlockRightUp">
                <div style="background: url(../Image/zh-TW/TipGary_TipUserLocation.png) no-repeat; text-align:center; width: 175px; height:39px; float: left;  line-height:39px;">
                    <asp:Label ID="LbLocation" runat="server" Text="<%$ Resources:Resource, TipInternetStudy %>" Font-Bold="true"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyBtnStudy" runat="server" Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Resource, TipTeachContent %>"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyBtnScore" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, TipSearchScore %>"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <div style="text-align:center; height:39px; float: left;  line-height:39px; margin-left: 20px">
                        <asp:Label ID="LbYear" runat="server" Text="新增100年度：" Font-Bold="true" Font-Size="26px"></asp:Label>
                    </div>
                    
                    <div style="text-align:center; width: 850px; height:50px; float: left;  line-height:55px; vertical-align:middle; text-align:right;">
                        <asp:Button ID="BtnBack" runat="server" Text="<%$ Resources:Resource, BtnBackPage %>" OnClick="Btn_Click" />
                        <asp:Button ID="BtnCancel" runat="server" Text="<%$ Resources:Resource, BtnCancelAdd %>" OnClick="Btn_Click" />
                    </div>
                </div>
                <div style="text-align:center; height:39px; line-height:39px; margin-left: 30px; text-align:left">
                    <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, TipStage1 %>" Font-Bold="true" Font-Size="20px"></asp:Label>
                </div>
                <div align="left" style="text-align:center; height:39px; line-height:39px; margin-left: 60px; text-align:left; ">
                    <asp:Label ID="Label3" runat="server" Text="<%$ Resources:Resource, TipInputDeadline %>" Font-Bold="true" Font-Size="16px"></asp:Label>
                    
                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>--%>
                    <asp:TextBox ID="TbToday" runat="server" Width="300px" CausesValidation="true"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Ex: 2014-01-01" ControlToValidate="TbToday" Operator="DataTypeCheck" Type="Date"
                        ValidateEmptyText="True"></asp:CompareValidator>
                            <%--<asp:CalendarExtender ID="CalendarExtender1" runat="server"
                                Enabled="True" Format="yyyy/MM/dd" 
                                TargetControlID="TbToday"></asp:CalendarExtender>--%>
                        <%--</ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="BtnCompleted" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="BtnBack" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                </div>
                <div style="margin-left: 30px">
                    <hr />
                </div>
                <div style="text-align:center; height:39px; line-height:39px; margin-left: 30px; text-align:left">
                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Resource, TipStage2 %>" Font-Bold="true" Font-Size="20px"></asp:Label>
                </div>
                <div align="left" style="text-align:center; height:39px; line-height:39px; margin-left: 60px; text-align:left; ">
                    <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Resource, TipInputQuestions %>" Font-Bold="true" Font-Size="16px"></asp:Label>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 1070px">
                        <tr>
                            <td colspan="2" align="center">
                                <%--<asp:UpdatePanel ID="UpdateCompleted" runat="server">
                                    <ContentTemplate>--%>
                                        <asp:Label ID="LbCompleted" runat="server"></asp:Label>                                        
                                    <%--</ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="BtnCompleted" EventName="Click" />
                                        <asp:AsyncPostBackTrigger ControlID="BtnBack" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>--%>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="text-align:center; height:39px; line-height:39px; margin-left: 30px; text-align:left">
                    <asp:Label ID="Label6" runat="server" Text="<%$ Resources:Resource, TipStage3 %>" Font-Bold="true" Font-Size="20px"></asp:Label>
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
