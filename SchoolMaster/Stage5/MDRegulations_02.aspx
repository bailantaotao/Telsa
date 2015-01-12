﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MDRegulations_02.aspx.cs" Inherits="Stage5_MDRegulations_02" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style>
        #BlockLeft {
            float: left;
            padding-top: 235px;
            width: 285px;
        }
        #BlockRight {
            float: left;
            padding-top: 210px;
            width: 739px;
        }
        #BlockRightUp {
            height: 40px;
            padding-left:25px;
        }
        #BlockRightDown {
            padding-top: 10px;
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
        .paneltop
        {
            border:1px solid black;
        }
    </style>
</head>
<body style="margin: 0; padding: 0; font-size: 14pt; border-top-style: none; font-family: Arial; border-right-style: none; border-left-style: none; border-bottom-style: none; background:url(../../<%= backgroundImage %>) no-repeat center top;">
    <form id="form1" runat="server">
    <div align="center" style="width: 1024px; margin: 0px auto;">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
        </asp:ScriptManager>
        <div id="BlockLeft">
            <div class ="Option" style="text-align:left">
                <asp:ImageButton ID="ImgBtnIndex" runat="server" 
                    ImageUrl="../../Image/zh-CN/ButtonBackIndex.png" OnClick="ImgBtnIndex_Click"/>
            </div>
            <div class ="Option">
                <img src="../../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInternetStudy" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="../../SchoolMaster/InternetStudy.aspx" Text="<%$ Resources:Resource, HyInternetStudy %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlKPI" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrL="../../SchoolMaster/KPIExamMain.aspx" Text="<%$ Resources:Resource, HyKPI %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlSchoolDevelop" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="../../SchoolMaster/PlanList.aspx" Text="<%$ Resources:Resource, HySchoolDevelop %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlMonitor" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="../../SchoolMaster/GuideSDPEvaluateResult.aspx" Text="<%$ Resources:Resource, HyFollowingMonitor %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlInstitution" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="~/Stage5/MDRegulations_00.aspx" Text="<%$ Resources:Resource, HyRuleManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlStudentManage" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="../../SchoolMaster/QViewStudentList.aspx" Text="<%$ Resources:Resource, HyStudentManage %>"></asp:HyperLink>
            </div>
            <div class ="Option">
                <img src="../../Image/zh-TW/TipWhite.png" />
                <asp:HyperLink ID="HlQuestinnaire" runat="server" ForeColor="White" Font-Size="<%$ Resources:Resource, TextSizeHyLink %>" NavigateUrl="../../SchoolMaster/SurveyPreList.aspx" Text="<%$ Resources:Resource, HyQuestionnaire %>"></asp:HyperLink>
            </div>
        </div>
        <div id="BlockRight">
            <div id="BlockRightUp">
                <div style="background: url(../Image/zh-TW/TipGary_TipUserLocation.png) no-repeat; text-align:center; width: 175px; height:39px; float: left;  line-height:39px;">
                    <asp:Label ID="LbLocation" runat="server" Text="规章制度管理" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
            </div>
            <div id="BlockRightDown">
                <div id="BlockRightDownDataDisplay">
                    <table align="center" >
                        <tr>
                        <td colspan="2" rowspan="5">
                        <asp:Label ID="Label1" runat="server" Text="规章制度选单:"></asp:Label>
                        <asp:DropDownList ID="DlRegulationSelect" runat="server" AutoPostBack="true"  Font-Size="14px" Width="177px" Height="30px"
                            onselectedindexchanged="SelectedIndexChanged" >
                            <asp:ListItem Selected="True" Value="0">请选择</asp:ListItem>
                            <asp:ListItem Value="1">党支部制度</asp:ListItem>
                            <asp:ListItem Value="2">少先队工作制度</asp:ListItem>
                            <asp:ListItem Value="3">教师及领导岗位职责</asp:ListItem>
                            <asp:ListItem Value="4">图书室管理制度及细则</asp:ListItem>
                            <asp:ListItem Value="5">管理细则</asp:ListItem>
                            <asp:ListItem Value="6">安全制度</asp:ListItem>
                            <asp:ListItem Value="7">其它管理制度</asp:ListItem>
                        </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label22" runat="server" Text="提示:" Font-Size="16pt" ForeColor="Red"></asp:Label>
                        </td>
                        <tr>
                            <td>
                                <asp:Label ID="Label23" runat="server" Text="1.首次点选参考范例" Font-Size="14pt" ForeColor="Purple"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label24" runat="server" Text="2.编辑成本校规章制度另存新档" Font-Size="14pt" ForeColor="Purple"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label25" runat="server" Text="3.上传为本校规章制度" Font-Size="14pt" ForeColor="Purple"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label26" runat="server" Text="4.尔后更新下载本校规章制度修改" Font-Size="14pt" ForeColor="Purple"></asp:Label>
                            </td>
                        </tr>
                    </tr>
                    </table>
                    <table align="center" width="700">
　                    <tr align="center" align="center">
　                       <td colspan="5" height="50" bgcolor="#eebb95">少先队工作制度</td>
　                    </tr>
　                    
                    </table>
                    <table width="739px">
                        <thead>
                            <tr>
                                <th width="250px">名稱</th>
                                <th width="130px">範本</th>
                                <%-- <th width="70px">已上傳</th>--%>
                                <th width="100px">浏览附件</th>
                                <th width="50px">上傳</th>
                                <th width="50px">下載</th>
                            </tr>
                        </thead>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="大队委职责"></asp:Label>
                            </td>
                            <td>
                                <a href="./02/01.doc"><font color="red">參考範例</font></a>
                            </td>
                            <%--<td>
                                <asp:Label ID="LbStatus1" runat="server" Text=""></asp:Label>
                            </td>--%>
                            <td>
                                <asp:FileUpload ID="FileUpload1" runat="server"  Font-Size="14pt"  style="margin-left: 0px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button2" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click" CommandArgument="1"/>
                            </td>
                            <td>
                                <asp:Button ID="Button1" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="ButtonDownLoad_Click" CommandArgument="1" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="中队委职责"></asp:Label>
                            </td>
                            <td>
                                <a href="./02/02.doc"><font color="red">參考範例</font></a>
                            </td>
                            <%--<td>
                                <asp:Label ID="LbStatus2" runat="server" Text=""></asp:Label>
                            </td>--%>
                            <td>
                                <asp:FileUpload ID="FileUpload2" runat="server"  Font-Size="14pt"  style="margin-left: 0px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click" CommandArgument="2" Height="21px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="<%$ Resources:Resource, BtnClick %>"  OnClick="ButtonDownLoad_Click"  CommandArgument="2" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="升降国旗制度"></asp:Label>
                            </td>
                            <td>
                                <a href="./02/03.doc"><font color="red">參考範例</font></a>
                            </td>
                            <%--<td>
                                <asp:Label ID="LbStatus3" runat="server" Text=""></asp:Label>
                            </td>--%>
                            <td>
                                <asp:FileUpload ID="FileUpload3" runat="server"  Font-Size="14pt"  style="margin-left: 0px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button5" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click" CommandArgument="3"/>
                            </td>
                            <td>
                                <asp:Button ID="Button6" runat="server" Text="<%$ Resources:Resource, BtnClick %>"  OnClick="ButtonDownLoad_Click"  CommandArgument="3" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="少先队工作制度"></asp:Label>
                            </td>
                            <td>
                                <a href="./02/04.doc"><font color="red">參考範例</font></a>
                            </td>
                            <%--<td>
                                <asp:Label ID="LbStatus4" runat="server" Text=""></asp:Label>
                            </td>--%>
                            <td>
                                <asp:FileUpload ID="FileUpload4" runat="server"  Font-Size="14pt"  style="margin-left: 0px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button7" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click" CommandArgument="4"/>
                            </td>
                            <td>
                                <asp:Button ID="Button8" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="ButtonDownLoad_Click"  CommandArgument="4" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="少先队干部的培训"></asp:Label>
                            </td>
                            <td>
                                <a href="./02/05.doc"><font color="red">參考範例</font></a>
                            </td>
                            <%--<td>
                                <asp:Label ID="LbStatus1" runat="server" Text=""></asp:Label>
                            </td>--%>
                            <td>
                                <asp:FileUpload ID="FileUpload5" runat="server"  Font-Size="14pt"  style="margin-left: 0px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button9" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click" CommandArgument="5"/>
                            </td>
                            <td>
                                <asp:Button ID="Button10" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="ButtonDownLoad_Click" CommandArgument="5" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="少先队队前教育"></asp:Label>
                            </td>
                            <td>
                                <a href="./02/06.doc"><font color="red">參考範例</font></a>
                            </td>
                            <%--<td>
                                <asp:Label ID="LbStatus2" runat="server" Text=""></asp:Label>
                            </td>--%>
                            <td>
                                <asp:FileUpload ID="FileUpload6" runat="server"  Font-Size="14pt"  style="margin-left: 0px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button11" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click" CommandArgument="6" Height="21px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button12" runat="server" Text="<%$ Resources:Resource, BtnClick %>"  OnClick="ButtonDownLoad_Click"  CommandArgument="6" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="总则"></asp:Label>
                            </td>
                            <td>
                                <a href="./02/07.doc"><font color="red">參考範例</font></a>
                            </td>
                            <%--<td>
                                <asp:Label ID="LbStatus3" runat="server" Text=""></asp:Label>
                            </td>--%>
                            <td>
                                <asp:FileUpload ID="FileUpload7" runat="server"  Font-Size="14pt"  style="margin-left: 0px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button13" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click" CommandArgument="7"/>
                            </td>
                            <td>
                                <asp:Button ID="Button14" runat="server" Text="<%$ Resources:Resource, BtnClick %>"  OnClick="ButtonDownLoad_Click"  CommandArgument="7" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="细则"></asp:Label>
                            </td>
                            <td>
                                <a href="./02/08.doc"><font color="red">參考範例</font></a>
                            </td>
                            <%--<td>
                                <asp:Label ID="LbStatus4" runat="server" Text=""></asp:Label>
                            </td>--%>
                            <td>
                                <asp:FileUpload ID="FileUpload8" runat="server"  Font-Size="14pt"  style="margin-left: 0px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button15" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click" CommandArgument="8"/>
                            </td>
                            <td>
                                <asp:Button ID="Button16" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="ButtonDownLoad_Click"  CommandArgument="8" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="规范的礼仪"></asp:Label>
                            </td>
                            <td>
                                <a href="./02/09.doc"><font color="red">參考範例</font></a>
                            </td>
                            <%--<td>
                                <asp:Label ID="LbStatus1" runat="server" Text=""></asp:Label>
                            </td>--%>
                            <td>
                                <asp:FileUpload ID="FileUpload9" runat="server"  Font-Size="14pt"  style="margin-left: 0px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button17" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click" CommandArgument="9"/>
                            </td>
                            <td>
                                <asp:Button ID="Button18" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="ButtonDownLoad_Click" CommandArgument="9" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="值日生制度"></asp:Label>
                            </td>
                            <td>
                                <a href="./02/10.doc"><font color="red">參考範例</font></a>
                            </td>
                            <%--<td>
                                <asp:Label ID="LbStatus2" runat="server" Text=""></asp:Label>
                            </td>--%>
                            <td>
                                <asp:FileUpload ID="FileUpload10" runat="server"  Font-Size="14pt"  style="margin-left: 0px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button19" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click" CommandArgument="10" Height="21px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button20" runat="server" Text="<%$ Resources:Resource, BtnClick %>"  OnClick="ButtonDownLoad_Click"  CommandArgument="10" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="路队纪律制度"></asp:Label>
                            </td>
                            <td>
                                <a href="./02/11.doc"><font color="red">參考範例</font></a>
                            </td>
                            <%--<td>
                                <asp:Label ID="LbStatus3" runat="server" Text=""></asp:Label>
                            </td>--%>
                            <td>
                                <asp:FileUpload ID="FileUpload11" runat="server"  Font-Size="14pt"  style="margin-left: 0px"/>
                            </td>
                            <td>
                                <asp:Button ID="Button21" runat="server" Text="<%$ Resources:Resource, BtnClick %>" OnClick="btnUpload_Click" CommandArgument="11"/>
                            </td>
                            <td>
                                <asp:Button ID="Button22" runat="server" Text="<%$ Resources:Resource, BtnClick %>"  OnClick="ButtonDownLoad_Click"  CommandArgument="11" />
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
