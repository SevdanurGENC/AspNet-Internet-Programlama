using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class KullaniciGirisEkrani : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["oturum"] == "basarili")
            Response.Redirect("VeriEkle.aspx");
    }

    protected void btnGiris_Click(object sender, EventArgs e)
    { 
        if (txtKullaniciAdi.Text == "admin" && txtSifre.Text == "1234")
        {
            Session["oturum"] = "basarili";
            Response.Redirect("VeriEkle.aspx");
        }
        else
        {
            Session["oturum"] = "basarisiz";
            Label3.Text = "Kullanıcı adı veya Şifreniz yanlış.";
        }
    }
}