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

namespace eDecor.WinUI.Podkategorije
{
    public partial class frmPodkategorije : Form
    {
        private readonly APIService _podkategorijeService = new APIService("Podkategorije");
        private readonly APIService _kategorijeService = new APIService("Kategorije");
        public frmPodkategorije()
        {
            InitializeComponent();
        }

        private async void frmPodkategorije_Load(object sender, EventArgs e)
        {
            await lodaKategorije();
            var list = await _podkategorijeService.Get<List<Model.Podkategorije>>(null);
            dgvPodkategorije.AutoGenerateColumns = false;
            dgvPodkategorije.DataSource = list;
        }

        private async Task lodaKategorije()
        {
            var list = await _kategorijeService.Get<List<Model.Kategorije>>(null);
            list.Insert(0, new Model.Kategorije() { KategorijaId = 0, Naziv = "Odaberi kategoriju" });
            cbKategorije.DisplayMember = "Naziv";
            cbKategorije.ValueMember = "KategorijaId";
            cbKategorije.DataSource = list;
        }

        private void dgvPodkategorije_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = int.Parse(dgvPodkategorije.SelectedRows[0].Cells[0].Value.ToString());
            frmPodkategorijeDetalji frm = new frmPodkategorijeDetalji(id);
            frm.ShowDialog();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var list = await _podkategorijeService.Get<List<Model.Podkategorije>>(new PodkategorijeSearchRequest() { Naziv = txtNaziv.Text, KategorijaID = int.Parse(cbKategorije.SelectedValue.ToString())});
            dgvPodkategorije.AutoGenerateColumns = false;
            dgvPodkategorije.DataSource = list;
        }
    }
}
