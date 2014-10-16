
///////////////////////////////////////////////////
//
//			Mohammed Samir Fayed
//			ms_fayed@hotmail.com
//			24-05-2009   12:02 PM
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

    #region tProject
    /// <summary>
    /// This object represents the properties and methods of a ( Project ) Table.
    /// </summary>
    public class tProject
    {
        private const string mFields = "[ProjectID],[ProjectName],[ProjectSponsor],[ProjectProgram],[ProjectManager],[ProjectStartDate],[ProjectStartDateHijri],[ProjectEndDate],[ProjectEndDateHijri],[ProjectActualStartDate],[ProjectActualStartDateHijri],[ProjectActualEndDate],[ProjectActualEndDateHijri],[ProjectContractor],[ProjectBudget],[ProjectProgress],[ProjectPaiedValue],[Project_ProjectType],[Project_DepartmentID],[ProjectDescription],[ProjectBossNote],[Project_ProgressTypeID]";

        #region Private Fields,ToString() Method

        private int _id;
        private int _ProjectID;
        private string _ProjectName = String.Empty;
        private string _ProjectSponsor = String.Empty;
        private string _ProjectProgram = String.Empty;
        private string _ProjectManager = String.Empty;
        private DateTime _ProjectStartDate;
        private int _ProjectStartDateHijri;
        private DateTime _ProjectEndDate;
        private int _ProjectEndDateHijri;
        private DateTime _ProjectActualStartDate;
        private int _ProjectActualStartDateHijri;
        private DateTime _ProjectActualEndDate;
        private int _ProjectActualEndDateHijri;
        private string _ProjectContractor = String.Empty;
        private int _ProjectBudget;
        private string _ProjectProgress;
        private int _ProjectPaiedValue;
        private int _Project_ProjectType;
        private int _Project_DepartmentID;
        private string _ProjectDescription = String.Empty;
        private string _ProjectBossNote = String.Empty;
        private int _Project_ProgressTypeID;
        private int _ProjectOrder;
        private int _ProjectDMLactionUID;

        public override string ToString()
        {
            // the text that will be displayed in Listbox or Combobox
            return _id.ToString();
        }

        #endregion

        #region Public Properties
        public int ProjectID
        {
            get { return _id; }
        }
        public string ProjectName
        {
            get { return _ProjectName; }
            set { if (value.Length > 50) _ProjectName = value.Substring(0, 50); else _ProjectName = value; }
        }
        public string ProjectSponsor
        {
            get { return _ProjectSponsor; }
            set { if (value.Length > 50) _ProjectSponsor = value.Substring(0, 50); else _ProjectSponsor = value; }
        }
        public string ProjectProgram
        {
            get { return _ProjectProgram; }
            set { if (value.Length > 50) _ProjectProgram = value.Substring(0, 50); else _ProjectProgram = value; }
        }
        public string ProjectManager
        {
            get { return _ProjectManager; }
            set { if (value.Length > 50) _ProjectManager = value.Substring(0, 50); else _ProjectManager = value; }
        }
        public DateTime ProjectStartDate
        {
            get { return _ProjectStartDate; }
            set { _ProjectStartDate = value; }
        }
        public int ProjectStartDateHijri
        {
            get { return _ProjectStartDateHijri; }
            set { _ProjectStartDateHijri = value; }
        }
        public string ProjectStartDateHijriString
        {
            get
            {
                string myDate = ProjectStartDateHijri.ToString();
                if (myDate.Length != 8) return "";
                //return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
                return myDate.Substring(0, 4) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(6, 2);
            }
        }
        public DateTime ProjectEndDate
        {
            get { return _ProjectEndDate; }
            set { _ProjectEndDate = value; }
        }
        public int ProjectEndDateHijri
        {
            get { return _ProjectEndDateHijri; }
            set { _ProjectEndDateHijri = value; }
        }
        public string ProjectEndDateHijriString
        {
            get
            {
                string myDate = ProjectEndDateHijri.ToString();
                if (myDate.Length != 8) return "";
               // return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
                return myDate.Substring(0, 4)+ "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(6, 2) ;
            }
        }
        public DateTime ProjectActualStartDate
        {
            get { return _ProjectActualStartDate; }
            set { _ProjectActualStartDate = value; }
        }
        public int ProjectActualStartDateHijri
        {
            get { return _ProjectActualStartDateHijri; }
            set { _ProjectActualStartDateHijri = value; }
        }
        public DateTime ProjectActualEndDate
        {
            get { return _ProjectActualEndDate; }
            set { _ProjectActualEndDate = value; }
        }
        public int ProjectActualEndDateHijri
        {
            get { return _ProjectActualEndDateHijri; }
            set { _ProjectActualEndDateHijri = value; }
        }
         public string ProjectContractor
        {
            get { return _ProjectContractor; }
            set { if (value.Length > 50) _ProjectContractor = value.Substring(0, 50); else _ProjectContractor = value; }
        }
        public int ProjectBudget
        {
            get { return _ProjectBudget; }
            set { _ProjectBudget = value; }
        }
        public string ProjectProgress
        {
            get { return _ProjectProgress; }
            set { if (value.Length > 50) _ProjectProgress = value.Substring(0, 50); else _ProjectProgress = value; }
        }
        
        public int ProjectPaiedValue
        {
            get { return _ProjectPaiedValue; }
            set { _ProjectPaiedValue = value; }
        }
        public int Project_ProjectType
        {
            get { return _Project_ProjectType; }
            set { _Project_ProjectType = value; }
        }
       
        public int Project_DepartmentID
        {
            get { return _Project_DepartmentID; }
            set { _Project_DepartmentID = value; }
        }
        public string ProjectDescription
        {
            get { return _ProjectDescription; }
            set { if (value.Length > 50) _ProjectDescription = value.Substring(0, 50); else _ProjectDescription = value; }
        }
        public string ProjectBossNote
        {
            get { return _ProjectBossNote; }
            set { if (value.Length > 50) _ProjectBossNote = value.Substring(0, 50); else _ProjectBossNote = value; }
        }
        

        public int Project_ProgressTypeID
        {
            get { return _Project_ProgressTypeID; }
            set { _Project_ProgressTypeID = value; }
        }

        public int ProjectOrder
        {
            get { return _ProjectOrder; }
            set { _ProjectOrder = value; }
        }

        public int ProjectDMLactionUID
        {
            get { return _ProjectDMLactionUID; }
            set { _ProjectDMLactionUID = value; }
        }

        #endregion

        #region Constractors

        public tProject()
        {
        }

        public tProject(int id)
        {
            LoadFromID(id);
        }

        public tProject(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT * FROM [tProject] WHERE ProjectID = {0}", id);
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
                colOrdinal = reader.GetOrdinal("ProjectID");
                _id = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectName");
                if (!reader.IsDBNull(colOrdinal)) _ProjectName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectSponsor");
                if (!reader.IsDBNull(colOrdinal)) _ProjectSponsor = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectProgram");
                if (!reader.IsDBNull(colOrdinal)) _ProjectProgram = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectManager");
                if (!reader.IsDBNull(colOrdinal)) _ProjectManager = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectStartDate");
                if (!reader.IsDBNull(colOrdinal)) _ProjectStartDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectStartDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ProjectStartDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectEndDate");
                if (!reader.IsDBNull(colOrdinal)) _ProjectEndDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectEndDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ProjectEndDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectActualStartDate");
                if (!reader.IsDBNull(colOrdinal)) _ProjectActualStartDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectActualStartDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ProjectActualStartDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectActualEndDate");
                if (!reader.IsDBNull(colOrdinal)) _ProjectActualEndDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectActualEndDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ProjectActualEndDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectContractor");
                if (!reader.IsDBNull(colOrdinal)) _ProjectContractor = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectBudget");
                if (!reader.IsDBNull(colOrdinal)) _ProjectBudget = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectProgress");
                if (!reader.IsDBNull(colOrdinal)) _ProjectProgress = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectPaiedValue");
                if (!reader.IsDBNull(colOrdinal)) _ProjectPaiedValue = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("Project_ProjectType");
                if (!reader.IsDBNull(colOrdinal)) _Project_ProjectType = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("Project_DepartmentID");
                if (!reader.IsDBNull(colOrdinal)) _Project_DepartmentID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDescription");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDescription = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectBossNote");
                if (!reader.IsDBNull(colOrdinal)) _ProjectBossNote = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("Project_ProgressTypeID");
                if (!reader.IsDBNull(colOrdinal)) _Project_ProgressTypeID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectOrder");
                if (!reader.IsDBNull(colOrdinal)) _ProjectOrder = reader.GetInt32(colOrdinal);
                
               
            }
        }

        #endregion

        #region Create,Update,Delete

        public int Create()
        {
            DbCommand myCmd = fayedDAL.CreateCommand();
            string mCols, mValues = "";

            mCols = "[ProjectName],[ProjectSponsor],[ProjectProgram],[ProjectManager],[ProjectStartDate],[ProjectStartDateHijri],[ProjectEndDate],[ProjectEndDateHijri],[ProjectActualStartDate],[ProjectActualStartDateHijri],[ProjectActualEndDate],[ProjectActualEndDateHijri],[ProjectContractor],[ProjectBudget],[ProjectProgress],[ProjectPaiedValue],[Project_ProjectType],[Project_DepartmentID],[ProjectDescription],[ProjectBossNote],[Project_ProgressTypeID],[ProjectOrder],[ProjectDMLcreateUID],[ProjectDMLcreateDate],[ProjectDMLactionUID],[ProjectDMLactionDate],[ProjectDMLactionType]";
            mValues += string.Format("'{0}',", ProjectName);
            mValues += string.Format("'{0}',", ProjectSponsor);
            mValues += string.Format("'{0}',", ProjectProgram);
            mValues += string.Format("'{0}',", ProjectManager);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(ProjectStartDate));
            mValues += string.Format("{0},", ProjectStartDateHijri);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(ProjectEndDate));
            mValues += string.Format("{0},", ProjectEndDateHijri);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(ProjectActualStartDate));
            mValues += string.Format("{0},", ProjectActualStartDateHijri);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(ProjectActualEndDate));
            mValues += string.Format("{0},", ProjectActualEndDateHijri);
            mValues += string.Format("'{0}',", ProjectContractor);
            mValues += string.Format("{0},", ProjectBudget);
            mValues += string.Format("'{0}',", ProjectProgress);
            mValues += string.Format("{0},", ProjectPaiedValue);
            mValues += string.Format("{0},", Project_ProjectType);
            mValues += string.Format("{0},", Project_DepartmentID);
            mValues += string.Format("'{0}',", ProjectDescription);
            mValues += string.Format("'{0}',", ProjectBossNote);
            mValues += string.Format("{0},", Project_ProgressTypeID);
            mValues += string.Format("{0},", ProjectOrder);


            mValues += string.Format("{0},", ProjectDMLactionUID); //DMLcreateUID
            mValues += string.Format("{0},", "GetDate()"); //DMLcreateDate
            mValues += string.Format("{0},", ProjectDMLactionUID); //OprationUID
            mValues += string.Format("{0},", "GetDate()"); //DMLDate
            mValues += string.Format("'{0}'", "Insert"); //DMLOperation

            string query = String.Format("INSERT INTO [tProject] ({0}) VALUES ({1})", mCols, mValues);
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
            
            mTemp += string.Format("[ProjectName]='{0}',", ProjectName);
            mTemp += string.Format("[ProjectSponsor]='{0}',", ProjectSponsor);
            mTemp += string.Format("[ProjectProgram]='{0}',", ProjectProgram);
            mTemp += string.Format("[ProjectManager]='{0}',", ProjectManager);
            mTemp += string.Format("[ProjectStartDate]={0},", fayedDAL.GetSqlDate(ProjectStartDate));
            mTemp += string.Format("[ProjectStartDateHijri]={0},", ProjectStartDateHijri);
            mTemp += string.Format("[ProjectEndDate]={0},", fayedDAL.GetSqlDate(ProjectEndDate));
            mTemp += string.Format("[ProjectEndDateHijri]={0},", ProjectEndDateHijri);
            mTemp += string.Format("[ProjectActualStartDate]={0},", fayedDAL.GetSqlDate(ProjectActualStartDate));
            mTemp += string.Format("[ProjectActualStartDateHijri]={0},", ProjectActualStartDateHijri);
            mTemp += string.Format("[ProjectActualEndDate]={0},", fayedDAL.GetSqlDate(ProjectActualEndDate));
            mTemp += string.Format("[ProjectActualEndDateHijri]={0},", ProjectActualEndDateHijri);
            mTemp += string.Format("[ProjectContractor]='{0}',", ProjectContractor);
            mTemp += string.Format("[ProjectBudget]={0},", ProjectBudget);
            mTemp += string.Format("[ProjectProgress]='{0}',", ProjectProgress);
            mTemp += string.Format("[ProjectPaiedValue]={0},", ProjectPaiedValue);
            mTemp += string.Format("[Project_ProjectType]={0},", Project_ProjectType);
            mTemp += string.Format("[Project_DepartmentID]={0},", Project_DepartmentID);
            mTemp += string.Format("[ProjectDescription]='{0}',", ProjectDescription);
            mTemp += string.Format("[ProjectBossNote]='{0}',", ProjectBossNote);
            mTemp += string.Format("[Project_ProgressTypeID]={0},", Project_ProgressTypeID);
            mTemp += string.Format("[ProjectOrder]={0},", ProjectOrder);

            mTemp += string.Format("[ProjectDMLactionUID]={0},", ProjectDMLactionUID);
            mTemp += string.Format("[ProjectDMLactionDate]={0},", "GetDate()");
            mTemp += string.Format("[ProjectDMLactionType]='{0}'", "Update");


            string query = string.Format("UPDATE [tProject] SET {0} WHERE ProjectID = {1}", mTemp, ProjectID);
            myCmd.CommandText = query;
            return fayedDAL.ExecuteNonQuery(myCmd);
        }

        public int Delete()
        {
            if (_id == 0) return 0;
            List<ETDL.tProject> myProj = new List<ETDL.tProject>();
            ETDL.tProject.FillList(myProj, "ProjectID=" + _id + "");

            DbCommand myCmd = fayedDAL.CreateCommand();
            string mTemp = "";

            foreach (ETDL.tProject mTheProj in myProj)
            {
                mTemp = string.Format("[ProjectDMLactionType]='{0}',", "Delete");
                mTemp += string.Format("[ProjectDMLactionDate]={0},", "GetDate()");
                mTemp += string.Format("[ProjectDMLactionUID]={0}", ProjectDMLactionUID);
                //mTemp += "[DepartmentIsDeleted]=1";



                string query = string.Format("UPDATE [tProject] SET {0} WHERE ProjectID = {1}", mTemp, mTheProj.ProjectID);
                myCmd.CommandText = query;
                fayedDAL.ExecuteNonQuery(myCmd);

                Delete(mTheProj.ProjectID);
            }

            return 1;
        }

        #endregion

        #region Static Methods

        public static int Delete(int id)
        {
            if (id == 0) return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tProject] WHERE ProjectID = {0}", id));
        }

        public static int Delete(string mFilter)
        {
            if (mFilter.Trim() == "") return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tProject] WHERE {0}", mFilter));
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
            string TempSql = string.Format("SELECT {0} FROM [tProject]", mFields);
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
            string TempSql = "SELECT * FROM [tProject]";
            if (SqlFilter != "") TempSql += " WHERE " + SqlFilter;
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;
            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                tProject TempObj;
                while (reader.Read())
                {
                    TempObj = new tProject(reader);
                    lst.Add(TempObj);
                }
            }
            reader.Close();
        }

        public string GetWhereCluse()
        {
            string mWhere = "";

            if (this.ProjectBudget >0) mWhere += string.Format("([ProjectBudget] LIKE '{0}%') AND", this.ProjectBudget);
            if (this.Project_DepartmentID > 0) mWhere += string.Format("([Project_DepartmentID] = {0}) AND", this.Project_DepartmentID);
            if (this.ProjectManager != "") mWhere += string.Format("([ProjectManager] LIKE '{0}%') AND", this.ProjectManager);
            if (this.ProjectPaiedValue > 0) mWhere += string.Format("([ProjectPaiedValue] LIKE '{0}%') AND", this.ProjectPaiedValue);
            if (this.ProjectProgram != "") mWhere += string.Format("([ProjectProgram] LIKE '{0}%') AND", this.ProjectProgram);
            if (this.ProjectName != "") mWhere += string.Format("([ProjectName] LIKE '{0}%') AND", this.ProjectName);
            if (this.ProjectSponsor != "") mWhere += string.Format("([ProjectSponsor] LIKE '{0}%') AND", this.ProjectSponsor);
            if (mWhere.Length > 4)
            {
                mWhere = mWhere.Substring(0, mWhere.Length - 4);
            }
            return mWhere;
        }
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
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectID]) FROM [tproject] Where ProjectBudget=2");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static int DangProject(int myCond)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectID]) FROM [tproject] Where (ProjectBudget=2 and PortfolioID=" + myCond + ")");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get Count of Opened Project
        public static int OpenProject()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectID]) FROM [tproject] Where ProjectBudget=1");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static int GetProjectDataByID(int myPro)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT [ProjectID] FROM [tProject] Where ProjectID=" + myPro + "");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static int OpenProject(int myCond)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectID]) FROM [tproject] Where (ProjectBudget=1 and PortfolioID=" + myCond + ")");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get Count of Finished Project 
        public static int FinishedProject()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectID]) FROM [tproject] Where ProjectBudget=3");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static int FinishedProject(int myCond)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectID]) FROM [tproject] Where (ProjectBudget=3 and PortfolioID="+myCond+")");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get Count of Secret Project 
        public static int SecretPro()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectID]) FROM [tproject] WHERE IsSecret='True'");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get Count of NonSecret Project 
        public static int NonSecretPro()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectID]) FROM [tproject] WHERE IsSecret='False'");
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

        public static tProject GetProject(int id)
        {
            return new tProject(id);
        }
        //get last ID
        public static int myGetLastID()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT MAX([ProjectID]) FROM [tProject]");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get DropDwonlist ID
        public static int myGetDLID(string myDLValue)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT [ProjectID] FROM [tProject] WHERE ([ProjectName]='" + myDLValue + "')");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //Fill DropDownList
        public static void FillDropDownList(DropDownList myDropDownList)
        {
            DataTable dt = new DataTable();
            string mystring = "SELECT [ProjectID],[ProjectName] FROM tProject";
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
            string mystring = "SELECT [ProjectID],[ProjectName] FROM tProject where " + cond + "";
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
        public static void FillDropDownListFromView(DropDownList myDropDownList,string cond)
        {
            List<tProject> myList = new List<tProject>();
            tProject.FillList(myList,cond);

            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر مشروع---", "0"));

            foreach (tProject oDataRow in myList)
            {
                myDropDownList.Items.Add(new ListItem(oDataRow.ProjectName, oDataRow.ProjectID.ToString()));
                //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
            }
            myList.Clear();
            myList = null;
        }
        //Fill Gridview
        public static void FillGridView(GridView myGrideView,string mystring)
        {
            DataTable dt = new DataTable();
           // string mystring = "SELECT [ProjectID],[ProjectName] FROM Project";
            fayedDAL.FillDataTable(dt, mystring);
            myGrideView.DataSource = dt;
            myGrideView.DataBind();

        }
       
      
        public static DataTable GetProjectData(string str)
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


