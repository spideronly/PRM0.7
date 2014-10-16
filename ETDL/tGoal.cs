
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
    #region tGoal
    /// <summary>
    /// This object represents the properties and methods of a ( Goal ) Table.
    /// </summary>
    public class tGoal : IfayedDbTable
    {
        private const string mFields = "[GoalID],[Goal_ProjectID],[GoalName],[GoalOrder]";

        #region Private Fields,ToString() Method

        private int _id;
         private int _Goal_ProjectID;
        private string _GoalName = String.Empty;
        private int _GoalOrder;

        private int _GoalDMLactionUID;




        public override string ToString()
        {
            // the text that will be displayed in Listbox or Combobox
            return _GoalName.ToString();
        }

        #endregion

        #region Public Properties

        public int GoalID
        {
            get { return _id; }
            //set { _id = value; }
        }

         public int Goal_ProjectID
        {
            get { return _Goal_ProjectID; }
            set { _Goal_ProjectID = value; }
        }
        public string GoalName
        {
            get { return _GoalName; }
            set { if (value.Length > 100) _GoalName = value.Substring(0, 100); else _GoalName = value; }
        }
        public int GoalOrder
        {
            get { return _GoalOrder; }
            set { _GoalOrder = value; }
        }
        public int GoalDMLactionUID
        {
            get { return _GoalDMLactionUID; }
            set { _GoalDMLactionUID = value; }
        }
       


        #endregion

        #region Constractors

        public tGoal()
        {
        }

        public tGoal(int id)
        {
            LoadFromID(id);
        }

        public tGoal(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT {0} FROM [tGoal] WHERE [GoalID] = {1}", mFields, id);
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
                colOrdinal = reader.GetOrdinal("GoalID");
                _id = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("Goal_ProjectID");
                if (!reader.IsDBNull(colOrdinal)) _Goal_ProjectID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("GoalName");
                if (!reader.IsDBNull(colOrdinal)) _GoalName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("GoalOrder");
                if (!reader.IsDBNull(colOrdinal)) _GoalOrder = reader.GetInt32(colOrdinal);
            }
        }

        #endregion

        #region Create,Update,Delete

        public int Create()
        {
            DbCommand myCmd = fayedDAL.CreateCommand();
            string mCols, mValues = "";

            mCols = "[Goal_ProjectID],[GoalName],[GoalOrder],[GoalDMLcreateUID],[GoalDMLcreateDate],[GoalDMLactionUID],[GoalDMLactionDate],[GoalDMLactionType]";
            mValues += string.Format("{0},", Goal_ProjectID);
            mValues += string.Format("'{0}',", GoalName);
            mValues += string.Format("{0},", GoalOrder);

            mValues += string.Format("{0},", GoalDMLactionUID); //DMLcreateUID
            mValues += string.Format("{0},", "GetDate()"); //DMLcreateDate
            mValues += string.Format("{0},", GoalDMLactionUID); //OprationUID
            mValues += string.Format("{0},", "GetDate()"); //DMLDate
            mValues += string.Format("'{0}'", "Insert"); //DMLOperation
            string query = String.Format("INSERT INTO [tGoal] ({0}) VALUES ({1})", mCols, mValues);
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
            mTemp += string.Format("[Goal_ProjectID]={0},", Goal_ProjectID);
            mTemp += string.Format("[GoalName]='{0}',", GoalName);
            mTemp += string.Format("[GoalOrder]={0},", GoalOrder);

            mTemp += string.Format("[GoalDMLactionUID]={0},", GoalDMLactionUID);
            mTemp += string.Format("[GoalDMLactionDate]={0},", "GetDate()");
            mTemp += string.Format("[GoalDMLactionType]='{0}'", "Update");


            string query = string.Format("UPDATE [tGoal] SET {0} WHERE [GoalID] = {1}", mTemp, _id);
            myCmd.CommandText = query;
            return fayedDAL.ExecuteNonQuery(myCmd);
        }

        public int Delete()
        {
           if (_id == 0) return 0;
            List<ETDL.tGoal> myGoals = new List<ETDL.tGoal>();
            ETDL.tGoal.FillList(myGoals, "GoalID=" + _id + "");

            DbCommand myCmd = fayedDAL.CreateCommand();
            string mTemp = "";

            foreach (ETDL.tGoal mTheGoal in myGoals)
            {
                mTemp = string.Format("[GoalDMLactionType]='{0}',", "Delete");
                mTemp += string.Format("[GoalDMLactionDate]={0},", "GetDate()");
                mTemp += string.Format("[GoalDMLactionUID]={0}", GoalDMLactionUID);
                //mTemp += "[DepartmentIsDeleted]=1";



                string query = string.Format("UPDATE [tGoal] SET {0} WHERE GoalID = {1}", mTemp, mTheGoal.GoalID);
                myCmd.CommandText = query;
                fayedDAL.ExecuteNonQuery(myCmd);

                Delete(mTheGoal.GoalID);
            }

            return 1;
        }

        

        #endregion


        #region Static Methods

        public static int Delete(int id)
        {
            if (id == 0 || id == 1) return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tGoal] WHERE [GoalID] = {0}", id));
        }

        public static int Delete(string mFilter)
        {
            if (mFilter.Trim() == "") return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [tGoal] WHERE ([GoalID]>=1) AND {0}", mFilter));
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
            string TempSql = "SELECT * FROM [tGoal] WHERE ([GoalID]>=1)";
            if (SqlFilter != "") TempSql += string.Format(" AND ({0}) ", SqlFilter);
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;

            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                tGoal TempObj;
                while (reader.Read())
                {
                    TempObj = new tGoal(reader);
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
            string TempSql = "SELECT * FROM [tGoal] WHERE ([GoalID]>1)";
            if (SqlFilter != "") TempSql += string.Format(" AND ({0}) ", SqlFilter);
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;

            fayedDAL.FillDataTable(lst, TempSql);
        }

        public static int GetGaolDataByGoal_ProjectID(int myProID)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT [GoalID] FROM [tGoal] Where Goal_ProjectID=" + myProID + "");
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static void FillDropDownList(DropDownList myDropDownList)
        {
            List<tGoal> myList = new List<tGoal>();
            tGoal.FillList(myList);

            myDropDownList.Items.Clear();
            myDropDownList.Items.Add(new ListItem("---اختر هدف---", "0"));

            foreach (tGoal oDataRow in myList)
            {
                myDropDownList.Items.Add(new ListItem(oDataRow.ToString(), oDataRow.GoalID.ToString()));
                //myDropDownList.Items[myDropDownList.Items.Count - 1].Attributes.Add("style", "color:blue");
            }
            myList.Clear();
            myList = null;
        }


        public static int GetRowsCount()
        {
            return fayedDAL.GetRowsCount("tGoal");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("tGoal", SqlFilter);
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




//public static bool IsUserHavePremitions(int GoalID)
//       {
//           int ii = GetRowsCount("[loginPer_GoalID]=" + GoalID.ToString());
//           if (ii > 0) return true;
//           else return false;
//       }
