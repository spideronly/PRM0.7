
///////////////////////////////////////////////////
//
//			TwoSuns
//			mShmsan@hotmail.com
//			09-06-2009   01:18 PM
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
    #region tReport
    /// <summary>
    /// This object represents the properties and methods of a ( Goal ) Table.
    /// </summary>
    public class tReport : IfayedDbTable
    {
        private const string mFields = "[ReportID],[Report_ProjectID],[Report_UserID],[ReportCreateDate],[ReportCreateDateHijri],[ReportDateFrom],[ReportDateFromHijri],[ReportDateTo],[ReportDateToHijri],[ReportNote],[ReportOrder]";

        #region Private Fields,ToString() Method

        private int _id;
        private int _Report_ProjectID;
        private int _Report_UserID;
        private DateTime _ReportCreateDate;
        private int _ReportCreateDateHijri;
        private DateTime _ReportDateFrom;
        private int _ReportDateFromHijri;
        private DateTime _ReportDateTo;
        private int _ReportDateToHijri;
        private string _ReportNote;
        private int _ReportOrder;

        



       
        #endregion

        #region Public Properties

        public int ReportID
        {
            get { return _id; }
            //set { _id = value; }
        }

        public int Report_ProjectID
        {
            get { return _Report_ProjectID; }
            set { _Report_ProjectID = value; }
        }
        public int Report_UserID
        {
            get { return _Report_UserID; }
            set { _Report_UserID = value; }
        }
        public DateTime ReportCreateDate
        {
            get { return _ReportCreateDate; }
            set { _ReportCreateDate = value; }
        }
        public int ReportCreateDateHijri
        {
            get { return _ReportCreateDateHijri; }
            set { _ReportCreateDateHijri = value; }
        }
        public DateTime ReportDateFrom
        {
            get { return _ReportDateFrom; }
            set { _ReportDateFrom = value; }
        }
        public int ReportDateFromHijri
        {
            get { return _ReportDateFromHijri; }
            set { _ReportDateFromHijri = value; }
        }
        public DateTime ReportDateTo
        {
            get { return _ReportDateTo; }
            set { _ReportDateTo = value; }
        }
        public int ReportDateToHijri
        {
            get { return _ReportDateToHijri; }
            set { _ReportDateToHijri = value; }
        }
        public string ReportNote
        {
            get { return _ReportNote; }
            set { if (value.Length > 100) _ReportNote = value.Substring(0, 100); else _ReportNote = value; }
        }
        public int ReportOrder
        {
            get { return _ReportOrder; }
            set { _ReportOrder = value; }
        }

       

        #endregion

        #region Constractors

        public tReport()
        {
        }

        public tReport(int id)
        {
            LoadFromID(id);
        }

        public tReport(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT {0} FROM [tReport] WHERE [ReportID] = {1}", mFields, id);
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
                throw new ApplicationException("Selected Goal Row Does Not Exist.");
            }
        }

        protected void LoadFromReader(DbDataReader reader)
        {
            int colOrdinal;
            if (reader != null && !reader.IsClosed)
            {
                colOrdinal = reader.GetOrdinal("ReportID");
                _id = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("Report_ProjectID");
                if (!reader.IsDBNull(colOrdinal)) _Report_ProjectID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("Report_UserID");
                if (!reader.IsDBNull(colOrdinal)) _Report_UserID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ReportCreateDate");
                if (!reader.IsDBNull(colOrdinal)) _ReportCreateDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ReportCreateDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ReportCreateDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ReportDateFrom");
                if (!reader.IsDBNull(colOrdinal)) _ReportDateFrom = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ReportDateFromHijri");
                if (!reader.IsDBNull(colOrdinal)) _ReportDateFromHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ReportDateTo");
                if (!reader.IsDBNull(colOrdinal)) _ReportDateTo = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ReportDateToHijri");
                if (!reader.IsDBNull(colOrdinal)) _ReportDateToHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ReportNote");
                if (!reader.IsDBNull(colOrdinal)) _ReportNote = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ReportOrder");
                if (!reader.IsDBNull(colOrdinal)) _ReportOrder = reader.GetInt32(colOrdinal);
                


            }
        }

        #endregion

        #region Create,Update,Delete

        public int Create()
        {
            DbCommand myCmd = fayedDAL.CreateCommand();
            string mCols, mValues = "";

            mCols = "[Report_ProjectID],[Report_UserID],[ReportCreateDate],[ReportCreateDateHijri],[ReportDateFrom],[ReportDateFromHijri],[ReportDateTo],[ReportDateToHijri],[ReportNote],[ReportOrder]";
            mValues += string.Format("{0},", Report_ProjectID);
            mValues += string.Format("{0},", Report_UserID);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(ReportCreateDate));
            mValues += string.Format("{0},", ReportCreateDateHijri);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(ReportDateFrom));
            mValues += string.Format("{0},", ReportDateFromHijri);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(ReportDateTo));
            mValues += string.Format("{0},", ReportDateToHijri);
            mValues += string.Format("'{0}',", ReportNote);
            mValues += string.Format("{0}", ReportOrder);

            string query = String.Format("INSERT INTO [tReport] ({0}) VALUES ({1})", mCols, mValues);
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
            mTemp += string.Format("[Report_ProjectID]={0},", Report_ProjectID);
            mTemp += string.Format("[Report_ProjectID]={0},", Report_UserID);
            mTemp += string.Format("[ReportCreateDate]={0},", fayedDAL.GetSqlDate(ReportCreateDate));
            mTemp += string.Format("[ReportCreateDateHijri]={0},", ReportCreateDateHijri);
            mTemp += string.Format("[ReportDateFrom]={0},", fayedDAL.GetSqlDate(ReportDateFrom));
            mTemp += string.Format("[ReportDateFromHijri]={0},", ReportDateFromHijri);
            mTemp += string.Format("[ReportDateTo]={0},", fayedDAL.GetSqlDate(ReportDateTo));
            mTemp += string.Format("[ReportDateToHijri]={0},", ReportDateToHijri);
            mTemp += string.Format("[ReportNote]='{0}',", ReportNote);
            mTemp += string.Format("[ReportOrder]={0}", ReportOrder);


            string query = string.Format("UPDATE [tReport] SET {0} WHERE [ReportID] = {1}", mTemp, _id);
            myCmd.CommandText = query;
            return fayedDAL.ExecuteNonQuery(myCmd);
        }

        public int Delete()
        {
             return Delete(_id);
        }

        #endregion


        #region Static Methods

        public static int Delete(int id)
        {
            if (id == 0 || id == 1) return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tReport] WHERE [ReportID] = {0}", id));
        }

        public static int Delete(string mFilter)
        {
            if (mFilter.Trim() == "") return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tReport] WHERE ([ReportID]>=1) AND {0}", mFilter));
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
            string TempSql = "SELECT * FROM [tReport] WHERE ([ReportID]>=1)";
            if (SqlFilter != "") TempSql += string.Format(" AND ({0}) ", SqlFilter);
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;

            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                tReport TempObj;
                while (reader.Read())
                {
                    TempObj = new tReport(reader);
                    lst.Add(TempObj);
                }
            }
            reader.Close();
        }

        public static void FillList(DataTable lst, string SqlFilter)
        {
            FillList(lst, SqlFilter, "");
        }

        public static void FillList(DataTable lst, string SqlFilter, string mOrderBy)
        {
            string TempSql = "SELECT * FROM [tReport] WHERE ([ReportID]>=1)";
            if (SqlFilter != "") TempSql += string.Format(" AND ({0}) ", SqlFilter);
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;

            fayedDAL.FillDataTable(lst, TempSql);
        }

        //public static int GetReportDataByReport_ProjectID(int myProID)
        //{
        //    object mm = fayedDAL.ExecuteScalar("SELECT [ReportID] FROM [tReport] Where Report_ProjectID=" + myProID + "");
        //    if (mm != null)
        //        return int.Parse(mm.ToString());
        //    else
        //        return 0;
        //}



        public static int GetRowsCount()
        {
            return fayedDAL.GetRowsCount("tReport");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("tReport", SqlFilter);
        }




        #endregion

        #region IfayedDbTable impelementation

        void IfayedDbTable.FillList(IList lst)
        {
            FillList(lst);
        }

        void IfayedDbTable.FillList(IList lst, string SqlFilter)
        {
            FillList(lst, SqlFilter);
        }

        #endregion

    }
    #endregion

}
