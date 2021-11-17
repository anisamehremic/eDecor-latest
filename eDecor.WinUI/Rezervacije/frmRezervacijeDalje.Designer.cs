namespace eDecor.WinUI.Rezervacije
{
    partial class frmRezervacijeDalje
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
            this.components = new System.ComponentModel.Container();
            this.gbDetalji = new System.Windows.Forms.GroupBox();
            this.cbStatus = new System.Windows.Forms.CheckBox();
            this.cbPopust = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbGrad = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbNapomena = new System.Windows.Forms.RichTextBox();
            this.txtAdresa = new System.Windows.Forms.TextBox();
            this.cbKlijent = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSpremi = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbArtikli = new System.Windows.Forms.ComboBox();
            this.nubKolicina = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCijena = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbDetalji.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nubKolicina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // gbDetalji
            // 
            this.gbDetalji.Controls.Add(this.cbStatus);
            this.gbDetalji.Controls.Add(this.cbPopust);
            this.gbDetalji.Controls.Add(this.label3);
            this.gbDetalji.Controls.Add(this.cbGrad);
            this.gbDetalji.Controls.Add(this.label2);
            this.gbDetalji.Controls.Add(this.rtbNapomena);
            this.gbDetalji.Controls.Add(this.txtAdresa);
            this.gbDetalji.Controls.Add(this.cbKlijent);
            this.gbDetalji.Controls.Add(this.label5);
            this.gbDetalji.Controls.Add(this.label4);
            this.gbDetalji.Controls.Add(this.label1);
            this.gbDetalji.Location = new System.Drawing.Point(12, 108);
            this.gbDetalji.Name = "gbDetalji";
            this.gbDetalji.Size = new System.Drawing.Size(501, 215);
            this.gbDetalji.TabIndex = 1;
            this.gbDetalji.TabStop = false;
            this.gbDetalji.Text = "Detalji rezervacije";
            // 
            // cbStatus
            // 
            this.cbStatus.AutoSize = true;
            this.cbStatus.Checked = true;
            this.cbStatus.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStatus.Location = new System.Drawing.Point(413, 180);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(62, 17);
            this.cbStatus.TabIndex = 18;
            this.cbStatus.Text = "Aktivna";
            this.cbStatus.UseVisualStyleBackColor = true;
            // 
            // cbPopust
            // 
            this.cbPopust.FormattingEnabled = true;
            this.cbPopust.Location = new System.Drawing.Point(6, 90);
            this.cbPopust.Name = "cbPopust";
            this.cbPopust.Size = new System.Drawing.Size(204, 21);
            this.cbPopust.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Popust";
            // 
            // cbGrad
            // 
            this.cbGrad.FormattingEnabled = true;
            this.cbGrad.Location = new System.Drawing.Point(6, 135);
            this.cbGrad.Name = "cbGrad";
            this.cbGrad.Size = new System.Drawing.Size(204, 21);
            this.cbGrad.TabIndex = 15;
            this.cbGrad.Validating += new System.ComponentModel.CancelEventHandler(this.cbGrad_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Grad";
            // 
            // rtbNapomena
            // 
            this.rtbNapomena.Location = new System.Drawing.Point(271, 44);
            this.rtbNapomena.Name = "rtbNapomena";
            this.rtbNapomena.Size = new System.Drawing.Size(204, 67);
            this.rtbNapomena.TabIndex = 13;
            this.rtbNapomena.Text = "";
            // 
            // txtAdresa
            // 
            this.txtAdresa.Location = new System.Drawing.Point(6, 177);
            this.txtAdresa.Name = "txtAdresa";
            this.txtAdresa.Size = new System.Drawing.Size(204, 20);
            this.txtAdresa.TabIndex = 12;
            this.txtAdresa.Validating += new System.ComponentModel.CancelEventHandler(this.txtAdresa_Validating);
            // 
            // cbKlijent
            // 
            this.cbKlijent.FormattingEnabled = true;
            this.cbKlijent.Location = new System.Drawing.Point(6, 44);
            this.cbKlijent.Name = "cbKlijent";
            this.cbKlijent.Size = new System.Drawing.Size(204, 21);
            this.cbKlijent.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(268, 26);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "Napomena";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Klijent";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 159);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Adresa";
            // 
            // btnSpremi
            // 
            this.btnSpremi.Location = new System.Drawing.Point(438, 333);
            this.btnSpremi.Name = "btnSpremi";
            this.btnSpremi.Size = new System.Drawing.Size(75, 23);
            this.btnSpremi.TabIndex = 2;
            this.btnSpremi.Text = "Spremi";
            this.btnSpremi.UseVisualStyleBackColor = true;
            this.btnSpremi.Click += new System.EventHandler(this.btnSpremi_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 18);
            this.label6.TabIndex = 10;
            this.label6.Text = "Artikli:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(412, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 18);
            this.label8.TabIndex = 12;
            this.label8.Text = "Količina:";
            // 
            // cbArtikli
            // 
            this.cbArtikli.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbArtikli.FormattingEnabled = true;
            this.cbArtikli.Location = new System.Drawing.Point(18, 31);
            this.cbArtikli.Name = "cbArtikli";
            this.cbArtikli.Size = new System.Drawing.Size(289, 23);
            this.cbArtikli.TabIndex = 13;
            this.cbArtikli.SelectedIndexChanged += new System.EventHandler(this.cbArtikli_SelectedIndexChanged);
            // 
            // nubKolicina
            // 
            this.nubKolicina.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nubKolicina.Location = new System.Drawing.Point(415, 31);
            this.nubKolicina.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nubKolicina.Name = "nubKolicina";
            this.nubKolicina.Size = new System.Drawing.Size(72, 23);
            this.nubKolicina.TabIndex = 14;
            this.nubKolicina.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nubKolicina.ValueChanged += new System.EventHandler(this.nubKolicina_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 18);
            this.label7.TabIndex = 15;
            this.label7.Text = "Cijena:";
            // 
            // txtCijena
            // 
            this.txtCijena.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCijena.Location = new System.Drawing.Point(72, 68);
            this.txtCijena.Name = "txtCijena";
            this.txtCijena.ReadOnly = true;
            this.txtCijena.Size = new System.Drawing.Size(100, 21);
            this.txtCijena.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(179, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 18);
            this.label9.TabIndex = 17;
            this.label9.Text = "KM";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmRezervacijeDalje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 364);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtCijena);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nubKolicina);
            this.Controls.Add(this.cbArtikli);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSpremi);
            this.Controls.Add(this.gbDetalji);
            this.Name = "frmRezervacijeDalje";
            this.Text = "Rezervacija dalje";
            this.Load += new System.EventHandler(this.frmRezervacijeDalje_Load);
            this.gbDetalji.ResumeLayout(false);
            this.gbDetalji.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nubKolicina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox gbDetalji;
        private System.Windows.Forms.CheckBox cbStatus;
        private System.Windows.Forms.ComboBox cbPopust;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbGrad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbNapomena;
        private System.Windows.Forms.TextBox txtAdresa;
        private System.Windows.Forms.ComboBox cbKlijent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSpremi;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbArtikli;
        private System.Windows.Forms.NumericUpDown nubKolicina;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCijena;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}