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

//using System.Net;
//using System.IO;
using System.Data;


using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Text;
public partial class Loanapproved : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        bindgrid();
        bindgrid1();
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
        cmd = new SqlCommand("SELECT  Apno,Userid,Loantype,Amount,Applydate FROM Loanapply where Apno = '" + str + "'", con);

        SqlDataAdapter Adpt = new SqlDataAdapter(cmd);

        DataSet ds = new DataSet();
        Adpt.Fill(ds);
        Adpt.Dispose();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            TextBox1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Apno"]);
            TextBox2.Text = Convert.ToString(ds.Tables[0].Rows[0]["Userid"]);
            TextBox3.Text = Convert.ToString(ds.Tables[0].Rows[0]["Loantype"]);
            TextBox4.Text = Convert.ToString(ds.Tables[0].Rows[0]["Amount"]);
            TextBox5.Text = Convert.ToString(ds.Tables[0].Rows[0]["Applydate"]);

            
        }

        con.Close();

        if (con.State == System.Data.ConnectionState.Closed)
            con.Open();

        cmd = new SqlCommand("SELECT  Email FROM Usertbl where Userid = '" + TextBox2.Text + "'", con);

        SqlDataAdapter Adpt1 = new SqlDataAdapter(cmd);

        DataSet ds1 = new DataSet();
        Adpt1.Fill(ds1);
        Adpt1.Dispose();
        foreach (DataRow dr1 in ds1.Tables[0].Rows)
        {
            Label10.Text = Convert.ToString(ds1.Tables[0].Rows[0]["Email"]);
           


        }

        

    }

   

    protected void Button1_Click(object sender, EventArgs e)
    {

        string amt = Encryption(TextBox4.Text, "hi", "saltValue", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);
        string status = Encryption(DropDownList1.Text, "hi", "saltValue", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);
        string inter = Encryption(TextBox6.Text, "hi", "saltValue", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);
        string tyear = Encryption(TextBox7.Text, "hi", "saltValue", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);


        con.Open();
        cmd = new SqlCommand("insert into Loanapproved values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + amt + "','" + TextBox5.Text + "','" + status + "','" + inter + "','" + tyear + "')", con);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        con.Close();

        try
        {

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            System.Net.NetworkCredential cred = new System.Net.NetworkCredential("testmailalert20@gmail.com", "qwghdvduxumxjidk");

            mail.To.Add(Label10.Text);
            mail.Subject = "Loan Status";

            mail.From = new System.Net.Mail.MailAddress("testmailalert20@gmail.com");
            mail.IsBodyHtml = true; // Aceptamos HTML
            mail.Body = "<b>" + "Thanks For Visiting Bank" + "</b>" + "<br> <br>" + "Loan Status:" + DropDownList1.Text + "<br>" + " Loan Type:" + TextBox3.Text + "<br>" + " Amount: " + TextBox4.Text + "<br>" + " Interest:" + TextBox6.Text + "<br>" + " Total Year:" + TextBox7.Text;
            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient("smtp.gmail.com");


            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = cred; //asignamos la credencial
            smtp.Send(mail);

        }

        catch
        {

        }
        

        Response.Redirect("Loanapproved.aspx");
    }

    private void bindgrid1()
    {

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        cmd = new SqlCommand("select * from Loanapproved", con);
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        adp.Fill(ds);
        GridView2.DataSource = ds;
        GridView2.DataBind();
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
    }



    public static string Encryption(string plainText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
    {

        byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
        byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
        PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
        byte[] keyBytes = password.GetBytes(keySize / 8);
        RijndaelManaged symmetricKey = new RijndaelManaged();
        symmetricKey.Mode = CipherMode.CBC;
        ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);

        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
        cryptoStream.FlushFinalBlock();


        byte[] cipherTextBytes = memoryStream.ToArray();
        memoryStream.Close();
        cryptoStream.Close();

        string cipherText = Convert.ToBase64String(cipherTextBytes);
        return cipherText;
    }
    public static string Decrypt(string cipherText, string passPhrase, string saltValue, string hashAlgorithm, int passwordIterations, string initVector, int keySize)
    {

        byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
        byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
        byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
        PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
        byte[] keyBytes = password.GetBytes(keySize / 8);
        RijndaelManaged symmetricKey = new RijndaelManaged();
        symmetricKey.Mode = CipherMode.CBC;
        ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
        MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
        CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        byte[] plainTextBytes = new byte[cipherTextBytes.Length];
        int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        memoryStream.Close();
        cryptoStream.Close();
        string plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        return plainText;
    }






}
