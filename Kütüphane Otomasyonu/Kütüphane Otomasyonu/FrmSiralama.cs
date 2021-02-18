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
    public partial class FrmSiralama : Form
    {
        public FrmSiralama()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-387VI6I\\MSSQLSERVER01;Initial Catalog=KutuphaneOtomasyonu;Integrated Security=True");
        DataSet daset = new DataSet();
     
        private void FrmSiralama_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from Uye order by okukitapsayisi desc", baglanti);
            adtr.Fill(daset, "Uye");
            dataGridView1.DataSource = daset.Tables["Uye"];
            baglanti.Close();
            LblEnCokKitapOkuyan.Text = "";
            LblEnAzKOkuyan.Text = "";
            LblEnCokKitapOkuyan.Text = daset.Tables["Uye"].Rows[0]["adsoyad"].ToString() + "=";
            LblEnCokKitapOkuyan.Text += daset.Tables["Uye"].Rows[0]["okukitapsayisi"].ToString();
            LblEnAzKOkuyan.Text = daset.Tables["Uye"].Rows[dataGridView1.Rows.Count - 2]["adsoyad"].ToString() + "=";
            LblEnAzKOkuyan.Text+= daset.Tables["Uye"].Rows[dataGridView1.Rows.Count - 2]["okukitapsayisi"].ToString();

        }
    }
}
