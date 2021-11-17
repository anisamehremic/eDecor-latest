using eDecor.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDecor.WinUI.Artikli
{
    public partial class frmArtikli : Form
    {
        private readonly APIService _artikliService = new APIService("Artikli");
        private readonly APIService _kategorijeService = new APIService("Kategorije");
        private readonly APIService _podkategorijeService = new APIService("Podkategorije");
        public frmArtikli()
        {
            InitializeComponent();
        }

        private async void frmArtikli_Load(object sender, EventArgs e)
        {
            await loadKategorije();
            await loadPodategorije();

            var list = await _artikliService.Get<List<Model.Artikli>>(null);
            dgvArtikli.AutoGenerateColumns = false;
            dgvArtikli.DataSource = list;
        }

        private async Task loadKategorije()
        {
            var list = await _kategorijeService.Get<List<Model.Kategorije>>(null);
            list.Insert(0, new Model.Kategorije() { KategorijaId = 0, Naziv = "Odaberi kategoriju" });

            cbKategorije.DisplayMember = "Naziv";
            cbKategorije.ValueMember = "KategorijaId";
            cbKategorije.DataSource = list;
        }

        private async Task loadPodategorije()
        {
            var list = await _podkategorijeService.Get<List<Model.Podkategorije>>(null);
            list.Insert(0, new Model.Podkategorije() { PodkategorijaId = 0, Naziv = "Odaberi podkategoriju" });

            cbPodkategorije.DisplayMember = "Naziv";
            cbPodkategorije.ValueMember = "PodkategorijaId";
            cbPodkategorije.DataSource = list;
        }

        private void dgvArtikli_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = int.Parse(dgvArtikli.SelectedRows[0].Cells[0].Value.ToString());
            frmArtikliDetalji frm = new frmArtikliDetalji(id);
            frm.ShowDialog();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var list = await _artikliService.Get<List<Model.Artikli>>(new ArtikliSearchRequest() 
            { 
                Naziv = txtNaziv.Text,
                KategorijaID = int.Parse(cbKategorije.SelectedValue.ToString()),
                PodkategorijaID = int.Parse(cbPodkategorije.SelectedValue.ToString())
            });
            dgvArtikli.AutoGenerateColumns = false;
            dgvArtikli.DataSource = list;
        }

        private async void cbKategorije_SelectedIndexChanged(object sender, EventArgs e)
        {
            int kategorijaId = int.Parse(cbKategorije.SelectedValue.ToString());
            if (kategorijaId != 0) {
                var list = await _podkategorijeService.Get<List<Model.Podkategorije>>(new PodkategorijeSearchRequest() { KategorijaID = kategorijaId });
                list.Insert(0, new Model.Podkategorije() { PodkategorijaId = 0, Naziv = "Odaberi podkategoriju"});
                
                cbPodkategorije.DisplayMember = "Naziv";
                cbPodkategorije.ValueMember = "PodkategorijaId";
                cbPodkategorije.DataSource = list;
                
                lblPodkategorije.Visible = true;
                cbPodkategorije.Visible = true;
            }
            else{
                cbPodkategorije.SelectedValue = 0;
                lblPodkategorije.Visible = false;
                cbPodkategorije.Visible = false;
            }
        }
    }
}
