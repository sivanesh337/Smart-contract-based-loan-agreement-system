using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Net;

public partial class Downloadmaterials : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    SqlCommand cmd;
    SqlDataReader dr;
    string syear;
    protected void Page_Load(object sender, EventArgs e)
    {
        
       
        bindgrid();
    }

    private void bindgrid()
    {
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        cmd = new SqlCommand("select * from Documentupload", con);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //
        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
          try
          {
        string str = GridView1.Rows[e.NewSelectedIndex].Cells[4].Text;
        cmd = new SqlCommand("Select Documentname from Documentupload where Documentname='" + str + "'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {

            string filePath = Server.MapPath("~/uploads");
            string _DownloadableProductFileName = str;

            System.IO.FileInfo FileName = new System.IO.FileInfo(filePath + "\\" + _DownloadableProductFileName);
            FileStream myFile = new FileStream(filePath + "\\" + _DownloadableProductFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            //Reads file as binary values
            BinaryReader _BinaryReader = new BinaryReader(myFile);


            long startBytes = 0;
            string lastUpdateTiemStamp = File.GetLastWriteTimeUtc(filePath).ToString("r");
            string _EncodedData = HttpUtility.UrlEncode(_DownloadableProductFileName, Encoding.UTF8) + lastUpdateTiemStamp;

            Response.Clear();
            Response.Buffer = false;
            Response.AddHeader("Accept-Ranges", "bytes");
            Response.AppendHeader("ETag", "\"" + _EncodedData + "\"");
            Response.AppendHeader("Last-Modified", lastUpdateTiemStamp);
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + FileName.Name);
            Response.AddHeader("Content-Length", (FileName.Length - startBytes).ToString());
            Response.AddHeader("Connection", "Keep-Alive");
            Response.ContentEncoding = Encoding.UTF8;

            //Send data
            _BinaryReader.BaseStream.Seek(startBytes, SeekOrigin.Begin);

            //Dividing the data in 1024 bytes package
            int maxCount = (int)Math.Ceiling((FileName.Length - startBytes + 0.0) / 1024);

            //Download in block of 1024 bytes
            int i;
            for (i = 0; i < maxCount && Response.IsClientConnected; i++)
            {
                Response.BinaryWrite(_BinaryReader.ReadBytes(1024));
                Response.Flush();
            }
        }


         }
        catch (Exception ex)
        {

        }

        //

    }
}
