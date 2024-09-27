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
public partial class NewUser : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    SqlCommand cmd = new SqlCommand();
    SqlDataReader dr;
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
               
        con.Open();
        cmd = new SqlCommand("select uname from Register where uname='" + TextBox2.Text + "'", con);
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Response.Write("<script>alert('The user Details are Already Exist')</script>");
            cmd.Dispose();
            dr.Close();
        }
        else
        {
            try
           {
                dr.Close();
              
                cmd = new SqlCommand("insert into Register values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')", con);
                cmd.ExecuteNonQuery();
               
                cmd.Dispose();

           
                    Response.Redirect("Userlogin.aspx");
               
           }
            catch
            {


            }

        }
        con.Close();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        cmd = new SqlCommand("select Userid from Usertbl where Userid='" + TextBox2.Text + "'", con);
        dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            Response.Write("<script>alert('The user Details are Already Exist')</script>");
            cmd.Dispose();
            dr.Close();
        }
        else
        {
            try
            {
                dr.Close();

                cmd = new SqlCommand("insert into Usertbl values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "')", con);
                cmd.ExecuteNonQuery();

                cmd.Dispose();


                Response.Redirect("Userlogin.aspx");

            }
            catch
            {


            }

        }
        con.Close();
    }
}
