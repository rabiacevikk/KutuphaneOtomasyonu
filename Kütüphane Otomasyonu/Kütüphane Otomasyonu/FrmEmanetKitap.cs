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
    public partial class FrmEmanetKitap : Form
    {
        public FrmEmanetKitap()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-387VI6I\\MSSQLSERVER01;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True");
        DataSet daset = new DataSet();
        private void BtnIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void sepetlistele()
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from sepet", baglanti);
            adtr.Fill(daset, "sepet");
            dataGridView1.DataSource = daset.Tables["sepet"];
            baglanti.Close();
        }
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into sepet(barkodno,kitapadi,yazari,yayinevi,sayfasayisi,kitapsayisi,teslimtarihi,iadetarihi) values (@barkodno,@kitapadi,@yazari,@yayinevi,@sayfasayisi,@kitapsayisi,@teslimtarihi,@iadetarihi)", baglanti);
            komut.Parameters.AddWithValue("@barkodno",TxtBarkodNo.Text);
            komut.Parameters.AddWithValue("@kitapadi", TxtKitapAdi.Text);
            komut.Parameters.AddWithValue("@yazari", TxtYazari.Text);
            komut.Parameters.AddWithValue("@yayinevi", TxtYayinevi.Text);
            komut.Parameters.AddWithValue("@sayfasayisi", TxtSayfaSayisi.Text);
            komut.Parameters.AddWithValue("@kitapsayisi", TxtKitapSayisi.Text);
            komut.Parameters.AddWithValue("@teslimtarihi", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@iadetarihi", dateTimePicker2.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitaplar sepete eklendi", "Ekleme İşlemi");
            daset.Tables["sepet"].Clear();
            sepetlistele();
            LblKitapSayisi.Text = "";
            kitapsayisi();
            foreach (Control item in GrpKitapBilgi.Controls)
            {
                if (item is TextBox)
                {
                    if (item!=TxtKitapSayisi)
                    {
                        item.Text = "";
                    }
                }
            }
        }
        private void kitapsayisi()
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select sum(kitapsayisi) from sepet", baglanti);
            LblKitapSayisi.Text = komut.ExecuteScalar().ToString();
            baglanti.Close();
        }
        private void FrmEmanetKitap_Load(object sender, EventArgs e)
        {
            sepetlistele();
            kitapsayisi();
        }

        private void TxtTcAra_TextChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from uye where tc like '" + TxtTcAra.Text + "'", baglanti);
            SqlDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                TxtAdSoyad.Text = read["adsoyad"].ToString();
                TxtYas.Text = read["yas"].ToString();
                TxtTelefon.Text = read["telefon"].ToString();
            }
            baglanti.Close();
            baglanti.Open();
            //etikete kitap sayısı yazdırma
            SqlCommand komut2 = new SqlCommand("select sum(kitapsayisi) from emanetkitaplar where tc='"+TxtTcAra.Text+"'", baglanti);
            LblKayitliKitapSayisi.Text = komut2.ExecuteScalar().ToString();
            baglanti.Close();
            if (TxtTcAra.Text=="")
            {
                foreach (Control item in GrpUyeBilgileri.Controls)
                {
                    item.Text = "";
                    LblKayitliKitapSayisi.Text = "";
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
            }
            baglanti.Close();
            if (TxtBarkodNo.Text=="")
            {
                foreach (Control item in GrpKitapBilgi.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != TxtKitapSayisi)
                        {
                            item.Text = "";
                        }
                    }
            
                }
            }
        
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from sepet where barkodno='" + dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString() + "'", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşlemi Yapıldı.", "Silme İşlemi");
            daset.Tables["sepet"].Clear();
            sepetlistele();
            LblKitapSayisi.Text = "";
            kitapsayisi();
        }

        private void BtnTeslimEt_Click(object sender, EventArgs e)
        {
            if (LblKitapSayisi.Text!="")
            {
                if (LblKayitliKitapSayisi.Text=="" && int.Parse(LblKitapSayisi.Text) <=3|| LblKayitliKitapSayisi.Text != "" && int.Parse(LblKayitliKitapSayisi.Text) + int.Parse(LblKitapSayisi.Text) <= 3)
                {
                    if (TxtTcAra.Text!="" && TxtAdSoyad.Text!="" && TxtYas.Text!="" && TxtTelefon.Text!="")
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count-1;i++)
                        {
                            baglanti.Open();
                            SqlCommand komut = new SqlCommand("insert into emanetkitaplar(tc,adsoyad,yas,telefon,barkodno,kitapadi,yazari,yayinevi,sayfasayisi,kitapsayisi,teslimtarihi,iadetarihi)   values (@tc,@adsoyad,@yas,@telefon,@barkodno,@kitapadi,@yazari,@yayinevi,@sayfasayisi,@kitapsayisi,@teslimtarihi,@iadetarihi)", baglanti);
                            komut.Parameters.AddWithValue("@tc", TxtTcAra.Text);
                            komut.Parameters.AddWithValue("@adsoyad", TxtAdSoyad.Text);
                            komut.Parameters.AddWithValue("@yas", TxtYas.Text);
                            komut.Parameters.AddWithValue("@telefon", TxtTelefon.Text);
                            komut.Parameters.AddWithValue("barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                            komut.Parameters.AddWithValue("kitapadi", dataGridView1.Rows[i].Cells["kitapadi"].Value.ToString());
                            komut.Parameters.AddWithValue("yazari", dataGridView1.Rows[i].Cells["yazari"].Value.ToString());
                            komut.Parameters.AddWithValue("yayinevi", dataGridView1.Rows[i].Cells["yayinevi"].Value.ToString());
                            komut.Parameters.AddWithValue("sayfasayisi", dataGridView1.Rows[i].Cells["sayfasayisi"].Value.ToString());
                            komut.Parameters.AddWithValue("kitapsayisi", int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()));
                            komut.Parameters.AddWithValue("teslimtarihi", dataGridView1.Rows[i].Cells["teslimtarihi"].Value.ToString());
                            komut.Parameters.AddWithValue("iadetarihi", dataGridView1.Rows[i].Cells["iadetarihi"].Value.ToString());
                            komut.ExecuteNonQuery();
                            baglanti.Close();
                            baglanti.Open();
                            SqlCommand komut2 = new SqlCommand("update uye set okukitapsayisi=okukitapsayisi+'" + int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()) + "' where tc='" + TxtTcAra.Text + "' ", baglanti);
                            komut2.ExecuteNonQuery();
                            SqlCommand komut3 = new SqlCommand("update kitap set stoksayisi=stoksayisi-'" + int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()) + "'where barkodno='" +dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "'", baglanti);
                                komut3.ExecuteNonQuery();
                            baglanti.Close();
                        }
                        baglanti.Open();
                        SqlCommand komut4 = new SqlCommand("delete from sepet", baglanti);
                        komut4.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Kitaplar Emanet Edildi.");
                        daset.Tables["sepet"].Clear();
                        sepetlistele();
                        TxtTcAra.Text = "";
                        LblKitapSayisi.Text = "";
                        kitapsayisi();
                        LblKayitliKitapSayisi.Text = "";

                    } 
                    else
                    {
                        MessageBox.Show("Önce üye ismi seçmeniz gerekir!!!", "Uyarı");
                    }
                    
                }
                else
                {
                    MessageBox.Show("Emanet Kitap Sayısı 3 ten fazla olamaz!!!", "Uyarı");
                }
              
            }
            else
            {
                MessageBox.Show("Önce Sepete Kitap eklenmelidir.", "Uyarı");
            }
        }
    }
}
