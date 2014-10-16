<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DeparmentUsers.aspx.cs" Inherits="DeparmentUsers" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div dir="rtl" style="font-family: Tahoma; font-size: 10px; font-weight: bold;">
           <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
        <center style="font-family: tahoma; font-size: 10px; font-weight: bold">
            <div>
            <asp:GridView ID="GridView1" runat="server" Width="618px" 
                        AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" 
                            OnRowCommand="GridView1_RowCommand" BorderStyle="Solid" 
                            >
                            <Columns>
                                <asp:TemplateField>
                                <HeaderTemplate>
                                
                                <asp:Label ID="lblDepName" runat= "server" Text='<%# Bind("DepartmentName") %>'>
                                            </asp:Label>
                                </HeaderTemplate>
                                    <ItemTemplate>
                                            <asp:Label ID="lblUsername" runat= "server" Text='<%# Bind("UserDisplayName") %>'>
                                            </asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" CommandArgument='<%# Bind("Permission_UserID") %>'
                                            CommandName="MyDelete" Text="حذف" ForeColor="Black" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="سوف يتم الحذف نهائيا ، هل تريد المتابعة"
                                            TargetControlID="lnkDelete" />
                                    </ItemTemplate>
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:TemplateField>
                             
                            </Columns>
                            <EmptyDataTemplate>
                                <div class="style7">
                                    <span class="style19">لا يوجد للمستخدم صلاحيات على اي إداره</span>
                                </div>
                            </EmptyDataTemplate>
                            <HeaderStyle BackColor="#CCCCCC" />
                        </asp:GridView>
                
             
            </div>
            <br />
            
            
                <asp:Label ID="lblMessage" runat="server" ForeColor="DarkRed" />
                <br />
            <br />
            <div>
                إضافة مستخدمين للأداره
                <asp:DropDownList ID="DlLoginUsers" runat="server" SkinID="cmbTahoma" AutoPostBack="True"
                     Width="269px" />
            </div>
            <br />
            <div>
                المشاريع :
                <asp:CheckBox ID="ChbProjectShow" runat="server" Text="مشاهدة" />
                <asp:CheckBox ID="ChbProjectAdd" runat="server" Text="اضافة" />
                <asp:CheckBox ID="ChbProjectUpdate" runat="server" Text="تعديل" />
                <asp:CheckBox ID="ChbProjectDelete" runat="server" Text="حذف" />
            </div>
            <br />
            <div>
                التقارير :
                <asp:CheckBox ID="ChbReportCreate" Text="إنشاء" runat="server" />
            </div>
            
            <br />
            <asp:Button ID="BtnAddUserToDep" runat="server" Text="اضافه" 
                       onclick="BtnAddUserToDep_Click" />
            <br />
        </center>
        
    </div>
    </form>
</body>
</html>
