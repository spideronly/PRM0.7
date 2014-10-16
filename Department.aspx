<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Department.aspx.cs" Inherits="Department" Title="نظام المشاريع" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="divPrm" runat="server" style="width: 100%; height: 500px" align="center" visible="false">
	 <br /><br /><br /><br /><br />
	 <asp:Label ID="lblCantSee" runat="server" Text="لا توجد لديك صلاحية لاظهار هذه الصفحة" Font-Bold="True" 
         ForeColor="White"></asp:Label>
         </div>
         <div id="divAllData" runat="server">
        <br />
        <center>
        <p style="font-family: tahoma; font-size: 10pt; font-weight: bold">
            الادارات والاقسام
        </p>
        </center>
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%">
                    <tr style="border: thin solid #000000">
                        <td style="vertical-align: top; text-align: right">
                            <asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows" NodeIndent="15" 
                                Font-Size="12pt" OnSelectedNodeChanged="TreeView1_SelectedNodeChanged">
                                <ParentNodeStyle Font-Bold="False" />
                                <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                                <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px" VerticalPadding="0px" />
                                <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                            </asp:TreeView>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnMoveUp" runat="server" ImageUrl="images/Up.gif" 
                                OnClick="btnMoveUp_Click" />
                            <br />
                            <asp:ImageButton ID="btnMoveDown" runat="server" ImageUrl="images/Down.gif" 
                                OnClick="btnMoveDown_Click" />
                            <br />
                            <asp:ImageButton ID="btnMoveLeft" runat="server" ImageUrl="~/images/left.gif" 
                                OnClick="btnMoveLeft_Click" />
                            <br />
                            <asp:ImageButton ID="btnMoveRight" runat="server" ImageUrl="~/images/right.gif" 
                                OnClick="btnRight_Click" />
                            <br />
                            <br />
                            <br />
                        </td>
                        <td style="vertical-align: middle" valign="top">
                            <div style="padding: 10px; margin: 2px; border: 2px solid #000000; width: 398px;">
                                <table border="0" 
                                    style="font-family: tahoma; font-size: 10px; font-weight: bold">
                                    <tr>
                                        <td>
                                            الاســـــم
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtDepName" runat="server" Width="300px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="text-align: center">
                                            <asp:Button ID="btnAdd" runat="server" Text="اضافة" OnClick="btnAdd_Click" SkinID="TahomaButton" />
                                            <asp:Button ID="btnEdit" runat="server" Text="تعديل" OnClick="btnEdit_Click" SkinID="TahomaButton" />
                                            <asp:Button ID="btnDelete" runat="server" Text="حذف" OnClick="btnDelete_Click" SkinID="TahomaButton" />
                                            <cc1:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" TargetControlID="btnDelete" ConfirmText="سيتم حذف القسم مع جميع الاقسام الفرعية إن وجدت . هل تريد المتابعه ؟" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            <br />
                                            <br />
                                            <br />
                                            <b>
                                                <asp:Label ID="lblMeessage" runat="server" ForeColor="DarkRed" />
                                            </b>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
	 


</asp:Content>

