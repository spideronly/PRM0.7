///////////////////////////////////////////////////
//
//			Sami Shamsan
//			eng.shamsan@gmail.com
//
///////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for myReportHelper
/// </summary>
public class myReportHelper
{

    public static void DownloadReportAsPdf(Stimulsoft.Report.StiReport mRep)
    {
        DownloadReportAsPdf(mRep, "");
    }
    public static void DownloadReportAsWord(Stimulsoft.Report.StiReport mRep)
    {
        DownloadReportAsWord(mRep, "");
    }

    public static void DownloadReportAsPdf(Stimulsoft.Report.StiReport mRep,string mFileName)
    {
        if (mFileName.Trim() == "")
            mFileName = "test";

        System.IO.MemoryStream myMs = new System.IO.MemoryStream();
        mRep.ExportDocument(Stimulsoft.Report.StiExportFormat.Pdf, myMs);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.pdf", HttpContext.Current.Server.UrlPathEncode(mFileName)));
        HttpContext.Current.Response.BufferOutput = false;
        HttpContext.Current.Response.OutputStream.Write(myMs.ToArray(), 0, (int)myMs.Length);

        HttpContext.Current.Response.End();
    }
    public static void DownloadReportAsWord(Stimulsoft.Report.StiReport mRep, string mFileName)
    {
        if (mFileName.Trim() == "")
            mFileName = "test";

        System.IO.MemoryStream myMs = new System.IO.MemoryStream();
        mRep.ExportDocument(Stimulsoft.Report.StiExportFormat.Word2007, myMs);

        HttpContext.Current.Response.Clear();
        HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment; filename={0}.docx", HttpContext.Current.Server.UrlPathEncode(mFileName)));
        HttpContext.Current.Response.BufferOutput = false;
        HttpContext.Current.Response.OutputStream.Write(myMs.ToArray(), 0, (int)myMs.Length);

        HttpContext.Current.Response.End();
    }
}
