<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UserControlComment.ascx.cs" Inherits="Manager_UserControlComment" %>
<div style="line-height:30px">
    <div style="float:left; width: 450px">
        <asp:Label ID="LbTitle" runat="server" Text=""></asp:Label>
    </div>
    <div style="float:left; line-height:30px; width: 250px; text-align:right">
        <asp:Label ID="LbTime" runat="server" Text=""></asp:Label>
        <asp:ImageButton ID="ImgBtnDelete" runat="server" ImageUrl="<%$ Resources:Resource, ImgUrlDelete %>" OnClick="ImgBtnDelete_Click"/>
    </div>
</div>
<div style="width: 700px; text-align:left">
        <asp:Label ID="LbComment" runat="server" Text=""  style="word-break:break-all"></asp:Label>
</div>