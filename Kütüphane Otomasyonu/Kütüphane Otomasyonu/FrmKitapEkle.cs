using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kütüphane_Otomasyonu
{
    public partial class FrmKitapEkle : Form
    {
        public FrmKitapEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-387VI6I\\MSSQLSERVER01;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True");
        private void FrmKitapEkle_Load(object sender, EventArgs e)
        {

        }

        private void TxtIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Kitap(barkodno,kitapadi,yazari,yayinevi,sayfasayisi,turu,stoksayisi,rafno,aciklama,kayittarihi)values(@barkodno,@kitapadi,@yazari,@yayinevi,@sayfasayisi,@turu,@stoksayisi,@rafno,@aciklama,@kayittarihi)",baglanti);
            komut.Parameters.AddWithValue("@barkodno", TxtBarkodNo.Text);
            komut.Parameters.AddWithValue("@kitapadi", TxtKitapAdi.Text);
            komut.Parameters.AddWithValue("@yazari", TxtYazari.Text);
            komut.Parameters.AddWithValue("@yayinevi", TxtYayinevi.Text);
            komut.Parameters.AddWithValue("@sayfasayisi", TxtSayfaSayisi.Text);
            komut.Parameters.AddWithValue("@turu", CmbTuru.Text);
            komut.Parameters.AddWithValue("@stoksayisi", TxtStokSayisi.Text);
            komut.Parameters.AddWithValue("@rafno", TxtRafNo.Text);
            komut.Parameters.AddWithValue("@aciklama", TxtAciklama.Text);
            komut.Parameters.AddWithValue("@kayittarihi",DateTime.Now.ToShortDateString());
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Kaydı Yapıldı.");
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {

                    item.Text = "";
                }

                else if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }
    }
}


