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
    #region tProjectType
    /// <summary>
    /// This object represents the properties and methods of a ( tProjectType ) Table.
    /// </summary>
    public class tProjectType : IfayedDbTable
    {
        private const string mFields = "[ProjectTypeID],[ProjectTypeName]";

        #region Private Fields,ToString() Method

        private int _id;
        private string _ProjectTypeName = String.Empty;





        public override string ToString()
        {
            // the text that will be displayed in Listbox or Combobox
            return _ProjectTypeName.ToString();
        }

        #endregion

        #region Public Properties

        public int ProjectTypeID
        {
            get { return _id; }
            //set { _id = value; }
        }

        public string ProjectTypeName
        {
            get { return _ProjectTypeName; }
            set { if (value.Length > 100) _ProjectTypeName = value.Substring(0, 100); else _ProjectTypeName = value; }
        }









        #endregion

        #region Constractors

        public tProjectType()
        {
        }

        public tProjectType(int id)
        {
            LoadFromID(id);
        }

        public tProjectType(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT {0} FROM [tProjectType] WHERE [ProjectTypeID] = {1}", mFields, id);
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
                throw new ApplicationException("Selected tProjectType Row Does Not Exist.");
            }
        }

        protected void LoadFromReader(DbDataReader reader)
        {
            int colOrdinal;
            if (reader != null && !reader.IsClosed)
            {
                colOrdinal = reader.GetOrdinal("ProjectTypeID");
                _id = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectTypeName");
                if (!reader.IsDBNull(colOrdinal)) _ProjectTypeName = reader.GetString(colOrdinal);

            }
        }

        #endregion

        #region Create,Update,Delete

        public int Create()
        {
            DbCommand myCmd = fayedDAL.CreateCommand();
            string mCols, mValues = "";

            mCols = "[ProjectTypeName]";
            mValues += string.Format("'{0}'", ProjectTypeName);

            string query = String.Format("INSERT INTO [tProjectType] ({0}) VALUES ({1})", mCols, mValues);
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

            mTemp += string.Format("[ProjectTypeName]='{0}',", ProjectTypeName);


            string query = string.Format("UPDATE [tProjectType] SET {0} WHERE [ProjectTypeID] = {1}", mTemp, _id);
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
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tProjectType] WHERE [ProjectTypeID] = {0}", id));
        }

        public static int Delete(string mFilter)
        {
            if (mFilter.Trim() == "") return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tProjectType] WHERE ([ProjectTypeID]>1) AND {0}", mFilter));
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
            string TempSql = "SELECT * FROM [tProjectType] WHERE ([ProjectTypeID]>=1)";
            if (SqlFilter != "") TempSql += string.Format(" AND ({0}) ", SqlFilter);
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;

            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                tProjectType TempObj;
                while (reader.Read())
                {
                    TempObj = new tProjectType(reader);
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
            string TempSql = "SELECT * FROM [tProjectType] WHERE ([ProjectTypeID]>1)";
            if (SqlFilter != "") TempSql += string.Format(" AND ({0}) ", SqlFilter);
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;

            fayedDAL.FillDataTable(lst, TempSql);
        }

        public static void FillDropDownList(DropDownList myDropDownList)
        {
            List<tProjectType> myList = new List<tProjectType>();
            tProjectType.FillList(myList);

            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر---", "0"));

            foreach (tProjectType oDataRow in myList)
            {
                myDropDownList.Items.Add(new ListItem(oDataRow.ToString(), oDataRow.ProjectTypeID.ToString()));
                //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
            }
            myList.Clear();
            myList = null;
        }


        public static int GetRowsCount()
        {
            return fayedDAL.GetRowsCount("tProjectType");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("tProjectType", SqlFilter);
        }

        //public static bool IsUserHavePremitions(int ProjectTypeID)
        //{
        //    int ii = GetRowsCount("[ProjectTypeID]=" + ProjectTypeID.ToString());
        //    if (ii > 0) return true;
        //    else return false;
        //}

        //public static int CheckLogin(string mProjectTypeName, string mUserModificationDate)
        //{
        //    if (mProjectTypeName == "" || mUserModificationDate == "") return -1;

        //    object mRet = fayedDAL.ExecuteScalar(string.Format("SELECT [ProjectTypeID] FROM [CusType] WHERE [ProjectTypeName] = '{0}' AND [ModificationDate] = '{1}'", mProjectTypeName, mUserModificationDate));
        //    if (mRet == null)
        //        return -1;
        //    else
        //        return (int)mRet;
        //}

        //public static string GetLoginDisplayName(int mProjectTypeID)
        //{
        //    if (mProjectTypeID <= 0) return "";

        //    object mRet = fayedDAL.ExecuteScalar("SELECT [DisplayName] FROM [CusType] WHERE [ProjectTypeID] =" + mProjectTypeID);
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




//public static bool IsUserHavePremitions(int ProjectTypeID)
//       {
//           int ii = GetRowsCount("[loginPer_ProjectTypeID]=" + ProjectTypeID.ToString());
//           if (ii > 0) return true;
//           else return false;
//       }
