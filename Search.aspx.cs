using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["mProWereCluse"] != null)
        {
            ViewState["mProWereCluse"] = Session["mProWereCluse"];
            Session["mProWereCluse"] = null;
        }
        if (!this.IsPostBack)
        {
           
            ETDL.tDepartment.FillDropDownList(this.DlDep);
            mShowData();
            ViewState["mEmpSortingType"] = "Asc";
        }

    }
    protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        ViewState["mProWereCluse"] = null;
        ETDL.tProjectData myPro = new ETDL.tProjectData();

        if (TxtBudjet.Text != "")
            myPro.ProjectDataBudget = int.Parse(TxtBudjet.Text);
        myPro.ProjectDataContractor = TxtContractor.Text;
        myPro.ProjectDataManager = TxtManager.Text;
        if (TxtPaidValue.Text != "")
            myPro.ProjectDataPaiedValue = int.Parse(TxtPaidValue.Text);
        myPro.ProjectDataProgram = TxtProgram.Text;
        myPro.ProjectDataName = TxtProjectName.Text;
        myPro.ProjectDataSponsor = TxtProjectSponser.Text;
        if (DlDep.SelectedValue != "0")
            myPro.ProjectData_DepartmentID = int.Parse(DlDep.SelectedValue);
        Session["mProWereCluse"] = myPro.GetWhereCluse();
        ViewState["mProWereCluse"] = Session["mProWereCluse"];
        myPro = null;
        mShowData();
      //  myFindFrame.InnerHtml = "<iframe id=\"IframeEdit\" src=\"FindResult.aspx\" frameborder=\"0\" width=\"594px\" height=\"470px\" scrolling=\"no\"></iframe>";

        //ModalPopupExtender1.Show();
       return;
    }
    private void mShowData()
    {
        List<ETDL.tProjectData> myList = new List<ETDL.tProjectData>();

        if (ViewState["mProWereCluse"] != null)
        {
            if (ViewState["mEmpSorting"] == null)
                ETDL.tProjectData.FillList(myList, ViewState["mProWereCluse"].ToString());
            else
                ETDL.tProjectData.FillList(myList, ViewState["mProWereCluse"].ToString(), ViewState["mEmpSorting"].ToString() + " " + ViewState["mEmpSortingType"].ToString());
        }
        else
            if (ViewState["mEmpSorting"] == null)
                ETDL.tProjectData.FillList(myList);
            else
                ETDL.tProjectData.FillList(myList, "", ViewState["mEmpSorting"].ToString() + " " + ViewState["mEmpSortingType"].ToString());

        if (myList.Count > 0)
        {
            GridView1.DataSource = myList;
            GridView1.DataBind();
            btnExcelExport.Visible = true;
            GridView1.Visible = true;
        }
        else
        {
            GridView1.Visible = false;
            btnExcelExport.Visible = false;
            Response.Write("<h2><center><br/><br/><br/><br/>لا توجد نتائج لهذا البحث</center></h2>");
        }

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MySelect")
        {
            Session["mCurrentPro"] = e.CommandArgument.ToString();
            // window.parent.document.getElementById('ctl00_ContentPlaceHolder1_btnCancel').click();
            // window.parent.window.location.reload(true);
            // window.parent.window.location='default.aspx';  
            ScriptManager.RegisterStartupScript(this, this.GetType(), "key1", "window.parent.window.location='Report.aspx';", true);
        }
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        mShowData();
    }

    protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
    {
        if (ViewState["mEmpSortingType"].ToString() == "Asc")
            ViewState["mEmpSortingType"] = "Desc";
        else
            ViewState["mEmpSortingType"] = "Asc";

        ViewState["mEmpSorting"] = e.SortExpression;

        mShowData();
    }

    protected void btnExcelExport_Click(object sender, EventArgs e)
    {
        //if (ViewState["mProWereCluse"] != null)
        //    ETDL.tProject.ExportToExcel(ViewState["mProWereCluse"].ToString(), myPre.empPersData_Show, myPre.canSeeHidenData, myPre.empJobInfoData_Show, myPre.empSalaryData_Show);
        //else
        //    ETDL.tProject.ExportToExcel("", myPre.empPersData_Show, myPre.canSeeHidenData, myPre.empJobInfoData_Show, myPre.empSalaryData_Show);

    }
}
