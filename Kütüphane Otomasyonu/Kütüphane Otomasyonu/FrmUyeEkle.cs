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
    public partial class FrmUyeEkle : Form
    {
        public FrmUyeEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-387VI6I\\MSSQLSERVER01;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True");
        private void BtnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into uye(tc,adsoyad,yas,cinsiyet,telefon,adres,email,okukitapsayisi) values(@tc,@adsoyad,@yas,@cinsiyet,@telefon,@adres,@email,@okukitapsayisi)", baglanti);
            komut.Parameters.AddWithValue("@tc", MskTc.Text);
            komut.Parameters.AddWithValue("@adsoyad", TxtAdSoyad.Text);
            komut.Parameters.AddWithValue("yas", TxtYas.Text);
            komut.Parameters.AddWithValue("@cinsiyet", CmbCınsıyet.Text);
            komut.Parameters.AddWithValue("@telefon", MskTelefon.Text);
            komut.Parameters.AddWithValue("@adres", TxtAdres.Text);
            komut.Parameters.AddWithValue("@email", TxtMail.Text);
            komut.Parameters.AddWithValue("@okukitapsayisi", TxtOKitapSayisi.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Üye Kaydı Yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    if (item != TxtOKitapSayisi)
                    {
                        item.Text = "";
                    }

                }
                else if (item is MaskedTextBox)
                {
                    
                    item.Text = "";
                }
                else if(item is ComboBox)
                {
                    item.Text = "";
                }

            }
        }

        private void FrmUyeEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
