<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QInputScore2.aspx.cs" Inherits="SchoolMaster_QInputScore2" %>

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
                    <asp:Label ID="LbLocation" runat="server" Text="<%$ Resources:Resource, QStudentManageTip %>" Font-Bold="true" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipBlack.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="true" ForeColor="Black" Text="<%$ Resources:Resource, QStudentData %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
                         NavigateUrl="QViewStudentList.aspx"></asp:HyperLink>
                </div>
                <div style="text-align:center; width: 14px; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <img src="../Image/zh-TW/TipRed.png" />
                </div>
                <div style="text-align:center; width: auto; height:39px; float: left;  line-height:39px; vertical-align:middle; padding-left:15px;">
                    <asp:HyperLink ID="HyperLink3" runat="server" Font-Bold="true" ForeColor="Red" Text="<%$ Resources:Resource, QStudentScoreInput %>" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"
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
                <div id="BlockRightDownController">
                    <table width="739px">
                        <tr>
                            <td align="left">
                                学校: <asp:Label ID="LbSchool" runat="server" Text="石家庄市井陉县南障城镇明德小学"></asp:Label>
                            </td>
                            <td align="left">
                                学年: <asp:Label ID="LbYear" runat="server" Text="2014"></asp:Label>
                            </td>
                            <td align="left">
                                学期: <asp:Label ID="LbSemester" runat="server" Text="1"></asp:Label>
                            </td>
                            <td align="left">
                                学校代号: <asp:Label ID="LbSchoolNo" runat="server" Text="NM14001"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="739px">
                        
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
                                        <asp:DropDownList ID="DdlStudentName" runat="server" Width="80px" Font-Size="14pt" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                    <%--<Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="BtnStore" EventName="Click" />
                                    </Triggers>--%>
                                </asp:UpdatePanel>
                            </td>
                            <td>
                                <asp:Button ID="BtnStore" runat="server" Text="查询" OnClick="BtnStore_Click" Font-Size="14pt"/>
                            </td>
                        </tr>
                    </table>
                    <%--<table width="739px">
                        <tr>
                            <td colspan="1" align="left" width="60%">                                
                                <asp:Label ID="LbTipProvince" runat="server" Text="<%$ Resources:Resource, TipPlanSchoolName %>"></asp:Label>
                                <asp:Label ID="LbSchoolName" runat="server" Text=""></asp:Label>
                            </td>
                            <td colspan="1" align="right" width="20%">
                                <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Resource, TipPlanSchoolMaster %>"></asp:Label>
                                <asp:Label ID="LbSchoolMaster" runat="server" Text=""></asp:Label>
                            </td>
                            <td colspan="1" align="right" width="20%">
                                <asp:Label ID="Label4" runat="server" Text="<%$ Resources:Resource, TipPlanSchoolSN %>"></asp:Label>
                                <asp:Label ID="LbSchoolSN" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>--%>
                </div>
                <div id="BlockRightDownDataDisplay">
                    <table style="width: 735px">
                        <tr>
                            <td align="left" style="">
                                <asp:GridView ID="gvPerson" runat="server" AutoGenerateColumns="False" BackColor="White" Width="850px"  
                                        BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4"  
                                        onpageindexchanging="gvPerson_PageIndexChanging"  
                                        onrowcancelingedit="gvPerson_RowCancelingEdit"  
                                        onrowdatabound="gvPerson_RowDataBound" onrowdeleting="gvPerson_RowDeleting"  
                                        onrowediting="gvPerson_RowEditing" onrowupdating="gvPerson_RowUpdating"  
                                        onsorting="gvPerson_Sorting" AllowPaging="True" PageSize="10"> 
                                    <RowStyle BackColor="White" ForeColor="#003399" /> 
                                    <Columns> 
                                        <asp:BoundField DataField="GradeLevel" HeaderText="年级" ReadOnly="True"  ItemStyle-Width="50px" 
                                            SortExpression="GradeLevel" /> 
                                        <asp:BoundField DataField="Class" HeaderText="班级" ReadOnly="True" ItemStyle-Width="50px" 
                                            SortExpression="Class" /> 
                                        <asp:BoundField DataField="StudentID" HeaderText="班内学号" ReadOnly="True"  ItemStyle-Width="100px" 
                                            SortExpression="StudentID">
                                            <ItemStyle Width="100px"></ItemStyle>
                                        </asp:BoundField> 
                                        <asp:TemplateField HeaderText="语文" SortExpression="Chinese" ItemStyle-Width="50px"> 
                                            <EditItemTemplate> 
                                                <asp:TextBox ID="tbChin" runat="server" Text='<%# Bind("Chinese") %>' MaxLength="3" Width="50px"></asp:TextBox> 
                                            </EditItemTemplate> 
                                            <ItemTemplate> 
                                                <asp:Label ID="lbChin" runat="server" Text='<%# Bind("Chinese") %>'></asp:Label> 
                                            </ItemTemplate> 
                                            <ItemStyle Width="50px"></ItemStyle>
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="数学" SortExpression="Math" ItemStyle-Width="50px"> 
                                            <EditItemTemplate> 
                                                <asp:TextBox ID="tbMath" runat="server" Text='<%# Bind("Math") %>' MaxLength="3" Width="50px"></asp:TextBox> 
                                            </EditItemTemplate> 
                                            <ItemTemplate> 
                                                <asp:Label ID="lbMath" runat="server" Text='<%# Bind("Math") %>' Width="50px"></asp:Label> 
                                            </ItemTemplate> 
                                            <ItemStyle Width="50px"></ItemStyle>
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="英语" SortExpression="English" ItemStyle-Width="50px"> 
                                            <EditItemTemplate> 
                                                <asp:TextBox ID="tbEng" runat="server" Text='<%# Bind("English") %>' MaxLength="3" Width="50px"></asp:TextBox> 
                                            </EditItemTemplate> 
                                            <ItemTemplate> 
                                                <asp:Label ID="lbEng" runat="server" Text='<%# Bind("English") %>' Width="50px"></asp:Label> 
                                            </ItemTemplate> 
                                            <ItemStyle Width="50px"></ItemStyle>
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="品德与社会" SortExpression="Society" ItemStyle-Width="130px"> 
                                            <EditItemTemplate> 
                                                <asp:TextBox ID="tbSoc" runat="server" Text='<%# Bind("Society") %>' MaxLength="3" Width="50px"></asp:TextBox> 
                                            </EditItemTemplate> 
                                            <ItemTemplate> 
                                                <asp:Label ID="lbSoc" runat="server" Text='<%# Bind("Society") %>' Width="50px"></asp:Label> 
                                            </ItemTemplate> 
                                            <ItemStyle Width="130px"></ItemStyle>
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="科学" SortExpression="Math" ItemStyle-Width="50px"> 
                                            <EditItemTemplate> 
                                                <asp:TextBox ID="tbSci" runat="server" Text='<%# Bind("Science") %>' MaxLength="3" Width="50px"></asp:TextBox> 
                                            </EditItemTemplate> 
                                            <ItemTemplate> 
                                                <asp:Label ID="lbSci" runat="server" Text='<%# Bind("Science") %>' Width="50px"></asp:Label> 
                                            </ItemTemplate> 
                                            <ItemStyle Width="50px"></ItemStyle>
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="音乐" SortExpression="Music" ItemStyle-Width="50px"> 
                                            <EditItemTemplate> 
                                                <asp:TextBox ID="tbMus" runat="server" Text='<%# Bind("Music") %>' MaxLength="3" Width="50px"></asp:TextBox> 
                                            </EditItemTemplate> 
                                            <ItemTemplate> 
                                                <asp:Label ID="lbMus" runat="server" Text='<%# Bind("Music") %>' Width="50px"></asp:Label> 
                                            </ItemTemplate> 
                                            <ItemStyle Width="50px"></ItemStyle>
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="体育" SortExpression="Physical" ItemStyle-Width="50px"> 
                                            <EditItemTemplate> 
                                                <asp:TextBox ID="tbPhy" runat="server" Text='<%# Bind("Physical") %>' MaxLength="3" Width="50px"></asp:TextBox> 
                                            </EditItemTemplate> 
                                            <ItemTemplate> 
                                                <asp:Label ID="lbPhy" runat="server" Text='<%# Bind("Physical") %>' Width="50px"></asp:Label> 
                                            </ItemTemplate> 
                                            <ItemStyle Width="50px"></ItemStyle>
                                        </asp:TemplateField> 
                                        <asp:TemplateField HeaderText="美术" SortExpression="Art" ItemStyle-Width="50px"> 
                                            <EditItemTemplate> 
                                                <asp:TextBox ID="tbArt" runat="server" Text='<%# Bind("Art") %>' MaxLength="3" Width="50px"></asp:TextBox> 
                                            </EditItemTemplate> 
                                            <ItemTemplate> 
                                                <asp:Label ID="lbArt" runat="server" Text='<%# Bind("Art") %>' Width="50px"></asp:Label> 
                                            </ItemTemplate> 
                                            <ItemStyle Width="50px"></ItemStyle>
                                        </asp:TemplateField> 
                                        <asp:CommandField ShowEditButton="True" ItemStyle-Width="120px"/> 
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
        <asp:Literal ID="ClientScriptArea" runat="server"></asp:Literal> 
    </div>
    </form>
</body>
</html>
