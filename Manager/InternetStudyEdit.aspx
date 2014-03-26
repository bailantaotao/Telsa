﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InternetStudyEdit.aspx.cs" Inherits="Manager_InternetStudyEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
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
            padding-top: 30px;
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
                <asp:HyperLink ID="HlInternetStudy" runat="server" ForeColor="White" Font-Size="14px">網路自學</asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlKPI" runat="server" ForeColor="White" Font-Size="14px">KPI</asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlSchoolDevelop" runat="server" ForeColor="White" Font-Size="14px">學校發展計畫</asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="14px">後期跟蹤指導執行監測</asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="14px">規章制度管理</asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlStudentManage" runat="server" ForeColor="White" Font-Size="14px">學生資料管理</asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlQuestinnaire" runat="server" ForeColor="White" Font-Size="14px">調查問卷管理</asp:HyperLink>
            </div>
        </div>
        <div id="BlockRight">
            <div id="BlockRightUp">
                <div style="background: url(../Image/zh-TW/TipGary_TipUserLocation.png) no-repeat; text-align:center; width: 175px; height:39px; float: left;  line-height:39px;">
                    <asp:Label ID="LbLocation" runat="server" Text="網路自學" Font-Bold="true"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyBtnStudy" runat="server" Font-Bold="true" ForeColor="Red">自學教材</asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyBtnScore" runat="server" Font-Bold="true" ForeColor="Black">自學成績查詢</asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <div style="text-align:center; height:39px; float: left;  line-height:39px; margin-left: 60px">
                        <asp:Label ID="Label2" runat="server" Text="年度："></asp:Label>
                    </div>
                    <div style="text-align:center; height:39px; float: left;  line-height:39px;">
                        <asp:UpdatePanel ID="UpdateCNo" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TbYearA" runat="server" Width="70px" MaxLength="4"></asp:TextBox>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="ImgBtnSearch" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div style="text-align:center; height:39px; float: left;  line-height:39px;">
                        ~
                    </div>
                    <div style="text-align:center; height:39px; float: left;  line-height:39px;">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="TbYearB" runat="server" Width="70px" MaxLength="4"></asp:TextBox>
                            </contenttemplate>
                            <triggers>
                                <asp:asyncpostbacktrigger controlid="imgbtnsearch" eventname="click" />
                            </triggers>
                        </asp:updatepanel>                        
                    </div>
                    <div style="text-align:center; width: auto; height:50px; float: left;  line-height:55px; vertical-align:middle; padding-left:15px;">
                        <asp:ImageButton ID="ImgBtnSearch" runat="server" OnClick="ImgBtnSearch_Click" ImageUrl="~/Image/zh-TW/ButtonSearchOrange.png"/>
                    </div>
                    <div style="text-align:center; width: 660px; height:50px; float: left;  line-height:55px; vertical-align:middle; text-align:right;">
                        <asp:TextBox ID="TbAddYear" runat="server" Width="70px" MaxLength="4"></asp:TextBox>
                        <asp:ImageButton ID="ImgBtnAddYear" runat="server" OnClick="ImgBtnSearch_Click" ImageUrl="~/Image/zh-TW/ButtonAddYearOrange.png"/>
                    </div>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 1070px">
                        <tr>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdateTotalCount" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="LbTotalCount" runat="server" Font-Size="Small"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ImgBtnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </td>
                            <td align="right">
                                <asp:UpdatePanel ID="UpdatePageSelect" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Label15" runat="server" Font-Size="Small" Text="第"></asp:Label>
                                        &nbsp;<asp:DropDownList ID="DdlPageSelect" runat="server" AutoPostBack="True" 
                                            Font-Size="Small" onselectedindexchanged="PageSelect_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp;<asp:Label ID="Label16" runat="server" Font-Size="Small" Text="頁"></asp:Label>
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
                                        <asp:Label ID="Label17" runat="server" Font-Size="Small" Text="第"></asp:Label>
                                        &nbsp;<asp:Label ID="PageOrder" runat="server" Font-Size="Small"></asp:Label>
                                        &nbsp;<asp:Label ID="Label19" runat="server" Font-Size="Small" Text="頁"></asp:Label>
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
    </div>
    </form>
</body>
</html>
