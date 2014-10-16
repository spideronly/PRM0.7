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

    #region vPermission
    /// <summary>
    /// This object represents the properties and methods of a ( vPermission ) Table.
    /// </summary>
    public class vPermission
    {
        private const string mFields = "[PermissionID],[Permission_UserID],[Permission_DepartmentID],[PermissionAdd],[PermissionView],[PermissionDelete],[PermissionUpdate],[PermissionCreateReport],[PermissionOrder],[DepartmentName],[UserDisplayName]";

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
        private string _UserDisplayName=String.Empty;
        private string _DepartmentName = String.Empty;




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

        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { if (value.Length > 100) _DepartmentName = value.Substring(0, 100); else _DepartmentName = value; }
        }
        public string UserDisplayName
        {
            get { return _UserDisplayName; }
            set { if (value.Length > 100) _UserDisplayName = value.Substring(0, 100); else _UserDisplayName = value; }
        }

        #endregion

        #region Constractors

        public vPermission()
        {
        }

        public vPermission(int id)
        {
            LoadFromID(id);
        }

        public vPermission(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT {0} FROM [vPermission] WHERE PermissionID = {1}", mFields, id);
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
                throw new ApplicationException("Selected vPermission Row Does Not Exist.");
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
                colOrdinal = reader.GetOrdinal("DepartmentName");
                if (!reader.IsDBNull(colOrdinal)) _DepartmentName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("UserDisplayName");
                if (!reader.IsDBNull(colOrdinal)) _UserDisplayName = reader.GetString(colOrdinal);


            }
        }

        #endregion


        #region Static Methods


        //public static int Delete(string mFilter)
        //{
        //    if (mFilter.Trim() == "") return 0;
        //    return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [vPermission] WHERE {0}", mFilter));
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
            string TempSql = string.Format("SELECT {0} FROM [vPermission]", mFields);
            if (SqlFilter != "") TempSql += string.Format(" Where {0}", SqlFilter);
            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                vPermission TempObj;
                while (reader.Read())
                {
                    TempObj = new vPermission(reader);
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



        public static int GetRowsCount()
        {
            return fayedDAL.GetRowsCount("vPermission");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("vPermission", SqlFilter);
        }

        //public static vPermission GetvPermission(int id)
        //{
        //    return new vPermission(id);
        //}


        #endregion
    }
    #endregion

}


