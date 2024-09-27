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
public partial class AddStaff : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    SqlCommand cmd = new SqlCommand();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        bindgrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
         con.Open();


         cmd = new SqlCommand("insert into Loan values('" + TextBox1.Text + "')", con);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();
                Response.Redirect("Addloan.aspx");
               
         

       
        
    }

    private void bindgrid()
    {

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        cmd = new SqlCommand("select * from Loan", con);
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
    
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
     
    }
   
   
    protected void Button2_Click(object sender, EventArgs e)
    {
       
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        try
        {
            string str = GridView1.Rows[e.RowIndex].Cells[1].Text;
            cmd = new SqlCommand("delete from Loan where Laonid='" + str + "'", con);
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            con.Close();
            bindgrid();
        }
        catch (Exception ex)
        {

        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
       
    }
}
