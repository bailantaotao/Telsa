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
        <div>
            <p><font color="red">**找不到负责人员吗？请自行在下方填入该使用者名称</font></p>
        </div>
        <asp:TextBox ID="tbUserName" runat="server"></asp:TextBox>
        <asp:Button ID="BtnSubmit" runat="server" Text="确认" OnClick="BtnSubmit_Click" />
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SQLConStr %>" SelectCommand="select SchoolUser.SU_NAME, SchoolUser.SHL_ID from Account left join SchoolUser on SchoolUser.SHL_ID = Account.ID where Account.UserID=@UserID">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="" Name="UserID" SessionField="UserID" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
