
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

    #region tPermission
    /// <summary>
    /// This object represents the properties and methods of a ( tPermission ) Table.
    /// </summary>
    public class tPermission
    {
        private const string mFields = "[PermissionID],[Permission_UserID],[Permission_DepartmentID],[PermissionAdd],[PermissionView],[PermissionDelete],[PermissionUpdate],[PermissionCreateReport],[PermissionOrder]";

        #region Private Fields,ToString() Method

        private int _id;
        private int _Permission_UserID;
        private int _Permission_DepartmentID;
        private int _PermissionOrder;
        private bool _PermissionAdd;
        private bool _PermissionView;
        private bool _PermissionDelete;
        private bool _PermissionUpdate;
        private bool _PermissionCreateReport;
  
        private int _PermissionDMLactionUID;

        

        #endregion

        #region Public Properties
        public int PermissionID
        {
            get { return _id; }
        }

        public int Permission_UserID
        {
            get { return _Permission_UserID; }
            set { _Permission_UserID = value; }
        }

        public int Permission_DepartmentID
        {
            get { return _Permission_DepartmentID; }
            set { _Permission_DepartmentID = value; }
        }

        public bool PermissionAdd
        {
            get { return _PermissionAdd; }
            set { _PermissionAdd = value; }
        }
        public bool PermissionView
        {
            get { return _PermissionView; }
            set { _PermissionView = value; }
        }
        public bool PermissionDelete
        {
            get { return _PermissionDelete; }
            set { _PermissionDelete = value; }
        }
        public bool PermissionUpdate
        {
            get { return _PermissionUpdate; }
            set { _PermissionUpdate = value; }
        }
        public bool PermissionCreateReport
        {
            get { return _PermissionCreateReport; }
            set { _PermissionCreateReport = value; }
        }
        
       
        public int PermissionOrder
        {
            get { return _PermissionOrder; }
            set { _PermissionOrder = value; }
        }
        public int PermissionDMLactionUID
        {
            get { return _PermissionDMLactionUID; }
            set { _PermissionDMLactionUID = value; }
        }



        #endregion

        #region Constractors

        public tPermission()
        {
        }

        public tPermission(int id)
        {
            LoadFromID(id);
        }

        public tPermission(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT {0} FROM [tPermission] WHERE PermissionID = {1}", mFields, id);
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
                throw new ApplicationException("Selected tPermission Row Does Not Exist.");
            }
        }

        protected void LoadFromReader(DbDataReader reader)
        {
            int colOrdinal;
            if (reader != null && !reader.IsClosed)
            {
                colOrdinal = reader.GetOrdinal("PermissionID");
                _id = reader.GetInt32(colOrdinal);

                colOrdinal = reader.GetOrdinal("Permission_UserID");
                if (!reader.IsDBNull(colOrdinal)) _Permission_UserID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("Permission_DepartmentID");
                if (!reader.IsDBNull(colOrdinal)) _Permission_DepartmentID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("PermissionOrder");
                if (!reader.IsDBNull(colOrdinal)) _PermissionOrder = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("PermissionAdd");
                if (!reader.IsDBNull(colOrdinal)) _PermissionAdd = reader.GetBoolean(colOrdinal);
                colOrdinal = reader.GetOrdinal("PermissionView");
                if (!reader.IsDBNull(colOrdinal)) _PermissionView = reader.GetBoolean(colOrdinal);
                colOrdinal = reader.GetOrdinal("PermissionDelete");
                if (!reader.IsDBNull(colOrdinal)) _PermissionDelete = reader.GetBoolean(colOrdinal);
                colOrdinal = reader.GetOrdinal("PermissionUpdate");
                if (!reader.IsDBNull(colOrdinal)) _PermissionUpdate = reader.GetBoolean(colOrdinal);
                colOrdinal = reader.GetOrdinal("PermissionCreateReport");
                if (!reader.IsDBNull(colOrdinal)) _PermissionCreateReport = reader.GetBoolean(colOrdinal);
              

            }
        }

        #endregion

        #region Create,Update,Delete


        public int Create()
        {
        //    if (this.Permission_UserID == "")
        //        throw new Exception("يجب ادخال الاســم أولا");

        //    if (GetRowsCount(string.Format("[Permission_UserID]='{0}' AND [Permission_DepartmentID]={1}", this.Permission_UserID, this.Permission_DepartmentID.ToString())) > 0)
        //        throw new Exception("هذا القسم تم ادخاله مسبقا");

            //if (Department_displayOrder == 0)
            //{
            //    Department_displayOrder = int.Parse(fayedDAL.ExecuteScalar("select max(PermissionID) from tPermission").ToString()) + 1;
            //}

            DbCommand myCmd = fayedDAL.CreateCommand();
            string mCols, mValues = "";

            mCols = "[Permission_UserID],[Permission_DepartmentID],[PermissionOrder],[PermissionAdd],[PermissionView],[PermissionDelete],[PermissionUpdate],[PermissionCreateReport],[PermissionDMLcreateUID],[PermissionDMLcreateDate],[PermissionDMLactionUID],[PermissionDMLactionDate],[PermissionDMLactionType]";

            mValues += string.Format("'{0}',", Permission_UserID);
            mValues += string.Format("{0},", Permission_DepartmentID);
            mValues += string.Format("{0},", PermissionOrder);
            mValues += string.Format("{0},", ((PermissionAdd == true) ? 1 : 0));
            mValues += string.Format("{0},", ((PermissionView == true) ? 1 : 0));
            mValues += string.Format("{0},", ((PermissionDelete == true) ? 1 : 0));
            mValues += string.Format("{0},", ((PermissionUpdate == true) ? 1 : 0));
            mValues += string.Format("{0},", ((PermissionCreateReport == true) ? 1 : 0));
      
            mValues += string.Format("{0},", PermissionDMLactionUID); //DMLcreateUID
            mValues += string.Format("{0},", "GetDate()"); //DMLcreateDate
            mValues += string.Format("{0},", PermissionDMLactionUID); //OprationUID
            mValues += string.Format("{0},", "GetDate()"); //DMLDate
            mValues += string.Format("'{0}'", "Insert"); //DMLOperation

            string query = String.Format("INSERT INTO [tPermission] ({0}) VALUES ({1})", mCols, mValues);
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

           // if (_id == 0) throw new Exception("حدد ما الذي تريد تعديله أولا");

            DbCommand myCmd = fayedDAL.CreateCommand();
            string mTemp = "";

            mTemp += string.Format("[Permission_UserID]='{0}',", Permission_UserID);
            mTemp += string.Format("[Permission_DepartmentID]={0},", Permission_DepartmentID);
            mTemp += string.Format("[PermissionOrder]={0},", PermissionOrder);
            mTemp += string.Format("[PermissionAdd]={0},", ((PermissionAdd == true) ? 1 : 0));
            mTemp += string.Format("[PermissionView]={0},", ((PermissionView == true) ? 1 : 0));
            mTemp += string.Format("[PermissionDelete]={0},", ((PermissionDelete == true) ? 1 : 0));
            mTemp += string.Format("[PermissionUpdate]={0},", ((PermissionUpdate == true) ? 1 : 0));
            mTemp += string.Format("[PermissionCreateReport]={0},", ((PermissionCreateReport == true) ? 1 : 0));
            

            mTemp += string.Format("[PermissionDMLactionUID]={0},", PermissionDMLactionUID);
            mTemp += string.Format("[PermissionDMLactionDate]={0},", "GetDate()");
            mTemp += string.Format("[PermissionDMLactionType]='{0}'", "Update");

            string query = string.Format("UPDATE [tPermission] SET {0} WHERE PermissionID = {1}", mTemp, PermissionID);
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
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tPermission] WHERE [PermissionID] = {0}", id));
        }

        //public static int Delete(string mFilter)
        //{
        //    if (mFilter.Trim() == "") return 0;
        //    return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tPermission] WHERE {0}", mFilter));
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
            string TempSql = string.Format("SELECT {0} FROM [tPermission]", mFields);
            if (SqlFilter != "") TempSql += string.Format("Where {0}", SqlFilter);


            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                tPermission TempObj;
                while (reader.Read())
                {
                    TempObj = new tPermission(reader);
                    lst.Add(TempObj);
                }
            }
            reader.Close();
        }

        public static int myGetLastID()
        {
            object mm = fayedDAL.ExecuteScalar("SELECT MAX([UserID]) FROM [tUser]");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }

        public static bool IsExist(int mUserID,int mDepID)
        {
            if (mUserID == 0 || mDepID==0) return false;

            object mRet = fayedDAL.ExecuteScalar(string.Format("SELECT [PermissionID] FROM [tPermission] WHERE [Permission_UserID] = {0} AND [Permission_DepartmentID] = {1}",mUserID, mDepID));
            if (mRet == null)
                return false;
            else
                return true;
        }
     
        public static int GetRowsCount()
        {
            return fayedDAL.GetRowsCount("tPermission");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("tPermission", SqlFilter);
        }

        //public static tPermission GettPermission(int id)
        //{
        //    return new tPermission(id);
        //}


        #endregion
    }
    #endregion

}


