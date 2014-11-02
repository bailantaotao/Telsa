﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuideViewList.aspx.cs" Inherits="Manager_GuideViewList" %>

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
            height: 20px;
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
        .style1
        {
            height: 22px;
        }
        .style2
        {
            width: 729px;
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
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/GuideViewPreList.aspx" Text="<%$ Resources:Resource, HyFollowingMonitor %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Manager/Stage5/MDRegulations_00.aspx" Text="<%$ Resources:Resource, HyRuleManage %>"></asp:HyperLink>
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
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Red" Text="执行/监测报告观看" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="GuideViewPreList.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table width="739px">
                        <tr>
                            <td align="center" class="style1">
                                <asp:HyperLink ID="LbTipProvince" runat="server" Text="‧执行/监测报告模板(说明)" NavigateUrl="GuideViewTemplates.aspx"></asp:HyperLink>
                            </td>
                        </tr>
                       
                        <tr>
                            <td>
                                &nbsp&nbsp&nbsp<asp:Label ID="LbAttachmentList" runat="server" Text="内容列表"></asp:Label>
                            </td>
                            <td align="right" >
                                <asp:Button ID="Button1" runat="server" Text="返回" onclick="Button1_Click" />
                            </td>
                        </tr>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 735px">
                        <tr>
                            <td align="center" class="style2" >
                                <%--<asp:UpdatePanel ID="UpdateTotalCount" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="LbTotalCount" runat="server" Font-Size="Small"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ImgBtnSearch" EventName="Click" />
                                    </Triggers>
                                </asp:UpdatePanel>--%>
                                &nbsp&nbsp&nbsp<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                    DataSourceID="SqlDataSource1" BackColor="#DEBA84" BorderColor="#DEBA84" 
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" Width="713px" 
                                    >
                                    <Columns>
                                        <asp:BoundField DataField="GuideAttachmentID" HeaderText="编号" 
                                            SortExpression="GuideAttachmentID" ItemStyle-HorizontalAlign="Center" 
                                            HeaderStyle-Width="60px"/>
                                        <asp:BoundField DataField="GuideAttachmentName" HeaderText="内容" 
                                            SortExpression="GuideAttachmentName" ItemStyle-HorizontalAlign="Center" 
                                            HeaderStyle-Width="550px"/>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("GuideAttachmentURL")%>' Target="_self" Text="线上观看" ></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:TelsaConnectionString %>" 
                                    
                                    SelectCommand="SELECT [GuideAttachmentID], [GuideAttachmentName], [GuideAttachmentURL] FROM [GuideAttachmentViewNameMapping] ORDER BY [GuideAttachmentID]">
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                                &nbsp&nbsp&nbsp<asp:Label ID="Label1" runat="server" Text="使用者上传其它附件列表"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2" align="center">
                                &nbsp&nbsp<asp:GridView ID="GridView2" 
                                    runat="server" AutoGenerateColumns="False" 
                                    BackColor="#DEBA84" BorderColor="#DEBA84" 
                                    BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" 
                                    Width="717px" DataSourceID="SqlDataSource2" HorizontalAlign="Center"
                                    >
                                    <Columns>
                                        <asp:BoundField DataField="ItemNo" HeaderText="編號" SortExpression="ItemNo" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="60px"/>
                                        <asp:BoundField DataField="GuideItemName" HeaderText="附件" 
                                            SortExpression="GuideItemName" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="500px"/>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("GuideItemUrl")%>'  Text="附件下载"></asp:HyperLink>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:TelsaConnectionString %>" 
                                    
                                    
                                    SelectCommand="SELECT [ItemNo], [GuideItemName], [GuideItemUrl], [SN] FROM [GuideItem] WHERE ([SN] = @SN) ORDER BY [ItemNo]">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="SN" SessionField="UserGuideListSN" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </td>
                        </tr>
                        <tr>
                            <td class="style2">
                            </td>
                        </tr>
                </div>
            </div>
        </div>
        <asp:Literal ID="ClientScriptArea" runat="server"></asp:Literal> 
    </div>
    </form>
</body>
</html>