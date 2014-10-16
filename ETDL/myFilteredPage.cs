using System;
using System.IO.Compression;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Codeproject.Compression;


public class myFilteredPage : Page
{
    protected List<ETDL.tPermission> myPre;
    protected ETDL.tUser myUserPre;
  

     
    protected override void OnInit(EventArgs e)
    {
        base.OnInit(e);

        this.Header.Controls.AddAt(0, new LiteralControl("<meta http-equiv=\"X-UA-Compatible\" content=\"IE=EmulateIE7\" />"));

        if (Request.Path.Contains("Default.aspx") == false)
        {
            if (Session["mCurrentUPermissions"] == null)
                Response.Redirect("~/Default.aspx", true);
            else
            {
                myPre = (List<ETDL.tPermission>)Session["mCurrentUPermissions"];
                myUserPre = (ETDL.tUser)Session["mPermission"];
            }
        }

      
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
    }

    
 

}
