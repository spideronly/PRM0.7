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

public partial class Department : myFilteredPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (myUserPre.UserBasicShow != true)
        {
            divAllData.Visible = false;
            divPrm.Visible = true;
        }
        if (!this.IsPostBack)
        {
            ETDL.tDepartment.FillTreeView(this.TreeView1);
            TreeView1.ExpandDepth = 2;
        }
    }
    //my methods
    private void mClear()
    {
        txtDepName.Text = "";
 
    }
    private bool mCheckNode()
    {
        if (TreeView1.SelectedNode == null)
        {
            lblMeessage.Text = "اختر القسم الذي تريده أولا";
            return false;
        }

        if (TreeView1.SelectedNode.Value == "0")
        {
            lblMeessage.Text = "هذا القسم لا يمكن حذفه أو تعديله";
            return false;
        }

        return true;

    }

    protected void TreeView1_SelectedNodeChanged(object sender, EventArgs e)
    {
        mClear();

        if (TreeView1.SelectedNode.Value == "0") return;

        //txtDepName.Text = TreeView1.SelectedNode.Text;

        ETDL.tDepartment myDep = new ETDL.tDepartment(int.Parse(TreeView1.SelectedNode.Value));
        txtDepName.Text = myDep.DepartmentName;
       
    }
    private void mShowTreeNode(TreeNode myNode)
    {
        myNode.Expand();
        if (myNode.Parent != null)
            mShowTreeNode(myNode.Parent);
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (TreeView1.SelectedNode == null)
        {
            lblMeessage.Text = "اختر القسم الرئيسي أولا";
            return;
        }

        ETDL.tDepartment myDep = new ETDL.tDepartment();
        try
        {
            myDep.DepartmentName = txtDepName.Text;
            myDep.DepartmentParentID = int.Parse(TreeView1.SelectedNode.Value);
            myDep.DepartmentDMLactionUID = int.Parse(Session["mCurrentUID"].ToString());
            myDep.Create();

            string mValuePath = TreeView1.SelectedNode.ValuePath;

            ETDL.tDepartment.FillTreeView(this.TreeView1);

            mShowTreeNode(TreeView1.FindNode(mValuePath));

            mClear();
            lblMeessage.Text = "تمت الاضافة";
        }
        catch (Exception ex)
        {
            lblMeessage.Text = ex.Message;
        }
        finally
        {
            myDep = null;
        }

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        if (mCheckNode() == false) return;

        try
        {
            ETDL.tDepartment myDep = new ETDL.tDepartment(int.Parse(TreeView1.SelectedNode.Value));
            myDep.DepartmentDMLactionUID = int.Parse(Session["mCurrentUID"].ToString());

            myDep.Delete();
            myDep = null;

            string mValuePath = TreeView1.SelectedNode.Parent.ValuePath;

            ETDL.tDepartment.FillTreeView(this.TreeView1);

            mShowTreeNode(TreeView1.FindNode(mValuePath));

            mClear();
            lblMeessage.Text = "تم الحذف";
        }
        catch (Exception ex)
        {
            lblMeessage.Text = ex.Message;
        }

    }
    protected void btnEdit_Click(object sender, EventArgs e)
    {
        if (mCheckNode() == false) return;

        try
        {
            ETDL.tDepartment myDep = new ETDL.tDepartment(int.Parse(TreeView1.SelectedNode.Value));

           

            myDep.DepartmentName = txtDepName.Text;

            myDep.DepartmentDMLactionUID = int.Parse(Session["mCurrentUID"].ToString());

            myDep.Update();
            myDep = null;

            string mValuePath = TreeView1.SelectedNode.Parent.ValuePath;

            ETDL.tDepartment.FillTreeView(this.TreeView1);

            mShowTreeNode(TreeView1.FindNode(mValuePath));

            mClear();
            lblMeessage.Text = "تم التعديل";
        }
        catch (Exception ex)
        {
            lblMeessage.Text = ex.Message;
        }
    }
    protected void btnRight_Click(object sender, ImageClickEventArgs e)
    {
        if (mCheckNode() == false) return;

        try
        {
            ETDL.tDepartment.MoveRight(int.Parse(TreeView1.SelectedNode.Value));

            string mValuePath = TreeView1.SelectedNode.Parent.ValuePath;

            ETDL.tDepartment.FillTreeView(this.TreeView1);

            mShowTreeNode(TreeView1.FindNode(mValuePath));

            mClear();
            lblMeessage.Text = "تم تعديل التسلسل الاداري";
        }
        catch (Exception ex)
        {
            lblMeessage.Text = ex.Message;
        }
    }
    protected void btnMoveLeft_Click(object sender, ImageClickEventArgs e)
    {
        if (mCheckNode() == false) return;

        try
        {
            ETDL.tDepartment.MoveLeft(int.Parse(TreeView1.SelectedNode.Value));

            string mValuePath = TreeView1.SelectedNode.Parent.ValuePath;

            ETDL.tDepartment.FillTreeView(this.TreeView1);

            mShowTreeNode(TreeView1.FindNode(mValuePath));

            mClear();
            lblMeessage.Text = "تم تعديل التسلسل الاداري";
        }
        catch (Exception ex)
        {
            lblMeessage.Text = ex.Message;
        }
    }
    protected void btnMoveUp_Click(object sender, ImageClickEventArgs e)
    {
        if (mCheckNode() == false) return;
        
        try
        {
            ETDL.tDepartment.MoveUp(int.Parse(TreeView1.SelectedNode.Value));

            string mValuePath = TreeView1.SelectedNode.Parent.ValuePath;

            ETDL.tDepartment.FillTreeView(this.TreeView1);

            mShowTreeNode(TreeView1.FindNode(mValuePath));

            mClear();
            lblMeessage.Text = "تم تعديل التسلسل الاداري";
        }
        catch (Exception ex)
        {
            lblMeessage.Text = ex.Message;
        }
    }
    protected void btnMoveDown_Click(object sender, ImageClickEventArgs e)
    {
        if (mCheckNode() == false) return;

        try
        {
            ETDL.tDepartment.MoveDown(int.Parse(TreeView1.SelectedNode.Value));

            string mValuePath = TreeView1.SelectedNode.Parent.ValuePath;

            ETDL.tDepartment.FillTreeView(this.TreeView1);

            mShowTreeNode(TreeView1.FindNode(mValuePath));

            mClear();
            lblMeessage.Text = "تم تعديل التسلسل الاداري";
        }
        catch (Exception ex)
        {
            lblMeessage.Text = ex.Message;
        }
    }
}


