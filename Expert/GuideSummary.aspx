<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuideSummary.aspx.cs" Inherits="Expert_GuideSummary" %>

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
        .style4
        {
            width: 263px;
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
                           <td align="center"  >
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideSummary" runat="server" Text="执行/监测报告内容摘要" ></asp:Label>
                           </td>
                           <td align="right">
                                <asp:Button ID="BtnSave" runat="server" Text="储存" Height="22px" 
                                    style="margin-left: 0px" Width="58px" onclick="BtnSave_Click" />
                            </td>
                            <td>
                                <asp:Button ID="BtnCancel" runat="server" Text="取消编辑并返回上一页" Height="22px" 
                                    Width="150px" onclick="BtnCancel_Click" />
                            </td>
                       </tr>
                       <tr>
                           <td class="style4" >
                               &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideSummaryUserName" runat="server"></asp:Label>
                           </td>
                           <td>
                               <asp:Label ID="LbGuideSummaryUserID" runat="server"></asp:Label>
                           </td>
                       </tr>
                       <tr>
                            <td align="left" class="style4" >
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideSummaryYear" runat="server" Text="学年：" ForeColor="Blue"></asp:Label>

                                <asp:DropDownList ID="DropDownList1" runat="server" 
                                    DataSourceID="SqlDataSource1" DataTextField="GuideSummaryYear" 
                                    DataValueField="GuideSummaryYear">
                                </asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                                    ConnectionString="<%$ ConnectionStrings:TelsaConnectionString2 %>" 
                                    SelectCommand="SELECT [GuideSummaryYear] FROM [GuideSummaryYearNameMapping]">
                                </asp:SqlDataSource>

                                <asp:Label ID="LbGuideYear" runat="server" Text=""></asp:Label>

                            &nbsp;

                            </td>
                            <td align="left" >
                                <asp:Label ID="LbGuideSummaryCycle" runat="server" Text="学期：" ForeColor="Blue"></asp:Label>
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                </asp:DropDownList>
                                
                                <asp:Label ID="LbGuideSemester" runat="server" Text=""></asp:Label>
                                
                            </td>

                            <td align="left" width="30%">
                                <asp:Label ID="LbGuideSummaryNo" runat="server" Text="项次：" ForeColor="Blue"></asp:Label>
                                <asp:DropDownList ID="DropDownList3" runat="server" AutoPostBack="True">
                                    <asp:ListItem>请选择</asp:ListItem>
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem>5</asp:ListItem>
                                    <asp:ListItem>6</asp:ListItem>
                                    <asp:ListItem>7</asp:ListItem>
                                    <asp:ListItem>8</asp:ListItem>
                                    <asp:ListItem>9</asp:ListItem>
                                    <asp:ListItem>10</asp:ListItem>
                                </asp:DropDownList>
                               
                            </td>
                        </tr>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 735px">
                        <tr>
                            <td align="left" style="">
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideSummaryContent" runat="server" Text="1.主要目的和主要活动内容"></asp:Label>   
                            </td>    
                        </tr>
                        <tr>
                            <td>
                                
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:TextBox 
                                    ID="TBGuideSummaryContent" runat="server" BorderStyle="Double" Height="50px" 
                                    TextMode="MultiLine" Width="669px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="">
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideSummaryExperience" runat="server" Text="2.主要经验"></asp:Label>   
                            </td>    
                        </tr>
                        <tr>
                            <td>
                                
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:TextBox 
                                    ID="TBGuideSummaryExperience" runat="server" BorderStyle="Double" Height="50px" 
                                    TextMode="MultiLine" Width="669px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="">
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideSummaryExistingProblem" runat="server" Text="3.存在的问题与困难"></asp:Label>   
                            </td>    
                        </tr>
                        <tr>
                            <td>
                                
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="TBGuideSummaryExistingProblem" runat="server" 
                                    BorderStyle="Double" Height="50px" 
                                    TextMode="MultiLine" Width="669px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="">
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideSummarySuggest" runat="server" Text="4.下一步工作的改进建议"></asp:Label>   
                            </td>    
                        </tr>
                        <tr>
                            <td>
                                
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="TBGuideSummarySuggest" runat="server" 
                                    BorderStyle="Double" Height="50px" 
                                    TextMode="MultiLine" Width="669px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="">
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:Label ID="LbGuideSummaryResult" runat="server" Text="5.评估监测结果"></asp:Label>   
                            </td>    
                        </tr>
                        <tr>
                            <td>
                                
                                &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp<asp:TextBox ID="TBGuideSummaryResult" runat="server" 
                                    BorderStyle="Double" Height="50px" 
                                    TextMode="MultiLine" Width="669px"></asp:TextBox>
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
