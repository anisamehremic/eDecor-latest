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

namespace eDecor.WinUI.Pretplate
{
    public partial class frmPretplate : Form
    {
        private readonly APIService _pretplateSevice = new APIService("Pretplate");
        private readonly APIService _kategorijeServices = new APIService("Kategorije");
        public frmPretplate()
        {
            InitializeComponent();
        }

        private void dgvPretplate_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = int.Parse(dgvPretplate.SelectedRows[0].Cells[0].Value.ToString());
            frmPretplateDetalji frm = new frmPretplateDetalji(id);
            frm.ShowDialog();
        }

        private async void txtKlijent_TextChanged(object sender, EventArgs e)
        {
            await searchRequest();
        }

        private async Task searchRequest()
        {
            var list = await _pretplateSevice.Get<List<Model.Pretplate>>(new PretplateSearchRequest() { KorisnickoIme = txtKlijent.Text, KategorijaID = int.Parse(cbKategorija.SelectedValue.ToString()) });
            dgvPretplate.AutoGenerateColumns = false;
            dgvPretplate.DataSource = list;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            await searchRequest();
        }

        private async void frmPretplate_Load(object sender, EventArgs e)
        {
            await loadKategorije();
            var list = await _pretplateSevice.Get<List<Model.Pretplate>>(null);
            dgvPretplate.AutoGenerateColumns = false;
            dgvPretplate.DataSource = list;
        }

        private async Task loadKategorije()
        {
            var list = await _kategorijeServices.Get<List<Model.Kategorije>>(null);
            list.Insert(0, new Model.Kategorije() { KategorijaId = 0, Naziv = "Odaberite kategoriju" });
            cbKategorija.DisplayMember = "Naziv";
            cbKategorija.ValueMember = "KategorijaId";
            cbKategorija.DataSource = list;
        }
    }
}
