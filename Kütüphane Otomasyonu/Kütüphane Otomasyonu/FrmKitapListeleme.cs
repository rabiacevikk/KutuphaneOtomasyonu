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
    public partial class FrmKitapListeleme : Form
    {
        public FrmKitapListeleme()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-387VI6I\\MSSQLSERVER01;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True");
        DataSet daset = new DataSet();
        private void kitaplistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from kitap", baglanti);
            adtr.Fill(daset, "kitap");
            dataGridView1.DataSource = daset.Tables["kitap"];
            baglanti.Close();
        }
        private void FrmKitapListeleme_Load(object sender, EventArgs e)
        {
            kitaplistele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialog;
            dialog = MessageBox.Show("Bu kaydı silmek mi istiyorsunuz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog==DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("delete from kitap where barkodno=@barkodno", baglanti);
                komut.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Silme İşlemi Gerçekleşti.");
                daset.Tables["kitap"].Clear();
                kitaplistele();
                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                    else if(item is ComboBox)
                    {
                        item.Text = "";
                    }
                }
            }
        }

        private void TxtIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update kitap set kitapadi=@kitapadi,yazari=@yazari,yayinevi=@yayinevi,sayfasayisi=@sayfasayisi,turu=@turu,stoksayisi=@stoksayisi,rafno=@rafno,aciklama=@aciklama where barkodno=@barkodno", baglanti);
            komut.Parameters.AddWithValue("@barkodno", TxtBarkodNo.Text);
            komut.Parameters.AddWithValue("@kitapadi", TxtKitapAdi.Text);
            komut.Parameters.AddWithValue("@yazari", TxtYazari.Text);
            komut.Parameters.AddWithValue("@yayinevi", TxtYayinevi.Text);
            komut.Parameters.AddWithValue("@sayfasayisi", TxtSayfaSayisi.Text);
            komut.Parameters.AddWithValue("@turu", CmbTuru.Text);
            komut.Parameters.AddWithValue("@stoksayisi", int.Parse(TxtStokSayisi.Text));
            komut.Parameters.AddWithValue("@rafno", TxtRafNo.Text);
            komut.Parameters.AddWithValue("@aciklama", TxtAciklama.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme İşlemi Gerçekleşti.");
            daset.Tables["kitap"].Clear();
            kitaplistele();
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


        private void TxtBarkodNo_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from kitap where barkodno like '" + TxtBarkodNo.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                TxtKitapAdi.Text = read["kitapadi"].ToString();
                TxtYazari.Text = read["yazari"].ToString();
                TxtYayinevi.Text = read["yayinevi"].ToString();
                TxtSayfaSayisi.Text = read["sayfasayisi"].ToString();
                CmbTuru.Text = read["turu"].ToString();
                TxtStokSayisi.Text = read["stoksayisi"].ToString();
                TxtRafNo.Text = read["rafno"].ToString();
                TxtAciklama.Text = read["aciklama"].ToString();
            }
            baglanti.Close();
        }

        private void TxtBarkodAra_TextChanged(object sender, EventArgs e)
        {

            daset.Tables["kitap"].Clear();
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from kitap where barkodno like '%" +TxtBarkodAra.Text + "%'", baglanti);
            adtr.Fill(daset, "kitap");
            dataGridView1.DataSource = daset.Tables["kitap"];
            baglanti.Close();
        }
    }
    }

