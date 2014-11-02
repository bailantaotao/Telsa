<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanItem7.aspx.cs" Inherits="SchoolMaster_PlanItem7" %>

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
            padding-top:10px;
            text-align:left;
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
            <div class ="Option" style="text-align:left">
                <asp:ImageButton ID="ImgBtnIndex" runat="server" ImageUrl="<%$ Resources:Resource, ImgUrlBackIndex %>" OnClick="ImgBtnIndex_Click"/>
            </div>
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
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/GuideSDPEvaluateResult.aspx" Text="<%$ Resources:Resource, HyFollowingMonitor %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/Stage5/MDRegulations_00.aspx" Text="<%$ Resources:Resource, HyRuleManage %>"></asp:HyperLink>
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
<<<<<<< HEAD
                            <td align="left" width="80%">  
                            </td>
=======
                            <%-- <td align="left" width="80%">
                                学期：<asp:Label ID="LbNO" runat="server" Text=""></asp:Label>   
                            </td>--%>
>>>>>>> develop
                        </tr>
                        <tr>
                            <td colspan="2" align="left">
                                <asp:Label ID="LbTipProvince" runat="server" Text="<%$ Resources:Resource, TipPlanTitle7 %>"></asp:Label>                                
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table width="739px" style="margin-left:20px"">
                        <tr>
                            <td>
                                名称：
                                <asp:TextBox ID="TbDepartmentName" runat="server"></asp:TextBox>
                                <asp:Button ID="BtnAdd" runat="server" Text="<%$ Resources:Resource, TipPlanAdd %>" OnClick="BtnAdd_Click"  Font-Size="14pt"/>
                            </td>
                        </tr>
                    </table>
                    
                </div>
                <div style="float: left; margin-left:20px">
                    <asp:GridView ID="GvDepartment" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" CellSpacing="2" BorderColor="#DEBA84">
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <EmptyDataTemplate>
                            Sorry, No any data.
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="Department" HeaderText="处室" ItemStyle-Width="120px" >
<ItemStyle Width="120px"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="SN" HeaderText="<%$ Resources:Resource, TipPlanTitle %>" ItemStyle-Width="120px" Visible="false" >
<ItemStyle Width="120px"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:Button ID="lbnView" runat="server" Text="<%$ Resources:Resource, TipEdit %>" OnClick="btn_View" 
                                        CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"  Width="50px"></asp:Button>
                                </ItemTemplate>

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:Button ID="lbnDelete" runat="server" Text="<%$ Resources:Resource, TipPlanDelete %>" OnClick="btn_Delete" 
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
