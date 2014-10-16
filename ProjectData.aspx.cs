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

public partial class ProjectData : myFilteredPage
{
    int myProjID;
    List<ETDL.tGoal> myGoalList = new List<ETDL.tGoal>();
    List<ETDL.tAbbreviate> myAbbrivateList = new List<ETDL.tAbbreviate>();
    List<ETDL.tConstraint> myConstraintList = new List<ETDL.tConstraint>();
    List<ETDL.tTask> myTaskList = new List<ETDL.tTask>();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
  
   
}
