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

public partial class Home : myFilteredPage
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ETDL.tDepartment.FillTreeView(this.TreeView1);
            TreeView1.ExpandDepth = 2;
        }
        
    }
    private void mShow()
    {
        int mDepID = int.Parse(Session["myDepID"].ToString());
        List<ETDL.tProjectData> myList = new List<ETDL.tProjectData>();
        ETDL.tProjectData.FillList(myList, "ProjectData_DepartmentID=" + mDepID + "");
        GridView1.DataSource = myList;
        GridView1.DataBind();
    }
    
    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (TreeView1.SelectedNode.Value == "0")
        {
            GridView1.Visible = false;
            return;
        }
        else
            GridView1.Visible = true;
        int myDepID = int.Parse(TreeView1.SelectedNode.Value);
        Session["myDepID"] = myDepID;
        mShow();
       
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        
        mShow();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "MyDelete")
        {
            ETDL.tProjectData myproject = new ETDL.tProjectData(int.Parse(e.CommandArgument.ToString()));
            myproject.Delete();
          
            mShow();
        }
        
        if (e.CommandName == "MySelect")
        {
            ETDL.tProjectData myproject = new ETDL.tProjectData(int.Parse(e.CommandArgument.ToString()));
            foreach (ETDL.tPermission mper in myPre)
            {
                if (mper.Permission_DepartmentID != 0)
                {
                    if (mper.Permission_DepartmentID == myproject.ProjectData_DepartmentID)
                    {
                        if (mper.PermissionView == true)
                        {
                            Session["ProjectID"] = int.Parse(e.CommandArgument.ToString());
                            Response.Redirect("AddNew.aspx");

                            //Response.Redirect("Default3.aspx");
                        }
                        else
                        {
                            
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('ليس لديك الصلاحيه على مشاريع هذا القسم');", true);
                            return;

                        }

                    }

                }
                
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "gg1", "alert('ليس لديك الصلاحيه على مشاريع هذا القسم');", true);
            return;

            
            
        }
        if (e.CommandName == "MyUpdate")
        {
            Session["ProjectID"] = int.Parse(e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mpar", "window.open('Default3.aspx','المشاريع','status=1,resizable=1,width=1000,height=900,scrollbars=1');", true);
   
        }
        if (e.CommandName == "MyPrint")
        {
            Session["ProjectID"] = int.Parse(e.CommandArgument.ToString());
            ScriptManager.RegisterStartupScript(this, this.GetType(), "mpar", "window.open('FullData.aspx','المشاريع','status=1,resizable=1,width=1000,height=900,scrollbars=1');", true);
            //Stimulsoft.Report.StiReport mRep = new Stimulsoft.Report.StiReport();
            //mRep.Load(Server.MapPath("~/Reports/ReportCreator.mrt"));
            //mRep.Compile();

            //ETDL.vReport mRec = new ETDL.vReport();


            //mRep.RegData("ReportCreator", mRec);

            //mRep.Render();

            //myReportHelper.DownloadReportAsPdf(mRep, "اقرار");
        }
    }
}
