﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewInternetStudyScore.aspx.cs" Inherits="Expert_ViewInternetStudyScore" %>

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
            height:70px;
        }
        #BlockRightDownDataDisplay {
            padding-top: 100px;
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
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(../<%= backgroundImage %>) no-repeat center top;">
    <form id="form1" runat="server">
    <div align="center" style="width: 1024px; margin: 0px auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
        </asp:ScriptManager>
        <div id="BlockLeft">
            <div class ="Option">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="<%$ Resources:Resource, ImgUrlBackIndex %>" OnClick="ImgBtnIndex_Click"/>
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
                    <asp:Label ID="LbLocation" runat="server" Text="<%$ Resources:Resource, TipInternetStudy %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyBtnScore" runat="server" Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Resource, TipSearchScore %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                        NavigateUrl="~/Expert/ViewInternetStudyScore.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, TipViewQuestion %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="~/Expert/ViewInternetStudyQuestionnaire.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:right">
                    <%-- <asp:ImageButton ID="ImgBtnLogout" runat="server"  
                        ImageUrl="<%$ Resources:Resource, ImgSubIndexUrlLogout %>" OnClick="ImgBtnLogout_Click"/>--%>
                    <asp:ImageButton ID="ImgBtnIndex" runat="server" ImageUrl="<%$ Resources:Resource, ImgUrlBackIndex %>" OnClick="ImgBtnIndex_Click"/>
                
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table style="width: 735px">
                        <tr>
                            <td>
                                <div style="text-align:center; height:55px; float: left;  line-height:55px; margin-left: 5px; width: 74px;">
                                    <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Resource, TipProvince %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                                </div>
                                <div style="text-align:center; height:55px; float: left;  line-height:55px; margin-left: 0px">
                                    <asp:Label ID="LbProvince" runat="server" Text="" Font-Size="<%$ Resources:Resource, TextSizeTitle %>" Font-Bold="true" Font-Underline="true"></asp:Label>
                                    <asp:DropDownList ID="DdlProvince" runat="server" OnSelectedIndexChanged="DdlProvince_SelectedIndexChanged" AutoPostBack="true">
                                        <asp:ListItem Text="<%$ Resources:Resource, TipPlzChoose %>"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DdlImportYear" runat="server" AutoPostBack="true" Font-Size="10pt" Width="100px" onselectedindexchanged="DdlImportYear_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="text-align:Left; height:55px; float: left;  line-height:55px; margin-left: 10px">
                                    <asp:Label ID="Label5" runat="server" Text="<%$ Resources:Resource, TipOrder %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                                    <asp:DropDownList ID="DdlOrderType" runat="server" AutoPostBack="true" 
                                        onselectedindexchanged="DdlOrderType_SelectedIndexChanged">
                                        <asp:ListItem Text="<%$ Resources:Resource, TipPlzChoose %>"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DdlTimeOrder" runat="server" AutoPostBack="true" 
                                        onselectedindexchanged="DdlTimeOrder_SelectedIndexChanged">
                                        <asp:ListItem Text="<%$ Resources:Resource, TipPlzChoose %>"></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="text-align:Left; height:55px; float: left;  line-height:55px; margin-left: 10px">
                                    <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Resource, TipYear %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                                </div>
                                <div style="text-align:Left; height:55px; float: left;  line-height:55px;">
                                    <asp:UpdatePanel ID="UpdateCNo" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="TbYearA" runat="server" Width="50px" MaxLength="4"></asp:TextBox>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ImgBtnSearch" EventName="Click" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                                <div style="text-align:Left; height:55px; float: left;  line-height:55px;">
                                    ~
                                </div>
                                <div style="text-align:Left; height:55px; float: left;  line-height:55px; width: 50px;">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="TbYearB" runat="server" Width="50px" MaxLength="4"></asp:TextBox>
                                        </contenttemplate>
                                        <triggers>
                                            <asp:asyncpostbacktrigger controlid="imgbtnsearch" eventname="click" />
                                        </triggers>
                                    </asp:updatepanel>                        
                                </div>
                                <div style="text-align:Left; width: auto; height:55px; float: left;  line-height:55px; vertical-align:middle; padding-left:10px; padding-top:10px">
                                    <asp:ImageButton ID="ImgBtnSearch" runat="server" OnClick="ImgBtnSearch_Click" ImageUrl="<%$ Resources:Resource, ImgUrlSearch %>"/>
                                </div>
                                <div style="text-align:left; padding-left:20px">
                                    &nbsp&nbsp&nbsp<asp:Button ID="BtnViewComment" runat="server" Text="<%$ Resources:Resource, TipViewComment %>" OnClick="BtnViewComment_Click"/>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 735px">
                        <tr> 
                            <td align="left">
                                <%--<asp:UpdatePanel ID="UpdateTotalCount" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="LbTotalCount" runat="server" Font-Size="Small"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ImgBtnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>--%>
                            </td>
                            <td align="right">
                                <asp:UpdatePanel ID="UpdatePageSelect" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Label15" runat="server" Font-Size="<%$ Resources:Resource, TextSizeTip %>" Text="<%$ Resources:Resource, TipNo %>"></asp:Label>
                                        &nbsp;<asp:DropDownList ID="DdlPageSelect" runat="server" AutoPostBack="True" 
                                            Font-Size="Small" onselectedindexchanged="PageSelect_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp;<asp:Label ID="Label16" runat="server" Font-Size="<%$ Resources:Resource, TextSizeTip %>" Text="<%$ Resources:Resource, TipPage %>"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ImgBtnSearch" EventName="Click" />
                                    </Triggers>
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
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ImgBtnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
        <asp:Literal ID="ClientScriptArea" runat="server"></asp:Literal> 
        s</div>
    </form>
</body>
</html>
