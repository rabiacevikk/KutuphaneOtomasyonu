
namespace Kütüphane_Otomasyonu
{
    partial class FrmEmanetKitapIade
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEmanetKitapIade));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnTeslimAl = new System.Windows.Forms.Button();
            this.BtnIptal = new System.Windows.Forms.Button();
            this.TxtBarkodNoArama = new System.Windows.Forms.TextBox();
            this.TxtTCArama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(650, 360);
            this.dataGridView1.TabIndex = 0;
            // 
            // BtnTeslimAl
            // 
            this.BtnTeslimAl.BackColor = System.Drawing.Color.White;
            this.BtnTeslimAl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnTeslimAl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnTeslimAl.Location = new System.Drawing.Point(356, 424);
            this.BtnTeslimAl.Name = "BtnTeslimAl";
            this.BtnTeslimAl.Size = new System.Drawing.Size(126, 42);
            this.BtnTeslimAl.TabIndex = 1;
            this.BtnTeslimAl.Text = "Teslim Al";
            this.BtnTeslimAl.UseVisualStyleBackColor = false;
            this.BtnTeslimAl.Click += new System.EventHandler(this.BtnTeslimAl_Click);
            // 
            // BtnIptal
            // 
            this.BtnIptal.BackColor = System.Drawing.Color.White;
            this.BtnIptal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnIptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BtnIptal.Location = new System.Drawing.Point(488, 424);
            this.BtnIptal.Name = "BtnIptal";
            this.BtnIptal.Size = new System.Drawing.Size(126, 42);
            this.BtnIptal.TabIndex = 1;
            this.BtnIptal.Text = "İptal";
            this.BtnIptal.UseVisualStyleBackColor = false;
            this.BtnIptal.Click += new System.EventHandler(this.BtnIptal_Click);
            // 
            // TxtBarkodNoArama
            // 
            this.TxtBarkodNoArama.BackColor = System.Drawing.Color.White;
            this.TxtBarkodNoArama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtBarkodNoArama.Location = new System.Drawing.Point(471, 12);
            this.TxtBarkodNoArama.Name = "TxtBarkodNoArama";
            this.TxtBarkodNoArama.Size = new System.Drawing.Size(161, 26);
            this.TxtBarkodNoArama.TabIndex = 2;
            this.TxtBarkodNoArama.TextChanged += new System.EventHandler(this.TxtBarkodNoArama_TextChanged);
            // 
            // TxtTCArama
            // 
            this.TxtTCArama.BackColor = System.Drawing.Color.White;
            this.TxtTCArama.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtTCArama.Location = new System.Drawing.Point(152, 15);
            this.TxtTCArama.Name = "TxtTCArama";
            this.TxtTCArama.Size = new System.Drawing.Size(156, 26);
            this.TxtTCArama.TabIndex = 3;
            this.TxtTCArama.TextChanged += new System.EventHandler(this.TxtTCArama_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(61, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "TC ye göre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(325, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "BarkodNo ya Göre";
            // 
            // FrmEmanetKitapIade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.ClientSize = new System.Drawing.Size(654, 478);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtTCArama);
            this.Controls.Add(this.TxtBarkodNoArama);
            this.Controls.Add(this.BtnIptal);
            this.Controls.Add(this.BtnTeslimAl);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEmanetKitapIade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kitap İade Sayfası";
            this.Load += new System.EventHandler(this.FrmEmanetKitapIade_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnTeslimAl;
        private System.Windows.Forms.Button BtnIptal;
        private System.Windows.Forms.TextBox TxtBarkodNoArama;
        private System.Windows.Forms.TextBox TxtTCArama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}