using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class GetLoginImage : myFilteredPage // System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["mCurrentUID"] == null)
            Response.Redirect("Default.aspx");

        Response.ContentType = "image/png";

        int myReq = int.Parse(Request.QueryString["mID"].ToString());
        ETDL.UserPic myUserPic;
        //  ETDL.Message myMsg;
        int mUserPicID = ETDL.UserPic.GetUserPicIDByUserID(myReq);

        if (mUserPicID == 0)
            return;
        else
            myUserPic = new ETDL.UserPic(mUserPicID); //hrDAL.tEmpPicture.GetByEmpID(mUserPicID);

        Response.BinaryWrite(myUserPic.UserImage);
        Response.Flush();
        Response.End();
        myUserPic = null;
    }
}
