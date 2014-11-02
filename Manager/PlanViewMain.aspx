<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanViewMain.aspx.cs" Inherits="SchoolMaster_PlanViewMain" %>

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
            padding-top:0px;
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
                <asp:ImageButton ID="ImgBtnIndex" runat="server" ImageUrl="<%$ Resources:Resource, ImgUrlBackIndex %>" OnClick="ImgBtnIndex_Click"/>
            </div>
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
                    <asp:Label ID="LbLocation" runat="server" Text="<%$ Resources:Resource, TipPlanSDP %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Resource, TipPlanDataView %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="PlanList.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, TipPlanDataAdd %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="PlanItemAdd.aspx"></asp:HyperLink>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownController">
                    <table align="left" width="739px">
                        <tr>
                            
                            <td align="left">
                                <asp:Button ID="btnBack" runat="server" Text="<%$ Resources:Resource, TipPlanBack %>" OnClick="btnBack_Click1"  Font-Size="14pt"/>
                            </td>
                        </tr>
                    </table>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table width="739px">
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbPlanItem1" runat="server" Text="<%$ Resources:Resource, LkbPlanItem1 %>" OnClick="LkbPlanItem1_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbPlanItem2" runat="server" Text="<%$ Resources:Resource, LkbPlanItem2 %>"  OnClick="LkbPlanItem2_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbPlanItem3" runat="server" Text="<%$ Resources:Resource, LkbPlanItem3 %>"  OnClick="LkbPlanItem3_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbPlanItem4" runat="server" Text="<%$ Resources:Resource, LkbPlanItem4 %>"  OnClick="LkbPlanItem4_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbPlanItem4_2" runat="server" Text="<%$ Resources:Resource, LkbPlanItem4_2 %>"  OnClick="LkbPlanItem4_2_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbPlanItem5" runat="server" Text="<%$ Resources:Resource, LkbPlanItem5 %>" OnClick="LkbPlanItem5_Click" ></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbPlanItem6" runat="server" Text="<%$ Resources:Resource, LkbPlanItem6 %>" OnClick="LkbPlanItem6_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbPlanItem7" runat="server" Text="<%$ Resources:Resource, LkbPlanItem7 %>" OnClick="LkbPlanItem7_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbPlanItem8" runat="server" Text="<%$ Resources:Resource, LkbPlanItem8 %>" OnClick="LkbPlanItem8_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbPlanItem9" runat="server" Text="<%$ Resources:Resource, LkbPlanItem9 %>" OnClick="LkbPlanItem9_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbPlanItem11" runat="server" Text="<%$ Resources:Resource, LkbPlanItem11 %>"  OnClick="LkbPlanItem11_Click" ></asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                    <table width="739px">
                        <tr>
                            <td align="left" width="10%">
                                <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, TipPlanAttachment %>"></asp:Label>
                            </td>
                            <td align="left" width="90%">
                                <%--<asp:Button ID="btnUpload" runat="server" Text="<%$ Resources:Resource, TipPlanUploadAttachment %>" OnClick="btnUpload_Click" />--%>
                            </td>
                        </tr>
                    </table>
                    <table width="739px">
                        <thead>
                            <tr>
                                <th width="350px">名稱</th>
                                <th width="70px">範本</th>
                                <th width="70px">已上傳</th>
                                <%--<th width="50px">上傳</th>--%>
                                <th width="50px">下載</th>
                            </tr>
                        </thead>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem1 %>"></asp:Label>
                            </td>
                            <td>
                                <a href="../template/stage3/attach1.doc"><font color="red">參考範例</font></a>
                            </td>
                            <td>
                                <asp:Label ID="LbStatus1" runat="server" Text=""></asp:Label>
                            </td>
                            <%--<td>
                                <asp:Button ID="Button2" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click"/>
                            </td>--%>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="ButtonDownLoad_Click" CommandArgument="1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem2 %>"></asp:Label>
                            </td>
                            <td>
                                <a href="../template/stage3/attach2.doc"><font color="red">參考範例</font></a>
                            </td>
                            <td>
                                <asp:Label ID="LbStatus2" runat="server" Text=""></asp:Label>
                            </td>
                           <%-- <td>
                                <asp:Button ID="Button3" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click"/>
                            </td>--%>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="<%$ Resources:Resource, BtnClick %>"  OnClick="ButtonDownLoad_Click"  CommandArgument="2" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem3 %>"></asp:Label>
                            </td>
                            <td>
                                <a href="../template/stage3/attach3.doc"><font color="red">參考範例</font></a>
                            </td>
                            <td>
                                <asp:Label ID="LbStatus3" runat="server" Text=""></asp:Label>
                            </td>
                           <%-- <td>
                                <asp:Button ID="Button5" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click"/>
                            </td>--%>
                            <td>
                                <asp:Button ID="Button6" runat="server" Text="<%$ Resources:Resource, BtnClick %>"  OnClick="ButtonDownLoad_Click"  CommandArgument="3" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem4 %>"></asp:Label>
                            </td>
                            <td>
                                <a href="../template/stage3/attach4.doc"><font color="red">參考範例</font></a>
                            </td>
                            <td>
                                <asp:Label ID="LbStatus4" runat="server" Text=""></asp:Label>
                            </td>
                           <%-- <td>
                                <asp:Button ID="Button7" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click"/>
                            </td>--%>
                            <td>
                                <asp:Button ID="Button8" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="ButtonDownLoad_Click"  CommandArgument="4" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem5 %>"></asp:Label>
                            </td>
                            <td>
                                <a href="../template/stage3/attach5.doc"><font color="red">參考範例</font></a>
                            </td>
                            <td>
                                <asp:Label ID="LbStatus5" runat="server" Text=""></asp:Label>
                            </td>
                           <%-- <td>
                                <asp:Button ID="Button9" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click"/>
                            </td>--%>
                            <td>
                                <asp:Button ID="Button10" runat="server" Text="<%$ Resources:Resource, BtnClick %>"  OnClick="ButtonDownLoad_Click"  CommandArgument="5" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem6 %>"></asp:Label>
                            </td>
                            <td>
                                <a href="../template/stage3/attach6.doc"><font color="red">參考範例</font></a>
                            </td>
                            <td>
                                <asp:Label ID="LbStatus6" runat="server" Text=""></asp:Label>
                            </td>
                            <%--<td>
                                <asp:Button ID="Button11" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click"/>
                            </td>--%>
                            <td>
                                <asp:Button ID="Button12" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="ButtonDownLoad_Click"  CommandArgument="6" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem7 %>"></asp:Label>
                            </td>
                            <td>
                                <a href="../template/stage3/attach7.doc"><font color="red">參考範例</font></a>
                            </td>
                            <td>
                                <asp:Label ID="LbStatus7" runat="server" Text=""></asp:Label>
                            </td>
                            <%--<td>
                                <asp:Button ID="Button13" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click"/>
                            </td>--%>
                            <td>
                                <asp:Button ID="Button14" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="ButtonDownLoad_Click" CommandArgument="7" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label16" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem8 %>"></asp:Label>
                            </td>
                            <td>
                                <a href="../template/stage3/attach8.doc"><font color="red">參考範例</font></a>
                            </td>
                            <td>
                                <asp:Label ID="LbStatus8" runat="server" Text=""></asp:Label>
                            </td>
                            <%--<td>
                                <asp:Button ID="Button15" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click"/>
                            </td>--%>
                            <td>
                                <asp:Button ID="Button16" runat="server" Text="<%$ Resources:Resource, BtnClick %>"  OnClick="ButtonDownLoad_Click"  CommandArgument="8" />
                            </td>
                        </tr>
                        <%--<tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbDownloadItem1" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem1 %>" OnClick="LkbDownloadItem1_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbDownloadItem2" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem2 %>" OnClick="LkbDownloadItem2_Click">></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbDownloadItem3" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem3 %>" OnClick="LkbDownloadItem3_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbDownloadItem4" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem4 %>" OnClick="LkbDownloadItem4_Click">></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbDownloadItem5" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem5 %>" OnClick="LkbDownloadItem5_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbDownloadItem6" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem6 %>" OnClick="LkbDownloadItem6_Click">></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbDownloadItem7" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem7 %>" OnClick="LkbDownloadItem7_Click"></asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="left">
                                <asp:LinkButton ID="LkbDownloadItem8" runat="server" Text="<%$ Resources:Resource, LkbDownloadItem8 %>" OnClick="LkbDownloadItem8_Click">></asp:LinkButton>
                            </td>
                        </tr>--%>
                    </table>
                </div>
            </div>
        </div>
        <asp:Literal ID="ClientScriptArea" runat="server"></asp:Literal> 
    </div>
    </form>
</body>
</html>
