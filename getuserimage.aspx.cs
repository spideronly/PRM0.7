using System;
using System.Collections;
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

public partial class GetUserImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["mCurrentUID"] == null)
            Response.Redirect("Default.aspx");
       
        Response.Clear();
        Response.ContentType = "image/png";

        if (Session["mCurrentUID"] != null)
        {
            //mShowData(int.Parse(Session["mCurrentEmp"].ToString()));
            ETDL.UserPic myUserPic;
            int mUserPicID = ETDL.UserPic.GetUserPicIDByUserID(int.Parse(Session["mCurrentUID"].ToString()));

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
}
