
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

    #region vReport
    /// <summary>
    /// This object represents the properties and methods of a ( Project ) Table.
    /// </summary>
    public class vReport
    {
        //private const string mFields = "[ProjectID],[ProjectName],[ProjectSponsor],[ProjectProgram],[ProjectManager],[ProjectStartDate],[ProjectStartDateHijri],[ProjectEndDate],[ProjectEndDateHijri],[ProjectActualStartDate],[ProjectActualStartDateHijri],[ProjectActualEndDate],[ProjectActualEndDateHijri],[ProjectContractor],[ProjectBudget],[ProjectProgress],[ProjectPaiedValue],[Project_ProjectType],[Project_DepartmentID],[ProjectDescription],[ProjectBossNote],[Project_ProgressTypeID],[Abbreviate_ProjectID],[AbbreviateName],[AbbreviateUpdateDate],[AbbreviateUpdateDateHijri],[AbbreviateMayorNote],";

        #region Private Fields,ToString() Method

        private int _id;
        private int _ProjectID;
        private string _ProjectName = String.Empty;
        private string _ProjectSponsor = String.Empty;
        private string _ProjectProgram = String.Empty;
        private string _ProjectManager = String.Empty;
        private DateTime _ProjectStartDate;
        private int _ProjectStartDateHijri;
        private DateTime _ProjectEndDate;
        private int _ProjectEndDateHijri;
        private DateTime _ProjectActualStartDate;
        private int _ProjectActualStartDateHijri;
        private DateTime _ProjectActualEndDate;
        private int _ProjectActualEndDateHijri;
        private string _ProjectContractor = String.Empty;
        private int _ProjectBudget;
        private string _ProjectProgress;
        private int _ProjectPaiedValue;
        private int _Project_ProjectType;
        private int _Project_DepartmentID;
        private string _ProjectDescription = String.Empty;
        private string _ProjectBossNote = String.Empty;
        private int _Project_ProgressTypeID;

       
        private string _AbbreviateName = String.Empty;
        private DateTime _AbbreviateUpdateDate;
        private int _AbbreviateUpdateDateHijri;
        private string _AbbreviateMayorNote;

        private string _ConstraintName = String.Empty;
        private string _ConstraintRequiredSolution = String.Empty;
        private string _ConstraintResponsibleName = String.Empty;
        private bool _ConstraintIsNeedMayor;
        private bool _ConstraintIsSolved;
        private DateTime _ConstraintDate;
        private int _ConstraintDateHijri;
        private DateTime _ConstraintPlanDate;
        private int _ConstraintPlanDateHijri;

        private string _DepartmentName = String.Empty;

        private string _GoalName = String.Empty;

        private string _ProjectTypeName = String.Empty;

        private string _ProgressTypeName = String.Empty;

        private string _TaskName = String.Empty;
        private string _TaskMayorNote = String.Empty;
        private string _TaskDelayReson = String.Empty;
        private DateTime _TaskPlanDate;
        private int _TaskPlanDateHijri;
        private DateTime _TaskActualDate;
        private int _TaskActualDateHijri;
        private bool _TaskIsAchived;
        private string _TaskUser = String.Empty;



        public override string ToString()
        {
            // the text that will be displayed in Listbox or Combobox
            return _id.ToString();
        }

        #endregion

        #region Public Properties
        public int ProjectID
        {
            get { return _id; }
        }
        public string ProjectName
        {
            get { return _ProjectName; }
            set { if (value.Length > 50) _ProjectName = value.Substring(0, 50); else _ProjectName = value; }
        }
        public string ProjectSponsor
        {
            get { return _ProjectSponsor; }
            set { if (value.Length > 50) _ProjectSponsor = value.Substring(0, 50); else _ProjectSponsor = value; }
        }
        public string ProjectProgram
        {
            get { return _ProjectProgram; }
            set { if (value.Length > 50) _ProjectProgram = value.Substring(0, 50); else _ProjectProgram = value; }
        }
        public string ProjectManager
        {
            get { return _ProjectManager; }
            set { if (value.Length > 50) _ProjectManager = value.Substring(0, 50); else _ProjectManager = value; }
        }
        public DateTime ProjectStartDate
        {
            get { return _ProjectStartDate; }
            set { _ProjectStartDate = value; }
        }
        public int ProjectStartDateHijri
        {
            get { return _ProjectStartDateHijri; }
            set { _ProjectStartDateHijri = value; }
        }
        public string ProjectStartDateHijriString
        {
            get
            {
                string myDate = ProjectStartDateHijri.ToString();
                if (myDate.Length != 8) return "";
                //return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
                return myDate.Substring(0, 4) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(6, 2);
            }
        }
        public DateTime ProjectEndDate
        {
            get { return _ProjectEndDate; }
            set { _ProjectEndDate = value; }
        }
        public int ProjectEndDateHijri
        {
            get { return _ProjectEndDateHijri; }
            set { _ProjectEndDateHijri = value; }
        }
        public string ProjectEndDateHijriString
        {
            get
            {
                string myDate = ProjectEndDateHijri.ToString();
                if (myDate.Length != 8) return "";
                // return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
                return myDate.Substring(0, 4) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(6, 2);
            }
        }
        public DateTime ProjectActualStartDate
        {
            get { return _ProjectActualStartDate; }
            set { _ProjectActualStartDate = value; }
        }
        public int ProjectActualStartDateHijri
        {
            get { return _ProjectActualStartDateHijri; }
            set { _ProjectActualStartDateHijri = value; }
        }
        public string ProjectActualStartDateHijriString
        {
            get
            {
                string myDate = ProjectActualStartDateHijri.ToString();
                if (myDate.Length != 8) return "";
                //return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
                return myDate.Substring(0, 4) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(6, 2);
            }
        }
        public DateTime ProjectActualEndDate
        {
            get { return _ProjectActualEndDate; }
            set { _ProjectActualEndDate = value; }
        }
        public int ProjectActualEndDateHijri
        {
            get { return _ProjectActualEndDateHijri; }
            set { _ProjectActualEndDateHijri = value; }
        }
        public string ProjectActualEndDateHijriString
        {
            get
            {
                string myDate = ProjectActualEndDateHijri.ToString();
                if (myDate.Length != 8) return "";
                //return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
                return myDate.Substring(0, 4) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(6, 2);
            }
        }
        public string ProjectContractor
        {
            get { return _ProjectContractor; }
            set { if (value.Length > 50) _ProjectContractor = value.Substring(0, 50); else _ProjectContractor = value; }
        }
        public int ProjectBudget
        {
            get { return _ProjectBudget; }
            set { _ProjectBudget = value; }
        }
        public string ProjectProgress
        {
            get { return _ProjectProgress; }
            set { if (value.Length > 50) _ProjectProgress = value.Substring(0, 50); else _ProjectProgress = value; }
        }

        public int ProjectPaiedValue
        {
            get { return _ProjectPaiedValue; }
            set { _ProjectPaiedValue = value; }
        }
        public int Project_ProjectType
        {
            get { return _Project_ProjectType; }
            set { _Project_ProjectType = value; }
        }

        public int Project_DepartmentID
        {
            get { return _Project_DepartmentID; }
            set { _Project_DepartmentID = value; }
        }
        public string ProjectDescription
        {
            get { return _ProjectDescription; }
            set { if (value.Length > 50) _ProjectDescription = value.Substring(0, 50); else _ProjectDescription = value; }
        }
        public string ProjectBossNote
        {
            get { return _ProjectBossNote; }
            set { if (value.Length > 50) _ProjectBossNote = value.Substring(0, 50); else _ProjectBossNote = value; }
        }


        public int Project_ProgressTypeID
        {
            get { return _Project_ProgressTypeID; }
            set { _Project_ProgressTypeID = value; }
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

        public string ConstraintName
        {
            get { return _ConstraintName; }
            set { if (value.Length > 50) _ConstraintName = value.Substring(0, 50); else _ConstraintName = value; }
        }
        public string ConstraintRequiredSolution
        {
            get { return _ConstraintRequiredSolution; }
            set { if (value.Length > 50) _ConstraintRequiredSolution = value.Substring(0, 50); else _ConstraintRequiredSolution = value; }
        }
        public string ConstraintResponsibleName
        {
            get { return _ConstraintResponsibleName; }
            set { if (value.Length > 50) _ConstraintResponsibleName = value.Substring(0, 50); else _ConstraintResponsibleName = value; }
        }
        public bool ConstraintIsNeedMayor
        {
            get { return _ConstraintIsNeedMayor; }
            set { _ConstraintIsNeedMayor = value; }
        }
        public bool ConstraintIsSolved
        {
            get { return _ConstraintIsSolved; }
            set { _ConstraintIsSolved = value; }
        }
        public DateTime ConstraintDate
        {
            get { return _ConstraintDate; }
            set { _ConstraintDate = value; }
        }
        public int ConstraintDateHijri
        {
            get { return _ConstraintDateHijri; }
            set { _ConstraintDateHijri = value; }
        }
        public string ConstraintDateHijriString
        {
            get
            {
                string myDate = ConstraintDateHijri.ToString();
                if (myDate.Length != 8) return "";
                //return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
                return myDate.Substring(0, 4) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(6, 2);
            }
        }
        public DateTime ConstraintPlanDate
        {
            get { return _ConstraintPlanDate; }
            set { _ConstraintPlanDate = value; }
        }
        public int ConstraintPlanDateHijri
        {
            get { return _ConstraintPlanDateHijri; }
            set { _ConstraintPlanDateHijri = value; }
        }
        public string ConstraintPlanDateHijriString
        {
            get
            {
                string myDate = ConstraintPlanDateHijri.ToString();
                if (myDate.Length != 8) return "";
                // return myDate.Substring(6, 2) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(0, 4);
                return myDate.Substring(0, 4) + "/" + myDate.Substring(4, 2) + "/" + myDate.Substring(6, 2);
            }
        }
        //
        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { if (value.Length > 100) _DepartmentName = value.Substring(0, 100); else _DepartmentName = value; }
        }

        //
        public string GoalName
        {
            get { return _GoalName; }
            set { if (value.Length > 100) _GoalName = value.Substring(0, 100); else _GoalName = value; }
        }
        //
        public string ProjectTypeName
        {
            get { return _ProjectTypeName; }
            set { if (value.Length > 100) _ProjectTypeName = value.Substring(0, 100); else _ProjectTypeName = value; }
        }
        //
        public string ProgressTypeName
        {
            get { return _ProgressTypeName; }
            set { if (value.Length > 100) _ProgressTypeName = value.Substring(0, 100); else _ProgressTypeName = value; }
        }
        //
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

        #endregion

        #region Constractors

        public vReport()
        {
        }

        public vReport(int id)
        {
            LoadFromID(id);
        }

        public vReport(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT * FROM [vReport] WHERE ProjectID = {0}", id);
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
                colOrdinal = reader.GetOrdinal("ProjectID");
                _id = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectName");
                if (!reader.IsDBNull(colOrdinal)) _ProjectName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectSponsor");
                if (!reader.IsDBNull(colOrdinal)) _ProjectSponsor = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectProgram");
                if (!reader.IsDBNull(colOrdinal)) _ProjectProgram = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectManager");
                if (!reader.IsDBNull(colOrdinal)) _ProjectManager = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectStartDate");
                if (!reader.IsDBNull(colOrdinal)) _ProjectStartDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectStartDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ProjectStartDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectEndDate");
                if (!reader.IsDBNull(colOrdinal)) _ProjectEndDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectEndDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ProjectEndDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectActualStartDate");
                if (!reader.IsDBNull(colOrdinal)) _ProjectActualStartDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectActualStartDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ProjectActualStartDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectActualEndDate");
                if (!reader.IsDBNull(colOrdinal)) _ProjectActualEndDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectActualEndDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ProjectActualEndDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectContractor");
                if (!reader.IsDBNull(colOrdinal)) _ProjectContractor = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectBudget");
                if (!reader.IsDBNull(colOrdinal)) _ProjectBudget = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectProgress");
                if (!reader.IsDBNull(colOrdinal)) _ProjectProgress = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectPaiedValue");
                if (!reader.IsDBNull(colOrdinal)) _ProjectPaiedValue = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("Project_ProjectType");
                if (!reader.IsDBNull(colOrdinal)) _Project_ProjectType = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("Project_DepartmentID");
                if (!reader.IsDBNull(colOrdinal)) _Project_DepartmentID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectDescription");
                if (!reader.IsDBNull(colOrdinal)) _ProjectDescription = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ProjectBossNote");
                if (!reader.IsDBNull(colOrdinal)) _ProjectBossNote = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("Project_ProgressTypeID");
                if (!reader.IsDBNull(colOrdinal)) _Project_ProgressTypeID = reader.GetInt32(colOrdinal);

                colOrdinal = reader.GetOrdinal("AbbreviateName");
                if (!reader.IsDBNull(colOrdinal)) _AbbreviateName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("AbbreviateUpdateDate");
                if (!reader.IsDBNull(colOrdinal)) _AbbreviateUpdateDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("AbbreviateUpdateDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _AbbreviateUpdateDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("AbbreviateMayorNote");
                if (!reader.IsDBNull(colOrdinal)) _AbbreviateMayorNote = reader.GetString(colOrdinal);

                colOrdinal = reader.GetOrdinal("ConstraintName");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintRequiredSolution");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintRequiredSolution = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintResponsibleName");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintResponsibleName = reader.GetString(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintIsNeedMayor");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintIsNeedMayor = reader.GetBoolean(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintIsSolved");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintIsSolved = reader.GetBoolean(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintDate");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintDateHijri = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintPlanDate");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintPlanDate = reader.GetDateTime(colOrdinal);
                colOrdinal = reader.GetOrdinal("ConstraintPlanDateHijri");
                if (!reader.IsDBNull(colOrdinal)) _ConstraintPlanDateHijri = reader.GetInt32(colOrdinal);

                colOrdinal = reader.GetOrdinal("DepartmentName");
                if (!reader.IsDBNull(colOrdinal)) _DepartmentName = reader.GetString(colOrdinal);

                colOrdinal = reader.GetOrdinal("GoalName");
                if (!reader.IsDBNull(colOrdinal)) _GoalName = reader.GetString(colOrdinal);

                colOrdinal = reader.GetOrdinal("ProjectTypeName");
                if (!reader.IsDBNull(colOrdinal)) _ProjectTypeName = reader.GetString(colOrdinal);

                colOrdinal = reader.GetOrdinal("ProgressTypeName");
                if (!reader.IsDBNull(colOrdinal)) _ProgressTypeName = reader.GetString(colOrdinal);

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





            }
        }

        #endregion

      

   
      

        #region Static Methods

      

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
            string TempSql = string.Format("SELECT * FROM [vReport]");
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
            string TempSql = "SELECT * FROM [vReport]";
            if (SqlFilter != "") TempSql += " WHERE " + SqlFilter;
            if (mOrderBy != "") TempSql += " ORDER BY " + mOrderBy;
            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                vReport TempObj;
                while (reader.Read())
                {
                    TempObj = new vReport(reader);
                    lst.Add(TempObj);
                }
            }
            reader.Close();
        }

        public string GetWhereCluse()
        {
            string mWhere = "";

            if (this.ProjectBudget > 0) mWhere += string.Format("([ProjectBudget] LIKE '{0}%') AND", this.ProjectBudget);
            if (this.Project_DepartmentID > 0) mWhere += string.Format("([Project_DepartmentID] = {0}) AND", this.Project_DepartmentID);
            if (this.ProjectManager != "") mWhere += string.Format("([ProjectManager] LIKE '{0}%') AND", this.ProjectManager);
            if (this.ProjectPaiedValue > 0) mWhere += string.Format("([ProjectPaiedValue] LIKE '{0}%') AND", this.ProjectPaiedValue);
            if (this.ProjectProgram != "") mWhere += string.Format("([ProjectProgram] LIKE '{0}%') AND", this.ProjectProgram);
            if (this.ProjectName != "") mWhere += string.Format("([ProjectName] LIKE '{0}%') AND", this.ProjectName);
            if (this.ProjectSponsor != "") mWhere += string.Format("([ProjectSponsor] LIKE '{0}%') AND", this.ProjectSponsor);
            if (mWhere.Length > 4)
            {
                mWhere = mWhere.Substring(0, mWhere.Length - 4);
            }
            return mWhere;
        }
     

        public static DataTable GetData(string mstring)
        {
            DataTable dt = new DataTable();

            fayedDAL.FillDataTable(dt, mstring);
            return dt;
        }
        public static int GetRowsCount()
        {
            return fayedDAL.GetRowsCount("Project");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("Project", SqlFilter);
        }

        public static vReport GevReport(int id)
        {
            return new vReport(id);
        }
       
        
       
        //Fill Gridview
        public static void FillGridView(GridView myGrideView, string mystring)
        {
            DataTable dt = new DataTable();
            // string mystring = "SELECT [ProjectID],[ProjectName] FROM Project";
            fayedDAL.FillDataTable(dt, mystring);
            myGrideView.DataSource = dt;
            myGrideView.DataBind();

        }


        public static DataTable GevReportData(string str)
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


