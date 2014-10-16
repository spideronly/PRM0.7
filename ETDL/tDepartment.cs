
///////////////////////////////////////////////////
//
//			Mohammed Samir Fayed
//			ms_fayed@hotmail.com
//			18-05-2009   12:09 PM
//
///////////////////////////////////////////////////
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Web;
using System.Web.UI.WebControls;

namespace ETDL
{

    #region tDepartment
    /// <summary>
    /// This object represents the properties and methods of a ( tDepartment ) Table.
    /// </summary>
    public class tDepartment 
    {
        private const string mFields = "[DepartmentID],[DepartmentName],[DepartmentParentID],[DepartmentOrder],[DepartmentExternalCode]";

        #region Private Fields,ToString() Method

        private int _id;
        private string _DepartmentName = String.Empty;
        private int _DepartmentParentID;
        private int _DepartmentOrder;
        private string _DepartmentExternalCode;
       
        private int _DepartmentDMLactionUID;
       
        public override string ToString()
        {
            // the text that will be displayed in Listbox or Combobox
            return _DepartmentName;
        }

        #endregion

        #region Public Properties
        public int DepartmentID
        {
            get { return _id; }
        }

        
         public string DepartmentName
        {
            get { return _DepartmentName; }
            set { if (value.Length > 100) _DepartmentName = value.Substring(0, 100); else _DepartmentName = value; }
        }
        public int DepartmentParentID
        {
            get { return _DepartmentParentID; }
            set { _DepartmentParentID = value; }
        }

        public int DepartmentOrder
        {
            get { return _DepartmentOrder; }
            set { _DepartmentOrder = value; }
        }

        public string DepartmentExternalCode
        {
            get { return _DepartmentExternalCode; }
            set { if (value.Length > 50) _DepartmentExternalCode = value.Substring(0, 50); else _DepartmentExternalCode = value; }
        }

        
        public int DepartmentDMLactionUID
        {
            get { return _DepartmentDMLactionUID; }
            set { _DepartmentDMLactionUID = value; }
        }
      
        #endregion

        #region Constractors

        public tDepartment()
        {
        }

        public tDepartment(int id)
        {
            LoadFromID(id);
        }

        public tDepartment(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT {0} FROM [tDepartment] WHERE DepartmentID = {1}", mFields, id);
            DbDataReader reader = fayedDAL.ExecuteReader(mSql);

            if (reader.HasRows)
            {
                reader.Read();
                this.LoadFromReader(reader);
                reader.Close();
            }
            else
            {
                if (!reader.IsClosed) reader.Close();
                throw new ApplicationException("Selected tDepartment Row Does Not Exist.");
            }
        }

        protected void LoadFromReader(DbDataReader reader)
        {
            int colOrdinal;
            if (reader != null && !reader.IsClosed)
            {
                colOrdinal = reader.GetOrdinal("DepartmentID");
                _id = reader.GetInt32(colOrdinal);

                colOrdinal = reader.GetOrdinal("DepartmentName");
                if (!reader.IsDBNull(colOrdinal)) _DepartmentName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("DepartmentParentID");
                if (!reader.IsDBNull(colOrdinal)) _DepartmentParentID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("DepartmentOrder");
                if (!reader.IsDBNull(colOrdinal)) _DepartmentOrder = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("DepartmentExternalCode");
                if (!reader.IsDBNull(colOrdinal)) _DepartmentExternalCode = reader.GetString(colOrdinal);
               
              
            }
        }

        #endregion

        #region Create,Update,Delete


        public int Create()
        {
            if (this.DepartmentName == "")
                throw new Exception("يجب ادخال الاســم أولا");

            if (GetRowsCount(string.Format("[DepartmentName]='{0}' AND [DepartmentParentID]={1}", this.DepartmentName, this.DepartmentParentID.ToString())) > 0)
                throw new Exception("هذا القسم تم ادخاله مسبقا");

            //if (Department_displayOrder == 0)
            //{
            //    Department_displayOrder = int.Parse(fayedDAL.ExecuteScalar("select max(DepartmentID) from tDepartment").ToString()) + 1;
            //}

            DbCommand myCmd = fayedDAL.CreateCommand();
            string mCols, mValues = "";

            mCols = "[DepartmentName],[DepartmentParentID],[DepartmentOrder],[DepartmentExternalCode],[DepartmentDMLcreateUID],[DepartmentDMLcreateDate],[DepartmentDMLactionUID],[DepartmentDMLactionDate],[DepartmentDMLactionType]";

            mValues += string.Format("'{0}',", DepartmentName);
            mValues += string.Format("{0},", DepartmentParentID);
            mValues += string.Format("{0},", DepartmentOrder);
            mValues += string.Format("'{0}',", DepartmentExternalCode);


            mValues += string.Format("{0},", DepartmentDMLactionUID); //DMLcreateUID
            mValues += string.Format("{0},", "GetDate()"); //DMLcreateDate
            mValues += string.Format("{0},", DepartmentDMLactionUID); //OprationUID
            mValues += string.Format("{0},", "GetDate()"); //DMLDate
            mValues += string.Format("'{0}'", "Insert"); //DMLOperation

            string query = String.Format("INSERT INTO [tDepartment] ({0}) VALUES ({1})", mCols, mValues);
            myCmd.CommandText = query;

            bool mConState = fayedDAL.KeepConnection;
            fayedDAL.KeepConnection = true;
            int mRet = fayedDAL.ExecuteNonQuery(myCmd);
            _id = fayedDAL.GetLastID();
            fayedDAL.KeepConnection = mConState;
            return mRet;
        }

        public int Update()
        {

            if (_id == 0) throw new Exception("حدد القسم الذي تريد تعديله أولا");

            DbCommand myCmd = fayedDAL.CreateCommand();
            string mTemp = "";

            if (this.DepartmentName != "")
                mTemp += string.Format("[DepartmentName]='{0}',", DepartmentName);
            else return 0;
            mTemp += string.Format("[DepartmentParentID]={0},", DepartmentParentID);
            mTemp += string.Format("[DepartmentOrder]={0},", DepartmentOrder);
            mTemp += string.Format("[DepartmentExternalCode]='{0}',", DepartmentExternalCode);

            mTemp += string.Format("[DepartmentDMLactionUID]={0},", DepartmentDMLactionUID);
            mTemp += string.Format("[DepartmentDMLactionDate]={0},", "GetDate()");
            mTemp += string.Format("[DepartmentDMLactionType]='{0}'", "Update");

            string query = string.Format("UPDATE [tDepartment] SET {0} WHERE DepartmentID = {1}", mTemp, DepartmentID);
            myCmd.CommandText = query;
            return fayedDAL.ExecuteNonQuery(myCmd);
        }

        public int Delete()
        {
            if (_id == 0) return 0;
            List<ETDL.tDepartment> myDeps = new List<ETDL.tDepartment>();
            ETDL.tDepartment.FillListWithChilds(myDeps, _id);

            DbCommand myCmd = fayedDAL.CreateCommand();
            string mTemp = "";

            foreach (ETDL.tDepartment mTheDep in myDeps)
            {
                mTemp = string.Format("[DepartmentDMLactionType]='{0}',", "Delete");
                mTemp += string.Format("[DepartmentDMLactionDate]={0},", "GetDate()");
                mTemp += string.Format("[DepartmentDMLactionUID]={0}", DepartmentDMLactionUID);
                //mTemp += "[DepartmentIsDeleted]=1";



                string query = string.Format("UPDATE [tDepartment] SET {0} WHERE DepartmentID = {1}", mTemp, mTheDep.DepartmentID);
                myCmd.CommandText = query;
                fayedDAL.ExecuteNonQuery(myCmd);

                Delete(mTheDep.DepartmentID);
            }

            return 1;
        }

        #endregion

        #region Static Methods

        public static int Delete(int id)
        {
            if (id == 0) return 0;

            //bool mConState = fayedDAL.KeepConnection;
            //fayedDAL.KeepConnection = true;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tDepartment] WHERE [DepartmentID] = {0}", id));
            //return fayedDAL.ExecuteNonQuery(string.Format("Update [tEmployees] SET [emp_DepartmentID]=0 WHERE [emp_DepartmentID] = {0}", id));
            //int mRet = fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tDepartment] WHERE [DepartmentID] = {0}", id));

            //fayedDAL.KeepConnection = mConState;
            //return mRet;
        }

        //public static int Delete(string mFilter)
        //{
        //    if (mFilter.Trim() == "") return 0;
        //    return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tDepartment] WHERE {0}", mFilter));
        //}

        public static void FillList(System.Windows.Forms.ListBox mlst)
        {
            FillList(mlst.Items);
        }
        public static void FillList(System.Windows.Forms.ListBox mlst, string SqlFilter)
        {
            FillList(mlst.Items, SqlFilter);
        }

        public static void FillList(System.Windows.Forms.ComboBox mCombo)
        {
            FillList(mCombo.Items);
        }
        public static void FillList(System.Windows.Forms.ComboBox mCombo, string SqlFilter)
        {
            FillList(mCombo.Items, SqlFilter);
        }

        public static void FillList(IList lst)
        {
            FillList(lst, "");
        }

        public static void FillList(IList lst, string SqlFilter)
        {
            FillList(lst, SqlFilter, "");
        }

        public static void FillList(IList lst, string SqlFilter, string mOrderBy)
        {
            string TempSql = string.Format("SELECT {0} FROM [tDepartment] ", mFields);
            if (SqlFilter != "") TempSql += string.Format(" WHERE ({0})", SqlFilter);
            

            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                tDepartment TempObj;
                while (reader.Read())
                {
                    TempObj = new tDepartment(reader);
                    lst.Add(TempObj);
                }
            }
            reader.Close();
        }

        // make the node in the same level of parent
        public static void MoveRight(int DepID)
        {
            tDepartment mDep = new tDepartment(DepID);

            if (mDep.DepartmentParentID == 0)
                return;
            else
            {
                tDepartment mDepParent = new tDepartment(mDep.DepartmentParentID);
                mDep.DepartmentParentID = mDepParent.DepartmentParentID;
                mDep.DepartmentDMLactionUID = 1;
                mDep.Update();
            }
        }
        // make the node in the same level of parent
        public static void MoveLeft(int DepID)
        {
            tDepartment mDep = new tDepartment(DepID);

            List<tDepartment> mBrothers = GetFirstLevelChilds(mDep.DepartmentParentID);
            if (mBrothers[0].DepartmentID == mDep.DepartmentID) return;

            for (int ii = 1; ii < mBrothers.Count; ii++)
            {
                if (mBrothers[ii].DepartmentID == mDep.DepartmentID)
                {
                    mBrothers[ii].DepartmentParentID = mBrothers[ii - 1].DepartmentID;
                    mBrothers[ii].DepartmentDMLactionUID = 1;
                    mBrothers[ii].Update();

                    break;
                }
            }
        }
        //Just Sort in the same level
        public static void MoveUp(int DepID)
        {
            tDepartment mDep = new tDepartment(DepID);

            List<tDepartment> mBrothers = GetFirstLevelChilds(mDep.DepartmentParentID);
            if (mBrothers[0].DepartmentID == mDep.DepartmentID) return;

            for (int ii = 1; ii < mBrothers.Count; ii++)
            {
                if (mBrothers[ii].DepartmentID == mDep.DepartmentID)
                {
                    mBrothers[ii].DepartmentOrder = mBrothers[ii - 1].DepartmentOrder;
                    mBrothers[ii].DepartmentDMLactionUID = 1;
                    mBrothers[ii].Update();

                    mBrothers[ii - 1].DepartmentOrder = mDep.DepartmentOrder;
                    mBrothers[ii - 1].DepartmentDMLactionUID = 1;
                    mBrothers[ii - 1].Update();

                    break;
                }
            }
        }
        //Just Sort in the same level
        public static void MoveDown(int DepID)
        {
            tDepartment mDep = new tDepartment(DepID);

            List<tDepartment> mBrothers = GetFirstLevelChilds(mDep.DepartmentParentID);
            if (mBrothers[mBrothers.Count - 1].DepartmentID == mDep.DepartmentID) return;

            for (int ii = 0; ii < mBrothers.Count - 1; ii++)
            {
                if (mBrothers[ii].DepartmentID == mDep.DepartmentID)
                {
                    mBrothers[ii].DepartmentOrder = mBrothers[ii + 1].DepartmentOrder;
                    mBrothers[ii].DepartmentDMLactionUID = 1;
                    mBrothers[ii].Update();

                    mBrothers[ii + 1].DepartmentOrder = mDep.DepartmentOrder;
                    mBrothers[ii + 1].DepartmentDMLactionUID = 1;
                    mBrothers[ii + 1].Update();

                    break;
                }
            }
        }
        public static List<tDepartment> GetFirstLevelChilds(int DepID)
        {
            List<tDepartment> myList = new List<tDepartment>();
            tDepartment.FillList(myList, "[DepartmentParentID]=" + DepID.ToString());
            return myList;
        }

        public static void FillListWithChilds(IList lst, int DepID)
        {
            List<tDepartment> myList = new List<tDepartment>();
            tDepartment.FillList(myList);

            lst.Clear();

            foreach (ETDL.tDepartment oDataRow in myList)
            {
                if (oDataRow.DepartmentID == DepID)
                {
                    //Create Parent Node and add to tree
                    lst.Add(oDataRow);
                    FillListWithChildsRec(DepID, myList, lst);
                    break;
                }
            }

            myList.Clear();
            myList = null;
        }

        private static void FillListWithChildsRec(int mDepID, List<ETDL.tDepartment> AllDep, IList ResultDep)
        {
            foreach (ETDL.tDepartment oDataRow in AllDep)
            {
                if (oDataRow.DepartmentParentID == mDepID)
                {
                    ResultDep.Add(oDataRow);
                    //Repeat for each child
                    FillListWithChildsRec(oDataRow.DepartmentID, AllDep, ResultDep);
                }
            }
        }

        public static void FillTreeView(TreeView myTreeView)
        {
            myTreeView.Nodes.Clear();

            List<tDepartment> myList = new List<tDepartment>();
            tDepartment.FillList(myList);

            TreeNode oNode = new TreeNode();
            oNode.Text = "أمانة جدة";
            oNode.Value = "0";
            myTreeView.Nodes.Add(oNode);

            foreach (ETDL.tDepartment oDataRow in myList)
            {
                //Find Root Node,A root node has ParentID NULL
                if (oDataRow.DepartmentParentID == 0)
                {
                    //Create Parent Node and add to tree
                    TreeNode oNode2 = new TreeNode();
                    oNode2.Text = oDataRow.DepartmentName;
                    oNode2.Value = oDataRow.DepartmentID.ToString();
                    oNode.ChildNodes.Add(oNode2);

                    //Recurively Populate From root
                    RecursivelyLoadTree(oDataRow.DepartmentID, oNode2, myList);
                }
            }
            myList.Clear();
            myList = null;
        }

        private static void RecursivelyLoadTree(int mDepID, TreeNode oNode, List<ETDL.tDepartment> myList)
        {
            foreach (ETDL.tDepartment oDataRow in myList)
            {
                if (oDataRow.DepartmentParentID == mDepID)
                {
                    //Create child node and add to Parent
                    TreeNode oChildNode = new TreeNode();
                    oChildNode.Text = oDataRow.DepartmentName;
                    oChildNode.Value = oDataRow.DepartmentID.ToString();
                    oNode.ChildNodes.Add(oChildNode);
                    //Repeat for each child
                    RecursivelyLoadTree(oDataRow.DepartmentID, oChildNode, myList);
                }
            }
        }

        public static void FillDropDownList(DropDownList myDropDownList)
        {
            List<tDepartment> myList = new List<tDepartment>();
            tDepartment.FillList(myList);

            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---     اخـتـر الـقـسـم     ---", "0"));

            foreach (ETDL.tDepartment oDataRow in myList)
            {
                //Find Root Node,A root node has ParentID NULL
                if (oDataRow.DepartmentParentID == 0)
                {
                    myDropDownList.Items.Add(new ListItem(oDataRow.DepartmentName, oDataRow.DepartmentID.ToString()));
                    myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
                    //Recurively Populate From root
                    RecursivelyLoadinDropDownList(oDataRow.DepartmentID, myDropDownList, HttpContext.Current.Server.HtmlDecode("&nbsp;&nbsp;&nbsp;"), myList, true);
                }
            }
            myList.Clear();
            myList = null;
        }

        private static void RecursivelyLoadinDropDownList(int mDepID, DropDownList myDropDownList, string toAdd, List<tDepartment> myList)
        {
            RecursivelyLoadinDropDownList(mDepID, myDropDownList, toAdd, myList, false);
        }

        private static void RecursivelyLoadinDropDownList(int mDepID, DropDownList myDropDownList, string toAdd, List<tDepartment> myList, bool withColor)
        {
            foreach (ETDL.tDepartment oDataRow in myList)
            {
                if (oDataRow.DepartmentParentID == mDepID)
                {
                    myDropDownList.Items.Add(new ListItem(toAdd + oDataRow.DepartmentName, oDataRow.DepartmentID.ToString()));
                    if (withColor) myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:#990000");

                    //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "padding-right:4px");
                    //oChildNode.Value = oDataRow.DepartmentID.ToString();
                    RecursivelyLoadinDropDownList(oDataRow.DepartmentID, myDropDownList, toAdd + HttpContext.Current.Server.HtmlDecode("&nbsp;&nbsp;&nbsp;"), myList, false);

                }
            }
        }

        public static string ParsFromDropList(DropDownList myList)
        {
            if (myList.Items.Count == 0) return "";

            string myStr = ",";
            foreach (ListItem mItem in myList.Items)
            {
                if (mItem.Value != "0")
                    myStr += mItem.Value + ",";
            }

            return myStr;
        }

        public static void FillDropDownListFromString(DropDownList myDropList, string mDeps)
        {
            FillDropDownListFromString(myDropList, mDeps, true);
        }

        public static void FillDropDownListFromString(DropDownList myDropList, string mDeps, bool ClearListFirst)
        {
            if (ClearListFirst)
            {
                myDropList.Items.Clear();
                myDropList.Items.Add(new ListItem("---  اخـتـر الـقـسـم  ---", "0"));
            }

            DropDownList myList = new DropDownList();
            FillDropDownList(myList);

            foreach (ListItem mItem in myList.Items)
            {
                if (CheckDepartment(int.Parse(mItem.Value), mDeps) == true)
                    if (myDropList.Items.Contains(mItem) == false)
                        myDropList.Items.Add(mItem);
            }
            myList.Dispose();
            myList = null;
        }

        public static string GetDepWithChilds(int DepID)
        {
            string mRet = AddDepartmentWithChilds(DepID, "");
            if (mRet.StartsWith(",")) mRet = mRet.Substring(1);
            if (mRet.EndsWith(",")) mRet = mRet.Substring(0, mRet.Length - 1);

            return mRet;
        }

        public static string GetDepWithChilds(int DepID,string AllowDeps)
        {
            string mRet = AddDepartmentWithChilds(DepID, "");
            string[] myDeps = mRet.Split(',');

            string mResult = "";
            foreach (string str in myDeps)
            {
                if (AllowDeps.IndexOf(string.Format(",{0},", str)) > -1)
                    mResult += str + ",";
            }
            if (mResult.EndsWith(",")) mResult = mResult.Substring(0, mResult.Length - 1);
            return mResult;
        }

        public static bool CheckDepartment(int DepID, string mDepartmentsString)
        {
            if (mDepartmentsString.IndexOf(string.Format(",{0},", DepID)) > -1)
                return true;
            else
                return false;
        }

        public static string AddDepartment(int DepID, string mDepartmentsString)
        {
            string myDeps = mDepartmentsString;
            if (myDeps.Length == 0) myDeps = ",";

            if (CheckDepartment(DepID, myDeps) == false)
                myDeps += string.Format("{0},", DepID);

            return myDeps;
        }

        public static string AddDepartmentWithChilds(int DepID, string mDepartmentsString)
        {
            return AddDepartmentWithChilds(DepID, mDepartmentsString, "");
        }

        public static string AddDepartmentWithChilds(int DepID, string mDepartmentsString, string mDepsCanSee)
        {
            string myDeps = mDepartmentsString;
            List<tDepartment> mTheDeps = new List<tDepartment>();
            tDepartment.FillListWithChilds(mTheDeps, DepID);

            if (mDepsCanSee == "")
                foreach (tDepartment mDep in mTheDeps)
                    myDeps = AddDepartment(mDep.DepartmentID, myDeps);
            else
            {
                foreach (tDepartment mDep in mTheDeps)
                    if (CheckDepartment(mDep.DepartmentID, mDepsCanSee))
                        myDeps = AddDepartment(mDep.DepartmentID, myDeps);
            }

            return myDeps;
        }

        public static string RemoveDepartment(int DepID, string mDepartmentsString)
        {
            return mDepartmentsString.Replace(string.Format("{0},", DepID), "");
        }

        public static string RemoveDepartmentWithChilds(int DepID, string mDepartmentsString)
        {
            string myDeps = mDepartmentsString;
            List<tDepartment> mTheDeps = new List<tDepartment>();
            tDepartment.FillListWithChilds(mTheDeps, DepID);

            foreach (tDepartment mDep in mTheDeps)
            {
                myDeps = RemoveDepartment(mDep.DepartmentID, myDeps);
            }

            return myDeps;
        }

        public static int GetRowsCount()
        {
            return fayedDAL.GetRowsCount("tDepartment");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("tDepartment", SqlFilter);
        }

        //public static tDepartment GettDepartment(int id)
        //{
        //    return new tDepartment(id);
        //}


        #endregion
    }
    #endregion

}


