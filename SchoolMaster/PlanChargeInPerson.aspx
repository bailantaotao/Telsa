﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlanChargeInPerson.aspx.cs" Inherits="SchoolMaster_PlanChargeInPerson" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="300px" style="margin-left:20px"">
            <tr>
                <td>                   
                    <asp:TextBox ID="TbPersonInCharge" runat="server" Width="100px"></asp:TextBox>
                    
                </td>
                <td rowspan="2">
                    <asp:Button ID="BtnAdd" runat="server" Text="<%$ Resources:Resource, TipPlanAdd %>" OnClick="BtnAdd_Click"  Font-Size="14pt"/>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DropDownList ID="DdlPersonInCharge" runat="server" Width="100px"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView ID="GvDepartment" runat="server" AutoGenerateColumns="False" BackColor="#DEBA84" BorderStyle="None"
            BorderWidth="1px" CellPadding="3" CellSpacing="2" BorderColor="#DEBA84">
                        <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                        <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                        <PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" />
                        <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                        <EmptyDataTemplate>
                            Sorry, No any data.
                        </EmptyDataTemplate>
                        <Columns>
                            <asp:BoundField DataField="PersonInCharge" HeaderText="負責人" ItemStyle-Width="150px" >
                                <HeaderStyle Width="150px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SN" HeaderText="<%$ Resources:Resource, TipPlanTitle %>" ItemStyle-Width="120px" Visible="false" >
                                <ItemStyle Width="120px"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="" ItemStyle-Width="50">
                                <ItemTemplate>
                                    <asp:Button ID="lbnDelete" runat="server" Text="<%$ Resources:Resource, TipPlanDelete %>" OnClick="btn_Delete" 
                                        CommandArgument="<%# ((GridViewRow)Container).RowIndex %>"  Width="50px"></asp:Button>
                                </ItemTemplate>

                                <HeaderStyle Width="50px" />

                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#FFF1D4" />
                        <SortedAscendingHeaderStyle BackColor="#B95C30" />
                        <SortedDescendingCellStyle BackColor="#F1E5CE" />
                        <SortedDescendingHeaderStyle BackColor="#93451F" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSubmit" runat="server" Text="确认" font-size="14pt" OnClick="btnSubmit_Click"/>
                    <asp:Button ID="btnCancel" runat="server" Text="取消" font-size="14pt" OnClick="btnCancel_Click"/>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>