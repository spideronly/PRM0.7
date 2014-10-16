using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
            if (Session["mCurrentUID"] == null)
            {
                myDiv.Visible = false;
               

            }
            else
            {
                myDiv.Visible = true;
                lblName.Text = "مرحباً " + Session["mCurrentUDisplayName"].ToString();
                mShowImg(int.Parse(Session["mCurrentUID"].ToString()));
            }
     
       

        //if (Session["mCurrentUID"] != null)
        //{
        //    ETDL.Users myUser = new ETDL.Users(int.Parse(Session["mCurrentUID"].ToString()));
        //    if (myUser.PermID == 1 )
        //    {
        //        HLAdministration.Enabled = false;
        //        HLEnterData.Enabled = false;
        //        HLHome.Enabled = false;
        //    }
        //    else if (myUser.PermID == 2 || myUser.PermID == 3 || myUser.PermID == 4)
        //    {
        //        HLAdministration.Enabled = true;
        //        HLEnterData.Enabled = true;
        //        HLHome.Enabled = true;
        //    }
        //}
       
    }
    public void mShowImg(int EmpID)
    {
        // be careful , here is trick
        ETDL.tUser myUser = new ETDL.tUser(EmpID);
        if (ETDL.UserPic.GetUserPicIDByUserID(myUser.UserID) > 0)
            divEmpImage.InnerHtml = "<img src=\"GetUserImage.aspx\" alt=\"...\" height=\"139px\" width=\"135px\" />";
        else
            divEmpImage.InnerHtml = "";
        myUser = null;
    }
    protected void BtnLogOut_Click(object sender, ImageClickEventArgs e)
    {
        Session.Clear();
        Response.Redirect("Default.aspx");
       
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
       
        ClearSession();
        Response.Redirect("Department.aspx");

    }
    protected void LBPermission_Click(object sender, EventArgs e)
    {
        
        ClearSession();
        Response.Redirect("Permission.aspx");
    }
    protected void LBAddnew_Click(object sender, EventArgs e)
    {
        
        ClearSession();
        Response.Redirect("AddNew.aspx");
    }
    protected void LBHome_Click(object sender, EventArgs e)
    {
       
        ClearSession();
        Response.Redirect("Home.aspx");

    }
    private void ClearSession()
    {
        Session["myGoal"] = null;
        Session["myAbbrivate"] = null;
        Session["myConstraint"] = null;
        Session["myTask"] = null;
        Session["ProjectID"] = null;
        Session["myDepID"] = null;
    }
    protected void BtnReport_Click(object sender, EventArgs e)
    {
        ClearSession();
        Response.Redirect("Report.aspx");
    }
}
