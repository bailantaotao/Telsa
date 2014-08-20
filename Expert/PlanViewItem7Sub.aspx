﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanViewItem7Sub.aspx.cs" Inherits="SchoolMaster_PlanViewItem7Sub" %>

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
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(../<%= backgroundImage %>) no-repeat center top;">
    <form id="form1" runat="server">
    <div align="center" style="width: 1024px; margin: 0px auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
        </asp:ScriptManager>
        <div id="BlockLeft">
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
                    <asp:Label ID="LbLocation" runat="server" Text="<%$ Resources:Resource, TipPlanSDP %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Resource, TipPlanDataView %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="PlanList.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table width="739px">
                        <tr>
                            <td align="left">
                                <asp:Label ID="LbTitle" runat="server" Text=""></asp:Label>                                
                            </td>
                            <td align="left">
                                <asp:Label ID="LbSemster" runat="server" Text=""></asp:Label>                                
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table width="739px">
                        <tr>
                            <td width="10%">
                                负责人姓名
                            </td>
                            <td width="15%" align="left">
                                <asp:Label ID="LbName" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td width="10%">
                                性别
                            </td>
                            <td width="15%" align="left">
                                <asp:Label ID="LbGender" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td width="10%">
                                职称
                            </td>
                            <td width="15%" align="left">
                                <asp:Label ID="LbProfession" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td width="10%">
                                部门人数
                            </td>
                            <td width="15%" align="left">
                                <asp:Label ID="LbNumbersOfPeople" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" align="left">
                                现况分析:
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" align="left">
                                <asp:Label ID="LbAdvantage" runat="server" Text="Label"  style="word-break:break-all"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="GvSchool" runat="server" AutoGenerateColumns="False" BackColor="#DDDDDD" BorderStyle="None"
            BorderWidth="1px" CellPadding="5" CellSpacing="1">
                        <RowStyle BackColor="#ffffff" ForeColor="Black" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <PagerStyle BackColor="#ffffff" HorizontalAlign="left" />
                        <HeaderStyle BackColor="#efefef" Font-Bold="True" />
                        <AlternatingRowStyle BackColor="#f7fafe" />
                        <EmptyDataTemplate>
                            Sorry, No any data.
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="Column1" HeaderText="目标" ItemStyle-Width="70px" />
                            <asp:BoundField DataField="Column2" HeaderText="活动与措施" ItemStyle-Width="70px" />
                            <asp:BoundField DataField="Column3" HeaderText="开始时间" ItemStyle-Width="70px" />
                            <asp:BoundField DataField="Column4" HeaderText="结束时间" ItemStyle-Width="70px" />
                            <asp:BoundField DataField="Column5" HeaderText="完成率" ItemStyle-Width="70px" />
                            <asp:BoundField DataField="Column6" HeaderText="完成情況" ItemStyle-Width="70px" />
                            
                        </Columns>
                    </asp:GridView>
                    
                </div>
                
                <table width="739px">
                    <tr>
                        <td width="90%" align="right" style="margin-right=20px;">
                            <asp:Button ID="BtnCancel" runat="server" Text="<%$ Resources:Resource, BtnBack %>" OnClick="BtnCancel_Click" />
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
