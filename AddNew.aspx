<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddNew.aspx.cs" Inherits="AddNew" Title="إضافة جديد" %>
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
        .collapsePanelHeader{
	width:100%;
	height:30px;
	background-image: url(images/bg-menu-main.png);
	background-repeat:repeat-x;
	color:#FFF;
	font-weight:bold;
}
.collapsePanel {
	
	background-color:white;
	overflow:hidden;
}
        .style13
     {
         color: #FF3300;
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
            <b>
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
	 <div id="divAllData" runat="server" style="font-family: tahoma; font-size: 10px; font-weight: bold; background-color: #F5F5F5;">
      
    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
        <Triggers>
        <asp:PostBackTrigger ControlID="ImgBtnSave" />
        </Triggers>
        <ContentTemplate>
        
    <div style="border: thin solid #000000; text-align: center">
   <center>
       أدخل تاريخ التقرير : من <span class="style13">*</span>
    <cc:datecontrol ID="txtFromDateReport" runat="server" />
    <br />
       &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; إلى
      <span class="style13">*</span>
      <cc:datecontrol ID="txtToDateReport" runat="server" />
   </center>
        <br />
       <div>
        <asp:RadioButton ID="RbProject" runat="server" Text="مشروع" GroupName="my" AutoPostBack="True"
            OnCheckedChanged="RbProject_CheckedChanged" Checked="True" />
        <asp:RadioButton ID="RbMubadrah" runat="server" Text="مبادره" GroupName="my" AutoPostBack="True"
            OnCheckedChanged="RbMubadrah_CheckedChanged" />
        <asp:RadioButton ID="RbTask" runat="server" Text="مهمَة" GroupName="my" AutoPostBack="True"
            OnCheckedChanged="RbTask_CheckedChanged" />
            </div>
        <br />
       <table>
       <tr>
       <td>
       <div id="DivProjectName" runat="server">
        إسم المشروع
       <span class="style13">*</span>
        </div>
        <div id="DivMubadaraName" runat="server">
         
         إسم المبادره
       <span class="style13">*</span>
        </div>
        <div id="DivTaskName" runat="server">
         إسم المهمه
         <span class="style13">*</span>
        </div>
       </td>
       <td>
        <asp:TextBox ID="TxtProjectName" runat="server" Width="400px"></asp:TextBox>
       </td>
       </tr>
       </table>
        
         
       
        <br />
        <br />
    </div>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpe" runat="Server" 
    TargetControlID="ContentPanel"
        ExpandControlID="TitlePanel"
         CollapseControlID="TitlePanel" 
         
         Collapsed="True"
         ExpandedText="(إخفاء)" 
         CollapsedText="(إظهار)" 
         ImageControlID="Image1"
        ExpandedImage="~/images/collapse_blue.jpg" 
        CollapsedImage="~/images/expand_blue.jpg"
        SuppressPostBack="true">
    </ajaxToolkit:CollapsiblePanelExtender>
    
    <asp:Panel ID="TitlePanel" runat="server" CssClass="collapsePanelHeader" Height="30px">
          <div style="padding:5px; cursor: pointer; vertical-align: middle;">
               
                     <asp:Image ID="Image1" runat="server" ImageUrl="~/images/expand_blue.jpg" />
             المعلومات الرئيسيه للمشروع
            </div>
       
        
        <br />
    </asp:Panel>
    <asp:Panel ID="ContentPanel" runat="server" CssClass="collapsePanel">
        <table border="0" style="width: 897px; font-family: tahoma; font-size: 10px; font-weight: bold;">
            <tr>
                <td bgcolor="WhiteSmoke">
                    راعي المشروع
                </td>
                <td>
                    <asp:TextBox ID="TxtProjectSponser" runat="server" 
                        Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                    البرنامج
                </td>
                <td>
                    <asp:TextBox ID="TxtProgram" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                    الإدارة المعنيه
                <span class="style13">*</span></td>
                <td>
                    <asp:DropDownList ID="DlDep" runat="server" Width="400px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                    مدير المشروع
                </td>
                <td>
                    <asp:TextBox ID="TxtManager" runat="server" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                 <div id="DivConDateS" runat="server">
                    تاريخ البدء التعاقدي
               <span class="style13">*</span>
                </div>
                <div id="DivNoConDateS" runat="server">
                    تاريخ البدء 
               <span class="style13">*</span>
                </div>
                </td>
                <td>
                    <cc:datecontrol ID="txtStartDate" runat="server" />
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                <div id="DivConDateE" runat="server">
                     تاريخ الإنتهاء التعاقدي
                <span class="style13">*</span>
                </div>
                <div id="DivNoConDateE" runat="server">
                      تاريخ الإنتهاء 
                <span class="style13">*</span>
                </div>
                  
                </td>
                <td>
                    <cc:datecontrol ID="txtEndDate" runat="server" />
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                    تاريخ البدء الفعلي
                </td>
                <td>
                    <cc:datecontrol ID="txtActualStartDate" runat="server" />
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                    تاريخ الانتهاء المتوقع
                </td>
                <td>
                    <cc:datecontrol ID="txtActualEndDate" runat="server" />
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                <div id="DivContractor" runat="server">
                    اسم المقاول
                </div>
                </td>
                <td>
                <div id="DivContractorName" runat="server">
                    <asp:TextBox ID="TxtContractor" runat="server" Width="400px"></asp:TextBox>
               </div>
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                    <div id="DivBudjectName" runat="server">
                        ميزانية المشروع
                    </div>
                </td>
                <td>
                    <div id="DivBudject" runat="server">
                    
                        <asp:TextBox ID="TxtBudjet" runat="server" Width="100px"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                TargetControlID="TxtBudjet" FilterType="Numbers"  />
                               
                        &nbsp;ريال سعودي
                    </div>
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                    <div id="DivPaiedValueName" runat="server">
                        القيمة المدفوعة حتى تاريخه
                    </div>
                </td>
                <td>
                    <div id="DivPaiedValue" runat="server">
                        <asp:TextBox ID="TxtPaidValue" runat="server" Width="100px"></asp:TextBox>
                           <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                TargetControlID="TxtPaidValue" FilterType="Numbers" />
                        &nbsp;ريال سعودي
                    </div>
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                    نوع نسبة الإنجاز
                </td>
                <td>
                    <asp:DropDownList ID="DlProgressType" runat="server" Width="150px" 
                        AutoPostBack="True" 
                        onselectedindexchanged="DlProgressType_SelectedIndexChanged1">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                    نسبة الإنجاز
                </td>
                <td>
                    <asp:TextBox ID="TxtProgress" runat="server" ReadOnly="True" Width="50px"></asp:TextBox>
                    &nbsp;%
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                    الاهداف الرئيسيه للمشروع
                </td>
                <td>
                    <asp:GridView ID="GridViewGoal" runat="server" AllowPaging="True" 
                    
                        AutoGenerateColumns="False" 
                      
                        OnPageIndexChanging="GridViewGoal_PageIndexChanging"
                        OnRowCommand="GridViewGoal_RowCommand1" 
                        PageSize="10"
                        
                        SelectedRowStyle-BackColor="Blue" 
                        ShowFooter="True"
                        Style="text-align: right;" 
                        Width="100%" 
                        OnRowDataBound="GridViewGoal_RowDataBound">
                         <FooterStyle BackColor="GrayText" />
                                <RowStyle BackColor="WhiteSmoke" />
                        <Columns>
                            <asp:TemplateField >
                               <HeaderTemplate>
                               <asp:Label ID="lblGoalTitle" runat="server" ForeColor="Black" Text="الأهـــداف الرئيسيه للمشروع :"></asp:Label>
                               </HeaderTemplate>
                                <ItemTemplate>
                                 <asp:HiddenField ID="HGoalID" runat="server" Value='<% # Bind ("GoalID") %>' />
                                    <asp:Literal ID="L2" runat="server" Text='<%# Bind("GoalName") %>' />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:TextBox ID="txtGoalName" runat="server" Width="700px"></asp:TextBox>
                                </FooterTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDeleteGoal" runat="server" CausesValidation="false" CommandArgument='<%# Bind("GoalID") %>'
                                        CommandName="MyDelete" Text="حذف" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="سوف يتم الحذف نهائيا ، هل تريد المتابعة"
                                        TargetControlID="lnkDeleteGoal" />
                                </ItemTemplate>
                                <FooterTemplate>
                                    <asp:LinkButton ID="lnkAddGoal" runat="server" CausesValidation="false" CommandName="MyAdd"
                                        ForeColor="White" Text="اضافة" />
                                </FooterTemplate>
                            </asp:TemplateField>
                        </Columns>
                           <PagerStyle BackColor="#FFFFE6" />
                         
                                <HeaderStyle BackColor="DarkGray" />
                                <AlternatingRowStyle BackColor="#87B6E9" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </ContentTemplate>
        </asp:UpdatePanel>
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
        <table class="style1" style="width: 904px; font-family: tahoma; font-size: 10px; font-weight: bold;">
            <tr>
                <td>
                    تاريخ التعديل
                </td>
                <td>
                    <cc:datecontrol ID="txtUpdateDate" runat="server" />
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="GridViewAbbrivate" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                Width="100%" PageSize="10" OnPageIndexChanging="GridViewAbbrivate_PageIndexChanging"
                                OnRowCommand="GridViewAbbrivate_RowCommand1" ShowFooter="True" 
                               
                                Style="text-align: right; 
                                font-weight: 700;" HeaderStyle-BackColor="#BCCAA4"
                                OnRowDataBound="GridViewAbbrivate_RowDataBound">
                               <FooterStyle BackColor="GrayText" />
                                <RowStyle BackColor="WhiteSmoke" />
                                <Columns>
                                    <asp:TemplateField >
                                        <HeaderTemplate>
                                         <asp:Label ID="lblAbbTitle" runat="server" ForeColor="Black" Text=" ملخص حالة المشروع/ إقتراحات توصيات لزيادة الفعاليه في المشروع :"></asp:Label>
                              
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:Literal ID="L21" runat="server" Text='<%# Bind("AbbreviateName") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtAbbrName" runat="server" Width="800px"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                 
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkAbbDelete" runat="server" CausesValidation="false" CommandName="MyDelete"
                                                Text="حذف" CommandArgument='<%# Bind("AbbreviateID") %>' />
                                            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkAbbDelete"
                                                ConfirmText="سوف يتم الحذف نهائيا ، هل تريد المتابعة" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="lnkAdd" runat="server" ForeColor="White" CausesValidation="false"
                                                CommandName="MyAdd" Text="اضافة" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                              <PagerStyle BackColor="#FFFFE6" />
                             
                                <HeaderStyle BackColor="DarkGray" />
                                <AlternatingRowStyle BackColor="#87B6E9" />
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
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
        <table class="style1" style="width: 898px ;font-family: tahoma; font-size: 10px; font-weight: bold;">
            <tr>
                <td bgcolor="WhiteSmoke">
                    
                    تاريخ ظهور المعوق
                </td>
                <td>
                    
                    <cc:datecontrol ID="txtConsDate" runat="server" />
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                التاريخ المخطط له
                    </td>
                <td>
                    <cc:datecontrol ID="txtConsPlanDate" runat="server" />
                    <asp:Button ID="BtnAddConsDate" runat="server" OnClick="BtnAddConsDate_Click" 
                        Text="..." Width="16px" />
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                    &nbsp;</td>
                <td>
                    <asp:TextBox ID="txtConsDateAlter" runat="server" Width="328px" Wrap="False" 
                        Visible="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="WhiteSmoke">
                    <asp:CheckBox ID="ChbIsNeddMayor" runat="server" AutoPostBack="True" 
                        oncheckedchanged="ChbIsNeddMayor_CheckedChanged" Text="هل تدخل الأمين مطلوب؟" />
                </td>
                <td bgcolor="WhiteSmoke">
                <div id="DivmayorNeed" runat="server" visible="False">
                   المطلوب من معالي الأمين : 
                    <asp:TextBox ID="txtConsRequriedFromMayor" runat="server" Visible="true" 
                        Width="328px" Wrap="False"></asp:TextBox>
                </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                   
                            <asp:GridView ID="GridViewConstraint" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                Width="100%" PageSize="10" OnPageIndexChanging="GridViewConstraint_PageIndexChanging"
                                OnRowCommand="GridViewConstraint_RowCommand1" ShowFooter="True" 
                               
                              
                          
                           RowStyle-BackColor="#FFFFE6"
                                Style="text-align: right;
                                 font-weight: 700;" 
                                 
                                OnRowDataBound="GridViewConstraint_RowDataBound">
                                <FooterStyle BackColor="GrayText" />
                                <RowStyle BackColor="WhiteSmoke" />
                                <Columns>
                                    <asp:TemplateField HeaderText=" الوصف :" FooterStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Literal ID="L1" runat="server" Text='<%# Bind("ConstraintName") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtConsName" runat="server" Width="200px"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" المطلوب :" FooterStyle-Width="200px">
                                        <ItemTemplate>
                                            <asp:Literal ID="L2" runat="server" Text='<%# Bind("ConstraintRequiredSolution") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtConsReq" runat="server" Width="200px"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" الشخص المسؤول :" FooterStyle-Width="150px">
                                        <ItemTemplate>
                                            <asp:Literal ID="L3" runat="server" Text='<%# Bind("ConstraintResponsibleName") %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="txtConsResponsible" runat="server" Width="150px"></asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" تم حل المعوق:">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChIsSolvedShow" runat="server" Checked='<%# Convert.ToBoolean (Eval("ConstraintIsSolved")) %>' />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:CheckBox ID="ChIsSolved" runat="server" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" تاريخ المعوق :" HeaderStyle-Width="120px" >
                                        <ItemTemplate>
                                            <asp:Literal ID="L127" runat="server" Text='<%# Bind("ConstraintDateHijriString") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText=" التاريخ المخطط لإنجازه:" HeaderStyle-Width="120px" >
                                        <ItemTemplate>
                                            <asp:Literal ID="L128" runat="server" Text='<%# Bind("ConstraintPlanDateHijriString") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText=" تدخل الأمين:">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChIsNeedMayor" runat="server" Checked='<%# Convert.ToBoolean (Eval("ConstraintIsNeedMayor")) %>' />
                                        </ItemTemplate>
                                       
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDeleteCons" runat="server" CausesValidation="false" CommandName="MyDelete"
                                                Text="حذف" CommandArgument='<%# Bind("ConstraintID") %>' />
                                            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="lnkDeleteCons"
                                                ConfirmText="سوف يتم الحذف نهائيا ، هل تريد المتابعة" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:LinkButton ID="lnkAdd" runat="server" ForeColor="DarkBlue" CausesValidation="false"
                                                CommandName="MyAdd" Text="اضافة" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <PagerStyle BackColor="#FFFFE6" />
                              
                                <HeaderStyle BackColor="DarkGray" />
                                <AlternatingRowStyle BackColor="#87B6E9" />
                            </asp:GridView>
                      
                </td>
            </tr>
        </table>
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
        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            
            <ContentTemplate>
                <table style="font-family: Tahoma; font-size: 10px; font-weight: bold">
                    <tr>
                        <td class="style16" colspan="2">
                           
                            
                            <div>
                            <center>
                                <img alt="" src="images/green.jpg" style="width: 17px; height: 14px" />مهام 
                                منجزه &nbsp;&nbsp;
                                <img alt="" src="images/Red.jpg" style="width: 17px; height: 14px" />مهام غير 
                                منجزه &nbsp;&nbsp;<img alt="" src="images/Blue.jpg" style="width: 18px; height: 14px" /> 
                                مهام مخطط لها
                       </center>
                        </div>
                        
                        </td>
                    </tr>
                    <tr>
                        <td class="style18">
                            &nbsp;
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
            
            <ContentTemplate>
                         <div>
                         
                         <h1></h1>
                         عرض 
                            (
                            <asp:RadioButton ID="RbAllTask" runat="server" GroupName="ee" Text="الكل" AutoPostBack="True"
                                Checked="True" />
                       
                            <asp:RadioButton ID="RbTaskAchived" runat="server" GroupName="ee" Text="منجزه" AutoPostBack="True" />
                          
                            <asp:RadioButton ID="RbTaskNotAchived" runat="server" GroupName="ee" Text="غير منجزه"
                                AutoPostBack="True" />
                            
                            <asp:RadioButton ID="RbTaskPlan" runat="server" GroupName="ee" Text="مخطط لها"
                                AutoPostBack="True" />
                                )
                                </div>
                            <asp:GridView ID="GridViewTask" runat="server" AutoGenerateColumns="false" ShowFooter="True"
                                Width="889px" OnPageIndexChanging="GridViewTask_PageIndexChanging1" OnRowCommand="GridViewTask_RowCommand"
                                OnRowDataBound="GridViewTask_RowDataBound" AllowPaging="True">
                                <Columns>
                                    <asp:TemplateField HeaderText=" الوصف :">
                                        <ItemTemplate>
                                            <asp:Literal ID="L10" runat="server" Text='<%# Bind("TaskName") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" السبب :">
                                        <ItemTemplate>
                                            <asp:Literal ID="L11" runat="server" Text='<%# Bind("TaskDelayReson") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText=" حالة المهمة :" ItemStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Literal ID="L126" runat="server" Text='<%# Bind("TaskStatus") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False" ItemStyle-Width="50px">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDeleteTask" runat="server" CausesValidation="false" CommandArgument='<%# Bind("TaskID") %>'
                                                CommandName="MyDelete" Text="حذف" />
                                            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="سوف يتم الحذف نهائيا ، هل تريد المتابعة"
                                                TargetControlID="lnkDeleteTask" />
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                </Columns>
                                 <HeaderStyle BackColor="DarkGray" />
                                <EmptyDataTemplate>
                                    <span class="style19">لا يوجد مهام</span>
                                </EmptyDataTemplate>
                            </asp:GridView>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            
                        </td>
                    </tr>
                </table>
                <asp:Panel ID="PanelData" runat="server">
                    <table style="font-family: tahoma; font-size: 10px; font-weight: bold">
                        <tr>
                            <td class="style18" bgcolor="WhiteSmoke">
                                اسم المهمه
                            <span class="style13">*</span></td>
                            <td class="style17">
                                <asp:TextBox ID="txtTaskName" runat="server" Width="214px"></asp:TextBox>
                                <asp:CheckBox ID="ChbISAchived" runat="server" Text="المهمه منجزه" />
                            </td>
                        </tr>
                        <tr>
                            <td class="style18" bgcolor="WhiteSmoke">
                                التاريخ المخطط له
                            <span class="style13">*</span></td>
                            <td class="style17">
                                <cc:datecontrol ID="txtTaskPlanDate" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="WhiteSmoke" >
                                تاريخ المهمه الفعلي
                                 <span class="style13">*</span>
                            </td>
                            <td>
                                <cc:datecontrol ID="txtTaskDate" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="WhiteSmoke">
                               <div id="divTaskReson" runat="server">
                                
                                
                            السبب
                            </div>
                            </td>
                            <td>
                            <div id="divTaskResonText" runat="server">
                                <asp:TextBox ID="txtTaskReson" runat="server" Width="214px"></asp:TextBox>
                           </div>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="WhiteSmoke">
                                صاحب المهمه&nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:DropDownList ID="DLTaskUser" runat="server" Style="margin-bottom: 0px" Width="215px">
                                </asp:DropDownList>
                                <asp:Button ID="BtnAddUser" runat="server" OnClick="BtnAddUser_Click" Text="..."
                                    Width="16px" />
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="WhiteSmoke">
                            </td>
                            <td >
                                <asp:TextBox ID="txtTaskUser" runat="server" Width="214px" Visible="false"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td bgcolor="WhiteSmoke" >
                                &nbsp;
                            </td>
                            <td >
                                <asp:ImageButton ID="BtnAddTask" runat="server" ImageUrl="icon/13.png" ValidationGroup="ss"
                                    OnClick="BtnAddTask_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <center style="border: thin solid #000000; height: 46px;">
        <asp:ImageButton ID="ImgBtnSave" runat="server" ImageUrl="~/icon/2.png" 
            OnClick="ImgBtnSave_Click" />
   </center>
    </div>

</asp:Content>

