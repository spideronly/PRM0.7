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

public partial class FullData : System.Web.UI.Page
{
    public ETDL.vReport myPro;
    public List<ETDL.tGoal> myGoalList = new List<ETDL.tGoal>();
    public List<ETDL.tTask> myTaskList= new List<ETDL.tTask>();
    public List<ETDL.tAbbreviate> myAbbList = new List<ETDL.tAbbreviate>();
    public List<ETDL.tConstraint> myConsList = new List<ETDL.tConstraint>();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ProjectID"] == null) Response.Redirect("Home.aspx");


        myPro = new ETDL.vReport((int)Session["ProjectID"]);
        ETDL.tGoal.FillList(myGoalList, "[Goal_ProjectID]=" + Session["ProjectID"].ToString());
        ETDL.tTask.FillList(myTaskList, "[Task_ProjectID]=" + Session["ProjectID"].ToString());
        ETDL.tAbbreviate.FillList(myAbbList, "[Abbreviate_ProjectID]=" + Session["ProjectID"].ToString());
        ETDL.tConstraint.FillList(myConsList, "[Constraint_ProjectID]=" + Session["ProjectID"].ToString());
        
    }
}
