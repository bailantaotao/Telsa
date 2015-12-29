<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MsgAnnocementRecord.aspx.cs" Inherits="MsgAnnocement" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script language="javascript" type="text/javascript">
        
    </script>
    <style type="text/css">
        .style1
        {
            width: 87px;
        }
    </style>
    </head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ToolkitScriptManager1" CombineScripts="false" />
    <div>
        <table style="width: 900px">
            <tr>
                <td class="style1">
                    <asp:Label ID="Label1" runat="server" Text="使用者:" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label> 
                </td>
                <td>
                    <asp:Label ID="LbUserName" runat="server" Font-Size="<%$ Resources:Resource, TextSizeTitle %>"></asp:Label> 
                </td>
            </tr>
        </table>
        <table style="width: 900px">
            <tr>
                <td align="left" >
                    <asp:GridView ID="GvMsgRecord" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" 
                                  BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                        CellSpacing="2" Width="600px">
                            <Columns>
                                <asp:TemplateField HeaderText="接收者"  ItemStyle-Width="20">
                                    <ItemTemplate>
                                        <asp:Label ID="ReceiverID" runat="server" Text="" Width="80px"></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" /><ItemStyle Width="80px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="传送时间"  ItemStyle-Width="20">
                                    <ItemTemplate>
                                        <asp:Label ID="SendTime" runat="server" Text="" Width="120px"></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" /><ItemStyle Width="120px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="传送内容"  ItemStyle-Width="80">
                                    <ItemTemplate>
                                        <asp:Label ID="Subjects" runat="server" Text="" Width="630px"></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" /><ItemStyle Width="630px"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                            <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                            <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                            <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#FFF1D4" />
                            <SortedAscendingHeaderStyle BackColor="#B95C30" />
                            <SortedDescendingCellStyle BackColor="#F1E5CE" />
                            <SortedDescendingHeaderStyle BackColor="#93451F" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                 <td colspan="2">             
                    <asp:Button ID="BtnClose" Text="<%$ Resources:Resource, BtnClose %>" runat="server" OnClick="BtnClose_Click" />   
                </td>
            </tr>
        </table>
        
               
    </div>
    </form>
</body>
</html>
