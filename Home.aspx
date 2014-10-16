<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Home.aspx.cs" Inherits="Home" Title="نظام المشاريع" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style20
        {
            width: 192px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
        <asp:PostBackTrigger ControlID="GridView1" />
        
        </Triggers>
        <ContentTemplate>
         <div style="border: thin solid #000000; width: 99%; height: 100%;">
            <table style="font-family: tahoma; font-size: 10px; font-weight: bold; width: 890px;" 
                bgcolor="White">
                <tr>
                    <td class="style20">
                        الأقسام والإدارات
                    </td>
                    <td style="text-align: center">
                       
                    </td>
                </tr>
                <tr>
                    <td style="vertical-align: top; text-align: right;" class="style20">
                        <asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows" NodeIndent="15"
                            Font-Size="12pt" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                                VerticalPadding="0px" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px"
                                NodeSpacing="0px" VerticalPadding="2px" />
                        </asp:TreeView>
                    </td>
                    <td style="vertical-align: middle">
                        <asp:GridView ID="GridView1" runat="server" Width="618px" 
                            AutoGenerateColumns="False" OnPageIndexChanging="GridView1_PageIndexChanging" 
                            OnRowCommand="GridView1_RowCommand" 
                            AlternatingRowStyle-BackColor="#87B6E9"
                           HeaderStyle-BackColor="DarkGray" 
                           RowStyle-BackColor="#FFFFE6"  
                            >
                            <Columns>
                            
                                <asp:TemplateField HeaderText=" اسم المشروع">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkProName" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ProjectDataID") %>'
                                            CommandName="MySelect" Text='<%# Bind("ProjectDataName") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ProjectDataID") %>'
                                            CommandName="MyDelete" Text="حذف" />
                                        <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="سوف يتم الحذف نهائيا ، هل تريد المتابعة"
                                            TargetControlID="lnkDelete" />
                                    </ItemTemplate>
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False" ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkEdit" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ProjectDataID") %>'
                                            CommandName="MyUpdate" Text="تعديل" />
                                    </ItemTemplate>
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:TemplateField>
                                      <asp:TemplateField ShowHeader="False" ItemStyle-Width="50px">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkPrint" runat="server" CausesValidation="false" CommandArgument='<%# Bind("ProjectDataID") %>'
                                            CommandName="MyPrint" Text="معاينه" />
                                    </ItemTemplate>
                                    <ItemStyle Width="50px"></ItemStyle>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>
                                <div class="style7">
                                    <span class="style19">لا يوجد مشاريع</span>
                                </div>
                            </EmptyDataTemplate>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td class="style20" style="vertical-align: top; text-align: right;">
                        &nbsp;</td>
                    <td style="vertical-align: middle">
                        &nbsp;</td>
                </tr>
            </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
