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

public partial class Default3 : myFilteredPage
{
    int myProjID;
    int myDepID;
    List<ETDL.tGoal> myGoalList = new List<ETDL.tGoal>();
    List<ETDL.tAbbreviate> myAbbrivateList = new List<ETDL.tAbbreviate>();
    List<ETDL.tConstraint> myConstraintList = new List<ETDL.tConstraint>();
    List<ETDL.tTask> myTaskList = new List<ETDL.tTask>();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["ProjectID"] != null)
        {
            myProjID = int.Parse(Session["ProjectID"].ToString());

            ETDL.tProjectData mpro = new ETDL.tProjectData(myProjID);
            myDepID = mpro.ProjectData_DepartmentID;
        }
        if (Session["ProjectID"] == null)
        {
            myProjID = ETDL.tProjectData.myGetLastID() + 1;

            // myDepID=int.Parse(DlDep.SelectedValue);
        }
        //if (Request.QueryString["mpar"] == "1")
        //{
        //    Session["ProjectID"] = null;
        //    myGoalList.RemoveRange(0, myGoalList.Count);
        //    myTaskList.RemoveRange(0, myTaskList.Count);
        //    myAbbrivateList.RemoveRange(0, myAbbrivateList.Count);
        //    myConstraintList.RemoveRange(0, myConstraintList.Count);
        //}


        //PanelData.Visible = !RbAllTask.Checked;

        if (!IsPostBack)
        {

            RadioBehavior();

            ETDL.tDepartment.FillDropDownList(this.DlDep);
            ETDL.tProgressType.FillDropDownList(this.DlProgressType);
            ETDL.tUser.FillDropDownList(this.DLTaskUser);
            mShowGoal();
            mShowAbbrivate();
            mShowConstaints();
            mShowTask();
            mshow();
            ClearList();
            RbProjectBehavior();
        }
        else
        {
            if (Session["myGoal"] != null)
                myGoalList = (List<ETDL.tGoal>)(Session["myGoal"]);
            if (Session["myAbbrivate"] != null)
                myAbbrivateList = (List<ETDL.tAbbreviate>)(Session["myAbbrivate"]);
            if (Session["myConstraint"] != null)
                myConstraintList = (List<ETDL.tConstraint>)(Session["myConstraint"]);
            if (Session["myTask"] != null)
                myTaskList = (List<ETDL.tTask>)(Session["myTask"]);
        }

    }
    private void ClearList()
    {
        if (Session["myGoal"] == null && Session["myAbbrivate"] == null && Session["myConstraint"] == null && Session["myTask"] == null)
        {
            myAbbrivateList.Clear();
            myConstraintList.Clear();
            myGoalList.Clear();
            myTaskList.Clear();
        }
    }
    // the Radio Button Behavior
    protected void RbTask_CheckedChanged(object sender, EventArgs e)
    {
        DivContractor.Visible = false;
        DivContractorName.Visible = false;
        DivConDateE.Visible = false;
        DivConDateS.Visible = false;
        DivNoConDateE.Visible = true;
        DivNoConDateS.Visible = true;
    }
    protected void RbMubadrah_CheckedChanged(object sender, EventArgs e)
    {
        DivContractor.Visible = false;
        DivContractorName.Visible = false;
        DivConDateE.Visible = false;
        DivConDateS.Visible = false;
        DivNoConDateE.Visible = true;
        DivNoConDateS.Visible = true;
    }
    protected void RbProject_CheckedChanged(object sender, EventArgs e)
    {
        RbProjectBehavior();
    }
    private void RbProjectBehavior()
    {
        DivContractor.Visible = true;
        DivContractorName.Visible = true;
        DivConDateE.Visible = true;
        DivConDateS.Visible = true;
        DivNoConDateE.Visible = false;
        DivNoConDateS.Visible = false;
    }

    //Page Method
    private void mshow()
    {
        if (Session["ProjectID"] != null)
        {
            int mPro = int.Parse(Session["ProjectID"].ToString());
            ETDL.tProjectData myPro = new ETDL.tProjectData(mPro);
            DlDep.SelectedValue = myPro.ProjectData_DepartmentID.ToString();
            DlProgressType.SelectedValue = myPro.ProjectData_ProgressTypeID.ToString();
            txtActualEndDate.Date = myPro.ProjectDataActualEndDate;
            txtActualStartDate.Date = myPro.ProjectDataActualStartDate;
            TxtBudjet.Text = myPro.ProjectDataBudget.ToString();
            TxtContractor.Text = myPro.ProjectDataContractor;
            txtEndDate.Date = myPro.ProjectDataEndDate;
            TxtManager.Text = myPro.ProjectDataManager;
            TxtPaidValue.Text = myPro.ProjectDataPaiedValue.ToString();
            TxtProgram.Text = myPro.ProjectDataProgram;
            TxtProgress.Text = myPro.ProjectDataProgress;
            TxtProjectName.Text = myPro.ProjectDataName;
            TxtProjectSponser.Text = myPro.ProjectDataSponsor;
            txtStartDate.Date = myPro.ProjectDataStartDate;
            if (myPro.ProjectData_ProjectType == 1)
                RbProject.Checked = true;
            if (myPro.ProjectData_ProjectType == 2)
                RbTask.Checked = true;
            if (myPro.ProjectData_ProjectType == 3)
                RbMubadrah.Checked = true;


        }

    }
    private void mClear()
    {
        TxtProjectName.Text = "";
        TxtBudjet.Text = "";
        TxtContractor.Text = "";
        TxtManager.Text = "";
        TxtPaidValue.Text = "";
        TxtProgram.Text = "";
        TxtProgress.Text = "";
        TxtProjectName.Text = "";
        TxtProjectSponser.Text = "";
        DlDep.SelectedIndex = -1;
        DlProgressType.SelectedIndex = -1;

    }
    private void RadioBehavior()
    {
        if (RbAllTask.Checked == true)
        {
            GridViewTask.Columns[1].Visible = true;
            divTaskReson.Visible = true;
            divTaskResonText.Visible = true;
        }
        if (RbTaskAchived.Checked == true)
        {
            GridViewTask.Columns[1].Visible = false;
            divTaskReson.Visible = false;
            divTaskResonText.Visible = false;
        }
        if (RbTaskNotAchived.Checked == true)
        {
            GridViewTask.Columns[1].Visible = true;
            divTaskReson.Visible = true;
            divTaskResonText.Visible = true;
        }
        if (RbTaskPlan.Checked == true)
        {
            GridViewTask.Columns[1].Visible = false;
            divTaskReson.Visible = false;
            divTaskResonText.Visible = false;
        }
    }

    private void mCreateTempToDatabase()
    {
        foreach (ETDL.tGoal mGoal in myGoalList)
        {
            if (mGoal.GoalID == 0)
                mGoal.Create();
            mShowGoal();
        }
        foreach (ETDL.tAbbreviate mAbbreviate in myAbbrivateList)
        {
            if (mAbbreviate.AbbreviateID == 0)
                mAbbreviate.Create();
            mShowAbbrivate();
        }
        foreach (ETDL.tConstraint mConstraint in myConstraintList)
        {
            if (mConstraint.ConstraintID == 0)
                mConstraint.Create();
            mShowConstaints();
        }
        foreach (ETDL.tTask mTask in myTaskList)
        {
            if (mTask.TaskID == 0)
                mTask.Create();
            mShowTask();
        }
    }
    //Goals
    private void mShowGoal()
    {
        if (!IsPostBack)
            ETDL.tGoal.FillList(myGoalList, "Goal_ProjectID=" + myProjID + "");
        else
            myGoalList = (List<ETDL.tGoal>)(Session["myGoal"]);
        if (myGoalList.Count == 0) myGoalList.Add(new ETDL.tGoal());
        GridViewGoal.DataSource = myGoalList;
        GridViewGoal.DataBind();
        if (!IsPostBack)
            Session["myGoal"] = myGoalList;

    }
    protected void GridViewGoal_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer && e.Row.RowType != DataControlRowType.Pager)
        {
            LinkButton lblTagLink = new LinkButton();
            lblTagLink = (LinkButton)e.Row.FindControl("lnkDeleteGoal");
            lblTagLink.CommandArgument = e.Row.RowIndex.ToString();
        }
    }

    protected void GridViewGoal_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "MyDelete")
            {

                //ETDL.tGoal myGoal = new ETDL.tGoal(int.Parse(e.CommandArgument.ToString()));
                int myIndex = int.Parse(e.CommandArgument.ToString());
                myGoalList = (List<ETDL.tGoal>)(Session["myGoal"]);
                myGoalList.RemoveAt(myIndex);
                GridViewGoal.DataSource = myGoalList;
                GridViewGoal.DataBind();
                Session["myGoal"] = myGoalList;
                //string mGoalID = ((HiddenField)(GridViewGoal.FindControl("HGoalID"))).Value;
                //ETDL.tGoal myGaols;
                //if (mGoalID != null)
                //{
                //    myGaols = new ETDL.tGoal(int.Parse(mGoalID));
                //    myGaols.Delete();
                //    myGaols = null;
                //}

            }

            else if (e.CommandName == "MyAdd")
            {
                TextBox myGoalName = (TextBox)GridViewGoal.FooterRow.FindControl("txtGoalName");

                ETDL.tGoal myGoal = new ETDL.tGoal();
                if (myGoalName.Text != "")
                {
                    //myGoal.GoalID = myGoalList.Count + 1;
                    myGoal.GoalName = myGoalName.Text;
                    myGoal.Goal_ProjectID = myProjID;// ETDL.tProjectData.myGetLastID()+1;
                    myGoal.GoalDMLactionUID = int.Parse(Session["mCurrentUID"].ToString());
                    myGoalList.Add(myGoal);
                    GridViewGoal.DataSource = myGoalList;
                    GridViewGoal.DataBind();
                    Session["myGoal"] = myGoalList;
                    //myGoal.Create();
                    //lblMessage.Text = "تمت الاضافة";
                    //ModalPopupExtender.Show();
                }
                else if (myGoalName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('أدخل البيانات أولاً');", true);
                    return;

                }
                //mShowGoal();
            }
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('حدث خطاء');", true);
            return;
        }
    }
    protected void GridViewGoal_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewGoal.PageIndex = e.NewPageIndex;
        mShowGoal();
    }

    //Abbrivates
    private void mShowAbbrivate()
    {
        if (!IsPostBack)
            ETDL.tAbbreviate.FillList(myAbbrivateList, "Abbreviate_ProjectID=" + myProjID + "");
        else
            myAbbrivateList = (List<ETDL.tAbbreviate>)(Session["myAbbrivate"]);
        if (myAbbrivateList.Count == 0) myAbbrivateList.Add(new ETDL.tAbbreviate());
        GridViewAbbrivate.DataSource = myAbbrivateList;
        GridViewAbbrivate.DataBind();
        if (!IsPostBack)
            Session["myAbbrivate"] = myAbbrivateList;
    }
    protected void GridViewAbbrivate_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer && e.Row.RowType != DataControlRowType.Pager)
        {
            LinkButton lblTagLink = new LinkButton();
            lblTagLink = (LinkButton)e.Row.FindControl("lnkAbbDelete");
            lblTagLink.CommandArgument = e.Row.RowIndex.ToString();
        }
    }
    protected void GridViewAbbrivate_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "MyDelete")
            {

                int myIndex = int.Parse(e.CommandArgument.ToString());
                myAbbrivateList.RemoveAt(myIndex);
                GridViewAbbrivate.DataSource = myAbbrivateList;
                GridViewAbbrivate.DataBind();
                Session["myAbbrivate"] = myAbbrivateList;
            }
            else if (e.CommandName == "MySelect")
            {

                // mShowAbbrivateEvalPartsData(int.Parse(e.CommandArgument.ToString()));
            }
            else if (e.CommandName == "MyAdd")
            {

                TextBox myAbbrName = (TextBox)GridViewAbbrivate.FooterRow.FindControl("txtAbbrName");
                ETDL.tAbbreviate myAbbr = new ETDL.tAbbreviate();
                if (myAbbrName.Text != "")
                {
                    if (txtUpdateDate.DateHijriAsNumber != 0)
                    {
                        myAbbr.AbbreviateName = myAbbrName.Text;
                        myAbbr.Abbreviate_ProjectID = myProjID;
                        myAbbr.AbbreviateUpdateDate = txtUpdateDate.Date;
                        myAbbr.AbbreviateUpdateDateHijri = txtUpdateDate.DateHijriAsNumber;
                        myAbbr.AbbreviateDMLactionUID = int.Parse(Session["mCurrentUID"].ToString());
                        // ETDL.tProjectData.myGetLastID()+1;
                        //myAbbr.Create();
                        //myAbbr = null;
                        myAbbrivateList.Add(myAbbr);
                        GridViewAbbrivate.DataSource = myAbbrivateList;
                        GridViewAbbrivate.DataBind();
                        Session["myAbbrivate"] = myAbbrivateList;
                        //lblMessage.Text = "تمت الاضافة";
                        //ModalPopupExtender.Show();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('أدخل تاريخ التعديل');", true);
                        return;

                    }

                }
                else if (myAbbrName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('أدخل البيانات أولاً');", true);
                    return;

                }
                //mShowAbbrivate();
            }
        }

        catch (Exception ex)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('حدث خطاء');", true);
            return;
        }
    }
    protected void GridViewAbbrivate_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewAbbrivate.PageIndex = e.NewPageIndex;
        mShowAbbrivate();
    }

    //Constraints
    private void mShowConstaints()
    {
        if (!IsPostBack)
            ETDL.tConstraint.FillList(myConstraintList, "Constraint_ProjectID=" + myProjID + "");
        else
            myConstraintList = (List<ETDL.tConstraint>)(Session["myConstraint"]);
        if (myConstraintList.Count == 0) myConstraintList.Add(new ETDL.tConstraint());
        GridViewConstraint.DataSource = myConstraintList;
        GridViewConstraint.DataBind();
        if (!IsPostBack)
            Session["myConstraint"] = myConstraintList;
    }
    protected void GridViewConstraint_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer && e.Row.RowType != DataControlRowType.Pager)
        {
            LinkButton lblTagLink = new LinkButton();
            lblTagLink = (LinkButton)e.Row.FindControl("lnkDeleteCons");
            lblTagLink.CommandArgument = e.Row.RowIndex.ToString();
        }
    }
    protected void GridViewConstraint_RowCommand1(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "MyDelete")
            {
                int myIndex = int.Parse(e.CommandArgument.ToString());
                myConstraintList.RemoveAt(myIndex);
                GridViewConstraint.DataSource = myConstraintList;
                GridViewConstraint.DataBind();
                Session["myConstraint"] = myConstraintList;

            }
            else if (e.CommandName == "MySelect")
            {

                // mShowAbbrivateEvalPartsData(int.Parse(e.CommandArgument.ToString()));
            }
            else if (e.CommandName == "MyAdd")
            {

                TextBox myConsName = (TextBox)GridViewConstraint.FooterRow.FindControl("txtConsName");
                TextBox myConsReq = (TextBox)GridViewConstraint.FooterRow.FindControl("txtConsReq");
                TextBox myConsResponsible = (TextBox)GridViewConstraint.FooterRow.FindControl("txtConsResponsible");

                CheckBox myIsSolved = (CheckBox)GridViewConstraint.FooterRow.FindControl("ChIsSolved");



                ETDL.tConstraint myCons = new ETDL.tConstraint();
                if (myConsName.Text != "")
                {

                    if (txtConsDate.DateHijriAsNumber != 0)
                    {
                        myCons.ConstraintName = myConsName.Text;
                        myCons.Constraint_ProjectID = myProjID;
                        myCons.ConstraintPlanDate = txtConsPlanDate.Date;
                        myCons.ConstraintPlanDateHijri = txtConsPlanDate.DateHijriAsNumber;
                        if (txtConsDate.Date != null)
                        {
                            myCons.ConstraintDate = txtConsDate.Date;
                            myCons.ConstraintDateHijri = txtConsDate.DateHijriAsNumber;
                        }
                        if (txtConsDateAlter.Text != "")
                            myCons.ConstraintDatetxt = txtConsDateAlter.Text;
                        myCons.ConstraintRequiredSolution = myConsReq.Text;
                        myCons.ConstraintResponsibleName = myConsResponsible.Text;
                        myCons.ConstraintIsNeedMayor = ChbIsNeddMayor.Checked;
                        myCons.ConstraintDMLactionUID = int.Parse(Session["mCurrentUID"].ToString());
                        if (txtConsRequriedFromMayor.Text != "")
                            myCons.ConstraintNeedMayor = txtConsRequriedFromMayor.Text;
                        myCons.ConstraintIsSolved = myIsSolved.Checked;
                        myConstraintList.Add(myCons);
                        GridViewConstraint.DataSource = myConstraintList;
                        GridViewConstraint.DataBind();
                        Session["myConstraint"] = myConstraintList;
                        //lblMessage.Text = "تمت الاضافة";
                        //ModalPopupExtender.Show();
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('أدخل تاريخ ظهور المعوق');", true);
                        return;
                    }

                }
                else if (myConsName.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('أدخل البيانات أولا');", true);
                    return;
                }
                //mShowConstaints();
            }
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('حدث خطاء');", true);
            return;
        }
    }
    protected void GridViewConstraint_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridViewConstraint.PageIndex = e.NewPageIndex;
        mShowConstaints();
    }

    //Tasks
    private void mShowTask()
    {

        if (!IsPostBack)
            ETDL.tTask.FillList(myTaskList, "Task_ProjectID=" + myProjID + "");
        else
            myTaskList = (List<ETDL.tTask>)(Session["myTask"]);
        if (myTaskList.Count == 0) myTaskList.Add(new ETDL.tTask());
        GridViewTask.DataSource = myTaskList;
        GridViewTask.DataBind();
        if (!IsPostBack)
            Session["myTask"] = myTaskList;
    }
    protected void BtnAddUser_Click(object sender, EventArgs e)
    {
        DLTaskUser.SelectedIndex = -1;
        txtTaskUser.Visible = !txtTaskUser.Visible;
        if (txtTaskUser.Visible == false)
            txtTaskUser.Text = "";
    }
    protected void BtnAddTask_Click(object sender, ImageClickEventArgs e)
    {
        if (txtTaskDate.Date == null || txtTaskName.Text == "" || txtTaskPlanDate.Date == null)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('أكمل البيانات اولا');", true);
            return;
        }
        else
        {
            ETDL.tTask myTask = new ETDL.tTask();
            myTask.TaskName = txtTaskName.Text;
            myTask.Task_ProjectID = myProjID;
            if (DLTaskUser.SelectedValue != "0")
                myTask.Task_UserID = int.Parse(DLTaskUser.SelectedValue);
            if (txtTaskUser.Text == "")
                myTask.TaskUser = txtTaskUser.Text;
            if (txtTaskReson.Text != "")
                myTask.TaskDelayReson = txtTaskReson.Text;
            myTask.TaskIsAchived = ChbISAchived.Checked;
            myTask.TaskActualDate = txtTaskDate.Date;
            myTask.TaskActualDateHijri = txtTaskDate.DateHijriAsNumber;
            myTask.TaskPlanDate = txtTaskPlanDate.Date;
            myTask.TaskPlanDateHijri = txtTaskPlanDate.DateHijriAsNumber;
            myTask.TaskDMLactionUID = int.Parse(Session["mCurrentUID"].ToString());
            myTaskList.Add(myTask);
            Session["myTask"] = myTaskList;
            GridViewTask.DataSource = myTaskList;
            GridViewTask.DataBind();
        }
    }
    protected void GridViewTask_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {
        GridViewTask.PageIndex = e.NewPageIndex;
        mShowTask();
    }
    protected void GridViewTask_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "MyDelete")
            {

                int myIndex = int.Parse(e.CommandArgument.ToString());
                myTaskList.RemoveAt(myIndex);
                GridViewTask.DataSource = myTaskList;
                GridViewTask.DataBind();
                Session["myTask"] = myTaskList;

            }
            //else if (e.CommandName == "MySelect")
            //{

            //    // mShowAbbrivateEvalPartsData(int.Parse(e.CommandArgument.ToString()));
            //}
            //else if (e.CommandName == "MyAdd")
            //{
            //    //if (myPre.basicData_Add == false)
            //    //{
            //    //    lblMessage.Text = "ليس لديك صلاحية للاضافة";
            //    //    return;
            //    //}


            //    TextBox myConsName = (TextBox)GridViewConstraint.FooterRow.FindControl("txtConsName");
            //    TextBox myConsReq = (TextBox)GridViewConstraint.FooterRow.FindControl("txtConsReq");
            //    TextBox myConsResponsible = (TextBox)GridViewConstraint.FooterRow.FindControl("txtConsResponsible");

            //    //DropDownList myCmbClass = (DropDownList)myGrid.FooterRow.FindControl("cmbClasses");

            //    //if (myEvName.Text.Trim() == "" || myCmbClass.SelectedValue == "0")
            //    //{
            //    //    lblMessage.Text = "فضلا أدخل اسم التقيم واختر الفئة";
            //    //    return;
            //    //}

            //    ETDL.tConstraint myCons = new ETDL.tConstraint();
            //    if (myConsName.Text != "")
            //    {
            //        if (txtUpdateDate.DateHijriAsNumber != 0)
            //        {
            //            myCons.ConstraintName = myConsName.Text;
            //            myCons.Constraint_ProjectID = myProjID;
            //            myCons.ConstraintPlanDate = txtUpdateDate.Date;
            //            myCons.ConstraintPlanDateHijri = txtUpdateDate.DateHijriAsNumber;
            //            // ETDL.tProjectData.myGetLastID()+1;
            //            myCons.Create();
            //            myCons = null;
            //            lblMessage.Text = "تمت الاضافة";
            //            ModalPopupExtender.Show();
            //        }
            //        else
            //        {
            //            lblMessage.Text = "أدخل تاريخ التعديل";
            //            ModalPopupExtender.Show();
            //        }

            //    }
            //    else if (myConsName.Text == "")
            //    {
            //        lblMessage.Text = "أدخل البيانات أولاً";
            //        ModalPopupExtender.Show();
            //    }
            //    mShowConstaints();
            //}
        }

        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('حدث خطاء');", true);
            return;

        }
    }
    protected void GridViewTask_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header && e.Row.RowType != DataControlRowType.Footer && e.Row.RowType != DataControlRowType.Pager)
        {
            LinkButton lblTagLink = new LinkButton();
            lblTagLink = (LinkButton)e.Row.FindControl("lnkDeleteTask");
            lblTagLink.CommandArgument = e.Row.RowIndex.ToString();
            if ((bool)(DataBinder.Eval(e.Row.DataItem, "TaskIsAchived")) == true)
            {
                e.Row.BackColor = System.Drawing.Color.LightGreen;
            }
            else
            {
                if ((DateTime)(DataBinder.Eval(e.Row.DataItem, "TaskPlanDate")) < System.DateTime.Now)
                    e.Row.BackColor = System.Drawing.Color.LightPink;
                else
                    e.Row.BackColor = System.Drawing.Color.LightBlue;
            }

            //If (e.Row.DataItem("UnitsInStock") < 20) Then

            // e.Row.BackColor = Drawing.Color.Red
        }
    }
    //Sav all data
    protected void ImgBtnSave_Click(object sender, ImageClickEventArgs e)
    {
        foreach (ETDL.tPermission mper in myPre)
        {
            if (mper.Permission_DepartmentID != 0)
            {
                if (mper.Permission_DepartmentID == myDepID)
                {
                    if (mper.PermissionUpdate == false)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('لا يوجد لك صلاحيه لإضافة أو تعديل البيانات');", true);
                        return;


                    }

                }

            }
        }

        try
        {
            if (TxtProjectName.Text == "" || DlDep.SelectedValue == "0" || txtEndDate.Date == null || txtStartDate.Date == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('أدخل البيانات اولاً');", true);
                return;
            }
            else
            {
                ETDL.tProjectData myProject;
                if (Session["ProjectID"] == null)
                    myProject = new ETDL.tProjectData();
                else
                    myProject = new ETDL.tProjectData(int.Parse(Session["ProjectID"].ToString()));
                // insert DropDownlists
                if (DlDep.SelectedValue != "0")
                    myProject.ProjectData_DepartmentID = int.Parse(DlDep.SelectedValue);
                if (DlProgressType.SelectedValue != "0")
                    myProject.ProjectData_ProgressTypeID = int.Parse(DlProgressType.SelectedValue);
                if (RbProject.Checked == true)
                    myProject.ProjectData_ProjectType = 1;
                if (RbTask.Checked == true)
                    myProject.ProjectData_ProjectType = 2;
                if (RbMubadrah.Checked == true)
                    myProject.ProjectData_ProjectType = 3;
                // insert Dates
                myProject.ProjectDataStartDate = txtStartDate.Date;
                myProject.ProjectDataStartDateHijri = txtStartDate.DateHijriAsNumber;
                myProject.ProjectDataEndDate = txtEndDate.Date;
                myProject.ProjectDataEndDateHijri = txtEndDate.DateHijriAsNumber;
                myProject.ProjectDataActualStartDate = txtActualStartDate.Date;
                myProject.ProjectDataActualStartDateHijri = txtActualStartDate.DateHijriAsNumber;
                myProject.ProjectDataActualEndDate = txtActualEndDate.Date;
                myProject.ProjectDataActualEndDateHijri = txtActualEndDate.DateHijriAsNumber;
                // insert TextBoxs

                if (TxtBudjet.Text != "" && TxtPaidValue.Text != "")
                {
                    int mbudg = int.Parse(TxtBudjet.Text);
                    int mPaValue = int.Parse(TxtPaidValue.Text);

                    if (mbudg < mPaValue)
                    {
                        lblMessage.Text = "تأكد من قيم أدخال الميزانية والقيمة المدفوعه";
                        ModalPopupExtender.Show();
                    }
                    else
                    {
                        myProject.ProjectDataBudget = Convert.ToInt32(TxtBudjet.Text);
                        myProject.ProjectDataPaiedValue = Convert.ToInt32(TxtPaidValue.Text);
                    }
                }

                myProject.ProjectDataContractor = TxtContractor.Text;
                myProject.ProjectDataManager = TxtManager.Text;
                myProject.ProjectDataName = TxtProjectName.Text;

                myProject.ProjectDataProgram = TxtProgram.Text;
                myProject.ProjectDataSponsor = TxtProjectSponser.Text;
                // Insert Progress
                if (DlProgressType.SelectedValue == "1")
                {
                    myProject.ProjectData_ProgressTypeID = int.Parse(DlProgressType.SelectedValue);
                    double myFinalRes = (100 / (myProject.ProjectDataBudget / myProject.ProjectDataPaiedValue));
                    if (myFinalRes > 100.0)
                        myProject.ProjectDataProgress = "100";
                    else
                        myProject.ProjectDataProgress = myFinalRes.ToString();
                }
                DateTime myCurrentdate = System.DateTime.Now.Date;
                double mRegisrationDate = ETDL.tProjectData.DateDiff(myProject.ProjectDataStartDate.Date, myProject.ProjectDataEndDate.Date);
                double myFinalDate = ETDL.tProjectData.DateDiff(myProject.ProjectDataStartDate.Date, myCurrentdate);
                if (DlProgressType.SelectedValue == "2")
                {
                    myProject.ProjectData_ProgressTypeID = int.Parse(DlProgressType.SelectedValue);
                    double myFinalRes = (100 / (mRegisrationDate / (myFinalDate)));
                    if (myFinalRes > 100.0)
                        myProject.ProjectDataProgress = "100";
                    else
                        myProject.ProjectDataProgress = myFinalRes.ToString();
                }
                myProject.ProjectDataDMLactionUID = int.Parse(Session["mCurrentUID"].ToString());
                //myProject.ProjectOrder
                //myProject.ProjectDescription = txtDescribtion.Text;
                if (Session["ProjectID"] != null)
                    myProject.Update();
                else
                {
                    myProject.Create();
                    Session["ProjectID"] = ETDL.tProjectData.myGetLastID();
                    ETDL.tPermission myPermition = new ETDL.tPermission();

                    myPermition.Permission_UserID = int.Parse(Session["mCurrentUID"].ToString());
                    if (DlDep.SelectedValue != "0")
                        myPermition.Permission_DepartmentID = int.Parse(DlDep.SelectedValue);
                    myPermition.PermissionAdd = true;
                    myPermition.PermissionCreateReport = true;
                    myPermition.PermissionDelete = true;
                    myPermition.PermissionUpdate = true;
                    myPermition.PermissionView = true;

                    myPermition.Create();
                    myPermition = null;

                }

                myProject = null;
                mshow();
                mCreateTempToDatabase();
            }
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
            ModalPopupExtender.Show();
        }



    }
    protected void BtnLogOut_Click(object sender, ImageClickEventArgs e)
    {
        Session.Clear();
        Response.Redirect("Default.aspx");
    }
    protected void DlProgressType_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (DlProgressType.SelectedValue == "1")
        {

            if ((int.Parse(TxtBudjet.Text)) < (int.Parse(TxtPaidValue.Text)))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('القيمة المدفوعة لابد أن تكون أقل من ميزانية المشروع');", true);
                return;
            }
            else
            {
                double myFinalRes = (100.0 / (double.Parse(TxtBudjet.Text) / double.Parse(TxtPaidValue.Text)));
                if (myFinalRes > 100.0)
                    TxtProgress.Text = "100";
                else
                    TxtProgress.Text = myFinalRes.ToString();
            }
        }
        DateTime myCurrentdate = System.DateTime.Now.Date;
        double mRegisrationDate = ETDL.tProjectData.DateDiff(txtStartDate.Date, txtEndDate.Date);
        double myFinalDate = ETDL.tProjectData.DateDiff(txtStartDate.Date, myCurrentdate);
        if (DlProgressType.SelectedValue == "2")
        {

            double myFinalRes = (100 / (mRegisrationDate / (myFinalDate)));
            if (myFinalRes > 100.0)
                TxtProgress.Text = "100";
            else
                TxtProgress.Text = myFinalRes.ToString();
        }
        if (TxtProgress.Text.Length > 5 && TxtProgress.Text != "100")
            TxtProgress.Text = TxtProgress.Text.Substring(0, 5);
    }
    protected void BtnAddConsDate_Click(object sender, EventArgs e)
    {
        txtConsDate.ClearText();
        txtConsDateAlter.Visible = !txtConsDateAlter.Visible;
        if (txtConsDateAlter.Visible == false)
            txtConsDateAlter.Text = "";
    }
    protected void ChbIsNeddMayor_CheckedChanged(object sender, EventArgs e)
    {
        if (ChbIsNeddMayor.Checked == true)
        {
            DivmayorNeed.Visible = true;
            txtConsRequriedFromMayor.Text = "";
        }
        else
            DivmayorNeed.Visible = false;
    }
}
