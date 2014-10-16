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

public partial class UsersByDeps : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ETDL.tUser.FillDropDownList(this.DlLoginUsers0);
            ETDL.tDepartment.FillDropDownList(this.DlDep);
        }
    }
    private void mShowUserInDep()
    {
        int mDepID = int.Parse(DlDep.SelectedValue);

        // ETDL.vPermission myPerm = new ETDL.vPermission(mPermissionID);
        List<ETDL.vPermission> myDepList = new List<ETDL.vPermission>();
        ETDL.vPermission.FillList(myDepList, "Permission_DepartmentID=" + mDepID + "");
        GridView2.DataSource = myDepList;
        GridView2.DataBind();
    }
    protected void DlDep_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DlDep.SelectedValue == "0")
        {
            Panel1.Visible = false;
            GridView2.DataBind();
            GridView2.Visible = false;
            return;
        }
        else
        {
            mShowUserInDep();
            Panel1.Visible = true;
            GridView2.Visible = true;
        }

    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;

        mShowUserInDep();
    }
    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MyDelete")
        {
            ETDL.tPermission myper = new ETDL.tPermission(int.Parse(e.CommandArgument.ToString()));
            myper.Delete();

            mShowUserInDep();
        }
       
    }
    protected void BtnAddUserToDep_Click(object sender, EventArgs e)
    {
        int mLoginUsers = int.Parse(DlLoginUsers0.SelectedValue);
        int mDepID = int.Parse(DlDep.SelectedValue);
        if (ETDL.tPermission.IsExist(mLoginUsers, mDepID))
        {
            lblMessage1.Text = "الاسم موجود فعلا .. ادخل اسم جديد";
            return;
        }
        if (DlLoginUsers0.SelectedValue == "0") return;

        ETDL.tPermission myPermition = new ETDL.tPermission();

        myPermition.Permission_UserID = mLoginUsers;
        myPermition.Permission_DepartmentID = mDepID;
        myPermition.PermissionAdd = ChbProjectAdd.Checked;
        myPermition.PermissionCreateReport = ChbReportCreate.Checked;
        myPermition.PermissionDelete = ChbProjectDelete.Checked;
        myPermition.PermissionUpdate = ChbProjectUpdate.Checked;
        myPermition.PermissionView = ChbProjectShow.Checked;

        myPermition.Create();
        myPermition = null;
        mShowUserInDep();
    }
}
