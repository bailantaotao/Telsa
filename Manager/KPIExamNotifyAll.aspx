<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KPIExamNotifyAll.aspx.cs" Inherits="Manager_KPIExamNotifyAll" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
        </asp:ScriptManager>
        <table width="739px">
            <tr>
                <td width="30%">
                    <asp:DropDownList ID="DdlProvince" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="DdlProvince_SelectedIndexChanged"></asp:DropDownList>
                </td>
                <td width="20%">
                    <asp:Button ID="BtnSend" runat="server" Text="<%$ Resources:Resource, BtnKPINotify %>" OnClick="BtnSend_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnCancel" runat="server" Text="<%$ Resources:Resource, BtnCancel %>" OnClick="BtnCancel_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID="GvSchool" runat="server" AutoGenerateColumns="False" BackColor="#DDDDDD" BorderStyle="None"
    BorderWidth="1px" CellPadding="5" CellSpacing="1">
                        <RowStyle BackColor="#ffffff" ForeColor="Black" />
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <PagerStyle BackColor="#ffffff" HorizontalAlign="left" />
                        <HeaderStyle BackColor="#efefef" Font-Bold="True" />
                        <AlternatingRowStyle BackColor="#f7fafe" />
                        <EmptyDataTemplate>
                            Sorry, No any data.
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRow" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="SchoolName" HeaderText="学校名称" ItemStyle-Width="450" />
                            <asp:BoundField DataField="ScoreLevel" HeaderText="等级" ItemStyle-Width="70" />
                            <asp:BoundField DataField="TotalScore" HeaderText="总分" ItemStyle-Width="70" />
                        </Columns>
                    </asp:GridView>
                    <%--<asp:UpdatePanel ID="UpdateCompleted" runat="server">
                        <ContentTemplate>
                            <asp:Panel ID="PnSchool" runat="server"></asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="DdlPageSelect" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>--%>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
