
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

    #region tTask
    /// <summary>
    /// This object represents the properties and methods of a ( Project ) Table.
    /// </summary>
    public class tTask
    {
        private const string mFields = "[TaskID],[Task_ProjectID],[TaskName],[TaskMayorNote],[TaskDelayReson],[TaskPlanDate],[TaskPlanDateHijri],[TaskActualDate],[TaskActualDateHijri],[TaskIsAchived],[TaskUser],[Task_UserID]";

        #region Private Fields,ToString() Method

        private int _id;
        private int _TaskID;
        private int _Task_ProjectID;
        private string _TaskName = String.Empty;
        private string _TaskMayorNote = String.Empty;
        private string _TaskDelayReson = String.Empty;
        private DateTime _TaskPlanDate;
        private int _TaskPlanDateHijri;
        private DateTime _TaskActualDate;
        private int _TaskActualDateHijri;
        private bool _TaskIsAchived;
        private string _TaskUser = String.Empty;
        private int _Task_UserID;
        private int _TaskOrder;

        private int _TaskDMLactionUID;
        



        public override string ToString()
        {
            // the text that will be displayed in Listbox or Combobox
            return _id.ToString();
        }

        #endregion

        #region Public Properties
        public int TaskID
        {
            get { return _id; }
        }
        public int Task_ProjectID
        {
            get { return _Task_ProjectID; }
            set { _Task_ProjectID = value; }
        }
        public string TaskName
        {
            get { return _TaskName; }
            set { if (value.Length > 50) _TaskName = value.Substring(0, 50); else _TaskName = value; }
        }
        public string TaskMayorNote
        {
            get { return _TaskMayorNote; }
            set { if (value.Length > 50) _TaskMayorNote = value.Substring(0, 50); else _TaskMayorNote = value; }
        }
        public string TaskDelayReson
        {
            get { return _TaskDelayReson; }
            set { if (value.Length > 50) _TaskDelayReson = value.Substring(0, 50); else _TaskDelayReson = value; }
        }
        
        public DateTime TaskPlanDate
        {
            get { return _TaskPlanDate; }
            set { _TaskPlanDate = value; }
        }

        
        public int TaskPlanDateHijri
        {
            get { return _TaskPlanDateHijri; }
            set { _TaskPlanDateHijri = value; }
        }
       
        public string TaskPlanDateHijriString
        {
            get
            {
                string myDate = TaskPlanDateHijri.ToString();
                if (myDate.Length != 8) return "";
                return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
            }
        }
        public DateTime TaskActualDate
        {
            get { return _TaskActualDate; }
            set { _TaskActualDate = value; }
        }


        public int TaskActualDateHijri
        {
            get { return _TaskActualDateHijri; }
            set { _TaskActualDateHijri = value; }
        }
   
        public bool TaskIsAchived
        {
            get { return _TaskIsAchived; }
            set { _TaskIsAchived = value; }
        }
        public string TaskUser
        {
            get { return _TaskUser; }
            set { if (value.Length > 50) _TaskUser = value.Substring(0, 50); else _TaskUser = value; }
        }
        public int Task_UserID
        {
            get { return _Task_UserID; }
            set { _Task_UserID = value; }
        }
        public int TaskOrder
        {
            get { return _TaskOrder; }
            set { _TaskOrder = value; }
        }

        public int TaskDMLactionUID
        {
            get { return _TaskDMLactionUID; }
            set { _TaskDMLactionUID = value; }
        }

        #endregion

        #region Constractors

        public tTask()
        {
        }

        public tTask(int id)
        {
            LoadFromID(id);
        }

        public tTask(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT * FROM [tTask] WHERE TaskID = {0}", id);
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
                colOrdinal = reader.GetOrdinal("TaskID");
                _id = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("Task_ProjectID");
                if (!reader.IsDBNull(colOrdinal)) _Task_ProjectID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("TaskName");
                if (!reader.IsDBNull(colOrdinal)) _TaskName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("TaskMayorNote");
                if (!reader.IsDBNull(colOrdinal)) _TaskMayorNote = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("TaskDelayReson");
                if (!reader.IsDBNull(colOrdinal)) _TaskDelayReson = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("TaskPlanDate");
                if (!reader.IsDBNull(colOrdinal)) _TaskPlanDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("TaskPlanDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _TaskPlanDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("TaskActualDate");
                if (!reader.IsDBNull(colOrdinal)) _TaskActualDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("TaskActualDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _TaskActualDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("TaskIsAchived");
                if (!reader.IsDBNull(colOrdinal)) _TaskIsAchived = reader.GetBoolean(colOrdinal);
                colOrdinal = reader.GetOrdinal("TaskUser");
                if (!reader.IsDBNull(colOrdinal)) _TaskUser = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("Task_UserID");
                if (!reader.IsDBNull(colOrdinal)) _Task_UserID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("TaskOrder");
                if (!reader.IsDBNull(colOrdinal)) _TaskOrder = reader.GetInt32(colOrdinal);
            }
        }

        #endregion

        #region Create,Update,Delete

        public int Create()
        {
            DbCommand myCmd = fayedDAL.CreateCommand();
            string mCols, mValues = "";

            mCols = "[Task_ProjectID],[TaskName],[TaskMayorNote],[TaskDelayReson],[TaskPlanDate],[TaskPlanDateHijri],[TaskActualDate],[TaskActualDateHijri],[TaskIsAchived],[TaskUser],[Task_UserID],[TaskOrder],[TaskDMLcreateUID],[TaskDMLcreateDate],[TaskDMLactionUID],[TaskDMLactionDate],[TaskDMLactionType]";
            mValues += string.Format("{0},", Task_ProjectID);
            mValues += string.Format("'{0}',", TaskName);
            mValues += string.Format("'{0}',", TaskMayorNote);
            mValues += string.Format("'{0}',", TaskDelayReson);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(TaskPlanDate));
            mValues += string.Format("{0},", TaskPlanDateHijri);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(TaskActualDate));
            mValues += string.Format("{0},", TaskActualDateHijri);
            mValues += string.Format("{0},", ((TaskIsAchived == true) ? 1 : 0));
            mValues += string.Format("'{0}',", TaskUser);
            mValues += string.Format("{0},", Task_UserID);
            mValues += string.Format("{0},", TaskOrder);

            mValues += string.Format("{0},", TaskDMLactionUID); //DMLcreateUID
            mValues += string.Format("{0},", "GetDate()"); //DMLcreateDate
            mValues += string.Format("{0},", TaskDMLactionUID); //OprationUID
            mValues += string.Format("{0},", "GetDate()"); //DMLDate
            mValues += string.Format("'{0}'", "Insert"); //DMLOperation

            string query = String.Format("INSERT INTO [tTask] ({0}) VALUES ({1})", mCols, mValues);
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
            mTemp += string.Format("[Task_ProjectID]={0},", Task_ProjectID);
            mTemp += string.Format("[TaskName]='{0}',", TaskName);
            mTemp += string.Format("[TaskMayorNote]='{0}',", TaskMayorNote);
            mTemp += string.Format("[TaskDelayReson]='{0}',", TaskDelayReson);
            mTemp += string.Format("[TaskPlanDate]={0},", fayedDAL.GetSqlDate(TaskPlanDate));
            mTemp += string.Format("[TaskPlanDateHijri]={0},", TaskPlanDateHijri);
            mTemp += string.Format("[TaskActualDate]={0},", fayedDAL.GetSqlDate(TaskPlanDate));
            mTemp += string.Format("[TaskActualDateHijri]={0},", TaskPlanDateHijri);
            mTemp += string.Format("[TaskIsAchived]={0}", ((TaskIsAchived == true) ? 1 : 0));
            mTemp += string.Format("[TaskUser]={0},", TaskUser);
            mTemp += string.Format("[Task_UserID]='{0}',", Task_UserID);
            mTemp += string.Format("[TaskUser]={0},", TaskOrder);

            mTemp += string.Format("[TaskDMLactionUID]={0},", TaskDMLactionUID);
            mTemp += string.Format("[TaskDMLactionDate]={0},", "GetDate()");
            mTemp += string.Format("[TaskDMLactionType]='{0}'", "Update");

            string query = string.Format("UPDATE [tTask] SET {0} WHERE TaskID = {1}", mTemp, TaskID);
            myCmd.CommandText = query;
            return fayedDAL.ExecuteNonQuery(myCmd);
        }

        public int Delete()
        {
            if (_id == 0) return 0;
            List<ETDL.tTask> myTask = new List<ETDL.tTask>();
            ETDL.tTask.FillList(myTask, "TaskID=" + _id + "");

            DbCommand myCmd = fayedDAL.CreateCommand();
            string mTemp = "";

            foreach (ETDL.tTask mTheTask in myTask)
            {
                mTemp = string.Format("[TaskDMLactionType]='{0}',", "Delete");
                mTemp += string.Format("[TaskDMLactionDate]={0},", "GetDate()");
                mTemp += string.Format("[TaskDMLactionUID]={0}", TaskDMLactionUID);
                //mTemp += "[DepartmentIsDeleted]=1";



                string query = string.Format("UPDATE [tTask] SET {0} WHERE TaskID = {1}", mTemp, mTheTask.TaskID);
                myCmd.CommandText = query;
                fayedDAL.ExecuteNonQuery(myCmd);

                Delete(mTheTask.TaskID);
            }

            return 1;
        }

        #endregion

        #region Static Methods

        public static int Delete(int id)
        {
            if (id == 0) return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tTask] WHERE TaskID = {0}", id));
        }

        public static int Delete(string mFilter)
        {
            if (mFilter.Trim() == "") return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tTask] WHERE {0}", mFilter));
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
            string TempSql = string.Format("SELECT {0} FROM [tTask]", mFields);
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
            string TempSql = "SELECT * FROM [tTask]";
            if (SqlFilter != "") TempSql += " WHERE " + SqlFilter;
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;
            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                tTask TempObj;
                while (reader.Read())
                {
                    TempObj = new tTask(reader);
                    lst.Add(TempObj);
                }
            }
            reader.Close();
        }

   
   
        public static int GetTaskDataByID(int myPro)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT [TaskID] FROM [tTask] Where TaskID=" + myPro + "");
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
            return fayedDAL.GetRowsCount("tTask");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("tTask", SqlFilter);
        }

        public static tTask GetTask(int id)
        {
            return new tTask(id);
        }
        //get last ID
        public static int myGetLastID()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT MAX([TaskID]) FROM [tTask]");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //get DropDwonlist ID
        public static int myGetDLID(string myDLValue)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT [TaskID] FROM [tTask] WHERE ([TaskName]='" + myDLValue + "')");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        //Fill DropDownList
        public static void FillDropDownList(DropDownList myDropDownList)
        {
            DataTable dt = new DataTable();
            string mystring = "SELECT [TaskID],[TaskName] FROM tTask";
            fayedDAL.FillDataTable(dt, mystring);
            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر مهمه---", "0"));
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
            string mystring = "SELECT [TaskID],[TaskName] FROM tTask where " + cond + "";
            fayedDAL.FillDataTable(dt, mystring);
            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر مهمه---", "0"));
            foreach (DataRow oDataRow in dt.Rows)
            {
                myDropDownList.Items.Add(new ListItem(oDataRow[1].ToString(), oDataRow[0].ToString()));
                //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
            }
        }
        //Fill DropDownList with condition from view
        public static void FillDropDownListFromView(DropDownList myDropDownList, string cond)
        {
            List<tTask> myList = new List<tTask>();
            tTask.FillList(myList, cond);

            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر مهمه---", "0"));

            foreach (tTask oDataRow in myList)
            {
                myDropDownList.Items.Add(new ListItem(oDataRow.TaskName, oDataRow.TaskID.ToString()));
                //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
            }
            myList.Clear();
            myList = null;
        }
        //Fill Gridview
        public static void FillGridView(GridView myGrideView, string mystring)
        {
            DataTable dt = new DataTable();
            // string mystring = "SELECT [TaskID],[TaskName] FROM Project";
            fayedDAL.FillDataTable(dt, mystring);
            myGrideView.DataSource = dt;
            myGrideView.DataBind();

        }


        public static DataTable GetTaskData(string str)
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


