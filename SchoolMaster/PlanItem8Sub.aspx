﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanItem8Sub.aspx.cs" Inherits="SchoolMaster_PlanItem8Sub" %>

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
                <asp:HyperLink ID="HlInternetStudy" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/InternetStudy.aspx" Text="<%$ Resources:Resource, HyInternetStudy %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlKPI" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/KPIExamMain.aspx" Text="<%$ Resources:Resource, HyKPI %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlSchoolDevelop" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/PlanList.aspx" Text="<%$ Resources:Resource, HySchoolDevelop %>"></asp:HyperLink>
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
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="REd" Text="<%$ Resources:Resource, TipPlanDataInput %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="#"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, TipPlanDataView %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="#"></asp:HyperLink>
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
                            <td width="15%">
                                <asp:DropDownList ID="DdlName" runat="server"></asp:DropDownList>
                            </td>
                            <td width="10%">
                                性别
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TbGender" runat="server" Height="17px" Width="90px"></asp:TextBox>
                            </td>
                            <td width="10%">
                                职称
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TbTitle" runat="server" Height="16px" Width="90px"></asp:TextBox>
                            </td>
                            <td width="10%">
                                部门人数
                            </td>
                            <td width="15%">
                                <asp:TextBox ID="TbNumbersOfPeople" runat="server" Height="16px" Width="90px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8" align="left">
                                现况分析:
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                <asp:TextBox ID="TbAdvantage" runat="server" Width="700px" Height="100px" TextMode="MultiLine"></asp:TextBox>
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
                            <asp:TemplateField HeaderText="目标" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:TextBox ID="column1" runat="server" Width="50px"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="活动与措施"  ItemStyle-Width="50px">
                                <ItemTemplate>
                                     <asp:TextBox ID="column2" runat="server" Width="50px"></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="开始时间"  ItemStyle-Width="50px">
                                <ItemTemplate>
                                     <asp:TextBox ID="column3" runat="server" Width="50px"></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="结束时间"  ItemStyle-Width="50">
                                <ItemTemplate>
                                     <asp:TextBox ID="column4" runat="server" Width="50px"></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="完成率"  ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:DropDownList ID="column5" runat="server">
                                        <asp:ListItem Value="0">0</asp:ListItem>
                                        <asp:ListItem Value="10">10</asp:ListItem>
                                        <asp:ListItem Value="20">20</asp:ListItem>
                                        <asp:ListItem Value="30">30</asp:ListItem>
                                        <asp:ListItem Value="40">40</asp:ListItem>
                                        <asp:ListItem Value="50">50</asp:ListItem>
                                        <asp:ListItem Value="60">60</asp:ListItem>
                                        <asp:ListItem Value="70">70</asp:ListItem>
                                        <asp:ListItem Value="80">80</asp:ListItem>
                                        <asp:ListItem Value="90">90</asp:ListItem>
                                        <asp:ListItem Value="100">100</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="完成情況"  ItemStyle-Width="50">
                                <ItemTemplate>
                                     <asp:TextBox ID="column6" runat="server" Width="50px"></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:Button ID="lbnView" runat="server" Text="<%$ Resources:Resource, TipPlanDelete %>" OnClick="btn_Clicked" 
                                        CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"  Width="50px"></asp:Button>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SN" HeaderText="#" ItemStyle-Width="20px" Visible="false"/>
                        </Columns>
                    </asp:GridView>
                    
                </div>
                <div style="float:left; margin-top:20px">
                    <asp:Button ID="BtnAdd" runat="server" Text="<%$ Resources:Resource, TipPlanAdd %>" OnClick="BtnAdd_Click" />
                </div>
                <table width="739px">
                    <tr>
                        <td width="90%" align="right">
                            <asp:Button ID="BtnStore" runat="server" Text="<%$ Resources:Resource, BtnPlanStore %>" OnClick="BtnStore_Click" />
                        </td>
                        <td width="10%" align="left" style="margin-left=20px;">
                            <asp:Button ID="BtnCancel" runat="server" Text="<%$ Resources:Resource, BtnPlanCancel %>" OnClick="BtnCancel_Click" />
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
