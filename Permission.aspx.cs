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

public partial class Permission : myFilteredPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (myUserPre.UserBasicShow != true)
        {
            divAllData.Visible = false;
            divPrm.Visible = true;
        }
        if (!IsPostBack)
        {
            ETDL.tUser.FillDropDownList(this.DlLoginUsers);
           
            ETDL.tDepartment.FillDropDownList(this.DlDeparment);
        }
    }
   //my Methods
    
    private void mClearTextBoxs()
    {
        lblMessage.Text = "";
        txtLoginName.Text = "";
        txtLoginPassword.Text = "";
        txtLoginDisplayName.Text = "";
    }
    private void mShow()
    {
        if (DlLoginUsers.SelectedValue == "0")
        {
            mClearData();
            return;
        }
        else
        {
           ETDL.tUser myUser = new ETDL.tUser(int.Parse(DlLoginUsers.SelectedValue));
            if (divAddUsers.Visible == true)
            {
                txtLoginDisplayName.Text = myUser.UserDisplayName;
                txtLoginName.Text = myUser.UserName;
                txtLoginPassword.Text = myUser.UserPassword;
                ChbPermShow.Checked = myUser.UserPermShow;
                ChbPermUpdate.Checked = myUser.UserPermUpdate;
                ChbBasicShow.Checked = myUser.UserBasicShow;
                LoginImage.ImageUrl = "GetLoginImage.aspx?mID=" + myUser.UserID.ToString();
               
            }
            int mPermissionID = ETDL.tUser.myGetPermissionByUserID(int.Parse(DlLoginUsers.SelectedValue));
            if (mPermissionID > 0)
            {
                ETDL.tPermission myPerm = new ETDL.tPermission(mPermissionID);
                ChbProjectAdd.Checked = myPerm.PermissionAdd;
                ChbProjectDelete.Checked = myPerm.PermissionDelete;
                ChbProjectShow.Checked = myPerm.PermissionView;
                ChbProjectUpdate.Checked = myPerm.PermissionUpdate;
                ChbReportCreate.Checked = myPerm.PermissionCreateReport;
                myPerm = null;
                myUser = null;
            }
            mShowDeparment();
        }
    }
    private void mSaveData()
    {
        if (DlLoginUsers.SelectedValue == "0") return;
        int mLoginUsers = int.Parse(DlLoginUsers.SelectedValue);
        ETDL.tUser myUSer = new ETDL.tUser(mLoginUsers);
        myUSer.UserBasicShow = ChbBasicShow.Checked;
        myUSer.UserPermShow = ChbPermShow.Checked;
        myUSer.UserPermUpdate = ChbPermUpdate.Checked;
        myUSer.Update();
        myUSer = null;
        
        //int mDepID = int.Parse(DlDeparment.SelectedValue);
        //int mPermissionID = ETDL.tUser.GetPermissionByUserIDandDepID(mLoginUsers,mDepID);
        //ETDL.tPermission myPermition = new ETDL.tPermission(mPermissionID);

        //myPermition.Permission_UserID = mLoginUsers;
        //myPermition.Permission_DepartmentID = mDepID;
        //myPermition.PermissionAdd = ChbProjectAdd.Checked;
        //myPermition.PermissionCreateReport = ChbReportCreate.Checked;
        //myPermition.PermissionDelete = ChbProjectDelete.Checked;
        //myPermition.PermissionUpdate = ChbProjectUpdate.Checked;
        //myPermition.PermissionView = ChbProjectShow.Checked;
       
        //myPermition.Update();
        //myPermition = null;
        
    }
    private void mClearData()
    {

        lblMessage.Text = "";
        txtLoginName.Text = "";
        txtLoginPassword.Text = "";
        txtLoginDisplayName.Text = "";
        ChbPermShow.Checked = false;
        ChbPermUpdate.Checked = false;
        ChbProjectAdd.Checked = false;
        ChbProjectDelete.Checked = false;
        ChbProjectShow.Checked = false;
        ChbProjectUpdate.Checked = false;
        ChbReportCreate.Checked = false;
        
    }
    private void mSaveImage(int mUserID)
    {
        if (this.FileUploadPic.HasFile)
        {
            ETDL.UserPic myUserPic;
            int mUserPicID = ETDL.UserPic.GetUserPicIDByUserID(mUserID);

            if (mUserPicID == 0)
                myUserPic = new ETDL.UserPic();
            else
                myUserPic = new ETDL.UserPic(mUserPicID);

            myUserPic.PicUserID = mUserID;
            myUserPic.UserImage = FileUploadPic.FileBytes;

            if (mUserPicID == 0)
                myUserPic.Create();
            else
                myUserPic.Update();

            myUserPic = null;
        }

    }
    //myAction Controls
    protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtLoginName.Text.Trim() == "" || txtLoginPassword.Text.Trim() == "")
            {
                lblMessage.Text = "البيانات غير كاملة";
                return;
            }
            if (ETDL.tUser.IsLoginNameExist(txtLoginName.Text))
            {
                lblMessage.Text = "الاسم موجود فعلا .. ادخل اسم جديد";
                return;
            }

            ETDL.tUser myUser = new ETDL.tUser();
            myUser.UserName = txtLoginName.Text;
            myUser.UserPassword = txtLoginPassword.Text;
            myUser.UserDisplayName = txtLoginDisplayName.Text;

            myUser.Create();
            mSaveImage(myUser.UserID);
            myUser = null;
            ETDL.tPermission myPerm = new ETDL.tPermission();
            myPerm.Permission_UserID = ETDL.tPermission.myGetLastID();
            myPerm.Create();
            myPerm = null;
            ETDL.tUser.FillDropDownList(this.DlLoginUsers);
            mClearTextBoxs();
        }
    protected void btnUpdate_Click(object sender, EventArgs e)
      {
          if (DlLoginUsers.SelectedValue == "0")
          {
              lblMessage.Text = "قم بتحديد مستخدم أولا";
              return;
          }

          if (txtLoginName.Text.Trim() == "" || txtLoginPassword.Text.Trim() == "")
          {
              lblMessage.Text = "البيانات غير كاملة";
              return;
          }

          ETDL.tUser myUser = new ETDL.tUser(int.Parse(DlLoginUsers.SelectedValue));
          myUser.UserName = txtLoginName.Text;
          myUser.UserPassword = txtLoginPassword.Text;
          myUser.UserDisplayName = txtLoginDisplayName.Text;

          myUser.Update();
          mSaveImage(myUser.UserID);

          myUser = null;

          ETDL.tUser.FillDropDownList(this.DlLoginUsers);
          mClearTextBoxs();
      }
    protected void btnDelete_Click(object sender, EventArgs e)
      {
          if (DlLoginUsers.SelectedValue == "0")
          {
              lblMessage.Text = "قم بتحديد مستخدم أولا";
              return;
          }
          int mPermissionID = ETDL.tUser.myGetPermissionByUserID(int.Parse(DlLoginUsers.SelectedValue));
          if (mPermissionID > 0)
          {
              ETDL.tPermission myPerm = new ETDL.tPermission(mPermissionID);
              myPerm.Delete();
              myPerm = null;
          }
            ETDL.tUser myUser = new ETDL.tUser(int.Parse(DlLoginUsers.SelectedValue));
          myUser.Delete();
          myUser = null;

          ETDL.tUser.FillDropDownList(this.DlLoginUsers);
          mClearTextBoxs();
      }
    protected void DlLoginUsers_SelectedIndexChanged(object sender, EventArgs e)
    {
       mShow();
    }
    protected void btnAddEdit_Click(object sender, EventArgs e)
    {
          
        mSaveData();
        
   }

    private void mShowDeparment()
    {
        int mUserID=int.Parse(DlLoginUsers.SelectedValue);
        
           // ETDL.vPermission myPerm = new ETDL.vPermission(mPermissionID);
            List<ETDL.vPermission> myPermission = new List<ETDL.vPermission>();
            ETDL.vPermission.FillList(myPermission, "Permission_UserID=" + mUserID + "");
            GridView1.DataSource = myPermission;
            GridView1.DataBind();
       
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;

        mShowDeparment();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MyDelete")
        {
            ETDL.tPermission myper = new ETDL.tPermission(int.Parse(e.CommandArgument.ToString()));
            myper.Delete();

            mShowDeparment();
        }
        if (e.CommandName == "MySelect")
        {
            Session["mDeparmentID"] = int.Parse(e.CommandArgument.ToString());
            myFindFrame.InnerHtml = "<iframe id=\"IframeEdit\" src=\"DeparmentUsers.aspx\" frameborder=\"0\" width=\"100%\" height=\"470px\" scrolling=\"no\"></iframe>";

            ModalPopupExtender1.Show();
        }
        if (e.CommandName == "myUpdate")
        {
            ETDL.tPermission myPermition = new ETDL.tPermission(int.Parse(e.CommandArgument.ToString()));
            DlDeparment.SelectedValue= myPermition.Permission_DepartmentID.ToString();
            ChbProjectAdd.Checked = myPermition.PermissionAdd;
            ChbProjectDelete.Checked = myPermition.PermissionDelete;
            ChbProjectShow.Checked = myPermition.PermissionView;
            ChbProjectUpdate.Checked = myPermition.PermissionUpdate;
            ChbReportCreate.Checked = myPermition.PermissionCreateReport;
            myPermition = null;
           
            //int rowindex=int.Parse((Label)()))
            //CheckBox mChbProjectAdd = (CheckBox)(GridView1.SelectedRow.FindControl("ChbProjectAdd"));
            //CheckBox mChbReportCreat = (CheckBox)(GridView1.SelectedRow.FindControl("ChbReportCreat"));
            //CheckBox mChbProjectDelete = (CheckBox)(GridView1.SelectedRow.FindControl("ChbProjectDelete"));
            //CheckBox mChbProjectEdit = (CheckBox)(GridView1.SelectedRow.FindControl("ChbProjectEdit"));
            //CheckBox mChbProjectShow = (CheckBox)(GridView1.SelectedRow.FindControl("ChbProjectShow"));
            //myPermition.PermissionAdd = mChbProjectAdd.Checked;
            //myPermition.PermissionCreateReport = mChbReportCreat.Checked;
            //myPermition.PermissionDelete = mChbProjectDelete.Checked;
            //myPermition.PermissionUpdate = mChbProjectEdit.Checked;
            //myPermition.PermissionView = mChbProjectShow.Checked;

            //myPermition.Update();
            //myPermition = null;
            //mShowDeparment();
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        myFindFrame.InnerHtml = "<iframe id=\"IframeEdit\" src=\"UsersByDeps.aspx\" frameborder=\"0\" width=\"100%\" height=\"470px\" scrolling=\"no\"></iframe>";

        ModalPopupExtender1.Show();
    }
    protected void BtnAddDepToUser_Click(object sender, EventArgs e)
    {
        int mLoginUsers = int.Parse(DlLoginUsers.SelectedValue);
        int mDepID = int.Parse(DlDeparment.SelectedValue);
        int mPermID = ETDL.tPermission.GetPermissionbyDepID(mDepID);
       
       
            if (DlLoginUsers.SelectedValue == "0") return;
            if (ChbHeriraclePerm.Checked == false)
            {
                if (ETDL.tPermission.IsExist(mLoginUsers, mDepID) == false)
                {
                    ETDL.tPermission myPermition;
                    if (ETDL.tPermission.IsExist(mLoginUsers, mDepID))
                        myPermition = new ETDL.tPermission(mPermID);
                    else
                        myPermition = new ETDL.tPermission();

                    myPermition.Permission_UserID = mLoginUsers;
                    myPermition.Permission_DepartmentID = mDepID;
                    myPermition.PermissionAdd = ChbProjectAdd.Checked;
                    myPermition.PermissionCreateReport = ChbReportCreate.Checked;
                    myPermition.PermissionDelete = ChbProjectDelete.Checked;
                    myPermition.PermissionUpdate = ChbProjectUpdate.Checked;
                    myPermition.PermissionView = ChbProjectShow.Checked;
                    if (ETDL.tPermission.IsExist(mLoginUsers, mDepID))
                        myPermition.Update();
                    else
                        myPermition.Create();
                    myPermition = null;
                }
            }
            if (ChbHeriraclePerm.Checked == true)
            {
                if (ETDL.tPermission.IsExist(mLoginUsers, mDepID) == false)
                {
                    ETDL.tPermission myPermition;
                    if (ETDL.tPermission.IsExist(mLoginUsers, mDepID))
                        myPermition = new ETDL.tPermission(mPermID);
                    else
                        myPermition = new ETDL.tPermission();

                    myPermition.Permission_UserID = mLoginUsers;
                    myPermition.Permission_DepartmentID = mDepID;
                    myPermition.PermissionAdd = ChbProjectAdd.Checked;
                    myPermition.PermissionCreateReport = ChbReportCreate.Checked;
                    myPermition.PermissionDelete = ChbProjectDelete.Checked;
                    myPermition.PermissionUpdate = ChbProjectUpdate.Checked;
                    myPermition.PermissionView = ChbProjectShow.Checked;
                    if (ETDL.tPermission.IsExist(mLoginUsers, mDepID))
                        myPermition.Update();
                    else
                        myPermition.Create();
                    myPermition = null;
                }
                List<ETDL.tDepartment> myDepList = new List<ETDL.tDepartment>();
                ETDL.tDepartment.FillList(myDepList, "DepartmentParentID=" + mDepID + "");
                foreach (ETDL.tDepartment myDepsID in myDepList)
                {
                    ETDL.tPermission myPerm = new ETDL.tPermission();
                    if (ETDL.tPermission.IsExist(mLoginUsers, myDepsID.DepartmentID) == false)
                    {
                        myPerm.Permission_UserID = mLoginUsers;
                        myPerm.Permission_DepartmentID = myDepsID.DepartmentID;
                        myPerm.PermissionAdd = ChbProjectAdd.Checked;
                        myPerm.PermissionCreateReport = ChbReportCreate.Checked;
                        myPerm.PermissionDelete = ChbProjectDelete.Checked;
                        myPerm.PermissionUpdate = ChbProjectUpdate.Checked;
                        myPerm.PermissionView = ChbProjectShow.Checked;
                        myPerm.Create();
                       
                        myPerm = null;
                       
                    }
                    RecursivelyCreate(myDepsID.DepartmentID, mLoginUsers);
                }

            }
            mShowDeparment();
            
        
    }
    private  void RecursivelyCreate(int mDepID,int mUserID)
    {
       
       
        List<ETDL.tDepartment> myList = new List<ETDL.tDepartment>();
        ETDL.tDepartment.FillList(myList, "DepartmentParentID="+mDepID+"");

        foreach (ETDL.tDepartment myDepsID in myList)
        {
          
            ETDL.tPermission myPerm = new ETDL.tPermission();
            if (ETDL.tPermission.IsExist(mUserID, myDepsID.DepartmentID) == false)
            {
                myPerm.Permission_UserID = mUserID;
                myPerm.Permission_DepartmentID = myDepsID.DepartmentID;
                myPerm.PermissionAdd = ChbProjectAdd.Checked;
                myPerm.PermissionCreateReport = ChbReportCreate.Checked;
                myPerm.PermissionDelete = ChbProjectDelete.Checked;
                myPerm.PermissionUpdate = ChbProjectUpdate.Checked;
                myPerm.PermissionView = ChbProjectShow.Checked;
                myPerm.Create();
                
                myPerm = null;
                RecursivelyCreate(myDepsID.DepartmentID, mUserID);
            }

        }
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        GridView1.DataBind();
        Session["SelecetdRowIndex"] = e.NewEditIndex;

    }
}
