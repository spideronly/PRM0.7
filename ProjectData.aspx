<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProjectData.aspx.cs" Inherits="ProjectData" Title="Untitled Page" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Src="DateControl.ascx" TagName="datecontrol" TagPrefix="cc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
  <style type="text/css">
        .modalBackground
        {
            background-color: #BED6E4;
            filter: alpha(opacity=70);
            opacity: 0.7;
        }
        .modalPopup
        {
            background-color: #ffffdd;
            border-width: 3px;
            border-style: solid;
            border-color: Gray;
            padding: 3px;
            width: 600px;
        }
        .collapsePanel
        {
            background-color: white;
            overflow: hidden;
        }
        .collapsePanelHeader
        {
            width: 100%;
            height: 10px;
            background-image: url(images/bg-menu-main.png);
            background-repeat: repeat-x;
            color: #FFF;
            font-family: Tahoma;
            font-size: small;
        }
        .style15
        {
            width: 100%;
        }
        .style16
        {
        }
        .style17
        {
            width: 593px;
        }
        .style18
        {
            width: 121px;
        }
        .style19
        {
            color: #CC0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div style="display: none">
        <asp:Button ID="btnFake1" runat="server" />
        <asp:Button ID="btnFake2" runat="server" />
    </div>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender" runat="server" TargetControlID="btnFake1"
        PopupControlID="Panel1" CancelControlID="CancelButton" DropShadow="true" BackgroundCssClass="modalBackground"
        PopupDragHandleControlID="Panel3" />
    <asp:Panel ID="Panel1" runat="server" Style="display: none" CssClass="modalPopup">
        <asp:Panel ID="Panel3" runat="server" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; color: Black">
            <div style="text-align: center">
                تنبيه
            </div>
        </asp:Panel>
        <br />
        <div style="text-align: center">
            <b>&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMessage" ForeColor="Black" runat="server" Font-Bold="True" Font-Names="Times New Roman"
                    Font-Size="14pt"></asp:Label>
            </b>
            <p style="text-align: center;">
                <input id="CancelButton" runat="server" type="button" style="width: 60px;" value="OK" />
            </p>
        </div>
        
    </asp:Panel>
    <div id="divPrm" runat="server" style="width: 100%; height: 500px" align="center" visible="false">
	 <br /><br /><br /><br /><br />
	 <asp:Label ID="lblCantSee" runat="server" Text="لا توجد لديك صلاحية لاظهار هذه الصفحة" Font-Bold="True" 
         ForeColor="White"></asp:Label>
         </div>
	 <div id="divAllData" runat="server">
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <ContentTemplate>
        
    <div style="text-align: center">
       
        <br />
        إسم المشروع
        <asp:TextBox ID="TxtProjectName" runat="server" Width="400px"></asp:TextBox>
    </div>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpe" runat="Server" TargetControlID="ContentPanel"
        ExpandControlID="TitlePanel" CollapseControlID="TitlePanel" Collapsed="True"
        TextLabelID="Label1" ExpandedText="(إخفاء)" CollapsedText="(إظهار)" ImageControlID="Image1"
        ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true">
    </ajaxToolkit:CollapsiblePanelExtender>
    <br />
    <asp:Panel ID="TitlePanel" runat="server">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" />
        المعلومات الرئيسيه للمشروع
        <br />
    </asp:Panel>
    <asp:Panel ID="ContentPanel" runat="server" CssClass="collapsePanel">
       <br />
       <br />
    </asp:Panel>
    <hr />
    </ContentTemplate>
        </asp:UpdatePanel>
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server"
        TargetControlID="ContentPanel2" ExpandControlID="Panel2" CollapseControlID="Panel2"
        Collapsed="True" TextLabelID="Label2" ExpandedText="(إخفاء)" CollapsedText="(إظهار)"
        ImageControlID="Image2" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="Panel2" runat="server">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/expand_blue.jpg" />
        ملخص حالة المشروع
    </asp:Panel>
    <asp:Panel ID="ContentPanel2" runat="server" CssClass="collapsePanel">
      <br />
      <br />
    </asp:Panel>
    <hr />
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="Server"
        TargetControlID="ContentPanel3" ExpandControlID="Panel4" CollapseControlID="Panel4"
        Collapsed="True" TextLabelID="Label3" ExpandedText="(إخفاء)" CollapsedText="(إظهار)"
        ImageControlID="Image3" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="Panel4" runat="server">
        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/expand_blue.jpg" />&nbsp;&nbsp;
        المعوقات الرئيسية للمشروع
    </asp:Panel>
    <asp:Panel ID="ContentPanel3" runat="server" CssClass="collapsePanel">
       <br />
       <br />
    </asp:Panel>
    <hr />
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="Server"
        TargetControlID="ContentPanel4" ExpandControlID="Panel6" CollapseControlID="Panel6"
        Collapsed="True" TextLabelID="Label4" ExpandedText="(إخفاء)" CollapsedText="(إظهار)"
        ImageControlID="Image4" ExpandedImage="~/images/collapse_blue.jpg" CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="Panel6" runat="server">
        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/expand_blue.jpg" />&nbsp;&nbsp;
        المهام الرئيسية
    </asp:Panel>
    <asp:Panel ID="ContentPanel4" runat="server" CssClass="collapsePanel">
      <br />
      <br />
    </asp:Panel>
    <hr />
    </div>
</asp:Content>

