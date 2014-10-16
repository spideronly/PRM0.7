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

public partial class Report : myFilteredPage
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
            ETDL.tDepartment.FillTreeView(this.TreeView1);
            TreeView1.ExpandDepth = 2;
            mShowData();
            
        }
       
    }
    private void mShowData()
    {
        if (Session["mCurrentPro"] != null)
        {
            LblProjectName.Visible = true;
            int mProjectID = int.Parse(Session["mCurrentPro"].ToString());
            ETDL.tProjectData myPro = new ETDL.tProjectData(mProjectID);
            LblProjectName.Text ="إصدار تقرير خاص ب : "+ myPro.ProjectDataName;
            LinkButton2.Visible = true;
        }
        else
            LinkButton2.Visible = false;
    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (TreeView1.SelectedNode.Value == "0")
        {
            Session["myDepID"] = null;
        }

        else
        {
            int myDepID = int.Parse(TreeView1.SelectedNode.Value);
            Session["myDepID"] = myDepID;
        }

    }


    protected void BtnShow_Click(object sender, EventArgs e)
    {
        if (Session["myDepID"] == null)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('أختر القسم أولاً');", true);
            return;
        }
        else
        {
            if (DlExportType.SelectedValue != "0")
            {
                if (txtStartDate.Date < txtEndDate.Date)
                {
                    Stimulsoft.Report.StiReport mRep = new Stimulsoft.Report.StiReport();
                    mRep.Load(Server.MapPath("~/Reports/Report.mrt"));
                    mRep.Compile();
                    int.Parse(Session["myDepID"].ToString());
                   
                   
                    ETDL.vReport  myVRep = new ETDL.vReport(1);
                    List<ETDL.tGoal> myGoalList = new List<ETDL.tGoal>();
                    ETDL.tGoal.FillList(myGoalList, "Goal_ProjectID=" + 1 + "");

                    mRep.RegData("Report", myVRep);

                    mRep.Render();

                    if (DlExportType.SelectedValue != "2")
                        myReportHelper.DownloadReportAsWord(mRep, "تقرير");
                    if (DlExportType.SelectedValue != "1")
                        myReportHelper.DownloadReportAsPdf(mRep, "تقرير");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('تأكد  من تاريخ البدايه والنهايه');", true);
                    return;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('أختر نوع التصدير');", true);
                return;
            }
        }
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        myFindFrame.InnerHtml = "<iframe id=\"IframeEdit\" src=\"Search.aspx\" frameborder=\"0\" width=\"100%\" height=\"470px\" scrolling=\"no\"></iframe>";

        ModalPopupExtender1.Show();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Session["mCurrentPro"] = null;
        LblProjectName.Text = String.Empty;
        LinkButton2.Visible = false;
    }
}
