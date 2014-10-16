<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Report.aspx.cs" Inherits="Report" Title="التقارير" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
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
        .style20
        {
            width: 192px;
        }
        .style21
        {
            width: 491px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   <div style="display: none">
        <asp:Button ID="btnFake1" runat="server" />
        <asp:Button ID="btnFake2" runat="server" />
    </div>
    <asp:Panel ID="Panel2" runat="server" Width="800px" Style="display: none" CssClass="modalPopup">
        <asp:Panel ID="Panel4" runat="server" Width="800px" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; padding: 2px; margin: 2px; width: 800px; color: Black">
            <div>
                شاشة البحث</div>
        </asp:Panel>
        <div>
            <div id="myFindFrame" runat="server" style="height: 450px; overflow: visible; width: 800px;">
            </div>
            <p style="text-align: center; width: 800px; height: 50px">
                <br />
                <input id="btnCancel" runat="server" type="button" style="width: 60px;" value="موافق" />
            </p>
        </div>
    </asp:Panel>
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnFake2"
        PopupControlID="Panel2" CancelControlID="btnCancel" DropShadow="true" BackgroundCssClass="modalBackground"
        PopupDragHandleControlID="Panel4" />
   <div id="divPrm" runat="server" style="width: 100%; height: 500px" align="center" visible="false">
	 <br /><br /><br /><br /><br />
	 <asp:Label ID="lblCantSee" runat="server" Text="لا توجد لديك صلاحية لاظهار هذه الصفحة" Font-Bold="True" 
         ForeColor="White"></asp:Label>
         </div>
          <div id="divAllData" runat="server">
    <div style="border: thin solid #000000; width: 99%; height: 100%;">
   
            <table style="font-family: tahoma; font-size: 10px; font-weight: bold; width: 889px;" 
                bgcolor="White" __designer:mapid="2e">
                <tr __designer:mapid="2f">
                    <td class="style20" __designer:mapid="30">
                        الأقسام والإدارات
                    </td>
                    <td style="text-align: center" __designer:mapid="31" class="style21">
                       
                        <asp:Label ID="LblProjectName" runat="server"></asp:Label>
&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
                            Visible="False">مسح</asp:LinkButton>
                       
                    </td>
                                        <td>
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">إبحث في المشاريع</asp:LinkButton>
                                        </td>
                </tr>
                <tr __designer:mapid="32">
                    <td style="vertical-align: top; text-align: right;" class="style20" 
                        __designer:mapid="33">
                        <asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows" NodeIndent="15"
                            Font-Size="12pt" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged" 
                            Width="89px">
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                                VerticalPadding="0px" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                                NodeSpacing="0px" VerticalPadding="2px" />
                        </asp:TreeView>
                    </td>
                    <td style="vertical-align: middle" __designer:mapid="39" valign="top" 
                        class="style21">
                          
                                    من
                           <cc:datecontrol ID="txtStartDate" runat="server" />
                           <br />
                            إلى
                            <cc:datecontrol ID="txtEndDate" runat="server" />
                           </td>
                </tr>
                <tr __designer:mapid="4f">
                    <td class="style20" style="vertical-align: top; text-align: right;" 
                        __designer:mapid="50">
                        &nbsp;</td>
                    <td style="vertical-align: middle; text-align: right;" __designer:mapid="51" 
                        class="style21">
                       <center style="text-align: right">
                           <asp:DropDownList ID="DlExportType" runat="server" Width="174px">
                               <asp:ListItem Value="0">----تصدير إلى----</asp:ListItem>
                               <asp:ListItem Value="1">Word2007</asp:ListItem>
                               <asp:ListItem Value="2">PDF</asp:ListItem>
                           </asp:DropDownList>
                        <asp:Button ID="BtnShow" runat="server" 
                            Text="تصــدير" Width="73px" onclick="BtnShow_Click" />
                            <br />
                            </center>
                            <br />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
                       
   
   </div>
   </div>
</asp:Content>

