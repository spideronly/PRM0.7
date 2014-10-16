///////////////////////////////////////////////////
//
//			Sami Shamsan
//			eng.shamsan@gmail.com
//
///////////////////////////////////////////////////
using System;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Web;


#region fayedDAL

public class fayedDAL
{
    public static DbConnection myConnection = GetSqlServerConnection(@"(local)\sqlexpress", "PER"); 
    public static bool KeepConnection = false;

    #region Database [Connection,Command] Creation

        public static string GetAccessConnectionString(string dbFileName) 
        {
            if (dbFileName.EndsWith(".mdb")) 
                return string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Persist Security Info=False", dbFileName);
            else
                return string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False", dbFileName);
        }

        public static string GetAccessConnectionString(string dbFileName,string dbPassword)
        {
            if (dbFileName.EndsWith(".mdb")) 
                return string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Jet OLEDB:Database Password={1}", dbFileName, dbPassword);
            else
                return string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Persist Security Info=False;Jet OLEDB:Database Password={1}", dbFileName, dbPassword);
        }

        public static OleDbConnection GetAccessConnection(string dbFileName)
        {
            return new OleDbConnection(GetAccessConnectionString(dbFileName));
        }

        public static OleDbConnection GetAccessConnection(string dbFileName, string dbPassword)
        {
            return new OleDbConnection(GetAccessConnectionString(dbFileName, dbPassword));
        }

        public static string GetSqlServerConnectionString(string mServer, string mDatabase, string mUser, string mPassword)
        {
            return string.Format("Server={0};database={1};user id={2};password={3};", mServer, mDatabase, mUser, mPassword);
        }

        public static string GetSqlServerConnectionString(string mServer, string mDatabase)
        {
            return string.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", mServer, mDatabase);
        }

        public static SqlConnection GetSqlServerConnection(string mServer, string mDatabase)
        {
            return new SqlConnection(GetSqlServerConnectionString(mServer, mDatabase));
        }

        public static SqlConnection GetSqlServerConnection(string mServer, string mDatabase, string mUser, string mPassword)
        {
            return new SqlConnection(GetSqlServerConnectionString(mServer, mDatabase, mUser, mPassword));
        }

        public static string GetMySqlConnectionString(string mServer, string mDatabase, string mUser, string mPassword)
        {
            return string.Format("server={0};user id={2};Password={3};persist security info=True;database={1}", mServer, mDatabase, mUser, mPassword);
        }
    
        public static DbCommand CreateCommand()
        {
            if (myConnection == null) throw new Exception("You must Assign New Connection to 'myConnection' First");
            return myConnection.CreateCommand();
        }

        public static DbParameter CreateParameter()
        {
            DbCommand myCmd = CreateCommand();
            return myCmd.CreateParameter();
        }

       


    #endregion

    #region Open,Close Connection

    public static void OpenConnection()
    {
        if (myConnection == null) throw new Exception("You must Assign New Connection to 'myConnection' First");

        if (myConnection.State == ConnectionState.Closed || myConnection.State == ConnectionState.Broken)
            myConnection.Open();
    }

    public static void CloseConnection()
    {
        if (myConnection != null)
        {
            myConnection.Close();
        }
    }

    #endregion


    #region ExecuteNonQuery

    public static int ExecuteNonQuery(string mSql)
    {
        DbCommand myCommand = CreateCommand();
        myCommand.CommandText = mSql;
        return ExecuteNonQuery(myCommand);
    }

    public static int ExecuteNonQuery(string mSql, params DbParameter[] mParamerters)
    {
        DbCommand myCommand = CreateCommand();
        myCommand.CommandText = mSql;
        
        if (mParamerters != null)
        {
            foreach (DbParameter parameter in mParamerters)
            {
                myCommand.Parameters.Add(parameter);
            }
        }
        return ExecuteNonQuery(myCommand);
    }

    public static int ExecuteNonQuery(DbCommand mCmd)
    {
        OpenConnection();
            mCmd.Connection = myConnection;
            int mRet = mCmd.ExecuteNonQuery();
            mCmd.Dispose();
        if (KeepConnection == false) CloseConnection();

        return mRet;
    }

    #endregion

    #region ExecuteScalar

    public static object ExecuteScalar(string mSql)
    {
        
        DbCommand myCommand = CreateCommand();
        myCommand.CommandText = mSql;
        return ExecuteScalar(myCommand);
    }

    public static object ExecuteScalar(string mSql, params DbParameter[] mParamerters)
    {

        DbCommand myCommand = CreateCommand();
        myCommand.CommandText = mSql;

        if (mParamerters != null)
        {
            foreach (DbParameter parameter in mParamerters)
            {
                myCommand.Parameters.Add(parameter);
            }
        }
        return ExecuteScalar(myCommand);

    }

    public static object ExecuteScalar(DbCommand mCmd)
    {
        OpenConnection();
            mCmd.Connection = myConnection;
            object mRet = mCmd.ExecuteScalar();
            mCmd.Dispose();
        
        if (KeepConnection == false) CloseConnection();

        return mRet;

    }

    #endregion

    #region ExecuteReader

    public static DbDataReader ExecuteReader(string mSql)
    {
        DbCommand myCommand = CreateCommand();
        myCommand.CommandText = mSql;
        return ExecuteReader(myCommand);
    }

    public static DbDataReader ExecuteReader(string mSql, params DbParameter[] mParamerters)
    {
        DbCommand myCommand = CreateCommand();
        myCommand.CommandText = mSql;

        if (mParamerters != null)
        {
            foreach (DbParameter parameter in mParamerters)
            {
                myCommand.Parameters.Add(parameter);
            }
        }
        return ExecuteReader(myCommand);
    }

    public static DbDataReader ExecuteReader(DbCommand mCmd)
    {
        OpenConnection();
        mCmd.Connection = myConnection;
        DbDataReader myDataReader;
        if (KeepConnection == false)
            myDataReader = mCmd.ExecuteReader(CommandBehavior.CloseConnection);
        else
            myDataReader = mCmd.ExecuteReader();

        return myDataReader;
    }

    #endregion


    #region Misc
    public static DataTable GetDataTable(string mSql)
    {
        DataTable myTable = new DataTable();
        FillDataTable(myTable, mSql);
        return myTable;
    }
    public static void FillDataTable(DataTable mTable, string mSql)
    {
        if (mSql.Trim().Length == 0) return;
        DbDataReader myReader = ExecuteReader(mSql);

        mTable.BeginLoadData();
        mTable.Load(myReader);
        mTable.EndLoadData();

        myReader.Close();
        myReader.Dispose();
    }

    //public static void FillDataTable(DataTable mTable, DbDataReader mReader)
    //{
    //    if (mReader.HasRows == false) return;

    //    DataTable _table = mReader.GetSchemaTable();
    //    DataColumn _dc;
    //    DataRow _row;

    //    for (int i = 0; i < _table.Rows.Count; i++)
    //    {
    //        _dc = new System.Data.DataColumn();

    //        if (!mTable.Columns.Contains(_table.Rows[i]["ColumnName"].ToString()))
    //        {
    //            _dc.ColumnName = _table.Rows[i]["ColumnName"].ToString();
    //            _dc.Unique = Convert.ToBoolean(_table.Rows[i]["IsUnique"]);
    //            _dc.AllowDBNull = Convert.ToBoolean(_table.Rows[i]["AllowDBNull"]);
    //            _dc.ReadOnly = Convert.ToBoolean(_table.Rows[i]["IsReadOnly"]);
                
    //            mTable.Columns.Add(_dc);
    //        }
    //    }

    //    while (mReader.Read())
    //    {
    //        _row = mTable.NewRow();
            
    //        for (int i = 0; i < mTable.Columns.Count; i++)
    //        {
    //            _row[mTable.Columns[i].ColumnName] = mReader[mTable.Columns[i].ColumnName];
    //        }

    //        mTable.Rows.Add(_row);
    //    }

    //    mReader.Close();
    //}


    public static int GetLastID()
    {
        // Get Last DENTITY in used in ( Microsoft Access,Sql Server ) database table
        return int.Parse(ExecuteScalar("SELECT @@IDENTITY").ToString());
    }

    public static int GetRowsCount(string mTable)
    {
        return GetRowsCount(mTable, "");
    }

    public static int GetRowsCount(string mTable, string SqlFilter)
    {
        string mSql = string.Format("SELECT COUNT(*) FROM [{0}]",mTable);
        if (SqlFilter != "") mSql += string.Format(" WHERE ({0})", SqlFilter);

        return (int)ExecuteScalar(mSql); ;
    }

    public static bool mIsExist(string mTable, string mField, int mValue)
    {
        int mNum = 0;
        mNum = (int)ExecuteScalar(string.Format("SELECT COUNT({0}) FROM {1} WHERE {0}={2}",mField,mTable,mValue));
        if (mNum > 0) return true;
        else return false;
    }

    public static bool mIsExist(string mTable, string mField, string mValue)
    {
        int mNum =0;
        mNum = (int)ExecuteScalar(string.Format("SELECT COUNT({0}) FROM {1} WHERE {0} LIKE '{2}'", mField, mTable, mValue));
        if(mNum>0) return true;
        else return false ;
    }

    public static string GetSqlTime(DateTime myTime)
    {
        if (myTime.Hour == 0 && myTime.Minute == 0 && myTime.Second == 0)
            return "NULL";
        else
            return string.Format("dbo.Time({0},{1},{2})", myTime.Hour, myTime.Minute, myTime.Second);
    }

   
    public static string GetSqlDate(DateTime myDate)
    {
        if (myDate.Year == 1 && myDate.Month == 1 && myDate.Day == 1)
            return "NULL";
        else
            return string.Format("dbo.Date({0},{1},{2})", myDate.Year, myDate.Month, myDate.Day);
        
        //create  function DateOnly(@DateTime DateTime)
        //-- Returns @DateTime at midnight; i.e., it removes the time portion of a DateTime value.
        //returns datetime
        //as
        //    begin
        //    return dateadd(dd,0, datediff(dd,0,@DateTime))
        //    end
        //go

        //create function Date(@Year int, @Month int, @Day int)
        //-- returns a datetime value for the specified year, month and day
        //-- Thank you to Michael Valentine Jones for this formula (see comments).
        //returns datetime
        //as
        //    begin
        //    return dateadd(month,((@Year-1900)*12)+@Month-1,@Day-1)
        //    end
        //go

        //create function Time(@Hour int, @Minute int, @Second int)
        //-- Returns a datetime value for the specified time at the "base" date (1/1/1900)
        //-- Many thanks to MVJ for providing this formula (see comments). 
        //returns datetime
        //as
        //    begin
        //    return dateadd(ss,(@Hour*3600)+(@Minute*60)+@Second,0)
        //    end
        //go

        //create function TimeOnly(@DateTime DateTime)
        //-- returns only the time portion of a DateTime, at the "base" date (1/1/1900)
        //-- Thanks, Peso! 
        //returns datetime
        //as
        //    begin
        //    return dateadd(day, -datediff(day, 0, @datetime), @datetime)
        //    end
        //go

        //create function DateTime(@Year int, @Month int, @Day int, @Hour int, @Minute int, @Second int)
        //-- returns a dateTime value for the date and time specified.
        //returns datetime
        //as
        //    begin
        //    return dbo.Date(@Year,@Month,@Day) + dbo.Time(@Hour, @Minute,@Second)
        //    end
        //go
    }

    public static string GetPagedSQL(int pageNum, int pageSize, string pKey, string tableName, string selectedFields, string ordering, string whereCluase, string joinStatment)
    {
        // Thanks to << تركي العسيري >>
        string sql;

        if (whereCluase != null) whereCluase = " WHERE " + whereCluase;
        if (ordering == null) ordering = pKey;

        if (pageNum <= 1)
        {
            pageNum = 1;
            // First Page. This is good for optimization
            if (joinStatment == null)
            {
                sql = string.Format(" SELECT TOP {0} {1} FROM [{2}] {3}", pageSize, selectedFields, tableName, whereCluase);
            }
            else
            {
                sql = string.Format(" SELECT TOP {0} {1} FROM [{2}] {3} {4}", pageSize, selectedFields, tableName, joinStatment, whereCluase);
            }
        }
        else
        {
            if (joinStatment == null)
            {
                sql = string.Format(" SELECT TOP {0} {1} FROM [{2}] {3}", pageSize, selectedFields, tableName, whereCluase);
            }
            else
            {
                sql = string.Format(" SELECT TOP {0} {1} FROM [{2}] {3} {4}", pageSize, selectedFields, tableName, joinStatment, whereCluase);
            }
            if (whereCluase == null)
            {
                sql += string.Format(" WHERE [{0}] NOT IN ", pKey);
            }
            else
            {
                sql += string.Format(" AND [{0}] NOT IN ", pKey);
            }
            sql += string.Format(" (SELECT TOP {0} [{1}] FROM [{2}] {3} ORDER BY {4})", (pageNum - 1) * pageSize, pKey, tableName, whereCluase, ordering);
        }

        sql += string.Format(" ORDER BY {0}", ordering);

        return sql;
    }
	

    #endregion

}

#endregion


#region IfayedDbTable

public interface IfayedDbTable
{
    void FillList(IList lst);
    void FillList(IList lst, string SqlFilter);
	//int Create();
    //int Update();
    //int Delete();
    //int GetRowsCount();
    //int GetRowsCount(string SqlFilter);
    //IfayedDbTable GetNew(int id);
}

#endregion


#region myListItem

//public class myListItem
//{
//    public string mItem;
//    public string mItemValue;

//    public myListItem()
//    {
//        mItem = "";
//        mItemValue = "";
//    }

//    public myListItem(string sItem)
//    {
//        mItem = sItem;
//        mItemValue = "";
//    }

//    public myListItem(string sItem, string sValue)
//    {
//        mItem = sItem;
//        mItemValue = sValue;
//    }

//    public override string ToString()
//    {
//        return mItem;
//    }
//}

#endregion


#region Arabic Data Search Form (frmFind)
/*



public class FrmFind : Form
{

    #region Windows Form Designer generated code

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.Button button2;

    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);

    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.label1 = new System.Windows.Forms.Label();
        this.textBox1 = new System.Windows.Forms.TextBox();
        this.listBox1 = new System.Windows.Forms.ListBox();
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
        this.label1.Location = new System.Drawing.Point(136, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(49, 14);
        this.label1.TabIndex = 0;
        this.label1.Text = "بحث عن";
        // 
        // textBox1
        // 
        this.textBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
        this.textBox1.Location = new System.Drawing.Point(10, 34);
        this.textBox1.Name = "textBox1";
        this.textBox1.Size = new System.Drawing.Size(291, 22);
        this.textBox1.TabIndex = 1;
        this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
        // 
        // listBox1
        // 
        this.listBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
        this.listBox1.FormattingEnabled = true;
        this.listBox1.ItemHeight = 14;
        this.listBox1.Location = new System.Drawing.Point(12, 71);
        this.listBox1.Name = "listBox1";
        this.listBox1.Size = new System.Drawing.Size(291, 200);
        this.listBox1.TabIndex = 2;
        this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
        // 
        // button1
        // 
        this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
        this.button1.Location = new System.Drawing.Point(187, 288);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(103, 28);
        this.button1.TabIndex = 3;
        this.button1.Text = "اختيار";
        this.button1.UseVisualStyleBackColor = true;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // button2
        // 
        this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
        this.button2.Location = new System.Drawing.Point(31, 288);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(103, 28);
        this.button2.TabIndex = 4;
        this.button2.Text = "الغاء";
        this.button2.UseVisualStyleBackColor = true;
        this.button2.Click += new System.EventHandler(this.button2_Click);
        // 
        // FrmFind
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(315, 328);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.listBox1);
        this.Controls.Add(this.textBox1);
        this.Controls.Add(this.label1);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmFind";
        this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Text = "بحث";
        this.Load += new System.EventHandler(this.FrmFind_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    static object mRetValue;
    static IfayedDbTable mTable;
    static string mTheFilter = "";

    public static object AA_ShowFind(IfayedDbTable Table, string mFilter)
    {
        if (Table == null) return null;
        if (mFilter == "") return null;
        mTheFilter = mFilter; // "[fieldName] like '{0}%'"
        mTable = Table;

        FrmFind mm = new FrmFind();
        mm.ShowDialog();
        mm.Dispose();
        mm = null;

        return mRetValue;
    }

    public FrmFind()
    {
        InitializeComponent();
    }

    private void FrmFind_Load(object sender, EventArgs e)
    {
        mDoSearch();
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        mDoSearch();
    }

    private void listBox1_DoubleClick(object sender, EventArgs e)
    {
        button1_Click(sender, e);
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (listBox1.SelectedIndex == -1) return;
        mRetValue = listBox1.SelectedItem;
        this.Close();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    //public static string AA_ShowFind(string mTableName, string mFieldName, string mRetFieldName)
    //{
    //    return AA_ShowFind(mTableName, mFieldName, mRetFieldName, "");
    //}


    //public static string AA_ShowFind(string mTableName, string mFieldName, string mRetFieldName, string mWhereCluse)
    //{
    //    mTable = mTableName;
    //    mField = mFieldName;
    //    mRetField = mRetFieldName;
    //    mWhere = mWhereCluse;

    //    FrmFind mm = new FrmFind();
    //    mm.ShowDialog();
    //    mm.Dispose();
    //    mm = null;

    //    return mRetValue;

    //}

    private void mDoSearch()
    {
        //DbDataReader myReader;
        //string mWhereCluse = "";

        //if (mWhere != "") mWhereCluse = " WHERE " + mWhere + " AND ";
        //else mWhereCluse = " WHERE ";

        //mWhereCluse = mWhereCluse + mField + " LIKE '" + textBox1.Text.Trim() + "%'";

        //if (mRetField == "")
        //    myReader =  fayedDAL.ExecuteReader("SELECT " + mField + " FROM " + mTable + mWhereCluse);
        //else
        //    myReader = fayedDAL.ExecuteReader("SELECT " + mField + "," + mRetField + " FROM " + mTable + mWhereCluse);

        //listBox1.Items.Clear();
        //if (myReader.FieldCount == 1)
        //{
        //    while (myReader.Read())
        //        listBox1.Items.Add(new myListItem(myReader.GetValue(0).ToString()));
        //}
        //else
        //{
        //    while (myReader.Read())
        //        listBox1.Items.Add(new myListItem(myReader.GetValue(0).ToString(), myReader.GetValue(1).ToString()));
        //}
        //myReader.Close();

        listBox1.Items.Clear();
        mTable.FillList(listBox1.Items, string.Format(mTheFilter, textBox1.Text));
    }

}

 */
#endregion

