<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ViewComment.aspx.cs" Inherits="Expert_ViewComment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Resource, TipNo %>"></asp:Label>
            <asp:DropDownList ID="DdlPageSelect" runat="server" AutoPostBack="true" Width="60px" OnSelectedIndexChanged="DdlPageSelect_SelectedIndexChanged">
                <asp:ListItem Text="<%$ Resources:Resource, TipPlzChoose %>"></asp:ListItem>
            </asp:DropDownList>
            <asp:Label ID="Label2" runat="server" Text="<%$ Resources:Resource, TipPage %>"></asp:Label>
        </div>
        <div>
            <asp:Label ID="LbComplete" runat="server" Text=""></asp:Label>
        </div>
    </div>
    </form>
</body>
</html>
