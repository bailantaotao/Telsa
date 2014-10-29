<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="test_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %> 

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> 
    <title></title> 
    <style type="text/css"> 
        .modalBackground { 
            background-color:#333333; 
            filter:alpha(opacity=70); 
            opacity:0.7; 
        } 
        .modalPopup { 
            background-color:#FFFFFF; 
            border-width:1px; 
            border-style:solid; 
            border-color:#CCCCCC; 
            padding:1px; 
            width:300px; 
            Height:200px; 
        }    
    </style> 
</head> 
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"> 
    </asp:ScriptManager>
        <div> 
        <asp:UpdatePanel ID="udpOutterUpdatePanel" runat="server"> 
             <ContentTemplate> 


                <div id="divControlContainer" runat="server"></div> 
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <input id="dummy" type="button" style="display: none" runat="server" />


                <ajaxToolkit:ModalPopupExtender runat="server" 
                        ID="mpeThePopup" 
                        TargetControlID="dummy" 
                        PopupControlID="pnlModalPopUpPanel" 
                        BackgroundCssClass="modalBackground"                        
                        DropShadow="true"/> 



                 <asp:Panel ID="pnlModalPopUpPanel" runat="server" CssClass="modalPopup"> 


                    <asp:UpdatePanel ID="udpInnerUpdatePanel" runat="Server" UpdateMode="Conditional"> 
                        <ContentTemplate> 
                            <p> 
                                <asp:DropDownList ID="ddlProducts" runat="server"></asp:DropDownList>                                
                                &nbsp; 
                                <asp:Button ID="btnChooseProduct" runat="server" Text="Choose" onclick="btnChooseProduct_Click"/> 
                                &nbsp; 
                                <asp:Button ID="btnCancelModalPopup" runat="server" Text="Cancel" OnClick="btnCancelModalPopup_Click" /> 
                            </P> 
                            <p> 
                                <asp:Label ID="lblText" runat="server"></asp:Label><br /> 
                            </p> 
                        </ContentTemplate>       


                        <Triggers> 
                            <asp:AsyncPostBackTrigger ControlID="btnChooseProduct" EventName="Click" /> 
                        </Triggers> 


                    </asp:UpdatePanel> 
                 </asp:Panel> 


            </ContentTemplate> 
        </asp:UpdatePanel> 
    </div> 
    </form>
</body>
</html>
