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
public partial class Applyloan : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    SqlCommand cmd = new SqlCommand();
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownList1.Items.Clear();
            cmd = new SqlCommand("select Loantype from Loan", con);
            if (con.State == System.Data.ConnectionState.Closed)
                con.Open();
            SqlDataReader dr1 = cmd.ExecuteReader();
            while (dr1.Read())
            {
                DropDownList1.Items.Add(dr1[0].ToString());
            }
            con.Close();
        }
        bindgrid();
        TextBox2.Text = System.DateTime.Now.ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        cmd = new SqlCommand("insert into Loanapply values('" + Session["User"].ToString() + "','" + DropDownList1.Text + "','" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text +"','"+ TextBox4.Text +"','null','null')", con);
        cmd.ExecuteNonQuery();

        cmd.Dispose();
        con.Close();
        Response.Redirect("Applyloan.aspx");
    }

    private void bindgrid()
    {

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        cmd = new SqlCommand("select * from Loanapply where Userid='" + Session["User"].ToString() + "'", con);
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

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();
        try
        {
            string str = GridView1.Rows[e.RowIndex].Cells[1].Text;
            cmd = new SqlCommand("delete from Loanapply where Apno='" + str + "'", con);
            cmd.ExecuteNonQuery();
            GridView1.EditIndex = -1;
            con.Close();
            bindgrid();
        }
        catch (Exception ex)
        {

        }
    }
}
