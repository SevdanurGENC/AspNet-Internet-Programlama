using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VeriSil : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["oturum"] == "basarili")
        { }
        else
        { Response.Redirect("KullaniciGirisEkrani.aspx"); }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string numarasi = TextBox1.Text;
        SqlConnection baglanti = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiCumlemiz"].ConnectionString);
        SqlCommand silKomutu = new SqlCommand("DELETE FROM Veriler WHERE Numara=@numara", baglanti);
        silKomutu.Parameters.AddWithValue("@numara", numarasi);
        baglanti.Open();
        silKomutu.ExecuteNonQuery();
        baglanti.Close();
        Label1.Text = numarasi + " Numaralı Öğrenci Veritabanından Silindi!";
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Session.Abandon();    //oturumu kapatma işlemi
        Response.Redirect("KullaniciGirisEkrani.aspx"); //sayfa yonlendirme kodu 

    }
}