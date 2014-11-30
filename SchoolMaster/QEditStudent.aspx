<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QEditStudent.aspx.cs" Inherits="SchoolMaster_QEditStudent" %>

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
        .auto-style1 {
            height: 26px;
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
                    <asp:Label ID="LbLocation" runat="server" Text="<%$ Resources:Resource, QStudentManageTip %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Resource, QStudentData %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="QViewStudentList.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, QStudentScoreInput %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="QInputScoreList.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, QStudentScore %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="QViewScoreList.aspx"></asp:HyperLink>
            </div>
            <div id="BlockRightDown">
                <table width="739px">
                    <tr>
                        <td align="left">
                            <ul>
                                <li>
                            <asp:HyperLink ID="HyperLink4" runat="server" Font-Bold="true" ForeColor="Red" Text="学生基本信息编辑" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="QEditStudent.aspx"></asp:HyperLink>
                                </li>
                                 <li>
                            <asp:HyperLink ID="HyperLink5" runat="server" Font-Bold="true" ForeColor="Black" Text="学生基本信息观看" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="QViewStudentList.aspx"></asp:HyperLink>
                                </li>
                            </ul>
                        </td>
                    </tr>
                </table>
                <table width="739px">
                    <tr>
                        <td align="left">
                            <h3>步骤一、学生基本资料输入</h3>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <div style="float:left;margin-left:30px">学生姓名:</div>
                            <div style="float:left"><asp:TextBox ID="tbStage1Name" runat="server" Font-Size="14pt"></asp:TextBox></div>
                            <div style="float:left;margin-left:30px">学籍辅号:</div>
                            <div style="float:left"><asp:TextBox ID="tbStage1ID" runat="server" Font-Size="14pt"></asp:TextBox></div>
                            <div style="float:left;margin-left:30px">
                                <asp:Button ID="btnStage1Input" runat="server" Text="输入" OnClick="btnStage1Input_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="739px">
                    <tr>
                        <td align="left">
                            <h3>步骤二、班级人员录入</h3>
                        </td>
                    </tr>
                    <tr>
                         <td align="left">
                            <div style="float:left;margin-left:30px">学生姓名:</div>
                            <div style="float:left"><asp:TextBox ID="tbStage2Name" runat="server" Font-Size="14pt"></asp:TextBox></div>
                            <div style="float:left;margin-left:30px">学籍辅号:</div>
                            <div style="float:left"><asp:TextBox ID="tbStage2ID" runat="server" Font-Size="14pt"></asp:TextBox></div>
                            <div style="float:left;margin-left:30px">
                                <asp:Button ID="BtnStage2Edit" runat="server" Text="查询学生" OnClick="BtnStage2Edit_Click" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvEditStudent" runat="server" AutoGenerateColumns="False" BackColor="White" Width="850px"  
                                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4"  
                                    onpageindexchanging="gvEdit_PageIndexChanging"  
                                    onrowcancelingedit="gvEdit_RowCancelingEdit"  
                                    onrowdatabound="gvEdit_RowDataBound" onrowdeleting="gvEdit_RowDeleting"  
                                    onrowediting="gvEdit_RowEditing" onrowupdating="gvEdit_RowUpdating"  
                                    onsorting="gvEdit_Sorting" AllowPaging="True" PageSize="10"> 
                                <RowStyle BackColor="White" ForeColor="#003399" /> 
                                <Columns> 
                                    <asp:TemplateField HeaderText="学年" ItemStyle-Width="50px"> 
                                        <EditItemTemplate> 
                                            <asp:TextBox ID="tbYear" runat="server" Text='' MaxLength="4" Width="80px"></asp:TextBox> 
                                        </EditItemTemplate> 
                                        <ItemTemplate> 
                                            <asp:Label ID="lbYear" runat="server" Text=''></asp:Label> 
                                        </ItemTemplate> 
                                        <ItemStyle Width="80px"></ItemStyle>
                                    </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="学期" ItemStyle-Width="50px"> 
                                        <EditItemTemplate> 
                                            <asp:TextBox ID="tbSemester" runat="server" Text='' MaxLength="1" Width="80px"></asp:TextBox> 
                                        </EditItemTemplate> 
                                        <ItemTemplate> 
                                            <asp:Label ID="lbSemester" runat="server" Text=''></asp:Label> 
                                        </ItemTemplate> 
                                        <ItemStyle Width="80px"></ItemStyle>
                                    </asp:TemplateField> 
                                    <asp:BoundField DataField="Name" HeaderText="学生姓名" ReadOnly="True" ItemStyle-Width="80px" 
                                        SortExpression="Name" /> 
                                    <asp:BoundField DataField="IdentifyID" HeaderText="学籍辅号" ReadOnly="True"  ItemStyle-Width="80px" 
                                        SortExpression="IdentifyID">
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField> 
                                    <asp:TemplateField HeaderText="年级" SortExpression="GradeLevel" ItemStyle-Width="50px"> 
                                        <EditItemTemplate> 
                                            <asp:TextBox ID="tbGradeLevel" runat="server" Text='<%# Bind("GradeLevel") %>' MaxLength="3" Width="50px"></asp:TextBox> 
                                        </EditItemTemplate> 
                                        <ItemTemplate> 
                                            <asp:Label ID="lbGradeLevel" runat="server" Text='<%# Bind("GradeLevel") %>'></asp:Label> 
                                        </ItemTemplate> 
                                        <ItemStyle Width="50px"></ItemStyle>
                                    </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="班级" SortExpression="Class" ItemStyle-Width="50px"> 
                                        <EditItemTemplate> 
                                            <asp:TextBox ID="tbClass" runat="server" Text='<%# Bind("Class") %>' MaxLength="3" Width="50px"></asp:TextBox> 
                                        </EditItemTemplate> 
                                        <ItemTemplate> 
                                            <asp:Label ID="lbClass" runat="server" Text='<%# Bind("Class") %>' Width="50px"></asp:Label> 
                                        </ItemTemplate> 
                                        <ItemStyle Width="50px"></ItemStyle>
                                    </asp:TemplateField> 
                                    <asp:TemplateField HeaderText="班内学号" SortExpression="StudentID" ItemStyle-Width="100px"> 
                                        <EditItemTemplate> 
                                            <asp:TextBox ID="tbStudentID" runat="server" Text='<%# Bind("StudentID") %>' MaxLength="3" Width="50px"></asp:TextBox> 
                                        </EditItemTemplate> 
                                        <ItemTemplate> 
                                            <asp:Label ID="lbStudentID" runat="server" Text='<%# Bind("StudentID") %>' Width="50px"></asp:Label> 
                                        </ItemTemplate> 
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:TemplateField> 
                                    <asp:CommandField ShowEditButton="True" ItemStyle-Width="100px"/> 
                                </Columns> 
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" /> 
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" /> 
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" /> 
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" /> 
                            </asp:GridView> 
                        </td>
                    </tr>
                </table>

                <table width="739px">
                    <tr>
                        <td colspan="4" align="left">
                            <h3>步骤三、班级人员管理</h3>
                        </td>
                    </tr>
                    <tr>
                        <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DdlYear" runat="server" Width="80px" Font-Size="14pt">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                   <%-- <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="BtnSearch" EventName="Click" />
                                    </Triggers>--%>
                                </asp:UpdatePanel>
                            </td>
                            <td align="left">
                                <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DdlSemester" runat="server" Width="80px" Font-Size="14pt">
                                            <asp:ListItem Value="0" Text="学期"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                            <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <%--<Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="BtnSearch" EventName="Click" />
                                    </Triggers>--%>
                                </asp:UpdatePanel>
                            </td>
                    </tr>
                    <tr>
                        <td align="left">
                            <asp:UpdatePanel ID="UpProvince" runat="server" Visible="true">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DdlGradeLevel" runat="server" Width="80px" Font-Size="14pt" OnSelectedIndexChanged="DdlGradeLevel_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <%--<Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="BtnStore" EventName="Click" />
                                </Triggers>--%>
                            </asp:UpdatePanel>
                        </td>
                        <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DdlClass" runat="server" Width="80px" Font-Size="14pt" AutoPostBack="true" OnSelectedIndexChanged="DdlClass_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <%-- <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="BtnStore" EventName="Click" />
                                </Triggers>--%>
                            </asp:UpdatePanel>
                        </td>
                        <td align="left">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DdlStudentID" runat="server" Width="80px" Font-Size="14pt" AutoPostBack="true">
                                    </asp:DropDownList>
                                </ContentTemplate>
                                <%--<Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="BtnStore" EventName="Click" />
                                </Triggers>--%>
                            </asp:UpdatePanel>
                        </td>
                        <td>
                            <asp:Button ID="BtnStage3" runat="server" Text="查询" OnClick="BtnStore_Click" Font-Size="14pt"/>
                        </td>
                    </tr>
                </table>
                <%-- <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="BtnSearch" EventName="Click" />
                                    </Triggers>--%>
                <table style="width: 735px">
                    <tr>
                        <td align="left" style="">
                            <asp:GridView ID="gvPerson" runat="server" AutoGenerateColumns="False" BackColor="White" Width="850px"  
                                    BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4"  
                                    onpageindexchanging="gvPerson_PageIndexChanging"  
                                    onrowcancelingedit="gvPerson_RowCancelingEdit"  
                                    onrowdatabound="gvPerson_RowDataBound" onrowdeleting="gvPerson_RowDeleting"  
                                    onrowediting="gvPerson_RowEditing" onrowupdating="gvPerson_RowUpdating"  
                                    onsorting="gvPerson_Sorting" AllowPaging="True"> 
                                <RowStyle BackColor="White" ForeColor="#003399" /> 
                                <Columns> 
                                    <asp:BoundField DataField="Name" HeaderText="學生姓名" ReadOnly="True"  ItemStyle-Width="50px" 
                                        SortExpression="GradeLevel"> 
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField> 
                                    <asp:BoundField DataField="IdentifyID" HeaderText="学籍辅号" ReadOnly="True" ItemStyle-Width="50px" 
                                        SortExpression="Class"> 
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField> 
                                    <asp:BoundField DataField="GradeLevel" HeaderText="年级" ReadOnly="True"  ItemStyle-Width="100px" 
                                        SortExpression="StudentID">
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField> 
                                    <asp:BoundField DataField="Class" HeaderText="班级" ReadOnly="True"  ItemStyle-Width="100px" 
                                        SortExpression="StudentID">
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField> 
                                    <asp:BoundField DataField="StudentID" HeaderText="班内学号" ReadOnly="True"  ItemStyle-Width="100px" 
                                        SortExpression="StudentID">
                                        <ItemStyle Width="100px"></ItemStyle>
                                    </asp:BoundField> 
                                    <asp:CommandField ItemStyle-Width="80px" ShowDeleteButton="True"/> 
                                </Columns> 
                                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" /> 
                                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" /> 
                                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" /> 
                                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" /> 
                            </asp:GridView> 
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="right">
                                
                        <td>
                            <asp:Button ID="BtnCancel" runat="server" Text="回到上一页" OnClick="BtnCancel_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
