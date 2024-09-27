using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Net;
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class Service : System.Web.Services.WebService
{
    SqlConnection con = new SqlConnection("server=.\\sqlexpress;database=Loanapp;Integrated security=true;");
    SqlCommand cmd;
    String Cdate;
    public Service()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    
   
   
    
    [WebMethod]
    public String Authenticateclient(String Clientid, String Pwd)
    {
        String s = "";
        if (con.State == ConnectionState.Closed)
            con.Open();

        cmd = new SqlCommand("select * from Usertbl where Userid='" + Clientid + "' and Pwd='" + Pwd + "'", con);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read())
        {
            s = "ok," + dr[1].ToString();
        }
        else
        {
            s = "not OK,not OK";
        }
        dr.Close();
        return s;
    }



   
    [WebMethod]
    public Boolean Newuser(String Userid, String Pwd, String Username, String Addr, String Mob, String Email)
    {
        Boolean boolResult = false;

        if (con.State == System.Data.ConnectionState.Closed) con.Open();
        cmd = new SqlCommand("insert into Usertbl values('" + Userid + "','" + Pwd + "','" + Username + "','" + Addr + "','" + Mob + "','" + Email + "')", con);
        cmd.ExecuteNonQuery();
        con.Close();
        boolResult = true;
        return boolResult;
    }

    [WebMethod]
    public Boolean Applyloan(String Userid, String Loantype, String Amount)
    {
        Boolean boolResult = false;

        if (con.State == System.Data.ConnectionState.Closed) con.Open();
        cmd = new SqlCommand("insert into Loanapply values('" + Userid + "','" + Loantype + "','" + Amount + "','" + System.DateTime.Now.ToShortDateString() + "','Loan Processing','Null')", con);
        cmd.ExecuteNonQuery();
        con.Close();
        boolResult = true;
        return boolResult;
    }


    [WebMethod]
    public String Uploaddocument(String Apno,String Userid, String Docname)
    {
        Boolean boolResult = false;

        if (con.State == System.Data.ConnectionState.Closed) con.Open();
        cmd = new SqlCommand("insert into Documentupload values('" + Apno + "','" + Userid + "','" +  Apno + "-" + System.DateTime.Now.ToString("dd-MM-yyyy")+".jpg" + "','" + System.DateTime.Now.ToShortDateString() + "')", con);
        cmd.ExecuteNonQuery();
        con.Close();
        boolResult = true;

        var bytes = Convert.FromBase64String(Docname);
        using (var imageFile = new FileStream(Server.MapPath("uploads/" + Apno + "-" + System.DateTime.Now.ToString("dd-MM-yyyy") + ".jpg"), FileMode.Create))
        {
            imageFile.Write(bytes, 0, bytes.Length);
            imageFile.Flush();
        }

        return "Upload Successfull";
    }

   
   
       
    [WebMethod]
    public string Viewloantype(string res)
    {

        string Result = "";

        if (con.State == System.Data.ConnectionState.Closed) con.Open();
        cmd = new SqlCommand("select * from Loan", con);
        //cmd = new SqlCommand("select * from Attendance", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Result += dr[1].ToString() + "#";

        }
        dr.Close();

        con.Close();

        return Result;

    }


    [WebMethod]
    public String Viewapplication(String res)
    {
        String Result = "";
        if (con.State == System.Data.ConnectionState.Closed) con.Open();
        cmd = new SqlCommand("select * from Loanapply where Userid='" + res + "'", con);
        //cmd = new SqlCommand("select * from Attendance", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Result += dr[0].ToString() + "," + dr[1].ToString() + "," + dr[2].ToString() + "," + dr[3].ToString() + "," + dr[4].ToString() + "," + dr[5].ToString() + "," + dr[6].ToString() + "#";

        }
        dr.Close();
        con.Close();
        return Result;

    }

    [WebMethod]
    public String Viewloanstatus(String res)
    {
        String Result = "";
        if (con.State == System.Data.ConnectionState.Closed) con.Open();
        cmd = new SqlCommand("select * from Loanapproved where Userid='" + res + "'", con);
        //cmd = new SqlCommand("select * from Attendance", con);
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            Result += dr[0].ToString() + "," + dr[1].ToString() + "," + dr[2].ToString() + "," + dr[3].ToString() + "," + dr[4].ToString() + "," + dr[5].ToString() + "," + dr[6].ToString() +"," + dr[7].ToString() +"," + dr[8].ToString() + "#";

        }
        dr.Close();
        con.Close();
        return Result;

    }

}
