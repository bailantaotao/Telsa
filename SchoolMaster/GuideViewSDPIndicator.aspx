<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuideViewSDPIndicator.aspx.cs" Inherits="SchoolMaster_GuideViewSDPIndicator" %>

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
            height: 18px;
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
            width: 72px;
        }
        .style2
        {
            width: 75px;
        }
        .style3
        {
            width: 80px;
        }
        .style4
        {
            width: 402px;
        }
        </style>
</head>
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(../<%= backgroundImage %>) no-repeat center top;" background="../Image/zh-CN/Background.png">
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
                <asp:HyperLink ID="HlStudentManage" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/QViewStudentList.aspx" Text="<%$ Resources:Resource, HyStudentManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlQuestinnaire" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/SchoolMaster/SurveyPreList.aspx" Text="<%$ Resources:Resource, HyQuestionnaire %>"></asp:HyperLink>
            </div>
        </div>
        <div id="BlockRight">
            <div id="BlockRightUp">
                <div style="background: url(../Image/zh-TW/TipGary_TipUserLocation.png) no-repeat; text-align:center; width: 175px; height:39px; float: left;  line-height:39px;">
                    <asp:Label ID="LbLocation" runat="server" Text="后期跟踪指导" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Black" Text="执行/监测报告输入" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="GuideSDPEvaluateResult.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Red" Text="执行/监测报告观看" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="GuideViewSDPEvaluateResult.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table width="739px">
                       <tr>
                           <td align="center">
                                <asp:Label ID="Label1" runat="server" Text="学校发展计划的关注点及评估监测指标"></asp:Label>
                           </td>
                       </tr>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 735px">
                        <tr>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style1" >
                                <asp:Label ID="Label2" runat="server" Text="类别" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style2" >
                                <asp:Label ID="Label4" runat="server" Text="一级指标" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style3" >
                                <asp:Label ID="Label5" runat="server" Text="二级指标" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4" >
                                <asp:Label ID="Label6" runat="server" Text="指导/评估时的关注内容" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                <asp:Label ID="Label3" runat="server" Text="分值(分)" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="8" style="border: thin Ridge black" 
                                class="style1" >
                                <asp:Label ID="Label9" runat="server" Text="学校发展计划的制定(40分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="4" style="border: thin Ridge black" 
                                class="style2" >
                                <asp:Label ID="Label10" runat="server" Text="制定的规范性(25分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="2" style="border: thin Ridge black" 
                                class="style3" >
                                <asp:Label ID="Label11" runat="server" Text="组织建设(5分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4" >
                                1.建立了SDP管理委员会，由不同人群代表组成，有1名以上女性代表。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                <asp:Label ID="Label13" runat="server" Text="2" ></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4" >
                                2.委员会在制定SDP时起到组织、计划、指导和管理的核心作用。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                3</td>
                        </tr>
                            <td align="center" colspan="1" rowspan="2" style="border: thin Ridge black" 
                                class="style3" >
                                <asp:Label ID="Label16" runat="server" Text="工具使用(20分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                            class="style4" >
                                1.在广泛征求各方面意见的基础上，采用SWOT分析法、优先排序法进行自我分析与确定影响学校发展的主要问题。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                10</td>
                        </tr>
                        <tr>
                             <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style4" >
                                 2.按照SMART目标、头脑风暴确定学年目标与活动措施。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                10</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="4" style="border: thin Ridge black" 
                                class="style2" >
                                <asp:Label ID="Label21" runat="server" Text="文本的合理性(15分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="2" style="border: thin Ridge black" 
                                class="style3" >
                                <asp:Label ID="Label22" runat="server" Text="文本撰寫(5分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4" >
                                1.按照SDP文本格式完整填写，内容真实，符合填写要求。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                3</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4" >
                                2.通过管理平台，向本省专家组征求意见，及时修订文本。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                2</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="2" style="border: thin Ridge black" 
                                class="style3" >
                                <asp:Label ID="Label27" runat="server" Text="文本質量(10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4" >
                                1.合理分析学校现状、规划设计切合学校实际的愿景; 明确学校存在的主要问题，制定相应的目标措施。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                5</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4" >
                                2.现状分析一主要问题一目标措施之间形成有效的逻辑支持结构和关系。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                5</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="6" style="border: thin Ridge black" 
                            class="style1" >
                                <asp:Label ID="Label32" runat="server" Text="学校发展计划的实施(30分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="6" style="border: thin Ridge black" 
                            class="style2" >
                                <asp:Label ID="Label33" runat="server" Text="实施的规范性(30分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="2" style="border: thin Ridge black" 
                            class="style3" >
                                <asp:Label ID="Label34" runat="server" Text="履行职责(13分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4" >
                                1.SDP管理委员会、各职能部门、教研组或年级组都明确自身在实施学校发展计划中应承担的任务、职责和目标。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                3</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4" >
                                2.各职能部门、教研组或年级组能根据SDP中既定的目标，各司其职，完成任务。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                10</td>
                        </tr>
                        <tr>
                             <td align="center" colspan="1" rowspan="2" style="border: thin Ridge black" 
                                 class="style3" >
                                <asp:Label ID="Label39" runat="server" Text="自评调整(7分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style4"  >
                                1.学校管理团队和教师对照计划内容，经常性的进行自我监测，总结经验，发现问题，及时调整，并形成自评机制。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                4</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4"  >
                                2.根据学校实际情况的变化，合理调整计画安排和目标要求。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                3</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="2" style="border: thin Ridge black" 
                                class="style3" >
                                <asp:Label ID="Label44" runat="server" Text="合作互动 (10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4" >
                                1.教师、学生、家长了解学校发展并参与相关活动。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                5</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4" >
                                2.学校管理团队、师生员工、家长和社区群众持续参与学校发展计划的实施活动，形成推进SDP持续开展的整体合力。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                10</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="5" style="border: thin Ridge black" 
                                class="style1" >
                                <asp:Label ID="Label45" runat="server" Text="学校发展计划的成效(30+20分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="3" style="border: thin Ridge black" 
                                class="style2" >
                                <asp:Label ID="Label50" runat="server" Text="自主目标实现(30分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style3" >
                                <asp:Label ID="Label51" runat="server" Text="学科能力(10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="3" style="border: thin Ridge black" 
                                class="style4" >
                                <asp:Label ID="Label7" runat="server" Text="各目标的实现程度，三个​​维度下各目标的实现程度，各项活动措施的落实情况，以及问题的解决程度。" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black">
                                10</td>
                        </tr>
                        <tr>
                             <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style3" >
                                <asp:Label ID="Label56" runat="server" Text="人格陶冶(10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                10</td>
                        </tr>
                        <tr>
                             <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                 class="style3" >
                                <asp:Label ID="Label67" runat="server" Text="学校管理(10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                10</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="2" style="border: thin Ridge black" 
                                class="style2" >
                                <asp:Label ID="Label61" runat="server" Text="预期目标实现(20分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style3" >
                                <asp:Label ID="Label62" runat="server" Text="获奖情况(10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4" >
                                用实例、数据说明本年度各类、各层次奖项的获得情况，特别是获奖名次的变化情况。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                10</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style3" >
                                <asp:Label ID="Label64" runat="server" Text="特色创新(10分)" ></asp:Label>
                            </td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" 
                                class="style4" >
                                在学校管理和教育教学等活动中逐步形成具有独特、稳定的经验和工作机制。</td>
                            <td align="center" colspan="1" rowspan="1" style="border: thin Ridge black" >
                                10</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="5" rowspan="1" style="border: thin Ridge black">
                                <asp:Label ID="LbGuideResultAssessment" runat="server" Text="总体评估(100分+20分)"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="8">
                                    &nbsp&nbsp&nbsp
                                <asp:Button ID="BtnCancel" runat="server" Text="返回" Height="22px" 
                                    Width="58px" onclick="BtnCancel_Click" />
                            </td>
                        </tr>
                    </table>
          </div>
    </form>
</body>
</html>
