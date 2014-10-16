<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsersByDeps.aspx.cs" Inherits="UsersByDeps" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div dir="rtl" style="font-family: tahoma; font-size: 10px; font-weight: bold">
    
                    <center>
                        <div>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                        المستخدمين حسب الإدارات ... الرجارء إختيار إدارة
                        <br />
                            <asp:DropDownList ID="DlDep" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="DlDep_SelectedIndexChanged" SkinID="cmbTahoma" 
                                Width="269px" />
                            <br />
                            <br />
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderStyle="Solid"
                                OnPageIndexChanging="GridView2_PageIndexChanging" OnRowCommand="GridView2_RowCommand"
                                Width="618px">
                                <Columns>
                                    <asp:TemplateField HeaderText="المستخدمين الذين لهم الصلاحية على هذه الإداره">
                                        
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsername" runat="server" 
                                                Text='<%# Bind("UserDisplayName") %>'> </asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="50px" ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkDelete0" runat="server" CausesValidation="false" CommandArgument='<%# Bind("PermissionID") %>'
                                                CommandName="MyDelete" ForeColor="Black" Text="حذف" />
                                            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender2" runat="server" ConfirmText="سوف يتم الحذف نهائيا ، هل تريد المتابعة"
                                                TargetControlID="lnkDelete0" />
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
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
                        <asp:Panel ID="Panel1" runat="server" Visible="False">
                        
                        <br />
                        <asp:Label ID="lblMessage1" runat="server" ForeColor="DarkRed" />
                        <br />
                        <br />
                        <div>
                            إضافة مستخدمين للأداره
                            <asp:DropDownList ID="DlLoginUsers0" runat="server" AutoPostBack="True" SkinID="cmbTahoma"
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
                            <asp:CheckBox ID="ChbReportCreate" runat="server" Text="إنشاء" />
                        </div>
                        <br />
                        <asp:Button ID="BtnAddUserToDep" runat="server" OnClick="BtnAddUserToDep_Click" 
                                Text="اضافه" />
                        <br />
                        </asp:Panel>
                    </center>
    
    </div>
    </form>
</body>
</html>
