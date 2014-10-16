
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
using System.IO;

namespace ETDL
{
    #region tUser
    /// <summary>
    /// This object represents the properties and methods of a ( tUser ) Table.
    /// </summary>
    public class tUser : IfayedDbTable
    {
        private const string mFields = "[UserID],[UserName],[UserPassword],[UserDisplayName],[UserEmail],[UserExt],[UserMobile],[UserExternalID],[UserPermShow],[UserPermUpdate],[UserBasicShow]";

        #region Private Fields,ToString() Method

        private int _id;
        private string _UserName = String.Empty;
        private string _UserPassword = String.Empty;
        private string _UserDisplayName = String.Empty;
        private string _UserEmail= String.Empty;
        private string _UserExt = String.Empty;
        private string _UserMobile = String.Empty;
        private string _UserExternalID = String.Empty;
        private bool _UserBasicShow;
        private bool _UserPermShow;
        private bool _UserPermUpdate;

        private int _UserDMLactionUID;
        
        //private byte[] _UserPic;
       
     


        public override string ToString()
        {
            // the text that will be displayed in Listbox or Combobox
            return _UserName.ToString();
        }

        #endregion

        #region Public Properties

        public int UserID
        {
            get { return _id; }
            //set { _id = value; }
        }

        public string UserName
        {
            get { return _UserName; }
            set { if (value.Length > 100) _UserName = value.Substring(0, 100); else _UserName = value; }
        }

        public string UserPassword
        {
            get { return _UserPassword; }
            set { if (value.Length > 100) _UserPassword = value.Substring(0, 100); else _UserPassword = value; }
        }

        public string UserDisplayName
        {
            get { return _UserDisplayName; }
            set { if (value.Length > 100) _UserDisplayName = value.Substring(0, 100); else _UserDisplayName = value; }
        }
        public string UserEmail
        {
            get { return _UserEmail; }
            set { if (value.Length > 100) _UserEmail = value.Substring(0, 100); else _UserEmail = value; }
        }
        public string UserExt
        {
            get { return _UserExt; }
            set { if (value.Length > 100) _UserExt = value.Substring(0, 100); else _UserExt = value; }
        }

        public string UserMobile
        {
            get { return _UserMobile; }
            set { if (value.Length > 100) _UserMobile = value.Substring(0, 100); else _UserMobile = value; }
        }
        public string UserExternalID
        {
            get { return _UserExternalID; }
            set { if (value.Length > 100) _UserExternalID = value.Substring(0, 100); else _UserExternalID = value; }
        }

        public bool UserBasicShow
        {
            get { return _UserBasicShow; }
            set { _UserBasicShow = value; }
        }

        public bool UserPermShow
        {
            get { return _UserPermShow; }
            set { _UserPermShow = value; }
        }
        public bool UserPermUpdate
        {
            get { return _UserPermUpdate; }
            set { _UserPermUpdate = value; }
        }

        public int UserDMLactionUID
        {
            get { return _UserDMLactionUID; }
            set { _UserDMLactionUID = value;}
        }
       
       

        
        #endregion

        #region Constractors

        public tUser()
        {
        }

        public tUser(int id)
        {
            LoadFromID(id);
        }

        public tUser(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT {0} FROM [tUser] WHERE [UserID] = {1}", mFields, id);
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
                throw new ApplicationException("Selected tUser Row Does Not Exist.");
            }
        }

        protected void LoadFromReader(DbDataReader reader)
        {
            int colOrdinal;
            if (reader != null && !reader.IsClosed)
            {
                colOrdinal = reader.GetOrdinal("UserID");
                _id = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("UserName");
                if (!reader.IsDBNull(colOrdinal)) _UserName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("UserPassword");
                if (!reader.IsDBNull(colOrdinal)) _UserPassword = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("UserDisplayName");
                if (!reader.IsDBNull(colOrdinal)) _UserDisplayName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("UserEmail");
                if (!reader.IsDBNull(colOrdinal)) _UserEmail = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("UserExt");
                if (!reader.IsDBNull(colOrdinal)) _UserExt = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("UserMobile");
                if (!reader.IsDBNull(colOrdinal)) _UserMobile = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("UserExternalID");
                if (!reader.IsDBNull(colOrdinal)) _UserExternalID = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("UserPermShow");
                if (!reader.IsDBNull(colOrdinal)) _UserPermShow = reader.GetBoolean(colOrdinal);
                colOrdinal = reader.GetOrdinal("UserPermUpdate");
                if (!reader.IsDBNull(colOrdinal)) _UserPermUpdate = reader.GetBoolean(colOrdinal);
                colOrdinal = reader.GetOrdinal("UserBasicShow");
                if (!reader.IsDBNull(colOrdinal)) _UserBasicShow = reader.GetBoolean(colOrdinal);
                
            }
        }

        #endregion

        #region Create,Update,Delete

        public int Create()
        {
            DbCommand myCmd = fayedDAL.CreateCommand();
            string mCols, mValues = "";

            mCols = "[UserName],[UserPassword],[UserDisplayName],[UserEmail],[UserExt],[UserMobile],[UserExternalID],[UserPermShow],[UserPermUpdate],[UserBasicShow],[UserDMLcreateUID],[UserDMLcreateDate],[UserDMLactionUID],[UserDMLactionDate],[UserDMLactionType]";

            mValues += string.Format("'{0}',", UserName);
            mValues += string.Format("'{0}',", UserPassword);
            mValues += string.Format("'{0}',", UserDisplayName);
            mValues += string.Format("'{0}',", UserEmail);
            mValues += string.Format("'{0}',", UserExt);
            mValues += string.Format("'{0}',", UserMobile);
            mValues += string.Format("'{0}',", UserExternalID);
            mValues += string.Format("{0},", ((UserPermShow == true) ? 1 : 0));
            mValues += string.Format("{0},", ((UserPermUpdate == true) ? 1 : 0));
            mValues += string.Format("{0},", ((UserBasicShow == true) ? 1 : 0));

            mValues += string.Format("{0},", UserDMLactionUID); //DMLcreateUID
            mValues += string.Format("{0},", "GetDate()"); //DMLcreateDate
            mValues += string.Format("{0},", UserDMLactionUID); //OprationUID
            mValues += string.Format("{0},", "GetDate()"); //DMLDate
            mValues += string.Format("'{0}'", "Insert"); //DMLOperation

           

            string query = String.Format("INSERT INTO [tUser] ({0}) VALUES ({1})", mCols, mValues);
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

            mTemp += string.Format("[UserName]='{0}',", UserName);
            mTemp += string.Format("[UserPassword]='{0}',", UserPassword);
            mTemp += string.Format("[UserDisplayName]='{0}',", UserDisplayName);
            mTemp += string.Format("[UserEmail]='{0}',", UserEmail );
            mTemp += string.Format("[UserExt]='{0}',", UserExt);
            mTemp += string.Format("[UserMobile]='{0}',", UserMobile);
            mTemp += string.Format("[UserExternalID]='{0}',", UserExternalID);
            mTemp += string.Format("[UserPermShow]={0},", ((UserPermShow == true) ? 1 : 0));
            mTemp += string.Format("[UserPermUpdate]={0},", ((UserPermUpdate == true) ? 1 : 0));
            mTemp += string.Format("[UserBasicShow]={0},", ((UserBasicShow == true) ? 1 : 0));

            mTemp += string.Format("[UserDMLactionUID]={0},", UserDMLactionUID);
            mTemp += string.Format("[UserDMLactionDate]={0},", "GetDate()");
            mTemp += string.Format("[UserDMLactionType]='{0}'", "Update");


            
            string query = string.Format("UPDATE [tUser] SET {0} WHERE [UserID] = {1}", mTemp, UserID);
            myCmd.CommandText = query;
            return fayedDAL.ExecuteNonQuery(myCmd);
        }

        public int Delete()
        {
            if (_id == 0) return 0;
            List<ETDL.tUser> myUser = new List<ETDL.tUser>();
            ETDL.tUser.FillList(myUser, "UserID=" + _id + "");

            DbCommand myCmd = fayedDAL.CreateCommand();
            string mTemp = "";

            foreach (ETDL.tUser mTheUser in myUser)
            {
                mTemp = string.Format("[UserDMLactionType]='{0}',", "Delete");
                mTemp += string.Format("[UserDMLactionDate]={0},", "GetDate()");
                mTemp += string.Format("[UserDMLactionUID]={0}", UserDMLactionUID);
                //mTemp += "[DepartmentIsDeleted]=1";



                string query = string.Format("UPDATE [tUser] SET {0} WHERE UserID = {1}", mTemp, mTheUser.UserID);
                myCmd.CommandText = query;
                fayedDAL.ExecuteNonQuery(myCmd);

                Delete(mTheUser.UserID);
            }

            return 1;
        }

        #endregion

       
        #region Static Methods

        public static int Delete(int id)
        {
            if (id == 0 || id == 1) return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tUser] WHERE [UserID] = {0}", id));
        }

        public static int Delete(string mFilter)
        {
            if (mFilter.Trim() == "") return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tUser] WHERE ([UserID]>1) AND {0}", mFilter));
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
            string TempSql = "SELECT * FROM [tUser] WHERE ([UserID]>=1)";
            if (SqlFilter != "") TempSql += string.Format(" AND ({0}) ", SqlFilter);
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;

            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                tUser TempObj;
                while (reader.Read())
                {
                    TempObj = new tUser(reader);
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
            string TempSql = "SELECT * FROM [tUser] WHERE ([UserID]>1)";
            if (SqlFilter != "") TempSql += string.Format(" AND ({0}) ", SqlFilter);
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;

            fayedDAL.FillDataTable(lst, TempSql);
        }
        public static bool IsLoginNameExist(string mUserName)
        {
            if (mUserName == "") return false;

            object mRet = fayedDAL.ExecuteScalar(string.Format("SELECT [UserID] FROM [tUser] WHERE [UserName] = '{0}'", mUserName));
            if (mRet == null)
                return false;
            else
                return true;
        }
        public static void FillDropDownList(DropDownList myDropDownList)
        {
            List<tUser> myList = new List<tUser>();
            tUser.FillList(myList);

            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر مستخدم---", "0"));

            foreach (tUser oDataRow in myList)
            {
                myDropDownList.Items.Add(new ListItem(oDataRow._UserDisplayName, oDataRow.UserID.ToString()));
                //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
            }
            myList.Clear();
            myList = null;
        }
        public static void FillDropDownListDisp(DropDownList myDropDownList)
        {
            List<tUser> myList = new List<tUser>();
            tUser.FillList(myList);

            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر مستخدم---", "0"));

            foreach (tUser oDataRow in myList)
            {
                myDropDownList.Items.Add(new ListItem(oDataRow._UserDisplayName, oDataRow.UserID.ToString()));
                //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
            }
            myList.Clear();
            myList = null;
        }
        public static void FillDropDownListDispWithAll(DropDownList myDropDownList)
        {
            List<tUser> myList = new List<tUser>();
            tUser.FillList(myList);

            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر مستخدم---", "0"));
            myDropDownList.Items.Add(new ListItem("الكل", "All"));

            foreach (tUser oDataRow in myList)
            {
                myDropDownList.Items.Add(new ListItem(oDataRow._UserDisplayName, oDataRow.UserID.ToString()));
                //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
            }
            myList.Clear();
            myList = null;
        }
        public static int GetRowsCount()
        {
            return fayedDAL.GetRowsCount("tUser");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("tUser", SqlFilter);
        }

        //public static bool IsUserHavePremitions(int UserID)
        //{
        //    int ii = GetRowsCount("[UserID]=" + UserID.ToString());
        //    if (ii > 0) return true;
        //    else return false;
        //}

        public static int CheckLogin(string mUserName, string mUserUserPassword)
        {
            if (mUserName == "" || mUserUserPassword == "") return -1;

            object mRet = fayedDAL.ExecuteScalar(string.Format("SELECT [UserID] FROM [tUser] WHERE [UserName] = '{0}' AND [UserPassword] = '{1}'", mUserName, mUserUserPassword));
            if (mRet == null)
                return -1;
            else
                return (int)mRet;
        }
        public static int CheckLoginIfFromSingleScreen(string mUserName)
        {
            if (mUserName == "") return -1;

            object mRet = fayedDAL.ExecuteScalar(string.Format("SELECT [UserID] FROM [tUser] WHERE [UserName] = '{0}'", mUserName));
            if (mRet == null)
                return -1;
            else
                return (int)mRet;
        }
        public static string GetLoginUserDisplayName(int mUserID)
        {
            if (mUserID <= 0) return "";

            object mRet = fayedDAL.ExecuteScalar("SELECT [UserDisplayName] FROM [tUser] WHERE [UserID] =" + mUserID);
            if (mRet == null)
                return "";
            else
                return mRet.ToString();
        }
        public static string GetLoginEnable(int mUserID)
        {
            if (mUserID <= 0) return "";

            object mRet = fayedDAL.ExecuteScalar("SELECT [Enable] FROM [tUser] WHERE [UserID] =" + mUserID);
           
           return mRet.ToString();
        }


        public static int myGetPermissionByUserID(int myUser)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT [PermissionID] FROM [tPermission] WHERE ([Permission_UserID]='" + myUser + "')");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static int GetPermissionByUserIDandDepID(int myUser,int myDepID)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT [PermissionID] FROM [tPermission] WHERE ([Permission_UserID]=" + myUser + " AND [Permission_DepartmentID]=" + myDepID + ")");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
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




//public static bool IsUserHavePremitions(int UserID)
//       {
//           int ii = GetRowsCount("[loginPer_UserID]=" + UserID.ToString());
//           if (ii > 0) return true;
//           else return false;
//       }
