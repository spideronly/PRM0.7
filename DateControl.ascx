<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DateControl.ascx.cs" Inherits="DateControl" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register assembly="MultiCultureCalendar" namespace="Common.Control" tagprefix="cc1" %>
<style type="text/css">
.popupControl
{
	background-color:White;
	position:absolute;
	visibility:hidden;
}
    </style>
<body style="font-weight: 700; font-size: medium">

<asp:UpdatePanel ID="UpdatePanel3" runat="server" RenderMode="Inline" UpdateMode="Always">
    <ContentTemplate>
  هجـري
        <asp:TextBox ID="txtDateHijri" runat="server" />
        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" 
            TargetControlID="txtDateHijri" Mask="99/99/9999" AutoComplete="False" 
            ClearMaskOnLostFocus="False" ClearTextOnInvalid="True" PromptCharacter=" " 
            InputDirection="RightToLeft" />
        
        
        <asp:Panel ID = "Panel1" runat="server" CssClass="popupControl">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            <center>
                <cc1:MultiCultureCalendar ID="MultiCultureCalendar3" runat="server" 
                BackColor="White" BorderColor="#999999" CellPadding="1" ForeColor="Black"
                Culture="ar-SA" DayNameFormat="Shortest"  
                FirstDayOfWeek="Saturday" Height="128px" 
                onselectionchanged="MultiCultureCalendar3_SelectionChanged" 
                Width="171px">
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <SelectorStyle BackColor="#CCCCCC" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True"/>
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                </cc1:MultiCultureCalendar>
       </center>
       </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <ajaxToolkit:PopupControlExtender ID="PopDateHijri" runat="server"
         TargetControlID="txtDateHijri"
         PopupControlID="Panel1" 
         Position="Bottom" />
        
        
  ميلادي
        <asp:TextBox ID="txtDate" runat="server" />
        <ajaxToolkit:CalendarExtender ID="txtDate_CalendarExtender" runat="server" 
            Enabled="True" FirstDayOfWeek="Saturday" Format="dd/MM/yyyy" 
            PopupPosition="BottomRight" TargetControlID="txtDate">
        </ajaxToolkit:CalendarExtender>
        <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender2" runat="server" 
            TargetControlID="txtDate" Mask="99/99/9999" AutoComplete="False" 
            ClearMaskOnLostFocus="False" ClearTextOnInvalid="True" PromptCharacter=" " 
            InputDirection="RightToLeft" />
        
        <%--<ajaxToolkit:PopupControlExtender ID="PopDate" runat="server" TargetControlID="txtDate" PopupControlID="myPlanel1" Position="Bottom"/>
        <asp:Panel ID = "myPlanel1" runat="server" CssClass="myDatePanle">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" RenderMode="Inline">
              <ContentTemplate>
                <cc1:MultiCultureCalendar ID="MultiCultureCalendar1"  runat="server"
                BackColor="White" BorderColor="#999999" CellPadding="1" ForeColor="Black" 
                FirstDayOfWeek="Saturday" Height="170px" 
                onselectionchanged="MultiCultureCalendar1_SelectionChanged" 
                Width="211px" Culture="ar-EG" 
                DayNameFormat="Shortest">
                <SelectedDayStyle BackColor="#666666" Font-Bold="True" ForeColor="White" />
                <TodayDayStyle BackColor="#CCCCCC" ForeColor="Black" />
                <SelectorStyle BackColor="#CCCCCC" />
                <OtherMonthDayStyle ForeColor="#808080" />
                <NextPrevStyle VerticalAlign="Bottom" />
                <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True"/>
                <TitleStyle BackColor="#999999" BorderColor="Black" Font-Bold="True" />
                </cc1:MultiCultureCalendar>
            </ContentTemplate>
          </asp:UpdatePanel>
        </asp:Panel>--%>
        
        <input type="button" id="button1" value="مسح" style="font-family:Tahoma"  onclick="<%= txtDateHijri.ClientID %>.value='';<%= txtDate.ClientID %>.value='';"/>
</ContentTemplate>
</asp:UpdatePanel>