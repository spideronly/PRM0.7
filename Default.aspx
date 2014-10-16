<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Title="تسجيل الدخول" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
	<style type="text/css">
    .style6 {
	text-align: center;
	direction: rtl;
	background-image: url('images/phoneA_03.png');
}
.style7 {
	text-align: center;
	direction: rtl;
	background-image: url('images/phoneA_06.png');
}
.style11 {
	text-align: center;
	background-image: url('images2/Project_logn_03.png');
}
.style12 {
	text-align: center;
	background-image: url('images2/Project_logn_06.png');
}
.style13 {
	text-align: center;
	background-image: url('images2/Project_logn_09.png');
}
.style14 {
	text-align: center;
	background-image: url('images2/Project_logn_13.png');
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<table id="Table_01" width="900" border="0" cellpadding="0" cellspacing="0" dir="ltr" style="height: 472px">
	<tr>
		<td colspan="6">
			<img src="images2/Project_logn_01.png" width="900" height="140" alt=""></td>
	</tr>
	<tr>
		<td rowspan="8">
			<img src="images2/Project_logn_02.png" width="538" height="331" alt=""></td>
		<td colspan="3" style="width: 204px; height: 34px" class="style11">
                    <asp:TextBox ID="TxtLoginInUser" runat="server" Width="172px" BorderStyle="None" BackColor="White" BorderColor="White"></asp:TextBox>
                </td>
		<td colspan="2" rowspan="4">
			<img src="images2/Project_logn_04.png" width="158" height="88" alt=""></td>
	</tr>
	<tr>
		<td colspan="3">
			<img src="images2/Project_logn_05.png" width="204" height="12" alt=""></td>
	</tr>
	<tr>
		<td colspan="3" style="width: 204px; height: 34px" class="style12">
                    <asp:TextBox ID="TxtLogInPass" runat="server" Width="172px" TextMode="Password" BorderStyle="None" BorderColor="White" BackColor="White"></asp:TextBox>
                </td>
	</tr>
	<tr>
		<td colspan="3">
			<img src="images2/Project_logn_07.png" width="204" height="8" alt=""></td>
	</tr>
	<tr>
		<td rowspan="2">
			<img src="images2/Project_logn_08.png" width="52" height="43" alt=""></td>
		<td style="width: 138px; height: 33px" class="style13">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/icon/6.png" 
                        onclick="ImageButton1_Click" />
                </td>
		<td colspan="2" rowspan="2">
			<img src="images2/Project_logn_10.png" width="54" height="43" alt=""></td>
		<td rowspan="4">
			<img src="images2/Project_logn_11.png" width="118" height="243" alt=""></td>
	</tr>
	<tr>
		<td>
			<img src="images2/Project_logn_12.png" width="138" height="10" alt=""></td>
	</tr>
	<tr>
		<td colspan="4" style="width: 244px; height: 42px" class="style14">
                    <asp:Label ID="lblMessage" runat="server" Font-Bold="True"></asp:Label>
                </td>
	</tr>
	<tr>
		<td colspan="4">
			<img src="images2/Project_logn_14.png" width="244" height="158" alt=""></td>
	</tr>
	<tr>
		<td>
			<img src="images2/spacer.gif" width="538" height="1" alt=""></td>
		<td>
			<img src="images2/spacer.gif" width="52" height="1" alt=""></td>
		<td>
			<img src="images2/spacer.gif" width="138" height="1" alt=""></td>
		<td>
			<img src="images2/spacer.gif" width="14" height="1" alt=""></td>
		<td>
			<img src="images2/spacer.gif" width="40" height="1" alt=""></td>
		<td>
			<img src="images2/spacer.gif" width="118" height="1" alt=""></td>
	</tr>
</table>

</asp:Content>

