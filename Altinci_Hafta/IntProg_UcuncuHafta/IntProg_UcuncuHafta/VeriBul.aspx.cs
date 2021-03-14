using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VeriBul : System.Web.UI.Page
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
        string aranacak = TextBox1.Text;
        SqlConnection baglanti = new SqlConnection(System.Web.Configuration.WebConfigurationManager.ConnectionStrings["baglantiCumlemiz"].ConnectionString);
        SqlCommand bulKomutu = new SqlCommand("SELECT * FROM Veriler WHERE AdSoyad=@adsoyad", baglanti);
        bulKomutu.Parameters.AddWithValue("@adsoyad", aranacak);
        baglanti.Open();
        SqlDataReader listele = bulKomutu.ExecuteReader();
        GridView1.DataSource = listele;
        GridView1.DataBind();
        baglanti.Close();
    }
     
}