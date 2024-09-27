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
public partial class Viewloanapplication : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        bindgrid();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        cmd = new SqlCommand("update Loanapply set Status='" + DropDownList1.Text + "',Decription='" + TextBox1.Text + "' where Apno='" + TextBox2.Text + "'", con);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();
        Response.Redirect("Viewloanapplication.aspx");
        cmd.Dispose();
        bindgrid();
    }

    private void bindgrid()
    {

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        cmd = new SqlCommand("select * from Loanapply", con);
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
        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        string str = GridView1.Rows[e.NewSelectedIndex].Cells[1].Text;
        cmd = new SqlCommand("SELECT  Apno FROM Loanapply where Apno = '" + str + "'", con);

        SqlDataAdapter Adpt = new SqlDataAdapter(cmd);

        DataSet ds = new DataSet();
        Adpt.Fill(ds);
        Adpt.Dispose();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            TextBox2.Text = Convert.ToString(ds.Tables[0].Rows[0]["Apno"]);
        

        }
    }
}
