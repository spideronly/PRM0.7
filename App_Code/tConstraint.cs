///////////////////////////////////////////////////
//
//			Sami Shamsan
//			eng.shamsan@gmail.com
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

    #region tConstraint
    /// <summary>
    /// This object represents the properties and methods of a ( Project ) Table.
    /// </summary>
    public class tConstraint
    {
        private const string mFields = "[ConstraintID],[ConstraintName],[ConstraintRequiredSolution],[ConstraintIsNeedMayor],[ConstraintIsSolved],[ConstraintResponsibleName],[ConstraintDate],[ConstraintDateHijri],[ConstraintPlanDate],[ConstraintPlanDateHijri],[ConstraintDatetxt],[ConstraintNeedMayor]";

        #region Private Fields,ToString() Method

        private int _id;
        private int _ConstraintID;
        private string _ConstraintName = String.Empty;
        private string _ConstraintRequiredSolution = String.Empty;
        private string _ConstraintResponsibleName = String.Empty;
        private bool _ConstraintIsNeedMayor;
        private bool _ConstraintIsSolved;
        private DateTime _ConstraintDate;
        private int _ConstraintDateHijri;
        private DateTime _ConstraintPlanDate;
        private int _ConstraintPlanDateHijri;
        private int _Constraint_ProjectID;
        private string _ConstraintDatetxt = String.Empty;
        private string _ConstraintNeedMayor = String.Empty;
        
        private int _ConstraintOrder;
        private int _ConstraintDMLactionUID;

        public override string ToString()
        {
            // the text that will be displayed in Listbox or Combobox
            return _id.ToString();
        }

        #endregion

        #region Public Properties
        public int ConstraintID
        {
            get { return _id; }
        }
        public string ConstraintName
        {
            get { return _ConstraintName; }
            set { if (value.Length > 50) _ConstraintName = value.Substring(0, 50); else _ConstraintName = value; }
        }
        public string ConstraintRequiredSolution
        {
            get { return _ConstraintRequiredSolution; }
            set { if (value.Length > 50) _ConstraintRequiredSolution = value.Substring(0, 50); else _ConstraintRequiredSolution = value; }
        }
        public string ConstraintResponsibleName
        {
            get { return _ConstraintResponsibleName; }
            set { if (value.Length > 50) _ConstraintResponsibleName = value.Substring(0, 50); else _ConstraintResponsibleName = value; }
        }
        public bool ConstraintIsNeedMayor
        {
            get { return _ConstraintIsNeedMayor; }
            set { _ConstraintIsNeedMayor = value; }
        }
        public bool ConstraintIsSolved
        {
            get { return _ConstraintIsSolved; }
            set { _ConstraintIsSolved = value; }
        }
        public DateTime ConstraintDate
        {
            get { return _ConstraintDate; }
            set { _ConstraintDate = value; }
        }
        public int ConstraintDateHijri
        {
            get { return _ConstraintDateHijri; }
            set { _ConstraintDateHijri = value; }
        }
        public string ConstraintDateHijriString
        {
            get
            {
                string myDate = ConstraintDateHijri.ToString();
                if (myDate.Length != 8) return "";
                //return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
                return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
            }
        }
        public DateTime ConstraintPlanDate
        {
            get { return _ConstraintPlanDate; }
            set { _ConstraintPlanDate = value; }
        }
        public int ConstraintPlanDateHijri
        {
            get { return _ConstraintPlanDateHijri; }
            set { _ConstraintPlanDateHijri = value; }
        }
        public string ConstraintPlanDateHijriString
        {
            get
            {
                string myDate = ConstraintPlanDateHijri.ToString();
                if (myDate.Length != 8) return "";
                // return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
                return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
            }
        }
       
       
        public int Constraint_ProjectID
        {
            get { return _Constraint_ProjectID; }
            set { _Constraint_ProjectID = value; }
        }


        public string ConstraintDatetxt
        {
            get { return _ConstraintDatetxt; }
            set { if (value.Length > 50) _ConstraintDatetxt = value.Substring(0, 50); else _ConstraintDatetxt = value; }
        }
        public string ConstraintNeedMayor
        {
            get { return _ConstraintNeedMayor; }
            set { if (value.Length > 50) _ConstraintNeedMayor = value.Substring(0, 50); else _ConstraintNeedMayor = value; }
        }
        
        public int ConstraintOrder
        {
            get { return _ConstraintOrder; }
            set { _ConstraintOrder = value; }
        }

        public int ConstraintDMLactionUID
        {
            get { return _ConstraintDMLactionUID; }
            set { _ConstraintDMLactionUID = value; }
        }

        #endregion

        #region Constractors

        public tConstraint()
        {
        }

        public tConstraint(int id)
        {
            LoadFromID(id);
        }

        public tConstraint(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT * FROM [tConstraint] WHERE ConstraintID = {0}", id);
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
                throw new ApplicationException("Selected Project Row Does Not Exist.");
            }
        }

        protected void LoadFromReader(DbDataReader reader)
        {
            int colOrdinal;
            if (reader != null && !reader.IsClosed)
            {
                colOrdinal = reader.GetOrdinal("ConstraintID");
                _id = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintName");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintRequiredSolution");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintRequiredSolution = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintResponsibleName");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintResponsibleName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintIsNeedMayor");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintIsNeedMayor = reader.GetBoolean(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintIsSolved");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintIsSolved = reader.GetBoolean(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintDate");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintPlanDate");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintPlanDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintPlanDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintPlanDateHijri = reader.GetInt32(colOrdinal);

                colOrdinal = reader.GetOrdinal("ConstraintNeedMayor");
                     if (!reader.IsDBNull(colOrdinal)) _ConstraintNeedMayor = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintDatetxt");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintDatetxt = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("Constraint_ProjectID");
                if (!reader.IsDBNull(colOrdinal)) _Constraint_ProjectID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintOrder");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintOrder = reader.GetInt32(colOrdinal);


            }
        }

        #endregion

        #region Create,Update,Delete

        public int Create()
        {
            DbCommand myCmd = fayedDAL.CreateCommand();
            string mCols, mValues = "";

            mCols = "[ConstraintName],[ConstraintRequiredSolution],[ConstraintResponsibleName],[ConstraintIsNeedMayor],[ConstraintNeedMayor],[ConstraintIsSolved],[ConstraintDate],[ConstraintDateHijri],[ConstraintDatetxt],[ConstraintPlanDate],[ConstraintPlanDateHijri],[Constraint_ProjectID],[ConstraintOrder],[ConstraintDMLcreateUID],[ConstraintDMLcreateDate],[ConstraintDMLactionUID],[ConstraintDMLactionDate],[ConstraintDMLactionType]";
            mValues += string.Format("'{0}',", ConstraintName);
            mValues += string.Format("'{0}',", ConstraintRequiredSolution);
            mValues += string.Format("'{0}',", ConstraintResponsibleName);
            mValues += string.Format("{0},", ((ConstraintIsNeedMayor == true) ? 1 : 0));

            mValues += string.Format("'{0}',", ConstraintNeedMayor);
            mValues += string.Format("{0},", ((ConstraintIsSolved == true) ? 1 : 0));
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(ConstraintDate));
            mValues += string.Format("{0},", ConstraintDateHijri);

            mValues += string.Format("'{0}',", ConstraintDatetxt);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(ConstraintPlanDate));
            mValues += string.Format("{0},", ConstraintPlanDateHijri);
            mValues += string.Format("{0},", Constraint_ProjectID);
            mValues += string.Format("{0},", ConstraintOrder);


            mValues += string.Format("{0},", ConstraintDMLactionUID); //DMLcreateUID
            mValues += string.Format("{0},", "GetDate()"); //DMLcreateDate
            mValues += string.Format("{0},", ConstraintDMLactionUID); //OprationUID
            mValues += string.Format("{0},", "GetDate()"); //DMLDate
            mValues += string.Format("'{0}'", "Insert"); //DMLOperation

            string query = String.Format("INSERT INTO [tConstraint] ({0}) VALUES ({1})", mCols, mValues);
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
            if (_id == 0) return 0;
            DbCommand myCmd = fayedDAL.CreateCommand();
            string mTemp = "";

            mTemp += string.Format("[ConstraintName]='{0}',", ConstraintName);
            mTemp += string.Format("[ConstraintRequiredSolution]='{0}',", ConstraintRequiredSolution);
            mTemp += string.Format("[ConstraintResponsibleName]='{0}',", ConstraintResponsibleName);
            mTemp += string.Format("[PermissionAdd]={0},", ((ConstraintIsNeedMayor == true) ? 1 : 0));

            mTemp += string.Format("[ConstraintNeedMayor]='{0}',", ConstraintNeedMayor);
            mTemp += string.Format("[PermissionView]={0},", ((ConstraintIsSolved == true) ? 1 : 0));
            mTemp += string.Format("[ConstraintDate]={0},", fayedDAL.GetSqlDate(ConstraintDate));
            mTemp += string.Format("[ConstraintDateHijri]={0},", ConstraintDateHijri);
            mTemp += string.Format("[ConstraintDatetxt]='{0}',", ConstraintDatetxt);

            mTemp += string.Format("[ConstraintPlanDate]={0},", fayedDAL.GetSqlDate(ConstraintPlanDate));
            mTemp += string.Format("[ConstraintPlanDateHijri]={0},", ConstraintPlanDateHijri);
            mTemp += string.Format("[Constraint_ProjectID]={0},", Constraint_ProjectID);
            mTemp += string.Format("[ConstraintOrder]={0},", ConstraintOrder);

            mTemp += string.Format("[ConstraintDMLactionUID]={0},", ConstraintDMLactionUID);
            mTemp += string.Format("[ConstraintDMLactionDate]={0},", "GetDate()");
            mTemp += string.Format("[ConstraintDMLactionType]='{0}'", "Update");


            string query = string.Format("UPDATE [tConstraint] SET {0} WHERE ConstraintID = {1}", mTemp, ConstraintID);
            myCmd.CommandText = query;
            return fayedDAL.ExecuteNonQuery(myCmd);
        }

        public int Delete()
        {
            if (_id == 0) return 0;
            List<ETDL.tConstraint> myCons = new List<ETDL.tConstraint>();
            ETDL.tConstraint.FillList(myCons, "ConstraintID=" + _id + "");

            DbCommand myCmd = fayedDAL.CreateCommand();
            string mTemp = "";

            foreach (ETDL.tConstraint mTheCons in myCons)
            {
                mTemp = string.Format("[ConstraintDMLactionType]='{0}',", "Delete");
                mTemp += string.Format("[ConstraintDMLactionDate]={0},", "GetDate()");
                mTemp += string.Format("[ConstraintDMLactionUID]={0}", ConstraintDMLactionUID);
                //mTemp += "[DepartmentIsDeleted]=1";



                string query = string.Format("UPDATE [tConstraint] SET {0} WHERE ConstraintID = {1}", mTemp, mTheCons.ConstraintID);
                myCmd.CommandText = query;
                fayedDAL.ExecuteNonQuery(myCmd);

                Delete(mTheCons.ConstraintID);
            }

            return 1;
        }

        #endregion

        #region Static Methods

        public static int Delete(int id)
        {
            if (id == 0) return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tConstraint] WHERE ConstraintID = {0}", id));
        }

        public static int Delete(string mFilter)
        {
            if (mFilter.Trim() == "") return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tConstraint] WHERE {0}", mFilter));
        }

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
        public static void FillList(DataTable lst, string SqlFilter)
        {
            FillList(lst, SqlFilter, "");
        }

        public static void FillList(DataTable lst, string SqlFilter, string mOrderBy)
        {
            string TempSql = string.Format("SELECT {0} FROM [tConstraint]", mFields);
            if (SqlFilter != "") TempSql += " WHERE " + SqlFilter;
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;

            fayedDAL.FillDataTable(lst, TempSql);
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
            string TempSql = "SELECT * FROM [tConstraint]";
            if (SqlFilter != "") TempSql += " WHERE " + SqlFilter;
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;
            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                tConstraint TempObj;
                while (reader.Read())
                {
                    TempObj = new tConstraint(reader);
                    lst.Add(TempObj);
                }
            }
            reader.Close();
        }

        //public string GetWhereCluse()
        //{
        //    string mWhere = "";

        //    if (this.ProjectBudget > 0) mWhere += string.Format("([ProjectBudget] LIKE '{0}%') AND", this.ProjectBudget);
        //    if (this.Constraint_ProjectID > 0) mWhere += string.Format("([Constraint_ProjectID] = {0}) AND", this.Constraint_ProjectID);
        //    if (this.ProjectManager != "") mWhere += string.Format("([ProjectManager] LIKE '{0}%') AND", this.ProjectManager);
        //    if (this.ProjectPaiedValue > 0) mWhere += string.Format("([ProjectPaiedValue] LIKE '{0}%') AND", this.ProjectPaiedValue);
        //    if (this.ConstraintResponsibleName != "") mWhere += string.Format("([ConstraintResponsibleName] LIKE '{0}%') AND", this.ConstraintResponsibleName);
        //    if (this.ConstraintName != "") mWhere += string.Format("([ConstraintName] LIKE '{0}%') AND", this.ConstraintName);
        //    if (this.ConstraintRequiredSolution != "") mWhere += string.Format("([ConstraintRequiredSolution] LIKE '{0}%') AND", this.ConstraintRequiredSolution);
        //    if (mWhere.Length > 4)
        //    {
        //        mWhere = mWhere.Substring(0, mWhere.Length - 4);
        //    }
        //    return mWhere;
        //}
        public static double DateDiff(DateTime myFirstDate, DateTime mySecondDate)
        {
            int mDiffDay = 0;
            if (mySecondDate >= myFirstDate)
            {
                if (myFirstDate.Year == mySecondDate.Year)
                {
                    if (myFirstDate.Month == mySecondDate.Month)
                    {
                        mDiffDay = mySecondDate.Day - myFirstDate.Day;
                    }
                    else
                    {
                        int DaysCount = 0;

                        DaysCount += DateTime.DaysInMonth(myFirstDate.Year, myFirstDate.Month) - myFirstDate.Day;//get remain day first date
                        DaysCount += mySecondDate.Day;//get days for second date
                        int mDiffMonth = mySecondDate.Month - myFirstDate.Month - 1;
                        for (int i = 0; i < mDiffMonth; i++)
                        {
                            DaysCount += DateTime.DaysInMonth(myFirstDate.Year, myFirstDate.AddMonths(myFirstDate.Month + 1 + i).Month);
                        }
                        mDiffDay = DaysCount;

                    }
                }
                else
                {
                    int DaysCount = 0;
                    DaysCount += DateTime.DaysInMonth(myFirstDate.Year, myFirstDate.Month) - myFirstDate.Day;//get remain day first date
                    DaysCount += mySecondDate.Day;//get days for second date

                    int mDiffMonth = mySecondDate.Month - myFirstDate.Month - 1;
                    for (int i = 0; i < mDiffMonth; i++)
                    {
                        DaysCount += DateTime.DaysInMonth(myFirstDate.Year, myFirstDate.AddMonths(myFirstDate.Month + 1 + i).Month);
                    }
                    mDiffDay = DaysCount;
                }
            }
            else
                mDiffDay = 0;
            return mDiffDay;

        }
        //get Count of Dangrouse Project that pass end date
        public static int DangProject()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ConstraintID]) FROM [tConstraint] Where ProjectBudget=2");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static int DangProject(int myCond)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ConstraintID]) FROM [tConstraint] Where (ProjectBudget=2 and PortfolioID=" + myCond + ")");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get Count of Opened Project
        public static int OpenProject()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ConstraintID]) FROM [tConstraint] Where ProjectBudget=1");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static int GetConstraintDataByID(int myPro)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT [ConstraintID] FROM [tConstraint] Where ConstraintID=" + myPro + "");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static int OpenProject(int myCond)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ConstraintID]) FROM [tConstraint] Where (ProjectBudget=1 and PortfolioID=" + myCond + ")");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get Count of Finished Project 
        public static int FinishedProject()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ConstraintID]) FROM [tConstraint] Where ProjectBudget=3");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static int FinishedProject(int myCond)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ConstraintID]) FROM [tConstraint] Where (ProjectBudget=3 and PortfolioID=" + myCond + ")");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get Count of Secret Project 
        public static int SecretPro()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ConstraintID]) FROM [tConstraint] WHERE IsSecret='True'");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get Count of NonSecret Project 
        public static int NonSecretPro()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ConstraintID]) FROM [tConstraint] WHERE IsSecret='False'");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }

        public static DataTable GetData(string mstring)
        {
            DataTable dt = new DataTable();

            fayedDAL.FillDataTable(dt, mstring);
            return dt;
        }
        public static int GetRowsCount()
        {
            return fayedDAL.GetRowsCount("Project");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("Project", SqlFilter);
        }

        public static tConstraint GetConstraint(int id)
        {
            return new tConstraint(id);
        }
        //get last ID
        public static int myGetLastID()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT MAX([ConstraintID]) FROM [tConstraint]");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get DropDwonlist ID
        public static int myGetDLID(string myDLValue)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT [ConstraintID] FROM [tConstraint] WHERE ([ConstraintName]='" + myDLValue + "')");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //Fill DropDownList
        public static void FillDropDownList(DropDownList myDropDownList)
        {
            DataTable dt = new DataTable();
            string mystring = "SELECT [ConstraintID],[ConstraintName] FROM tConstraint";
            fayedDAL.FillDataTable(dt, mystring);
            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر مشروع---", "0"));
            foreach (DataRow oDataRow in dt.Rows)
            {
                myDropDownList.Items.Add(new ListItem(oDataRow[1].ToString(), oDataRow[0].ToString()));
                //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
            }

        }
        //Fill DropDownList with condition from Table
        public static void FillDropDownListFromTable(DropDownList myDropDownList, string cond)
        {

            DataTable dt = new DataTable();
            string mystring = "SELECT [ConstraintID],[ConstraintName] FROM tConstraint where " + cond + "";
            fayedDAL.FillDataTable(dt, mystring);
            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر مشروع---", "0"));
            foreach (DataRow oDataRow in dt.Rows)
            {
                myDropDownList.Items.Add(new ListItem(oDataRow[1].ToString(), oDataRow[0].ToString()));
                //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
            }
        }
        //Fill DropDownList with condition from view
        public static void FillDropDownListFromView(DropDownList myDropDownList, string cond)
        {
            List<tConstraint> myList = new List<tConstraint>();
            tConstraint.FillList(myList, cond);

            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر مشروع---", "0"));

            foreach (tConstraint oDataRow in myList)
            {
                myDropDownList.Items.Add(new ListItem(oDataRow.ConstraintName, oDataRow.ConstraintID.ToString()));
                //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
            }
            myList.Clear();
            myList = null;
        }
        //Fill Gridview
        public static void FillGridView(GridView myGrideView, string mystring)
        {
            DataTable dt = new DataTable();
            // string mystring = "SELECT [ConstraintID],[ConstraintName] FROM Project";
            fayedDAL.FillDataTable(dt, mystring);
            myGrideView.DataSource = dt;
            myGrideView.DataBind();

        }


        public static DataTable GetConstraintData(string str)
        {

            //  str += @" WHERE (RemaningDays < 31) ORDER BY [الايام المتبقية]";

            return fayedDAL.GetDataTable(str);
        }


        #endregion

        #region IfayedDbTable impelementation

        //void IfayedDbTable.FillList(IList lst)
        //{
        //    FillList(lst);
        //}

        //void IfayedDbTable.FillList(IList lst, string SqlFilter)
        //{
        //    FillList(lst, SqlFilter);
        //}

        #endregion

    }
    #endregion

}


