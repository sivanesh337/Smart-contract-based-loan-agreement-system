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
public partial class Uploadmaterial : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    SqlCommand cmd = new SqlCommand();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
       
      TextBox2.Text= System.DateTime.Now.ToString();
        bgrid1();
    }
    private void bgrid1()
    {

        con.Close();
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter("select * from Documentupload where Userid='" + Session["User"].ToString() + "'", con);
        DataSet ds = new DataSet();
        da.Fill(ds);
        GridView1.DataSource = ds;
        GridView1.DataBind();
        con.Close();


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //
        if (TextBox3.Text == "" | FileUpload1.FileName == "")
        {
            Response.Write("<script>alert('Please Fill the All Column')</script>");

        }
        else
        {
            try
            {
               
                //Get the Input File Name and Extension.
                string fileName = Path.GetFileNameWithoutExtension(FileUpload1.PostedFile.FileName);
                string fileExtension = Path.GetExtension(FileUpload1.PostedFile.FileName);

                //Build the File Path for the original (input) and the encrypted (output) file.
                string input = Server.MapPath("~/Uploads/") + fileName + fileExtension;
             
              
                //Save the Input File, Encrypt it and save the encrypted file in output path.
                FileUpload1.SaveAs(input);
                File.Delete(input);
              


                if (FileUpload1.HasFile)
                {

                    string dest = Server.MapPath("Uploads\\" + FileUpload1.FileName.ToString());
                    FileUpload1.SaveAs(dest);
                    System.IO.FileInfo fileInfo = new System.IO.FileInfo(dest);
                    string ftype = FileUpload1.FileName.Substring(FileUpload1.FileName.LastIndexOf(".") + 1, (FileUpload1.FileName.Length - FileUpload1.FileName.LastIndexOf(".") - 1));
                    int filesize = FileUpload1.PostedFile.ContentLength;
                    if (con.State == ConnectionState.Closed) con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Documentupload values('"+ TextBox3.Text +"','"+ Session["User"].ToString()+"','" + FileUpload1.PostedFile.FileName + "','" + TextBox2.Text + "')", con);
                    cmd.ExecuteNonQuery();
                  
                }
            }
            catch
            {
            }

        }
        bgrid1();

        //
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        try
        {
            string str = GridView1.Rows[e.RowIndex].Cells[1].Text;
            cmd = new SqlCommand("delete from Documentupload where Docid=" + str + "", con);
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            con.Close();
            bgrid1();
        }
        catch (Exception ex)
        {

        }
    }
}
