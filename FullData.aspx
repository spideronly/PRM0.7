<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FullData.aspx.cs" Inherits="FullData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>بيانات المشروع</title>
     
    <script language=javascript>
function CallPrint(id)
{
var prtContent = document.getElementById(id);
var WinPrint = window.open('','','letf=200,top=100,width=700,height=500,toolbar=500,scrollbars=1,status=0');
WinPrint.document.write('<center>البيانات</center>');
WinPrint.document.write(prtContent.innerHTML);
WinPrint.document.close();
WinPrint.focus();
WinPrint.print();
//WinPrint.close();
prtContent.innerHTML=strOldOne;
}
</script>
    <style type="text/css">
        .style2
        {
            width: 146px;
            font-weight: bold;
        }
        .style4
        {
            width: 146px;
            height: 23px;
        }
        .style5
        {
            width: 676px;
            height: 23px;
        }
        
        .style6
        {
            width: 200px;
        }
        
    </style>
    
</head>
<body>
    <form id="form1" runat="server" dir="rtl">
    <div style="font-family: Arial; font-size: 10px; font-weight: bold;">
   <input type="button" value="طباعة هذه الصفحه" onClick="window.print()" />

   </div>
<div id="divArea">
    <div style="text-align: center">
        <br />
        <span style="font-family: 'Times New Roman', Times, serif; font-weight: bold; font-size: 24pt">
        <span style="text-decoration: underline">
        &nbsp;<img alt="" src="images/PrintPageHeader.jpg" 
            style="width: 723px; height: 132px" /><br />
        بيانات المشروع</span><br style="text-decoration: underline" />
            &nbsp;<br />
        </span>
    </div>
    <table border="0" width="100%" style="height: 637px">
        <tr>
            <td>
                <table border="1" width="100%" cellpadding="2" cellspacing="0" 
        style="font-weight: 700" dir="rtl">
                    <tr>
                        <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style4" 
                            >
                            <b>إسم المشروع</b>
                        </td>
                        <td class="style5">
                            <%= myPro.ProjectName %>
                        </td>
                    </tr>
                    <tr>
                        
                      <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style2" 
                            >
                            <b>راعي المشروع</b>
                            </td>
                        <td class="style5">
                            <%= myPro.ProjectSponsor %></td>
                    </tr>
                    <tr>
                        <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style2" 
                            >
                            مدير المشروع</td>
                        <td class="style5">
                            <%= myPro.ProjectManager %>
                            </td>
                    </tr>
                    <tr>
                        <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style2" 
                            >
                            البرنامج</td>
                        <td class="style5">
                             <%= myPro.ProjectProgram %></td>
                    </tr>
                    <tr>
                        <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style2" 
                            >
                            الإداره المعنيه</td>
                        <td class="style5">
                             <%= myPro.DepartmentName %></td>
                    </tr>
                    <tr>
                        <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style2" 
                            >
                            تاريخ البدء التعاقدي</td>
                        <td class="style5">
                             <%= myPro.ProjectStartDateHijriString %></td>
                    </tr>
                    <tr>
                        <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style2" 
                            >
                            تاريخ الإنتهاء التعاقدي</td>
                        <td class="style5">
                             <%= myPro.ProjectEndDateHijriString %>
                             </td>
                    </tr>
                    <tr>
                        <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style2" 
                            >
                            تاريخ البدء الفعلي</td>
                        <td class="style5">
                             <%= myPro.ProjectActualStartDateHijriString %>
                             </td>
                    </tr>
                    <tr>
                        <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style2" 
                            >
                            تاريخ الإنتهاء الفعلي</td>
                        <td class="style5">
                            <%= myPro.ProjectActualEndDateHijriString %></td>
                    </tr>
                    <tr>
                        <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style2" 
                            >
                            إسم المقاول</td>
                        <td class="style5">
                             <%= myPro.ProjectContractor %></td>
                    </tr>
                    <tr>
                        <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style2" 
                            >
                            ميزانيه المشروع</td>
                        <td class="style5">
                             <%= myPro.ProjectBudget %>
                              ريال سعودي</td>
                    </tr>
                    <tr>
                        <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style2" 
                            >
                            <b>القيمة المدفوعه حتى تاريخه </b>
                        </td>
                        <td class="style5">
                            <%= myPro.ProjectPaiedValue.ToString()  %>
                            ريال سعودي
                        </td>
                    </tr>
                    <tr>
                        <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style2" 
                            >
                            نوعية قياس الإنجاز</td>
                        <td class="style5">
                           
                            <%= myPro.ProgressTypeName %>
                          
                        </td>
                    </tr>
                    <tr>
                        <td style="font-family: 'Times New Roman', Times, serif; font-size: 12pt;" class="style2" 
                            >
                            نسبة الإنجاز</td>
                        <td class="style5">
                           
                            <%= myPro.ProjectProgress %>
                            %
                            </td>
                    </tr>
                    </table>
            
        
   
    
    
    <div style="text-align: center; font-family: 'Times New Roman', Times, serif; font-size: 18pt; height: 50px; background-color: #AEEFFF;">
        <b>
            <br />
            أهداف المشروع
            <br />
            <br />
        </b>
    
    
    </div>
       
    
     
    <table border="1" width="100%" cellpadding="2" cellspacing="0" dir="rtl">
        <% foreach (ETDL.tGoal myGoal in myGoalList)
           {%>
        <tr  style="text-align: center;">
            <td style="text-align: right">
                --&nbsp;&nbsp;&nbsp;&nbsp;
                <%= myGoal.GoalName %>
            </td>
        </tr>
        <%} %>
    </table>
    
    
     
    <div style="text-align: center; font-family: 'Times New Roman', Times, serif; font-size: 18pt; height: 50px; background-color: #AEEFFF;">
        <br />
        <b>
            ملخص حالة المشروع<br />
        </b><span style="font-family: 'Times New Roman', Times, serif"><b>
        <font size="5">
        <br />&nbsp;<br />
        <br /></font></b></span>
    </div>
       <table border="1" width="100%" cellpadding="2" cellspacing="0" 
        style="font-weight: 700" dir="ltr">
       
        <tr  style="text-align: center;">
            <td style="text-align: right">
                ملاحظات معالي الأمين</td>
            <td style="text-align: right">
                ملخص حالة المشروع/ إقتراحات توصيات لزيادة الفعاليه في المشروع</td>
        </tr>
         <% foreach (ETDL.tAbbreviate myAbb in myAbbList)
           {%>
        <tr  style="text-align: center;">
            <td style="text-align: right">
             
                </td>
            <td style="text-align: right">
             
                <%= myAbb.AbbreviateName %>
            </td>
        </tr>
        <%} %>
    </table>
   
    
     <div style="text-align: center; font-family: 'Times New Roman', Times, serif; font-size: 18pt; height: 50px; background-color: #AEEFFF;">
        <br />
        <b>
            المعوقات الرئيسيه للمشروع<br />
        </b><span style="font-family: 'Times New Roman', Times, serif"><b>
        <font size="5">
        <br />&nbsp;<br />
        <br /></font></b></span>
    </div>
  <table border="1" width="100%" cellpadding="2" cellspacing="0" 
        style="font-weight: 700" dir="rtl">
       
        <tr  style="text-align: center;">
            <td style="text-align: right">
                الوصــــــــف</td>
            <td style="text-align: right">
                تاريخ المعوق</td>
            <td style="text-align: right">
                الشخص /الجهه المسؤوله</td>
            <td style="text-align: right">
                التاريخ المخطط
            </td>
              <td style="text-align: right">
                المطلوب</td>
            <td style="text-align: right">
                هل تدخل الأمين مطلوب؟</td>
          
        </tr>
         <% foreach (ETDL.tConstraint myCons in myConsList)
           {%>
        <tr  style="text-align: center;">
            <td style="text-align: right">
             
                <%= myCons.ConstraintName %>
            </td>
            <td style="text-align: right">
                
                <%= myCons.ConstraintDateHijriString %>
            </td>
            <td style="text-align: right">
                
              <%= myCons.ConstraintResponsibleName %>
              </td>
            <td style="text-align: right">
               
                <%= myCons.ConstraintPlanDateHijriString %>
            </td>
                <td style="text-align: right">
                 <%= myCons.ConstraintRequiredSolution %>
                 </td>
            <td style="text-align: right">
                <% if( myCons.ConstraintIsNeedMayor==true) Response.Write("نعم"); %>
                <% if( myCons.ConstraintIsNeedMayor==false) Response.Write("لا"); %>
                </td>
        
        </tr>
         <%} %>
        </table>
    
    
     
    <div style="text-align: center; font-family: 'Times New Roman', Times, serif; font-size: 18pt; height: 50px; background-color: #AEEFFF;">
        <br />
        <b>
            المهام الرئيسيه التي تم إنجازها هذه الفتره</b><span style="font-family: 'Times New Roman', Times, serif"><b><font size="5"><br />&nbsp;<br />
        <br /></font></b></span>
    </div>
    
       <table border="1" width="100%" cellpadding="2" cellspacing="0" 
        style="font-weight: 700" dir="ltr">
       
        <tr  style="text-align: center;">
            <td style="text-align: right" class="style6">
                ملاحظات معالي الأمين</td>
            <td style="text-align: center">
                الوصـــــــــــــــــــــــــــف</td>
        </tr>
         <% foreach (ETDL.tTask myTasK in myTaskList)
           {%>
        <tr  style="text-align: center;">
            <td style="text-align: right" class="style6">
             
                </td>
            <td style="text-align: right">
             
                <%if( myTasK.TaskIsAchived==true)
                      Response.Write(myTasK.TaskName);
                       %>
            </td>
        </tr>
        <%} %>
    </table>
   
      
    <div style="text-align: center; font-family: 'Times New Roman', Times, serif; font-size: 18pt; height: 50px; background-color: #AEEFFF;">
        <br />
        <b>
            المهام الرئيسيه التي لم يتم إنجازها هذه الفتره</b><span style="font-family: 'Times New Roman', Times, serif"><b><font size="5"><br />&nbsp;<br />
        <br /></font></b></span>
    </div>
    
       <table border="1" width="100%" cellpadding="2" cellspacing="0" 
        style="font-weight: 700" dir="ltr">
       
        <tr  style="text-align: center;">
            <td style="text-align: right" class="style6">
                ملاحظات معالي الأمين</td>
            <td style="text-align: center">
                السبب</td>
            <td style="text-align: center">
                الوصـــــــــــــــف</td>
        </tr>
         <% foreach (ETDL.tTask myTasK in myTaskList)
           {%>
        <tr  style="text-align: center;">
            <td style="text-align: right" class="style6">
             
                </td>
            <td style="text-align: right">
              <%= myTasK.TaskName%>
               </td>
            <td style="text-align: right">
             
                <%if( myTasK.TaskIsAchived==false)
                      Response.Write(myTasK.TaskName);
                       %>
            </td>
        </tr>
        <%} %>
    </table>
       
    </table>
    
     </div>
    </form>
</body>
</html>
