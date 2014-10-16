
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="Default2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager><div id="divAllData" runat="server" style="font-family: tahoma; font-size: 10px; font-weight: bold; background-color: #F5F5F5;">
      
    
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server"
        TargetControlID="ContentPanel2"
         ExpandControlID="Panel2" 
         CollapseControlID="Panel2"
        Collapsed="True"
          ExpandedText="(إخفاء)"
           CollapsedText="(إظهار)"
        ImageControlID="Image2" 
        ExpandedImage="~/images/collapse_blue.jpg"
         CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="Panel2" runat="server"  CssClass="collapsePanelHeader" Height="30px">
        <div style="padding:5px; cursor: pointer; vertical-align: middle;">
        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/expand_blue.jpg" />
        ملخص حالة المشروع
        </div>
    </asp:Panel>
    <asp:Panel ID="ContentPanel2" runat="server" CssClass="collapsePanel">
        <br />
         <br />
          <br />
           <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender2" runat="Server"
        TargetControlID="ContentPanel3"
         ExpandControlID="Panel4" 
         CollapseControlID="Panel4"
        Collapsed="True"
          ExpandedText="(إخفاء)"
           CollapsedText="(إظهار)"
        ImageControlID="Image3" 
        ExpandedImage="~/images/collapse_blue.jpg"
         CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="Panel4" runat="server" CssClass="collapsePanelHeader" Height="30px">
         <div style="padding:5px; cursor: pointer; vertical-align: middle;">
        <asp:Image ID="Image3" runat="server" ImageUrl="~/images/expand_blue.jpg" />&nbsp;&nbsp;
        
      المعوقات الرئيسية للمشروع
    </div>
    </asp:Panel>
    <asp:Panel ID="ContentPanel3" runat="server" CssClass="collapsePanel">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
       
                        <ContentTemplate>
     
          </ContentTemplate>
                    </asp:UpdatePanel>
    </asp:Panel>
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender3" runat="Server"
        TargetControlID="ContentPanel4"
         ExpandControlID="Panel6" 
         CollapseControlID="Panel6"
        Collapsed="True" 
         ExpandedText="(إخفاء)"
          CollapsedText="(إظهار)"
        ImageControlID="Image4" 
        ExpandedImage="~/images/collapse_blue.jpg"
         CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true">
    </ajaxToolkit:CollapsiblePanelExtender>
    <asp:Panel ID="Panel6" runat="server" CssClass=" collapsePanelHeader" Height="30px" >
         <div style="padding:5px; cursor: pointer; vertical-align: middle;">
        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/expand_blue.jpg" />&nbsp;&nbsp;
        المهام الرئيسية
    </div>
    </asp:Panel>
    <asp:Panel ID="ContentPanel4" runat="server" CssClass="collapsePanel">
       
    </asp:Panel>
    <center style="border: thin solid #000000; height: 46px;">
        <asp:ImageButton ID="ImgBtnSave" runat="server" ImageUrl="~/icon/2.png" 
            OnClick="ImgBtnSave_Click" />
   </center>
    </div>
    </form>
</body>
</html>
