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

    #region tProjectData
    /// <summary>
    /// This object represents the properties and methods of a ( ProjectData ) Table.
    /// </summary>
    public class tProjectData
    {
        private const string mFields = "[ProjectDataID],[ProjectDataName],[ProjectDataSponsor],[ProjectDataProgram],[ProjectDataManager],[ProjectDataStartDate],[ProjectDataStartDateHijri],[ProjectDataEndDate],[ProjectDataEndDateHijri],[ProjectDataActualStartDate],[ProjectDataActualStartDateHijri],[ProjectDataActualEndDate],[ProjectDataActualEndDateHijri],[ProjectDataContractor],[ProjectDataBudget],[ProjectDataProgress],[ProjectDataPaiedValue],[ProjectData_ProjectType],[ProjectData_DepartmentID],[ProjectDataDescription],[ProjectDataBossNote],[ProjectData_ProgressTypeID]";

        #region Private Fields,ToString() Method

        private int _id;
        private int _ProjectDataID;
        private string _ProjectDataName = String.Empty;
        private string _ProjectDataSponsor = String.Empty;
        private string _ProjectDataProgram = String.Empty;
        private string _ProjectDataManager = String.Empty;
        private DateTime _ProjectDataStartDate;
        private int _ProjectDataStartDateHijri;
        private DateTime _ProjectDataEndDate;
        private int _ProjectDataEndDateHijri;
        private DateTime _ProjectDataActualStartDate;
        private int _ProjectDataActualStartDateHijri;
        private DateTime _ProjectDataActualEndDate;
        private int _ProjectDataActualEndDateHijri;
        private string _ProjectDataContractor = String.Empty;
        private int _ProjectDataBudget;
        private string _ProjectDataProgress;
        private int _ProjectDataPaiedValue;
        private int _ProjectData_ProjectType;
        private int _ProjectData_DepartmentID;
        private string _ProjectDataDescription = String.Empty;
        private string _ProjectDataBossNote = String.Empty;
        private int _ProjectData_ProgressTypeID;
        private int _ProjectDataOrder;
        private int _ProjectDataDMLactionUID;

        public override string ToString()
        {
            // the text that will be displayed in Listbox or Combobox
            return _id.ToString();
        }

        #endregion

        #region Public Properties
        public int ProjectDataID
        {
            get { return _id; }
        }
        public string ProjectDataName
        {
            get { return _ProjectDataName; }
            set { if (value.Length > 50) _ProjectDataName = value.Substring(0, 50); else _ProjectDataName = value; }
        }
        public string ProjectDataSponsor
        {
            get { return _ProjectDataSponsor; }
            set { if (value.Length > 50) _ProjectDataSponsor = value.Substring(0, 50); else _ProjectDataSponsor = value; }
        }
        public string ProjectDataProgram
        {
            get { return _ProjectDataProgram; }
            set { if (value.Length > 50) _ProjectDataProgram = value.Substring(0, 50); else _ProjectDataProgram = value; }
        }
        public string ProjectDataManager
        {
            get { return _ProjectDataManager; }
            set { if (value.Length > 50) _ProjectDataManager = value.Substring(0, 50); else _ProjectDataManager = value; }
        }
        public DateTime ProjectDataStartDate
        {
            get { return _ProjectDataStartDate; }
            set { _ProjectDataStartDate = value; }
        }
        public int ProjectDataStartDateHijri
        {
            get { return _ProjectDataStartDateHijri; }
            set { _ProjectDataStartDateHijri = value; }
        }
        public string ProjectDataStartDateHijriString
        {
            get
            {
                string myDate = ProjectDataStartDateHijri.ToString();
                if (myDate.Length != 8) return "";
                //return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
                return myDate.Substring(0, 4) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(6, 2);
            }
        }
        public DateTime ProjectDataEndDate
        {
            get { return _ProjectDataEndDate; }
            set { _ProjectDataEndDate = value; }
        }
        public int ProjectDataEndDateHijri
        {
            get { return _ProjectDataEndDateHijri; }
            set { _ProjectDataEndDateHijri = value; }
        }
        public string ProjectDataEndDateHijriString
        {
            get
            {
                string myDate = ProjectDataEndDateHijri.ToString();
                if (myDate.Length != 8) return "";
               // return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
                return myDate.Substring(0, 4)+ "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(6, 2) ;
            }
        }
        public DateTime ProjectDataActualStartDate
        {
            get { return _ProjectDataActualStartDate; }
            set { _ProjectDataActualStartDate = value; }
        }
        public int ProjectDataActualStartDateHijri
        {
            get { return _ProjectDataActualStartDateHijri; }
            set { _ProjectDataActualStartDateHijri = value; }
        }
        public DateTime ProjectDataActualEndDate
        {
            get { return _ProjectDataActualEndDate; }
            set { _ProjectDataActualEndDate = value; }
        }
        public int ProjectDataActualEndDateHijri
        {
            get { return _ProjectDataActualEndDateHijri; }
            set { _ProjectDataActualEndDateHijri = value; }
        }
         public string ProjectDataContractor
        {
            get { return _ProjectDataContractor; }
            set { if (value.Length > 50) _ProjectDataContractor = value.Substring(0, 50); else _ProjectDataContractor = value; }
        }
        public int ProjectDataBudget
        {
            get { return _ProjectDataBudget; }
            set { _ProjectDataBudget = value; }
        }
        public string ProjectDataProgress
        {
            get { return _ProjectDataProgress; }
            set { if (value.Length > 50) _ProjectDataProgress = value.Substring(0, 50); else _ProjectDataProgress = value; }
        }
        
        public int ProjectDataPaiedValue
        {
            get { return _ProjectDataPaiedValue; }
            set { _ProjectDataPaiedValue = value; }
        }
        public int ProjectData_ProjectType
        {
            get { return _ProjectData_ProjectType; }
            set { _ProjectData_ProjectType = value; }
        }
       
        public int ProjectData_DepartmentID
        {
            get { return _ProjectData_DepartmentID; }
            set { _ProjectData_DepartmentID = value; }
        }
        public string ProjectDataDescription
        {
            get { return _ProjectDataDescription; }
            set { if (value.Length > 50) _ProjectDataDescription = value.Substring(0, 50); else _ProjectDataDescription = value; }
        }
        public string ProjectDataBossNote
        {
            get { return _ProjectDataBossNote; }
            set { if (value.Length > 50) _ProjectDataBossNote = value.Substring(0, 50); else _ProjectDataBossNote = value; }
        }
        

        public int ProjectData_ProgressTypeID
        {
            get { return _ProjectData_ProgressTypeID; }
            set { _ProjectData_ProgressTypeID = value; }
        }

        public int ProjectDataOrder
        {
            get { return _ProjectDataOrder; }
            set { _ProjectDataOrder = value; }
        }

        public int ProjectDataDMLactionUID
        {
            get { return _ProjectDataDMLactionUID; }
            set { _ProjectDataDMLactionUID = value; }
        }

        #endregion

        #region Constractors

        public tProjectData()
        {
        }

        public tProjectData(int id)
        {
            LoadFromID(id);
        }

        public tProjectData(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT * FROM [tProjectData] WHERE ProjectDataID = {0}", id);
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
                throw new ApplicationException("Selected ProjectData Row Does Not Exist.");
            }
        }

        protected void LoadFromReader(DbDataReader reader)
        {
            int colOrdinal;
            if (reader != null && !reader.IsClosed)
            {
                colOrdinal = reader.GetOrdinal("ProjectDataID");
                _id = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataName");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataSponsor");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataSponsor = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataProgram");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataProgram = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataManager");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataManager = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataStartDate");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataStartDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataStartDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataStartDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataEndDate");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataEndDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataEndDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataEndDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataActualStartDate");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataActualStartDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataActualStartDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataActualStartDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataActualEndDate");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataActualEndDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataActualEndDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataActualEndDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataContractor");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataContractor = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataBudget");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataBudget = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataProgress");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataProgress = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataPaiedValue");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataPaiedValue = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectData_ProjectType");
                if (!reader.IsDBNull(colOrdinal)) _ProjectData_ProjectType = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectData_DepartmentID");
                if (!reader.IsDBNull(colOrdinal)) _ProjectData_DepartmentID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataDescription");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataDescription = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataBossNote");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataBossNote = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectData_ProgressTypeID");
                if (!reader.IsDBNull(colOrdinal)) _ProjectData_ProgressTypeID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDataOrder");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDataOrder = reader.GetInt32(colOrdinal);
                
               
            }
        }

        #endregion

        #region Create,Update,Delete

        public int Create()
        {
            DbCommand myCmd = fayedDAL.CreateCommand();
            string mCols, mValues = "";

            mCols = "[ProjectDataName],[ProjectDataSponsor],[ProjectDataProgram],[ProjectDataManager],[ProjectDataStartDate],[ProjectDataStartDateHijri],[ProjectDataEndDate],[ProjectDataEndDateHijri],[ProjectDataActualStartDate],[ProjectDataActualStartDateHijri],[ProjectDataActualEndDate],[ProjectDataActualEndDateHijri],[ProjectDataContractor],[ProjectDataBudget],[ProjectDataProgress],[ProjectDataPaiedValue],[ProjectData_ProjectType],[ProjectData_DepartmentID],[ProjectDataDescription],[ProjectDataBossNote],[ProjectData_ProgressTypeID],[ProjectDataOrder],[ProjectDataDMLcreateUID],[ProjectDataDMLcreateDate],[ProjectDataDMLactionUID],[ProjectDataDMLactionDate],[ProjectDataDMLactionType]";
            mValues += string.Format("'{0}',", ProjectDataName);
            mValues += string.Format("'{0}',", ProjectDataSponsor);
            mValues += string.Format("'{0}',", ProjectDataProgram);
            mValues += string.Format("'{0}',", ProjectDataManager);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(ProjectDataStartDate));
            mValues += string.Format("{0},", ProjectDataStartDateHijri);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(ProjectDataEndDate));
            mValues += string.Format("{0},", ProjectDataEndDateHijri);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(ProjectDataActualStartDate));
            mValues += string.Format("{0},", ProjectDataActualStartDateHijri);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(ProjectDataActualEndDate));
            mValues += string.Format("{0},", ProjectDataActualEndDateHijri);
            mValues += string.Format("'{0}',", ProjectDataContractor);
            mValues += string.Format("{0},", ProjectDataBudget);
            mValues += string.Format("'{0}',", ProjectDataProgress);
            mValues += string.Format("{0},", ProjectDataPaiedValue);
            mValues += string.Format("{0},", ProjectData_ProjectType);
            mValues += string.Format("{0},", ProjectData_DepartmentID);
            mValues += string.Format("'{0}',", ProjectDataDescription);
            mValues += string.Format("'{0}',", ProjectDataBossNote);
            mValues += string.Format("{0},", ProjectData_ProgressTypeID);
            mValues += string.Format("{0},", ProjectDataOrder);


            mValues += string.Format("{0},", ProjectDataDMLactionUID); //DMLcreateUID
            mValues += string.Format("{0},", "GetDate()"); //DMLcreateDate
            mValues += string.Format("{0},", ProjectDataDMLactionUID); //OprationUID
            mValues += string.Format("{0},", "GetDate()"); //DMLDate
            mValues += string.Format("'{0}'", "Insert"); //DMLOperation

            string query = String.Format("INSERT INTO [tProjectData] ({0}) VALUES ({1})", mCols, mValues);
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
            
            mTemp += string.Format("[ProjectDataName]='{0}',", ProjectDataName);
            mTemp += string.Format("[ProjectDataSponsor]='{0}',", ProjectDataSponsor);
            mTemp += string.Format("[ProjectDataProgram]='{0}',", ProjectDataProgram);
            mTemp += string.Format("[ProjectDataManager]='{0}',", ProjectDataManager);
            mTemp += string.Format("[ProjectDataStartDate]={0},", fayedDAL.GetSqlDate(ProjectDataStartDate));
            mTemp += string.Format("[ProjectDataStartDateHijri]={0},", ProjectDataStartDateHijri);
            mTemp += string.Format("[ProjectDataEndDate]={0},", fayedDAL.GetSqlDate(ProjectDataEndDate));
            mTemp += string.Format("[ProjectDataEndDateHijri]={0},", ProjectDataEndDateHijri);
            mTemp += string.Format("[ProjectDataActualStartDate]={0},", fayedDAL.GetSqlDate(ProjectDataActualStartDate));
            mTemp += string.Format("[ProjectDataActualStartDateHijri]={0},", ProjectDataActualStartDateHijri);
            mTemp += string.Format("[ProjectDataActualEndDate]={0},", fayedDAL.GetSqlDate(ProjectDataActualEndDate));
            mTemp += string.Format("[ProjectDataActualEndDateHijri]={0},", ProjectDataActualEndDateHijri);
            mTemp += string.Format("[ProjectDataContractor]='{0}',", ProjectDataContractor);
            mTemp += string.Format("[ProjectDataBudget]={0},", ProjectDataBudget);
            mTemp += string.Format("[ProjectDataProgress]='{0}',", ProjectDataProgress);
            mTemp += string.Format("[ProjectDataPaiedValue]={0},", ProjectDataPaiedValue);
            mTemp += string.Format("[ProjectData_ProjectType]={0},", ProjectData_ProjectType);
            mTemp += string.Format("[ProjectData_DepartmentID]={0},", ProjectData_DepartmentID);
            mTemp += string.Format("[ProjectDataDescription]='{0}',", ProjectDataDescription);
            mTemp += string.Format("[ProjectDataBossNote]='{0}',", ProjectDataBossNote);
            mTemp += string.Format("[ProjectData_ProgressTypeID]={0},", ProjectData_ProgressTypeID);
            mTemp += string.Format("[ProjectDataOrder]={0},", ProjectDataOrder);

            mTemp += string.Format("[ProjectDataDMLactionUID]={0},", ProjectDataDMLactionUID);
            mTemp += string.Format("[ProjectDataDMLactionDate]={0},", "GetDate()");
            mTemp += string.Format("[ProjectDataDMLactionType]='{0}'", "Update");


            string query = string.Format("UPDATE [tProjectData] SET {0} WHERE ProjectDataID = {1}", mTemp, ProjectDataID);
            myCmd.CommandText = query;
            return fayedDAL.ExecuteNonQuery(myCmd);
        }

        public int Delete()
        {
            if (_id == 0) return 0;
            List<ETDL.tProjectData> myProj = new List<ETDL.tProjectData>();
            ETDL.tProjectData.FillList(myProj, "ProjectDataID=" + _id + "");

            DbCommand myCmd = fayedDAL.CreateCommand();
            string mTemp = "";

            foreach (ETDL.tProjectData mTheProj in myProj)
            {
                mTemp = string.Format("[ProjectDataDMLactionType]='{0}',", "Delete");
                mTemp += string.Format("[ProjectDataDMLactionDate]={0},", "GetDate()");
                mTemp += string.Format("[ProjectDataDMLactionUID]={0}", ProjectDataDMLactionUID);
                //mTemp += "[DepartmentIsDeleted]=1";



                string query = string.Format("UPDATE [tProjectData] SET {0} WHERE ProjectDataID = {1}", mTemp, mTheProj.ProjectDataID);
                myCmd.CommandText = query;
                fayedDAL.ExecuteNonQuery(myCmd);

                Delete(mTheProj.ProjectDataID);
            }

            return 1;
        }

        #endregion

        #region Static Methods

        public static int Delete(int id)
        {
            if (id == 0) return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tProjectData] WHERE ProjectDataID = {0}", id));
        }

        public static int Delete(string mFilter)
        {
            if (mFilter.Trim() == "") return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tProjectData] WHERE {0}", mFilter));
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
            string TempSql = string.Format("SELECT {0} FROM [tProjectData]", mFields);
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
            string TempSql = "SELECT * FROM [tProjectData]";
            if (SqlFilter != "") TempSql += " WHERE " + SqlFilter;
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;
            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                tProjectData TempObj;
                while (reader.Read())
                {
                    TempObj = new tProjectData(reader);
                    lst.Add(TempObj);
                }
            }
            reader.Close();
        }

        public string GetWhereCluse()
        {
            string mWhere = "";

            if (this.ProjectDataBudget >0) mWhere += string.Format("([ProjectDataBudget] LIKE '{0}%') AND", this.ProjectDataBudget);
            if (this.ProjectData_DepartmentID > 0) mWhere += string.Format("([ProjectData_DepartmentID] = {0}) AND", this.ProjectData_DepartmentID);
            if (this.ProjectDataManager != "") mWhere += string.Format("([ProjectDataManager] LIKE '{0}%') AND", this.ProjectDataManager);
            if (this.ProjectDataPaiedValue > 0) mWhere += string.Format("([ProjectDataPaiedValue] LIKE '{0}%') AND", this.ProjectDataPaiedValue);
            if (this.ProjectDataProgram != "") mWhere += string.Format("([ProjectDataProgram] LIKE '{0}%') AND", this.ProjectDataProgram);
            if (this.ProjectDataName != "") mWhere += string.Format("([ProjectDataName] LIKE '{0}%') AND", this.ProjectDataName);
            if (this.ProjectDataSponsor != "") mWhere += string.Format("([ProjectDataSponsor] LIKE '{0}%') AND", this.ProjectDataSponsor);
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
        //get Count of Dangrouse ProjectData that pass end date
        public static int DangProjectData()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectDataID]) FROM [tProjectData] Where ProjectDataBudget=2");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static int DangProjectData(int myCond)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectDataID]) FROM [tProjectData] Where (ProjectDataBudget=2 and PortfolioID=" + myCond + ")");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get Count of Opened ProjectData
        public static int OpenProjectData()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectDataID]) FROM [tProjectData] Where ProjectDataBudget=1");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static int GetProjectDataDataByID(int myPro)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT [ProjectDataID] FROM [tProjectData] Where ProjectDataID=" + myPro + "");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static int OpenProjectData(int myCond)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectDataID]) FROM [tProjectData] Where (ProjectDataBudget=1 and PortfolioID=" + myCond + ")");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get Count of Finished ProjectData 
        public static int FinishedProjectData()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectDataID]) FROM [tProjectData] Where ProjectDataBudget=3");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static int FinishedProjectData(int myCond)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectDataID]) FROM [tProjectData] Where (ProjectDataBudget=3 and PortfolioID="+myCond+")");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get Count of Secret ProjectData 
        public static int SecretPro()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectDataID]) FROM [tProjectData] WHERE IsSecret='True'");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get Count of NonSecret ProjectData 
        public static int NonSecretPro()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT Count([ProjectDataID]) FROM [tProjectData] WHERE IsSecret='False'");
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
            return fayedDAL.GetRowsCount("ProjectData");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("ProjectData", SqlFilter);
        }

        public static tProjectData GetProjectData(int id)
        {
            return new tProjectData(id);
        }
        //get last ID
        public static int myGetLastID()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT MAX([ProjectDataID]) FROM [tProjectData]");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get DropDwonlist ID
        public static int myGetDLID(string myDLValue)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT [ProjectDataID] FROM [tProjectData] WHERE ([ProjectDataName]='" + myDLValue + "')");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //Fill DropDownList
        public static void FillDropDownList(DropDownList myDropDownList)
        {
            DataTable dt = new DataTable();
            string mystring = "SELECT [ProjectDataID],[ProjectDataName] FROM tProjectData";
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
            string mystring = "SELECT [ProjectDataID],[ProjectDataName] FROM tProjectData where " + cond + "";
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
            List<tProjectData> myList = new List<tProjectData>();
            tProjectData.FillList(myList,cond);

            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر مشروع---", "0"));

            foreach (tProjectData oDataRow in myList)
            {
                myDropDownList.Items.Add(new ListItem(oDataRow.ProjectDataName, oDataRow.ProjectDataID.ToString()));
                //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
            }
            myList.Clear();
            myList = null;
        }
        //Fill Gridview
        public static void FillGridView(GridView myGrideView,string mystring)
        {
            DataTable dt = new DataTable();
           // string mystring = "SELECT [ProjectDataID],[ProjectDataName] FROM ProjectData";
            fayedDAL.FillDataTable(dt, mystring);
            myGrideView.DataSource = dt;
            myGrideView.DataBind();

        }
       
      
        public static DataTable GetProjectDataData(string str)
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


