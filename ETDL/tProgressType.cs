
///////////////////////////////////////////////////
//
//			Mohammed Samir Fayed
//			ms_fayed@hotmail.com
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
    #region tProgressType
    /// <summary>
    /// This object represents the properties and methods of a ( tProgressType ) Table.
    /// </summary>
    public class tProgressType : IfayedDbTable
    {
        private const string mFields = "[ProgressTypeID],[ProgressTypeName]";

        #region Private Fields,ToString() Method

        private int _id;
        private string _ProgressTypeName = String.Empty;





        public override string ToString()
        {
            // the text that will be displayed in Listbox or Combobox
            return _ProgressTypeName.ToString();
        }

        #endregion

        #region Public Properties

        public int ProgressTypeID
        {
            get { return _id; }
            //set { _id = value; }
        }

        public string ProgressTypeName
        {
            get { return _ProgressTypeName; }
            set { if (value.Length > 100) _ProgressTypeName = value.Substring(0, 100); else _ProgressTypeName = value; }
        }









        #endregion

        #region Constractors

        public tProgressType()
        {
        }

        public tProgressType(int id)
        {
            LoadFromID(id);
        }

        public tProgressType(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT {0} FROM [tProgressType] WHERE [ProgressTypeID] = {1}", mFields, id);
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
                throw new ApplicationException("Selected tProgressType Row Does Not Exist.");
            }
        }

        protected void LoadFromReader(DbDataReader reader)
        {
            int colOrdinal;
            if (reader != null && !reader.IsClosed)
            {
                colOrdinal = reader.GetOrdinal("ProgressTypeID");
                _id = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProgressTypeName");
                if (!reader.IsDBNull(colOrdinal)) _ProgressTypeName = reader.GetString(colOrdinal);

            }
        }

        #endregion

        #region Create,Update,Delete

        public int Create()
        {
            DbCommand myCmd = fayedDAL.CreateCommand();
            string mCols, mValues = "";

            mCols = "[ProgressTypeName]";
            mValues += string.Format("'{0}'", ProgressTypeName);

            string query = String.Format("INSERT INTO [tProgressType] ({0}) VALUES ({1})", mCols, mValues);
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

            mTemp += string.Format("[ProgressTypeName]='{0}',", ProgressTypeName);


            string query = string.Format("UPDATE [tProgressType] SET {0} WHERE [ProgressTypeID] = {1}", mTemp, _id);
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
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tProgressType] WHERE [ProgressTypeID] = {0}", id));
        }

        public static int Delete(string mFilter)
        {
            if (mFilter.Trim() == "") return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tProgressType] WHERE ([ProgressTypeID]>1) AND {0}", mFilter));
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
            string TempSql = "SELECT * FROM [tProgressType] WHERE ([ProgressTypeID]>=1)";
            if (SqlFilter != "") TempSql += string.Format(" AND ({0}) ", SqlFilter);
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;

            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                tProgressType TempObj;
                while (reader.Read())
                {
                    TempObj = new tProgressType(reader);
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
            string TempSql = "SELECT * FROM [tProgressType] WHERE ([ProgressTypeID]>1)";
            if (SqlFilter != "") TempSql += string.Format(" AND ({0}) ", SqlFilter);
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;

            fayedDAL.FillDataTable(lst, TempSql);
        }

        public static void FillDropDownList(DropDownList myDropDownList)
        {
            List<tProgressType> myList = new List<tProgressType>();
            tProgressType.FillList(myList);

            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر---", "0"));

            foreach (tProgressType oDataRow in myList)
            {
                myDropDownList.Items.Add(new ListItem(oDataRow.ToString(), oDataRow.ProgressTypeID.ToString()));
                //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
            }
            myList.Clear();
            myList = null;
        }


        public static int GetRowsCount()
        {
            return fayedDAL.GetRowsCount("tProgressType");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("tProgressType", SqlFilter);
        }

        //public static bool IsUserHavePremitions(int ProgressTypeID)
        //{
        //    int ii = GetRowsCount("[ProgressTypeID]=" + ProgressTypeID.ToString());
        //    if (ii > 0) return true;
        //    else return false;
        //}

        //public static int CheckLogin(string mProgressTypeName, string mUserModificationDate)
        //{
        //    if (mProgressTypeName == "" || mUserModificationDate == "") return -1;

        //    object mRet = fayedDAL.ExecuteScalar(string.Format("SELECT [ProgressTypeID] FROM [CusType] WHERE [ProgressTypeName] = '{0}' AND [ModificationDate] = '{1}'", mProgressTypeName, mUserModificationDate));
        //    if (mRet == null)
        //        return -1;
        //    else
        //        return (int)mRet;
        //}

        //public static string GetLoginDisplayName(int mProgressTypeID)
        //{
        //    if (mProgressTypeID <= 0) return "";

        //    object mRet = fayedDAL.ExecuteScalar("SELECT [DisplayName] FROM [CusType] WHERE [ProgressTypeID] =" + mProgressTypeID);
        //    if (mRet == null)
        //        return "";
        //    else
        //        return mRet.ToString();
        //}


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




//public static bool IsUserHavePremitions(int ProgressTypeID)
//       {
//           int ii = GetRowsCount("[loginPer_ProgressTypeID]=" + ProgressTypeID.ToString());
//           if (ii > 0) return true;
//           else return false;
//       }
