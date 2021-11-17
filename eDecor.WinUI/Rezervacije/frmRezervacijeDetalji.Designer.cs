namespace eDecor.WinUI.Rezervacije
{
    partial class frmRezervacijeDetalji
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clbArtikli = new System.Windows.Forms.CheckedListBox();
            this.cmbDalje = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clbArtikli);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(589, 426);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Odaberi Artikle";
            // 
            // clbArtikli
            // 
            this.clbArtikli.FormattingEnabled = true;
            this.clbArtikli.Location = new System.Drawing.Point(6, 19);
            this.clbArtikli.Name = "clbArtikli";
            this.clbArtikli.Size = new System.Drawing.Size(577, 394);
            this.clbArtikli.TabIndex = 0;
            // 
            // cmbDalje
            // 
            this.cmbDalje.Location = new System.Drawing.Point(526, 444);
            this.cmbDalje.Name = "cmbDalje";
            this.cmbDalje.Size = new System.Drawing.Size(75, 23);
            this.cmbDalje.TabIndex = 1;
            this.cmbDalje.Text = "Dalje";
            this.cmbDalje.UseVisualStyleBackColor = true;
            this.cmbDalje.Click += new System.EventHandler(this.cmbDalje_Click);
            // 
            // frmRezervacijeDetalji
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(618, 474);
            this.Controls.Add(this.cmbDalje);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmRezervacijeDetalji";
            this.Text = "Rezervacije detalji";
            this.Load += new System.EventHandler(this.frmRezervacijeDetalji_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.CheckedListBox clbArtikli;
        private System.Windows.Forms.Button cmbDalje;
    }
}