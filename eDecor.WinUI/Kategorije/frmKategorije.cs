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

namespace eDecor.WinUI.Kategorije
{
    public partial class frmKategorije : Form
    {
        private readonly APIService _kategorijeService = new APIService("Kategorije");
        private int? _id = null;
        public frmKategorije()
        {
            InitializeComponent();
        }

        private async void frmKategorije_Load(object sender, EventArgs e)
        {
            var list = await _kategorijeService.Get<List<Model.Kategorije>>(null);
            dgvKategorije.AutoGenerateColumns = false;
            dgvKategorije.DataSource = list;
        }

        private async void txtNaziv_KeyUp(object sender, KeyEventArgs e)
        {
            var list = await _kategorijeService.Get<List<Model.Kategorije>>(null);
            dgvKategorije.AutoGenerateColumns = false;
            dgvKategorije.DataSource = list.Where(x=>x.Naziv.StartsWith(txtNaziv.Text)).ToList();
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var request = new KategorijeUpsertRequest() { Naziv = txtNaziv.Text, Opis = rtbOpis.Text };
                Model.Kategorije entity = null;
                if (_id.HasValue)
                    entity = await _kategorijeService.Update<Model.Kategorije>(_id.Value, request);
                else
                    entity = await _kategorijeService.Insert<Model.Kategorije>(request);

                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                }
                await refreshKategoriej();
            }
        }

        private async void pbRefresh_Click(object sender, EventArgs e)
        {
            await refreshKategoriej();
        }

        private async Task refreshKategoriej()
        {
            _id = null;
            txtNaziv.Text = string.Empty;
            rtbOpis.Text = string.Empty;
            var list = await _kategorijeService.Get<List<Model.Kategorije>>(null);
            dgvKategorije.AutoGenerateColumns = false;
            dgvKategorije.DataSource = list;
            btnDodaj.Text = "Dodaj";
            errorProvider.SetError(txtNaziv, null);
        }

        private void dgvKategorije_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var result = dgvKategorije.SelectedRows[0].DataBoundItem as Model.Kategorije;
            _id = result.KategorijaId;
            txtNaziv.Text = result.Naziv;
            rtbOpis.Text = result.Opis;
            btnDodaj.Text = "Uredi";
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            Validacija.Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }
    }
}
