<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Search.aspx.cs" Inherits="Search" %>

<%@ Register namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">

        .style15
        {
            width: 100%;
            font-weight: 700;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div dir="rtl">
    
        <table class="style15">
            <tr>
                <td bgcolor="#DCDCCB" class="style16">
                    راعي المشروع :</td>
                <td bgcolor="#BCCAA4">
                    <asp:TextBox ID="TxtProjectSponser" runat="server" 
                        style="font-weight: 700; font-size: medium" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#DCDCCB" class="style16">
                    إسم المشروع :
                </td>
                <td bgcolor="#BCCAA4">
                    <asp:TextBox ID="TxtProjectName" runat="server" 
                        style="font-weight: 700; font-size: medium" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#BCCAA4" class="style16">
                    الإداره المعنيه :
                </td>
                <td bgcolor="#DCDCCB">
                    <asp:DropDownList ID="DlDep" runat="server" Font-Bold="True" Font-Size="Medium" 
                        Width="400px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td bgcolor="#DCDCCB" class="style16">
                    مدير المشروع :
                </td>
                <td bgcolor="#BCCAA4">
                    <asp:TextBox ID="TxtManager" runat="server" 
                        style="font-weight: 700; font-size: medium" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#DCDCCB" class="style16">
                    البرنامج :</td>
                <td bgcolor="#BCCAA4">
                    <asp:TextBox ID="TxtProgram" runat="server" 
                        style="font-weight: 700; font-size: medium" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#BCCAA4" class="style16">
                    إسم المقاول :
                </td>
                <td bgcolor="#DCDCCB">
                    <asp:TextBox ID="TxtContractor" runat="server" 
                        style="font-weight: 700; font-size: medium" Width="400px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td bgcolor="#DCDCCB" class="style16">
                    <div id="DivBudjectName" runat="server">
                        ميزانية المشروع:
                    </div>
                </td>
                <td bgcolor="#BCCAA4">
                    <div id="DivBudject" runat="server">
                        <asp:TextBox ID="TxtBudjet" runat="server" 
                            style="font-weight: 700; font-size: medium" Width="100px"></asp:TextBox>
                        ريال سعودي
                    </div>
                </td>
            </tr>
            <tr>
                <td bgcolor="#BCCAA4" class="style16">
                    <div id="DivPaiedValueName" runat="server">
                        القيمة المدفوعة حتى تاريخه :
                    </div>
                </td>
                <td bgcolor="#DCDCCB">
                    <div id="DivPaiedValue" runat="server">
                        <asp:TextBox ID="TxtPaidValue" runat="server" 
                            style="font-weight: 700; font-size: medium" Width="100px"></asp:TextBox>
                        ريال سعودي
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:ImageButton ID="BtnSearch" runat="server" ImageUrl="~/icon/بحث.png" 
                        onclick="BtnSearch_Click" ValidationGroup="MY" />
                </td>
            </tr>
        </table>
        <center>
            
      <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
             AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" 
             Width="100%" PageSize="5" 
             onpageindexchanging="GridView1_PageIndexChanging" SkinID="myGrid" 
            AllowSorting="True" onsorting="GridView1_Sorting" BackColor="White" 
            BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
            style="text-align: center; font-weight: 700">
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <RowStyle ForeColor="#000066" />
                <Columns>
                   
                    
                   
                    
                    <asp:TemplateField HeaderText="إسم المشـــروع" ItemStyle-HorizontalAlign="Right" SortExpression="ProjectName">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkSelect2" runat="server" CausesValidation="false" 
                                CommandName="MySelect" Text='<%# Bind("ProjectDataName") %>'
                                CommandArgument='<%# Bind("ProjectDataID") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                    
                </Columns>
                
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                
            </asp:GridView>
          <asp:Button ID="btnExcelExport" runat="server" Text="تصدير اكسل" 
            onclick="btnExcelExport_Click" Font-Names="Tahoma" Visible="False" />
        </center>
    
    </div>
    </form>
</body>
</html>
