///////////////////////////////////////////////////////////
//
//      Date Control v.1.0
//      By : Mohammed Samir Fayed
//      ms_fayed@hotmail.com
//      19/05/2009
//
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DateControl : System.Web.UI.UserControl
{
    private const string _myDateFormat = "dd/MM/yyyy";

    public void ClearText()
    {
        txtDate.Text = "";
        txtDateHijri.Text = "";
    }
    public void DisableText()
    {
        txtDate.Enabled = false;
        txtDateHijri.Enabled = false;
    }
    public void EnableText()
    {
        txtDate.Enabled = true;
        txtDateHijri.Enabled = true;
    }

    public DateTime Date
    {
        get
        {
            DateTime myDate;
            string[] mTemp;
            try
            {
                if (txtDate.Text.Replace(" ", "").Length <= 2)
                {
                    if (txtDateHijri.Text.Replace(" ", "").Length <= 2)
                        myDate = new DateTime();
                    else
                    {
                        mTemp = txtDateHijri.Text.Split('/');
                        DateTime mHijriDate = new DateTime(int.Parse(mTemp[2]), int.Parse(mTemp[1]), int.Parse(mTemp[0]), new System.Globalization.UmAlQuraCalendar());

                        txtDate.Text = mHijriDate.ToString(_myDateFormat, new System.Globalization.CultureInfo("ar-EG").DateTimeFormat);
                        mTemp = txtDate.Text.Split('/');
                        myDate = new DateTime(int.Parse(mTemp[2]), int.Parse(mTemp[1]), int.Parse(mTemp[0]), new System.Globalization.GregorianCalendar());
                    }
                }
                else
                {
                    mTemp = txtDate.Text.Split('/');
                    myDate = new DateTime(int.Parse(mTemp[2]), int.Parse(mTemp[1]), int.Parse(mTemp[0]), new System.Globalization.GregorianCalendar());
                    txtDateHijri.Text = myDate.ToString(_myDateFormat, mArCulture.DateTimeFormat);
                }
                return myDate;
            }
            catch
            {
                return new DateTime();
            }
        }
        set
        {
            txtDate.Text = "";
            if (value.Year == 1 && value.Month == 1 && value.Day == 1) return;
            try
            {
                txtDate.Text = value.ToString(_myDateFormat, new System.Globalization.CultureInfo("ar-EG").DateTimeFormat);
                txtDateHijri.Text = value.ToString(_myDateFormat, mArCulture.DateTimeFormat);
            }
            catch { }
        }
    }



    public int DateHijriAsNumber
    {
        get
        {
            string[] mTemp;
            DateTime myDate;
            int myRetValue;
            try
            {
                if (txtDateHijri.Text.Replace(" ", "").Length <= 2)
                {
                    if (txtDate.Text.Replace(" ", "").Length <= 2)
                        myRetValue = 0;
                    else
                    {
                        mTemp = txtDate.Text.Split('/');
                        myDate = new DateTime(int.Parse(mTemp[2]), int.Parse(mTemp[1]), int.Parse(mTemp[0]), new System.Globalization.GregorianCalendar());
                        txtDateHijri.Text = myDate.ToString(_myDateFormat, mArCulture.DateTimeFormat);

                        mTemp = txtDateHijri.Text.Split('/');
                        myRetValue = int.Parse(mTemp[2] + mTemp[1] + mTemp[0]);
                    }
                }
                else
                {
                    mTemp = txtDateHijri.Text.Split('/');
                    myRetValue = int.Parse(mTemp[2] + mTemp[1] + mTemp[0]);

                    DateTime mHijriDate = new DateTime(int.Parse(mTemp[2]), int.Parse(mTemp[1]), int.Parse(mTemp[0]), new System.Globalization.UmAlQuraCalendar());
                    txtDate.Text = mHijriDate.ToString(_myDateFormat, new System.Globalization.CultureInfo("ar-EG").DateTimeFormat);
                }

                return myRetValue;
            }
            catch { return 0; }
        }
        set
        {
            txtDateHijri.Text = "";
            if (value.ToString().Length == 8)
            {
                txtDateHijri.Text = value.ToString();
                txtDateHijri.Text = txtDateHijri.Text.Substring(6, 2) + "/" + txtDateHijri.Text.Substring(4, 2) + "/" + txtDateHijri.Text.Substring(0, 4);

                string[] mm = txtDateHijri.Text.Split('/');
                DateTime mHijriDate = new DateTime(int.Parse(mm[2]), int.Parse(mm[1]), int.Parse(mm[0]), new System.Globalization.UmAlQuraCalendar());
                txtDate.Text = mHijriDate.ToString(_myDateFormat, new System.Globalization.CultureInfo("ar-EG").DateTimeFormat);
            }
        }
    }


    protected void MultiCultureCalendar1_SelectionChanged(object sender, EventArgs e)
    {
        //PopDate.Commit(MultiCultureCalendar1.SelectedDate.ToString(_myDateFormat, new System.Globalization.CultureInfo("ar-EG").DateTimeFormat));
        //txtDateHijri.Text = MultiCultureCalendar1.SelectedDate.ToString(_myDateFormat, new System.Globalization.CultureInfo("ar-SA").DateTimeFormat);
    }
   
    protected void MultiCultureCalendar3_SelectionChanged(object sender, EventArgs e)
    {
        PopDateHijri.Commit(MultiCultureCalendar3.SelectedDate.ToString(_myDateFormat, mArCulture.DateTimeFormat));
      
        txtDate.Text = MultiCultureCalendar3.SelectedDate.ToString(_myDateFormat, new System.Globalization.CultureInfo("ar-EG").DateTimeFormat);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private System.Globalization.CultureInfo mArCulture
    {
        get
        {
            System.Globalization.CultureInfo arCul = new System.Globalization.CultureInfo("ar-SA");
            arCul.DateTimeFormat.Calendar = new System.Globalization.UmAlQuraCalendar();
            return arCul;
        }
    }
}
