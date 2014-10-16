
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
    #region tAbbreviate
    /// <summary>
    /// This object represents the properties and methods of a ( Goal ) Table.
    /// </summary>
    public class tAbbreviate : IfayedDbTable
    {
        private const string mFields = "[AbbreviateID],[Abbreviate_ProjectID],[AbbreviateName],[AbbreviateUpdateDate],[AbbreviateUpdateDateHijri],[AbbreviateMayorNote],[AbbreviateOrder]";

        #region Private Fields,ToString() Method

        private int _id;
        private int _Abbreviate_ProjectID;
        private string _AbbreviateName = String.Empty;
        private DateTime _AbbreviateUpdateDate;
        private int _AbbreviateUpdateDateHijri;
        private string _AbbreviateMayorNote;
        private int _AbbreviateOrder;
        private int _AbbreviateDMLactionUID;



        public override string ToString()
        {
            // the text that will be displayed in Listbox or Combobox
            return _AbbreviateName.ToString();
        }

        #endregion

        #region Public Properties

        public int AbbreviateID
        {
            get { return _id; }
            //set { _id = value; }
        }

        public int Abbreviate_ProjectID
        {
            get { return _Abbreviate_ProjectID; }
            set { _Abbreviate_ProjectID = value; }
        }
        public string AbbreviateName
        {
            get { return _AbbreviateName; }
            set { if (value.Length > 100) _AbbreviateName = value.Substring(0, 100); else _AbbreviateName = value; }
        }
        public DateTime AbbreviateUpdateDate
        {
            get { return _AbbreviateUpdateDate; }
            set { _AbbreviateUpdateDate = value; }
        }
        public int AbbreviateUpdateDateHijri
        {
            get { return _AbbreviateUpdateDateHijri; }
            set { _AbbreviateUpdateDateHijri = value; }
        }
        public string AbbreviateMayorNote
        {
            get { return _AbbreviateMayorNote; }
            set { if (value.Length > 100) _AbbreviateMayorNote = value.Substring(0, 100); else _AbbreviateMayorNote = value; }
        }
        public int AbbreviateOrder
        {
            get { return _AbbreviateOrder; }
            set { _AbbreviateOrder = value; }
        }
        public int AbbreviateDMLactionUID
        {
            get { return _AbbreviateDMLactionUID; }
            set { _AbbreviateDMLactionUID = value; }
        }

        #endregion

        #region Constractors

        public tAbbreviate()
        {
        }

        public tAbbreviate(int id)
        {
            LoadFromID(id);
        }

        public tAbbreviate(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT {0} FROM [tAbbreviate] WHERE [AbbreviateID] = {1}", mFields, id);
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
                colOrdinal = reader.GetOrdinal("AbbreviateID");
                _id = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("Abbreviate_ProjectID");
                if (!reader.IsDBNull(colOrdinal)) _Abbreviate_ProjectID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("AbbreviateName");
                if (!reader.IsDBNull(colOrdinal)) _AbbreviateName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("AbbreviateUpdateDate");
                if (!reader.IsDBNull(colOrdinal)) _AbbreviateUpdateDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("AbbreviateUpdateDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _AbbreviateUpdateDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("AbbreviateMayorNote");
                if (!reader.IsDBNull(colOrdinal)) _AbbreviateMayorNote = reader.GetString(colOrdinal);
               
                
 
            }
        }

        #endregion

        #region Create,Update,Delete

        public int Create()
        {
            DbCommand myCmd = fayedDAL.CreateCommand();
            string mCols, mValues = "";

            mCols = "[Abbreviate_ProjectID],[AbbreviateName],[AbbreviateUpdateDate],[AbbreviateUpdateDateHijri],[AbbreviateMayorNote],[AbbreviateOrder],[AbbreviateDMLcreateUID],[AbbreviateDMLcreateDate],[AbbreviateDMLactionUID],[AbbreviateDMLactionDate],[AbbreviateDMLactionType]";
            mValues += string.Format("{0},", Abbreviate_ProjectID);
            mValues += string.Format("'{0}',", AbbreviateName);
            mValues += string.Format("{0},", fayedDAL.GetSqlDate(AbbreviateUpdateDate));
            mValues += string.Format("{0},", AbbreviateUpdateDateHijri);
            mValues += string.Format("'{0}',", AbbreviateMayorNote);
            mValues += string.Format("{0},", AbbreviateOrder);

            mValues += string.Format("{0},", AbbreviateDMLactionUID); //DMLcreateUID
            mValues += string.Format("{0},", "GetDate()"); //DMLcreateDate
            mValues += string.Format("{0},", AbbreviateDMLactionUID); //OprationUID
            mValues += string.Format("{0},", "GetDate()"); //DMLDate
            mValues += string.Format("'{0}'", "Insert"); //DMLOperation
            string query = String.Format("INSERT INTO [tAbbreviate] ({0}) VALUES ({1})", mCols, mValues);
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
            mTemp += string.Format("[Abbreviate_ProjectID]={0},", Abbreviate_ProjectID);
            mTemp += string.Format("[AbbreviateName]='{0}',", AbbreviateName);
            mTemp += string.Format("[AbbreviateUpdateDate]={0},", fayedDAL.GetSqlDate(AbbreviateUpdateDate));
            mTemp += string.Format("[AbbreviateUpdateDateHijri]={0},", AbbreviateUpdateDateHijri);
            mTemp += string.Format("[AbbreviateMayorNote]='{0}',", AbbreviateMayorNote);
            mTemp += string.Format("[AbbreviateOrder]={0},", AbbreviateOrder);

            mTemp += string.Format("[AbbreviateDMLactionUID]={0},", AbbreviateDMLactionUID);
            mTemp += string.Format("[AbbreviateDMLactionDate]={0},", "GetDate()");
            mTemp += string.Format("[AbbreviateDMLactionType]='{0}'", "Update");

            string query = string.Format("UPDATE [tAbbreviate] SET {0} WHERE [AbbreviateID] = {1}", mTemp, _id);
            myCmd.CommandText = query;
            return fayedDAL.ExecuteNonQuery(myCmd);
        }

        public int Delete()
        {
            if (_id == 0) return 0;
            List<ETDL.tAbbreviate> myAbbs = new List<ETDL.tAbbreviate>();
            ETDL.tAbbreviate.FillList(myAbbs, "AbbreviateID=" + _id + "");

            DbCommand myCmd = fayedDAL.CreateCommand();
            string mTemp = "";

            foreach (ETDL.tAbbreviate mTheAbb in myAbbs)
            {
                mTemp = string.Format("[AbbreviateDMLactionType]='{0}',", "Delete");
                mTemp += string.Format("[AbbreviateDMLactionDate]={0},", "GetDate()");
                mTemp += string.Format("[AbbreviateDMLactionUID]={0}", AbbreviateDMLactionUID);
                //mTemp += "[DepartmentIsDeleted]=1";



                string query = string.Format("UPDATE [tAbbreviate] SET {0} WHERE AbbreviateID = {1}", mTemp, mTheAbb.AbbreviateID);
                myCmd.CommandText = query;
                fayedDAL.ExecuteNonQuery(myCmd);

                Delete(mTheAbb.AbbreviateID);
            }

            return 1;
        }

        #endregion


        #region Static Methods

        public static int Delete(int id)
        {
            if (id == 0 || id == 1) return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tAbbreviate] WHERE [AbbreviateID] = {0}", id));
        }

        public static int Delete(string mFilter)
        {
            if (mFilter.Trim() == "") return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tAbbreviate] WHERE ([AbbreviateID]>=1) AND {0}", mFilter));
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
            string TempSql = "SELECT * FROM [tAbbreviate] WHERE ([AbbreviateID]>=1)";
            if (SqlFilter != "") TempSql += string.Format(" AND ({0}) ", SqlFilter);
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;

            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                tAbbreviate TempObj;
                while (reader.Read())
                {
                    TempObj = new tAbbreviate(reader);
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
            string TempSql = "SELECT * FROM [tAbbreviate] WHERE ([AbbreviateID]>=1)";
            if (SqlFilter != "") TempSql += string.Format(" AND ({0}) ", SqlFilter);
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;

            fayedDAL.FillDataTable(lst, TempSql);
        }

        public static int GetAbbreviateDataByAbbreviate_ProjectID(int myProID)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT [AbbreviateID] FROM [tAbbreviate] Where Abbreviate_ProjectID=" + myProID + "");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        


        public static int GetRowsCount()
        {
            return fayedDAL.GetRowsCount("tAbbreviate");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("tAbbreviate", SqlFilter);
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
