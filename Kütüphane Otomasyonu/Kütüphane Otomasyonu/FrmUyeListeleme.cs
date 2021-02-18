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
    public partial class FrmUyeListeleme : Form
    {
        public FrmUyeListeleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-387VI6I\\MSSQLSERVER01;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True");

        DataSet daset = new DataSet();
        private void MskTc_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from uye where tc like '" + MskTc.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                TxtAdSoyad.Text = read["adsoyad"].ToString();
                TxtYas.Text = read["yas"].ToString();
                CmbCınsıyet.Text = read["cinsiyet"].ToString();
                MskTelefon.Text = read["telefon"].ToString();
                TxtAdres.Text = read["adres"].ToString();
                TxtMail.Text = read["email"].ToString();
                TxtOKitapSayisi.Text = read["okukitapsayisi"].ToString();
            }
            baglanti.Close();
        }

        private void BtnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bu kaydı silmek mi istiyorsunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from uye where tc=@tc", baglanti);
                komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti.");
                daset.Tables["uye"].Clear();
                uyelistele();

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
                    else if (item is ComboBox)
                    {
                        item.Text = "";
                    }

                }
            }
        }
        private void uyelistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from uye", baglanti);
            adtr.Fill(daset, "uye");
            dataGridView1.DataSource = daset.Tables["uye"];
            baglanti.Close();
        }
        private void FrmUyeListeleme_Load(object sender, EventArgs e)
        {
            uyelistele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update uye set adsoyad=@adsoyad,yas=@yas,cinsiyet=@cinsiyet,telefon=@telefon,adres=@adres,email=@email,okukitapsayisi=@okukitapsayisi where tc=@tc", baglanti);
            komut.Parameters.AddWithValue("@tc", MskTc.Text);
            komut.Parameters.AddWithValue("@adsoyad", TxtAdSoyad.Text);
            komut.Parameters.AddWithValue("@yas", TxtYas.Text);
            komut.Parameters.AddWithValue("@cinsiyet", CmbCınsıyet.Text);
            komut.Parameters.AddWithValue("@telefon", MskTelefon.Text);
            komut.Parameters.AddWithValue("@adres", TxtAdres.Text);
            komut.Parameters.AddWithValue("@email", TxtMail.Text);
            komut.Parameters.AddWithValue("@okukitapsayisi", int.Parse(TxtOKitapSayisi.Text));
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Gerçekleşti");
            daset.Tables["uye"].Clear();
            uyelistele();

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
                else if (item is ComboBox)
                {
                    item.Text = "";
                }
            }
        }
       
    }
}
  
