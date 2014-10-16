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

public partial class DeparmentUsers : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            mShow();
            ETDL.tUser.FillDropDownList(this.DlLoginUsers);
        }
    }
    private void mShow()
    {
        int mDepID = int.Parse(Session["mDeparmentID"].ToString());

        // ETDL.vPermission myPerm = new ETDL.vPermission(mPermissionID);
        List<ETDL.vPermission> myDepList = new List<ETDL.vPermission>();
        ETDL.vPermission.FillList(myDepList, "Permission_DepartmentID=" + mDepID + "");
        GridView1.DataSource = myDepList;
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        //GridView1.PageIndex = e.NewPageIndex;

        //mShowDeparment();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //if (e.CommandName == "MyDelete")
        //{
        //    ETDL.tProject myproject = new ETDL.tProject(int.Parse(e.CommandArgument.ToString()));
        //    myproject.Delete();

        //    mShow();
        //}
        //if (e.CommandName == "MySelect")
        //{
        //    myFindFrame.InnerHtml = "<iframe id=\"IframeEdit\" src=\"DeparmentUsers.aspx\" frameborder=\"0\" width=\"100%\" height=\"470px\" scrolling=\"no\"></iframe>";

        //    ModalPopupExtender1.Show();
        //}
    }
    protected void BtnAddUserToDep_Click(object sender, EventArgs e)
    {
        int mLoginUsers = int.Parse(DlLoginUsers.SelectedValue);
        int mDepID = int.Parse(Session["mDeparmentID"].ToString());
        if (ETDL.tPermission.IsExist(mLoginUsers, mDepID))
        {
            lblMessage.Text = "الاسم موجود فعلا .. ادخل اسم جديد";
            return;
        }
        if (DlLoginUsers.SelectedValue == "0") return;
        
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
        mShow();
    }
}
