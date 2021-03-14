using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VeriEkle : System.Web.UI.Page
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
        string adi = TextBox1.Text;
        string numarasi = TextBox2.Text;
        int yasi = Convert.ToInt32(TextBox3.Text);
        decimal notu = Convert.ToDecimal(TextBox4.Text);
        SqlConnection baglanti = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiCumlemiz"].ConnectionString);
        SqlCommand ekleKomutu = new SqlCommand("INSERT INTO Veriler (AdSoyad, Numara, Yas, Notu) VALUES (@adSoyad, @numara, @yas, @notu)", baglanti);
        ekleKomutu.Parameters.AddWithValue("@adsoyad", adi);
        ekleKomutu.Parameters.AddWithValue("@numara", numarasi);
        ekleKomutu.Parameters.AddWithValue("@yas", yasi);
        ekleKomutu.Parameters.AddWithValue("@notu", notu);
        baglanti.Open();
        ekleKomutu.ExecuteNonQuery();
        baglanti.Close();
        Label5.Text = adi + " İsimli Öğrenci Veritabanına Eklendi!";
    } 
}