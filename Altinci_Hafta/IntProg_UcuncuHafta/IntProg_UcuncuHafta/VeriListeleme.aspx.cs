using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VeriListeleme : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["oturum"] == "basarili")
        { }
        else
        { Response.Redirect("KullaniciGirisEkrani.aspx"); }

        SqlConnection baglanti = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiCumlemiz"].ConnectionString);
        SqlCommand listeleKomutu = new SqlCommand("SELECT * FROM Veriler", baglanti);
        baglanti.Open();
        SqlDataReader listele = listeleKomutu.ExecuteReader();
        GridView1.DataSource = listele;
        GridView1.DataBind();
        baglanti.Close();
        listeleKomutu.Dispose();
        baglanti.Dispose();

    } 

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session.Abandon();    //oturumu kapatma işlemi
        Response.Redirect("KullaniciGirisEkrani.aspx"); //sayfa yonlendirme kodu 

    }
}