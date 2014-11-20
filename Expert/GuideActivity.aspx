<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuideActivity.aspx.cs" Inherits="Expert_GuideActivity" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
            height: 21px;
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
        .style2
        {
            width: 49%;
        }
        .style3
        {
            width: 21%;
        }
        .style5
        {
            width: 128px;
        }
        .style7
        {
            width: 317px;
        }
        .style8
        {
            width: 86%;
        }
    </style>
</head>
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(../<%= backgroundImage %>) no-repeat center top;" background="../Image/zh-CN/Background.png">
    <form id="form1" runat="server">
    <div align="center" style="width: 1024px; margin: 0px auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
        </asp:ScriptManager>
        <div id="BlockLeft">
            <div class ="Option">
                <asp:ImageButton ID="ImgBtnIndex" runat="server" ImageUrl="<%$ Resources:Resource, ImgUrlBackIndex %>" OnClick="ImgBtnIndex_Click"/>
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
                    <asp:Label ID="LbLocation" runat="server" Text="后期跟踪指导" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="REd" Text="执行/监测报告输入" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="GuidePreList.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Black" Text="执行/监测报告观看" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="GuideViewPreList.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table width="739px">
                       <tr>
                           <td align="center" class="style8">
                                <asp:Label ID="LbGuideActivity" runat="server" Text=""></asp:Label>
                           </td>
                           <td align="right" class="style2">
                                <asp:Button ID="BtnStore" runat="server" 
                                    Text="<%$ Resources:Resource, BtnPlanStore %>" onclick="BtnStore_Click" />
                            </td>
                           <td width="10%" align="left">
                                <asp:Button ID="BtnCancel" runat="server" Text="取消编辑并返回上一页"  
                                             style="Width: 150px" onclick="BtnCancel_Click"  />
                           </td>
                       </tr>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 735px">
                        <tr>
                            <td align="left" class="style3">
                                &nbsp&nbsp&nbsp<asp:Label ID="LbGuideActivityYear" runat="server" Text="学年:" ForeColor="Blue"></asp:Label>
       
                                <asp:Label ID="LbYear" runat="server" Text=""></asp:Label>
                                
                            </td>   
                            <td class="style5" >
                                
                                <asp:Label ID="LbGuideActivitySemester" runat="server" Text="学期:" ForeColor="Blue"></asp:Label>
                                
                                <asp:Label ID="LbSemester" runat="server" Text=""></asp:Label>
                                
                            </td> 
                            <td>
                                <asp:Label ID="LbGuideActivityTargetSchool" runat="server" Text="目标学校:" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="LbTargetSchool" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 735px">
                        <tr>
                            <td class="style7"  >
                                &nbsp&nbsp&nbsp<asp:Label ID="LbGuideActivityStartTime" runat="server" Text="开始时间:" ForeColor="Blue"></asp:Label>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                <cc1:CalendarExtender ID="TbGuideActivityStartTime" runat="server" 
                                    Enabled="True" TargetControlID="TextBox1" Format="yyyy/MM/dd">
                                </cc1:CalendarExtender>
                                
                            </td>
                            <td >
                                <asp:Label ID="LbGuideActivityEndTime" runat="server" Text="结束时间:" ForeColor="Blue"></asp:Label>
                                 <asp:TextBox ID="TextBox2" runat="server" Height="19px"></asp:TextBox>
                                
                                <cc1:CalendarExtender ID="TbGuideActivityEndTime" runat="server" Enabled="True" 
                                    TargetControlID="TextBox2" Format="yyyy/MM/dd" >
                                </cc1:CalendarExtender>
                                
                            </td>
                        </tr>
                    </table>
                    <table style="width: 735px">
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp<asp:Label ID="Label12" runat="server" Text="活动流程"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp<asp:TextBox ID="TbGuideActivityProgress" runat="server" Height="68px" 
                                    Width="604px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp<asp:Label ID="Label2" runat="server" Text="讨论重点"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp<asp:TextBox ID="TbGuideActivityPoint" runat="server" Height="68px" 
                                    Width="604px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp<asp:Label ID="Label3" runat="server" Text="说明:"></asp:Label>

                                <asp:TextBox ID="TbGuideActivityDescription" runat="server" Height="24px" TextMode="MultiLine" 
                                    Width="564px"></asp:TextBox>

                            </td>
                        </tr>
                        </table>
                     <table style="width: 735px">
                        <tr>
                            <td align="left" >
                                &nbsp&nbsp&nbsp<asp:Label ID="Label1" runat="server" Text="参与人员"></asp:Label>
                                <asp:Button ID="BtnAddMember" runat="server" Text="新增参与人员" 
                                    onclick="BtnAddMember_Click"  />
                            </td>
                        </tr>
                        
                        <asp:GridView ID="GvSchool" runat="server" AutoGenerateColumns="False" 
                                 BackColor="#DEBA84" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" CellSpacing="2" BorderColor="#DEBA84" Width="405px">
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <EmptyDataTemplate>
                            Sorry, No any data.
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField HeaderText="姓名"  ItemStyle-Width="50">
                                <ItemTemplate>
                                     <asp:TextBox ID="TbGuideActivityMemberName" runat="server" Width="100px"></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="性别"  ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:DropDownList ID="DlGuideActivityGender" runat="server">
                                        <asp:ListItem Value="请选择"></asp:ListItem>
                                        <asp:ListItem Value="男">男</asp:ListItem>
                                        <asp:ListItem Value="女">女</asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="100px"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="职务/职称"  ItemStyle-Width="50">
                                <ItemTemplate>
                                     <asp:TextBox ID="TbGuideActivityJob" runat="server" Width="100px"></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="100px"></ItemStyle>
                            </asp:TemplateField><asp:TemplateField HeaderText="单位"  ItemStyle-Width="50">
                                <ItemTemplate>
                                     <asp:TextBox ID="TbGuideActivityUnit" runat="server" Width="100px"></asp:TextBox>
                                </ItemTemplate>
                                <FooterStyle HorizontalAlign="Right" />

<ItemStyle Width="150px"></ItemStyle>
                            </asp:TemplateField><asp:TemplateField HeaderText="电话"  ItemStyle-Width="50">
                                <ItemTemplate>
                                     <asp:TextBox ID="TbGuideActivityPhone" runat="server" Width="150px"></asp:TextBox>
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
                            <asp:BoundField DataField="SN" HeaderText="#" ItemStyle-Width="20px" Visible="false">
<ItemStyle Width="20px"></ItemStyle>
                            </asp:BoundField>
                        </Columns>
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                             
                        
                    </table>
                    
          </div>
    </form>
</body>
</html>
