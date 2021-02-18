using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Otomasyonu
{
    public partial class FrmAnasayfa : Form
    {
        public FrmAnasayfa()
        {
            InitializeComponent();
        }


        private void BtnUyeEklemeIslemleri_Click(object sender, EventArgs e)
        {
            FrmUyeEkle fr = new FrmUyeEkle();
            fr.ShowDialog();

        }

        private void BtnUyeListelemeIslemleri_Click(object sender, EventArgs e)
        {
            FrmUyeListeleme fr = new FrmUyeListeleme();
            fr.ShowDialog();
        }

        private void BtnKitapEklemeIslemleri_Click(object sender, EventArgs e)
        {
            FrmKitapEkle fr = new FrmKitapEkle();
            fr.ShowDialog();
        }

        private void FrmAnasayfa_Load(object sender, EventArgs e)
        {

        }

        private void BtnKitapListelemeIslemleri_Click(object sender, EventArgs e)
        {
            FrmKitapListeleme fr = new FrmKitapListeleme();
            fr.ShowDialog();
        }

        private void BtnEmanetKitapVermeIslemleri_Click(object sender, EventArgs e)
        {
            FrmEmanetKitap fr = new FrmEmanetKitap();
            fr.ShowDialog();
        }

        private void BtnEmanetKitapListelemeİslemleri_Click(object sender, EventArgs e)
        {
            FrmEmanetKitapListeleme fr = new FrmEmanetKitapListeleme();
            fr.ShowDialog();
        }

        private void BtnKitapIadeIslemleri_Click(object sender, EventArgs e)
        {
            FrmEmanetKitapIade fr = new FrmEmanetKitapIade();
            fr.ShowDialog();
        }

        private void BtnSıralama_Click(object sender, EventArgs e)
        {
            FrmSiralama fr = new FrmSiralama();
            fr.ShowDialog();
        }

        private void BtnGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafik fr = new FrmGrafik();
            fr.ShowDialog();
        }
    }
}
