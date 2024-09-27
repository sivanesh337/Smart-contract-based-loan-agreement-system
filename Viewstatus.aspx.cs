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
using System.Net;
using System.IO;
using System.Data;
using System.Data.SqlClient;


using System.IO;
using System.Security.Cryptography;
using System.Net;
using System.Text;
public partial class Viewstatus : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.AppSettings["conn"]);
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        bindgrid1();
    }

    private void bindgrid1()
    {

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
        cmd = new SqlCommand("select * from Loanapproved where Userid='" + Session["User"].ToString() + "'", con);
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
        cmd = new SqlCommand("SELECT * FROM Loanapproved where id = '" + str + "'", con);

        SqlDataAdapter Adpt = new SqlDataAdapter(cmd);

        DataSet ds = new DataSet();
        Adpt.Fill(ds);
        Adpt.Dispose();
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            TextBox9.Text = Convert.ToString(ds.Tables[0].Rows[0]["id"]);
            TextBox1.Text = Convert.ToString(ds.Tables[0].Rows[0]["Apno"]);
            TextBox2.Text = Convert.ToString(ds.Tables[0].Rows[0]["Userid"]);
            TextBox3.Text = Convert.ToString(ds.Tables[0].Rows[0]["Loantype"]);
            TextBox4.Text = Convert.ToString(ds.Tables[0].Rows[0]["Amount"]);
            TextBox5.Text = Convert.ToString(ds.Tables[0].Rows[0]["Adate"]);
            TextBox8.Text = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
            TextBox6.Text = Convert.ToString(ds.Tables[0].Rows[0]["Interest"]);
            TextBox7.Text = Convert.ToString(ds.Tables[0].Rows[0]["totyear"]);

        }

        con.Close();

        //if (con.State == System.Data.ConnectionState.Closed)
        //    con.Open();

        //cmd = new SqlCommand("SELECT  Email FROM Usertbl where Userid = '" + TextBox2.Text + "'", con);

        //SqlDataAdapter Adpt1 = new SqlDataAdapter(cmd);

        //DataSet ds1 = new DataSet();
        //Adpt1.Fill(ds1);
        //Adpt1.Dispose();
        //foreach (DataRow dr1 in ds1.Tables[0].Rows)
        //{
        //    Label10.Text = Convert.ToString(ds1.Tables[0].Rows[0]["Email"]);



        //}

    }
    protected void Button1_Click(object sender, EventArgs e)
    {


       

        string amt = Decrypt(TextBox4.Text, "hi", "saltValue", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);
        string status = Decrypt(TextBox8.Text, "hi", "saltValue", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);
        string inter = Decrypt(TextBox6.Text, "hi", "saltValue", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);
        string tyear = Decrypt(TextBox7.Text, "hi", "saltValue", "SHA1", 2, "@1B2c3D4e5F6g7H8", 256);

        TextBox4.Text = amt.ToString();
        TextBox8.Text = status.ToString();
        TextBox6.Text = inter.ToString();
        TextBox7.Text = tyear.ToString();
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
