<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanItemAddMember.aspx.cs" Inherits="SchoolMaster_PlanItemAddMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true">
        </asp:ScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConStr %>" SelectCommand="select Account.UserName, Account.ID from Account left join SchoolUser on Account.ID = SchoolUser.SHL_ID and Account.UserName = SchoolUser.SU_NAME where SchoolUser.A_ID = @A_ID">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="0" Name="A_ID" SessionField="Province" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
