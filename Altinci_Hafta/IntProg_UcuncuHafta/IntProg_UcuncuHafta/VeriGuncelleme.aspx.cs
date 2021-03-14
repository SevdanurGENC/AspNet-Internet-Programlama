using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VeriGuncelleme : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["oturum"] == "basarili")
        { }
        else
        { Response.Redirect("KullaniciGirisEkrani.aspx"); }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Abandon();    //oturumu kapatma işlemi
        Response.Redirect("KullaniciGirisEkrani.aspx"); //sayfa yonlendirme kodu
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string numarasi = TextBox1.Text;
        decimal notu = Convert.ToDecimal(TextBox2.Text);
        SqlConnection baglanti = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiCumlemiz"].ConnectionString);
        SqlCommand guncelleKomutu = new SqlCommand("UPDATE Veriler SET Notu=@notu WHERE Numara=@numara", baglanti);
        guncelleKomutu.Parameters.AddWithValue("@notu", notu);
        guncelleKomutu.Parameters.AddWithValue("@numara", numarasi);
        baglanti.Open();
        guncelleKomutu.ExecuteNonQuery();
        baglanti.Close();
        Label1.Text = numarasi + " Numaralı Öğrencinin Notu Güncellendi: " + notu;
    }
     
}