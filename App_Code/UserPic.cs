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
using System.Drawing;
using System.IO;

namespace ETDL
{

    #region UserPic
    /// <summary>
    /// This object represents the properties and methods of a ( UserPic ) Table.
    /// </summary>
    public class UserPic : IfayedDbTable
    {
        #region Private Fields,ToString() Method

        private int _id;
        private int _PicUserID;
        private byte[] _UserImage;

        public override string ToString()
        {
            // the text that will be displayed in Listbox or Combobox
            return _id.ToString();
        }

        #endregion

        #region Public Properties
        public int UserPicID
        {
            get { return _id; }
        }

        public int PicUserID
        {
            get { return _PicUserID; }
            set { _PicUserID = value; }
        }

        public byte[] UserImage
        {
            get { return _UserImage; }
            set
            {
                //_UserImage = value;

                MemoryStream mySt = new MemoryStream();
                mySt.Write(value, 0, value.Length);

                Image myImage = Image.FromStream(mySt);
                myImage = ResizeImage(myImage, 150, 170, true);

                MemoryStream mySt2 = new MemoryStream();
                myImage.Save(mySt2, System.Drawing.Imaging.ImageFormat.Png);
                _UserImage = mySt2.GetBuffer();

                myImage.Dispose();
                mySt.Dispose();
                mySt2.Dispose();
            }
        }
        #endregion

        #region Constractors

        public UserPic()
        {
        }

        public UserPic(int id)
        {
            LoadFromID(id);
        }

        public UserPic(DbDataReader reader)
        {
            this.LoadFromReader(reader);
        }

        protected void LoadFromID(int id)
        {
            string mSql = string.Format("SELECT * FROM [UserPic] WHERE UserPicID = {0}", id);
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
                throw new ApplicationException("Selected UserPic Row Does Not Exist.");
            }
        }

        protected void LoadFromReader(DbDataReader reader)
        {
            int colOrdinal;
            if (reader != null && !reader.IsClosed)
            {
                colOrdinal = reader.GetOrdinal("UserPicID");
                _id = reader.GetInt32(colOrdinal);

                colOrdinal = reader.GetOrdinal("PicUserID");
                if (!reader.IsDBNull(colOrdinal)) _PicUserID = reader.GetInt32(colOrdinal);
                colOrdinal = reader.GetOrdinal("UserImage");
                if (!reader.IsDBNull(colOrdinal))
                {
                    System.IO.MemoryStream st = new System.IO.MemoryStream();
                    System.IO.BinaryWriter writer = new System.IO.BinaryWriter(st);
                    // read in file from the database one
                    // buffer at a time.  when the number
                    // of bytes read is zero then we know that we are done.
                    long numberOfBytes, startIndex = 0;
                    byte[] buffer = new byte[1000];
                    do
                    {
                        numberOfBytes = reader.GetBytes(colOrdinal, startIndex, buffer, 0, 1000);
                        if (numberOfBytes == 0) break;

                        writer.Write(buffer, 0, (int)numberOfBytes);
                        startIndex += numberOfBytes;
                    } while (true);
                    writer.Flush();
                    _UserImage = st.ToArray();
                    writer.Close();
                }
            }
        }

        #endregion

        #region Create,Update,Delete

        public int Create()
        {
            DbCommand myCmd = fayedDAL.CreateCommand();
            string mCols, mValues = "";

            mCols = "[PicUserID],[UserImage]";

            mValues += string.Format("{0},", PicUserID);
            mValues += "@ParmData1";
            DbParameter parm1 = myCmd.CreateParameter();
            parm1.DbType = DbType.Binary;
            parm1.ParameterName = "@ParmData1";
            parm1.Value = UserImage;
            myCmd.Parameters.Add(parm1);


            string query = String.Format("INSERT INTO [UserPic] ({0}) VALUES ({1})", mCols, mValues);
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
            mTemp += string.Format("[PicUserID]={0},", PicUserID);
            mTemp += "[UserImage]=@ParmData1";

            DbParameter parm1 = myCmd.CreateParameter();
            parm1.DbType = DbType.Binary;
            parm1.ParameterName = "@ParmData1";
            parm1.Value = UserImage;
            myCmd.Parameters.Add(parm1);


            string query = string.Format("UPDATE [UserPic] SET {0} WHERE UserPicID = {1}", mTemp, UserPicID);
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
            if (id == 0) return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [UserPic] WHERE UserPicID = {0}", id));
        }

        public static int Delete(string mFilter)
        {
            if (mFilter.Trim() == "") return 0;
            return fayedDAL.ExecuteNonQuery(string.Format("DELETE FROM [UserPic] WHERE {0}", mFilter));
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
            string TempSql = "SELECT * FROM [UserPic]";
            if (SqlFilter != "") TempSql += " WHERE " + SqlFilter;

            DbDataReader reader = fayedDAL.ExecuteReader(TempSql);
            if (reader.HasRows)
            {
                UserPic TempObj;
                while (reader.Read())
                {
                    TempObj = new UserPic(reader);
                    lst.Add(TempObj);
                }
            }
            reader.Close();
        }

        public static int GetRowsCount()
        {
            return fayedDAL.GetRowsCount("UserPic");
        }

        public static int GetRowsCount(string SqlFilter)
        {
            return fayedDAL.GetRowsCount("UserPic", SqlFilter);
        }

        public static int GetUserPicIDByUserID(int EmpID)
        {
            object mm = fayedDAL.ExecuteScalar("SELECT [UserPicID] FROM [UserPic] WHERE [PicUserID]=" + EmpID.ToString());
            if (mm != null)
                return int.Parse(mm.ToString());
            else
                return 0;
        }
        public static UserPic GetByEmpID(int id)
        {
            int ii = GetUserPicIDByUserID(id);

            if (ii > 0)
                return new UserPic(ii);
            else
                return null;
        }


        public static System.Drawing.Image ResizeImage(System.Drawing.Image FullsizeImage, int NewWidth, int MaxHeight, bool OnlyResizeIfWider)
        {
            // Prevent using images internal thumbnail
            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            FullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

            if (OnlyResizeIfWider)
            {
                if (FullsizeImage.Width <= NewWidth)
                {
                    NewWidth = FullsizeImage.Width;
                }
            }

            int NewHeight = FullsizeImage.Height * NewWidth / FullsizeImage.Width;

            if (MaxHeight > 0)
                if (NewHeight > MaxHeight)
                {
                    // Resize with height instead
                    NewWidth = FullsizeImage.Width * MaxHeight / FullsizeImage.Height;
                    NewHeight = MaxHeight;
                }

            return FullsizeImage.GetThumbnailImage(NewWidth, NewHeight, null, IntPtr.Zero);
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


