<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanItem4Sub.aspx.cs" Inherits="SchoolMaster_PlanItem4Sub" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
        <script language="javascript" type="text/javascript">
            function Conversion2() {
                //var year = parseInt(document.getElementById('column3').value.substr(0, 4)) - 1911;
                //document.getElementById('column3').value = year + document.getElementById('column3').value.substr(4, 8);
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
                         NavigateUrl="PlanList.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, TipPlanDataView %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="PlanViewList.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table width="739px">
                        <tr>
                            <td align="left" width="20%">
                                年分：<asp:Label ID="LbYear" runat="server" Text=""></asp:Label>   
                            </td>
                            <td align="left" width="60%">
                                学期：<asp:Label ID="LbNO" runat="server" Text=""></asp:Label>   
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <asp:Label ID="LbTitle" runat="server" Text=""></asp:Label>                                
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <asp:GridView ID="GvSchool" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" CellSpacing="2" BorderColor="#DEBA84">
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <EmptyDataTemplate>
                            Sorry, No any data.
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="目标" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:TextBox ID="column1" runat="server" Width="50px"></asp:TextBox>
                                </ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="活动与措施"  ItemStyle-Width="50px">
                                <ItemTemplate>
                                     <asp:TextBox ID="column2" runat="server" Width="50px"></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="开始时间"  ItemStyle-Width="50px">
                                <ItemTemplate>
                                     <asp:TextBox ID="column3" runat="server" Width="50px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="column3"
                                    Enabled="True" TargetControlID="column3" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="结束时间"  ItemStyle-Width="50">
                                <ItemTemplate>
                                     <asp:TextBox ID="column4" runat="server" Width="50px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="column4"
                                    Enabled="True" TargetControlID="column4" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="负责人"  ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:TextBox ID="column5" runat="server" Width="50px"></asp:TextBox>
                                    <asp:DropDownList ID="column51" runat="server">
                                        <asp:ListItem Value="<%$ Resources:Resource, TipPlzChoose %>"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="预算"  ItemStyle-Width="50">
                                <ItemTemplate>
                                     <asp:TextBox ID="column6" runat="server" Width="50px"></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="其中学校资源"  ItemStyle-Width="50">
                                <ItemTemplate>
                                     <asp:TextBox ID="column7" runat="server" Width="50px"></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="其他资源"  ItemStyle-Width="50">
                                <ItemTemplate>
                                     <asp:TextBox ID="column8" runat="server" Width="50px"></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="进展情况"  ItemStyle-Width="50">
                                <ItemTemplate>
                                     <%--<asp:TextBox ID="column9" runat="server" Width="50px"></asp:TextBox>--%>
                                    <asp:DropDownList ID="column9" runat="server">
                                        <asp:ListItem Value="0"></asp:ListItem>
                                        <asp:ListItem Value="10"></asp:ListItem>
                                        <asp:ListItem Value="20"></asp:ListItem>
                                        <asp:ListItem Value="30"></asp:ListItem>
                                        <asp:ListItem Value="40"></asp:ListItem>
                                        <asp:ListItem Value="50"></asp:ListItem>
                                        <asp:ListItem Value="60"></asp:ListItem>
                                        <asp:ListItem Value="70"></asp:ListItem>
                                        <asp:ListItem Value="80"></asp:ListItem>
                                        <asp:ListItem Value="90"></asp:ListItem>
                                        <asp:ListItem Value="100"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="时间"  ItemStyle-Width="50">
                                <ItemTemplate>
                                     <asp:TextBox ID="column10" runat="server" Width="50px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="column10"
                                    Enabled="True" TargetControlID="column10" Format="yyyy/MM/dd" OnClientDateSelectionChanged="Conversion2"></asp:CalendarExtender>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="负责人"  ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:DropDownList ID="column11" runat="server">
                                        <asp:ListItem Value="<%$ Resources:Resource, TipPlzChoose %>"></asp:ListItem>
                                    </asp:DropDownList>
                                     <%--<asp:TextBox ID="column11" runat="server" Width="50px"></asp:TextBox>--%>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:Button ID="lbnView" runat="server" Text="<%$ Resources:Resource, TipPlanDelete %>" OnClick="btn_Clicked" 
                                        CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"  Width="50px"></asp:Button>
                                </ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                    
                </div>
                <div style="float:left; margin-top:20px">
                    <asp:Button ID="BtnAdd" runat="server" Text="<%$ Resources:Resource, TipPlanAdd %>" OnClick="BtnAdd_Click"  Font-Size="14pt"/>
                </div>
                <table width="739px">
                    <tr>
                        <td width="90%" align="right">
                            <asp:Button ID="BtnStore" runat="server" Text="<%$ Resources:Resource, BtnPlanStore %>" OnClick="BtnStore_Click"  Font-Size="14pt"/>
                        </td>
                        <td width="10%" align="left" style="margin-left=20px;">
                            <asp:Button ID="BtnCancel" runat="server" Text="<%$ Resources:Resource, BtnPlanCancel %>" OnClick="BtnCancel_Click"  Font-Size="14pt"/>
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
