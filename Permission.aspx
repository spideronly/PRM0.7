<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Permission.aspx.cs" Inherits="Permission" Title="نظام المشاريع" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
        .style12
        {
            width: 100%;
        }
        .style
        {
            text-align: right;
        }
    </style>
   

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="display: none">
        <asp:Button ID="btnFake1" runat="server" />
        <asp:Button ID="btnFake2" runat="server" />
    </div>
    <asp:Panel ID="Panel2" runat="server" Width="800px" Style="display: none" CssClass="modalPopup">
        <asp:Panel ID="Panel4" runat="server" Width="800px" Style="cursor: move; background-color: #DDDDDD;
            border: solid 1px Gray; padding: 2px; margin: 2px; width: 800px; color: Black">
            <div>
                الصلاحيات بحسب الادارات</div>
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnAddEdit" />
            <asp:PostBackTrigger ControlID="btnAdd" />
            <asp:PostBackTrigger ControlID="btnUpdate" />
            <asp:PostBackTrigger ControlID="btnDelete" />
            <asp:PostBackTrigger ControlID="GridView1" />
             <asp:PostBackTrigger ControlID="LinkButton1" />
             <asp:PostBackTrigger ControlID="BtnAddDepToUser" />
            
        </Triggers>
        
        <ContentTemplate>
        <div id="divPrm" runat="server" style="width: 100%; height: 500px" align="center" visible="false">
	 <br /><br /><br /><br /><br />
	 <asp:Label ID="lblCantSee" runat="server" Text="لا توجد لديك صلاحية لاظهار هذه الصفحة" Font-Bold="True" 
         ForeColor="White"></asp:Label>
         </div>
            <div id="divAllData" runat="server">
            <center>
                <div id="divAddUsers" runat="server" visible="True" style="border: 2px solid #333399;
                    font-family: tahoma; font-size: 8pt; font-weight: bold; width: 800px;">
                    <br />
                    اسم المستخدم
                    <asp:TextBox ID="txtLoginName" runat="server" />
                    كلمة المرور
                    <asp:TextBox ID="txtLoginPassword" runat="server" />
                    الاسم المعروض
                    <asp:TextBox ID="txtLoginDisplayName" runat="server" />
                    <br />
                    &nbsp;<br />
                    <asp:Button ID="btnAdd" runat="server" Text="اضافة" Width="66px" Font-Bold="True"
                        SkinID="BoldButton" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" runat="server" Text="تحديث" Width="66px" Font-Bold="True"
                        SkinID="BoldButton" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnDelete" runat="server" Text="حذف" Width="66px" Font-Bold="True"
                        SkinID="BoldButton" OnClick="btnDelete_Click" />
                    <br />
                    <br />
                    <asp:Label ID="lblMessage" runat="server" ForeColor="DarkRed" />
                    <br />
                    <asp:FileUpload ID="FileUploadPic" runat="server" />
                    <asp:Image ID="LoginImage" runat="server" Height="106px" Width="96px" />
                    <br />
                    <br />
                </div>
            </center>
            <br />
           
                <center>
                    المستخدم
                    <asp:DropDownList ID="DlLoginUsers" runat="server" SkinID="cmbTahoma" AutoPostBack="True"
                        OnSelectedIndexChanged="DlLoginUsers_SelectedIndexChanged" Width="269px" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <table style="border-color: #000000; font-family: tahoma; font-size: 10px; font-weight: bold;"
                        border="1" cellpadding="0" cellspacing="0">
                        <thead>
                            <tr>
                                <td style="border-style: solid; border-width: 1px; text-align: center; font-size: 10pt;
                                    font-family: tahoma; font-weight: bold; background-color: #CCCCCC;">
                                    الصفحة
                                </td>
                                <td style="border-style: solid; border-width: 1px; text-align: center; font-size: 10pt;
                                    font-family: tahoma; font-weight: bold; background-color: #CCCCCC;">
                                    الصلاحيات
                                </td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td class="style5" bgcolor="#CCCCCC" colspan="2">
                                    <div style="text-align: center">
                                        الصلاحيات على مستوى الإدارات
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    الإدارات والاقسام
                                </td>
                                <td class="style">
                                    <asp:DropDownList ID="DlDeparment" runat="server" AutoPostBack="True"
                                        SkinID="cmbTahoma" Width="269px" />
                                        <br />
                                        <asp:CheckBox ID="ChbHeriraclePerm" runat="server" 
                                        Text="إضافة صلاحيه على الإدارت التابعه" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    المشاريع
                                </td>
                                <td class="style">
                                    <asp:CheckBox ID="ChbProjectShow" runat="server" Text="مشاهدة" />
                                    <asp:CheckBox ID="ChbProjectAdd" runat="server" Text="اضافة" />
                                    <asp:CheckBox ID="ChbProjectUpdate" runat="server" Text="تعديل" />
                                    <asp:CheckBox ID="ChbProjectDelete" runat="server" Text="حذف" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    التقارير
                                </td>
                                <td class="style">
                                    <asp:CheckBox ID="ChbReportCreate" Text="إنشاء" runat="server" />
                                    <br />
                                    <asp:Button ID="BtnAddDepToUser" runat="server" onclick="BtnAddDepToUser_Click" 
                                        Text="حفظ" Width="43px" />
                                    <br />
                                    <asp:Label ID="lblMessage1" runat="server" ForeColor="DarkRed" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style5" bgcolor="#CCCCCC" colspan="2">
                                    <div style="text-align: center">
                                        صلاحية&nbsp; واجهة البرنامج</div>
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    صلاحيات المستخدمين
                                </td>
                                <td class="style">
                                    <asp:CheckBox ID="ChbPermShow" runat="server" Text="مشاهدة" />
                                    <asp:CheckBox ID="ChbPermUpdate" runat="server" Text="تحديث بيانات" />
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    البيانات الأساسية
                                </td>
                                <td class="style">
                                    <asp:CheckBox ID="ChbBasicShow" runat="server" Text="مشاهده" />
                                    <asp:CheckBox ID="ChbDepAdd" runat="server" Text="اضافه" Visible="False" />
                                    <asp:CheckBox ID="ChbDepEdit" runat="server" Text="تعديل" Visible="False" />
                                    <asp:CheckBox ID="ChbDepDel" runat="server" Text="حذف" Visible="False" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <br />
                    <br />
                    <asp:GridView ID="GridView1" runat="server" Width="818px" AutoGenerateColumns="False"
                        OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCommand="GridView1_RowCommand"
                        BorderStyle="Solid" onrowediting="GridView1_RowEditing">
                        <Columns>
                            <asp:TemplateField HeaderText=" الادرات التي له صلاحيه عليها">
                                
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkProName" runat="server" CausesValidation="false" CommandArgument='<%# Bind("PermissionID") %>'
                                        CommandName="myUpdate" ForeColor="Black" Text='<%# Bind("DepartmentName") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>

                             <%--
                            <asp:TemplateField>
                    <ItemTemplate>
                       <asp:Label ID="lblSample" runat="server" Text='<%#String.Format("{0}",Ctype(Container,GridViewRow).RowIndex + 1)%>' />
                    </ItemTemplate> 
                         </asp:TemplateField>--%>
                            <asp:TemplateField ShowHeader="False" ItemStyle-Width="50px">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" CommandArgument='<%# Bind("PermissionID") %>'
                                        CommandName="MyDelete" Text="حذف" ForeColor="Black" />
                                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="سوف يتم الحذف نهائيا ، هل تريد المتابعة"
                                        TargetControlID="lnkDelete" />
                                </ItemTemplate>
                                <ItemStyle Width="50px"></ItemStyle>
                            </asp:TemplateField>
                          

                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkUpdate" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Permission_DepartmentID") %>'
                                       CommandName="MySelect" Text="الأشخاص الذين لهم صلاحيه على هذه الإداره" ForeColor="Black" />
                                    
                                </ItemTemplate>
                               <ItemStyle Width="210px"></ItemStyle>
                            </asp:TemplateField>
                          
                        </Columns>
                        <EmptyDataTemplate>
                            <div class="style7">
                                <span class="style19">لا يوجد للمستخدم صلاحيات على اي إداره</span>
                            </div>
                        </EmptyDataTemplate>
                        <HeaderStyle BackColor="#CCCCCC" />
                    </asp:GridView>
                    <br />
                    <br />
                    <asp:Button ID="btnAddEdit" runat="server" Text="تحديث الصلاحيات" OnClick="btnAddEdit_Click"
                        Font-Bold="True" Font-Size="14" ForeColor="#006699" />
                    <br />
                     <br />
                      <br />
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">المستخدمين 
                    حسب الإدارات ... الرجارء إختيار إدارة</asp:LinkButton>
                    <br />
                    <br />
                </center>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
