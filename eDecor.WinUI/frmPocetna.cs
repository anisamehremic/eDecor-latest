using eDecor.WinUI.Artikli;
using eDecor.WinUI.Drzave;
using eDecor.WinUI.Gradovi;
using eDecor.WinUI.Izvjestaji;
using eDecor.WinUI.Kategorije;
using eDecor.WinUI.Klijenti;
using eDecor.WinUI.Korisnici;
using eDecor.WinUI.Notifikacije;
using eDecor.WinUI.Ocjene;
using eDecor.WinUI.Podkategorije;
using eDecor.WinUI.Popusti;
using eDecor.WinUI.Pretplate;
using eDecor.WinUI.Rezervacije;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDecor.WinUI
{
    public partial class frmPocetna : Form
    {
        private int childFormNumber = 0;

        public frmPocetna()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void korisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }
        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisnici frm = new frmKorisnici();
            frm.MdiParent = this;
            //frm.WindowState = FormWindowState.Maximized;
            frm.Show();
        }

        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKorisniciDetalji frm = new frmKorisniciDetalji(null);
            frm.Show();
        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
            //this.Close();
        }


        private void gradoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmGradovi frm = new frmGradovi(null);
            frm.MdiParent = this;
            frm.Show();
        }

        private void drzaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDrzave frm = new frmDrzave(null);
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem6_Click(object sender, EventArgs e)
        {
            frmPopusti frm = new frmPopusti();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviPopustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPopustiDetaji frm = new frmPopustiDetaji(null);
            //frm.MdiParent = this;
            frm.Show();
        }
        private void pretragaToolStripMenuItem7_Click(object sender, EventArgs e)
        {
            frmPretplate frm = new frmPretplate();
            frm.MdiParent = this;
            frm.Show();
        }
        
        private void novaPretplataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPretplateDetalji frm = new frmPretplateDetalji(null);
            frm.Show();
        }


        private void ocjeneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOcjene frm = new frmOcjene();
            frm.MdiParent = this;
            frm.Show();
        }

        private void kategorijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKategorije frm = new frmKategorije();
            frm.MdiParent = this;
            frm.Show();
        }

        private void pretragaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmKlijenti frm = new frmKlijenti();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviKlijentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKlijentiDetalji frm = new frmKlijentiDetalji(null);
            frm.Show();
        }

        private void pretragaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmArtikli frm = new frmArtikli();
            frm.MdiParent = this;
            frm.Show();
        }

        private void noviArtikalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArtikliDetalji frm = new frmArtikliDetalji(null);
            frm.Show();
        }

        private void pretragaToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            frmRezervacije frm = new frmRezervacije();
            frm.MdiParent = this;
            frm.Show();
        }

        private void novaRezervacijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRezervacijeDetalji frm = new frmRezervacijeDetalji(null);
            frm.Show();
        }

        private void pretragaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmPodkategorije frm = new frmPodkategorije();
            frm.MdiParent = this;
            frm.Show();
        }

        private void novaPodkategorijaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPodkategorijeDetalji frm = new frmPodkategorijeDetalji(null);
            frm.Show();
        }

        private void izvjestajiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIzvjestaji frm = new frmIzvjestaji();
            frm.MdiParent = this;
            frm.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmNotifikacije frm = new frmNotifikacije();
            frm.MdiParent = this;
            frm.Show();
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmNotifikacijeDetalji frm = new frmNotifikacijeDetalji(null);
            frm.Show();
        }
    }
}
