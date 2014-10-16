using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
        //((Panel)Master.FindControl("PanelNav")).Visible = false;
        ((ImageButton)Master.FindControl("BtnLogOut")).Visible = false;
      
            if (Request.QueryString["AutoLogin"] != null)
            {
                string DomainUser = System.Web.HttpContext.Current.User.Identity.Name.ToLower().Replace(@"jeddah\", "");

                int mRet = ETDL.tUser.CheckLoginIfFromSingleScreen(DomainUser);
                if (mRet > 0)
                {
                    try
                    {
                        Session["mCurrentUID"] = mRet;
                        Session["mCurrentUDisplayName"] = ETDL.tUser.GetLoginUserDisplayName(mRet);
                        int myPerID = ETDL.tUser.myGetPermissionByUserID(mRet);
                        Session["mCurrentUPermissions"] = new ETDL.tPermission(myPerID);
                    }
                    catch
                    {
                        mErrorInLogin();
                    }

                    if (Session["mCurrentUID"] != null )
                        Response.Redirect("Home.aspx", true);
                    else
                        mErrorInLogin();


                }
            }
        
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        
        if (TxtLoginInUser.Text == "" || TxtLogInPass.Text == "")
        {
            lblMessage.ForeColor = System.Drawing.Color.Red;
            lblMessage.Text = "ادخل اسم المستخدم وكلمه المرور اولاً";
        }
        else
        {
            int mRet = ETDL.tUser.CheckLogin(TxtLoginInUser.Text, TxtLogInPass.Text);
            if (mRet > 0)
            {
                try
                {
                    Session["mCurrentUID"] = mRet;
                    Session["mCurrentUDisplayName"] = ETDL.tUser.GetLoginUserDisplayName(mRet);
                    //int myPerID = ETDL.tUser.myGetPermissionByUserID(mRet);
                    List<ETDL.tPermission> myPermissionList = new List<ETDL.tPermission>();
                    ETDL.tPermission.FillList(myPermissionList, "Permission_UserID=" + mRet + "");
                    Session["mCurrentUPermissions"] = myPermissionList;
                    ETDL.tUser myUser;
                    Session["mPermission"] = new ETDL.tUser(mRet); 
                    //int myroleID =ETDL.tUser.myGetUserRoleByUserID(mRet);
                    //Session["mCurrentUPermissions"] = new ETDL.Roles(myroleID);
                    //Session["mCurrentUPermissions"] = new ETDL.tUser(mRet);
                }
                catch
                {
                    mErrorInLogin();
                }

                if (Session["mCurrentUID"] != null)
                    Response.Redirect("Home.aspx", true);
                else
                    mErrorInLogin();


            }
            else
                mErrorInLogin();

        }
    }
    private void mErrorInLogin()
    {
        Session["mCurrentUID"] = null;
        Session["mCurrentUDisplayName"] = null;
       //Session["mCurrentUPermissions"] = null;
       

        lblMessage.ForeColor = System.Drawing.Color.Red;
        lblMessage.Text = "الاسم أو كلمة المرور غير صحيحة <br/>او انه ليس لديك صلاحيه الدخول";
        //+ "<br /><br />" + "أو ان المستخدم لم يتم تفعيله أو اعطاءه صلاحيات حتى الأن";
    }
}
