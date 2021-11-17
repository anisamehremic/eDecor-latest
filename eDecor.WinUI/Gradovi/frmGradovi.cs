using eDecor.Model.Requests;
using eDecor.WinUI.Validacija;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDecor.WinUI.Gradovi
{
    public partial class frmGradovi : Form
    {
        private readonly APIService _gradoviService = new APIService("Gradovi");
        private readonly APIService _drzaveService = new APIService("Drzave");
        private int? _id = null;
        public frmGradovi(int? id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmGradovi_Load(object sender, EventArgs e)
        {
            await LoadDrzave();
            var list =  await _gradoviService.Get<List<Model.Gradovi>>(null);
            dgvGradovi.AutoGenerateColumns = false;
            dgvGradovi.DataSource = list;
        }

        private async Task LoadDrzave()
        {
            var list = await _drzaveService.Get<List<Model.Drzave>>(null);
            list.Insert(0, new Model.Drzave() {DrzavaId = 0, Naziv = "Odaberi državu" });
            cbDrzave.DisplayMember = "Naziv";
            cbDrzave.ValueMember = "DrzavaID";
            cbDrzave.DataSource = list;
        }

        private async void txtNaziv_KeyUp(object sender, KeyEventArgs e)
        {
            errorProvider.SetError(txtNaziv, null);
            var list = await _gradoviService.Get<List<Model.Gradovi>>(new GradoviSearchRequest() { DrzavaId = int.Parse(cbDrzave.SelectedValue.ToString())});
            dgvGradovi.AutoGenerateColumns = false;
            dgvGradovi.DataSource = list.Where(x=>x.Naziv.StartsWith(txtNaziv.Text)).ToList();
        }

        private async void btnDodaj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() && cbDrzava_Validating())
            {
                var request = new GradoviUpsertRequest()
                {
                    DrzavaId = int.Parse(cbDrzave.SelectedValue.ToString()),
                    Naziv = txtNaziv.Text
                };

                Model.Gradovi entity = null;

                if (_id.HasValue)
                    entity = await _gradoviService.Update<Model.Gradovi>(_id.Value, request);
                else
                    entity = await _gradoviService.Insert<Model.Gradovi>(request);

                if (entity != null)
                    MessageBox.Show("Uspješno izvršeno");

                await refreshGradovi();
            }
        }
        private bool cbDrzava_Validating()
        {
            if (cbDrzave.SelectedIndex == 0)
            {
                errorProvider.SetError(cbDrzave, Properties.Resources.ObaveznoPolje);
                return false;
            }
            else
            {
                errorProvider.SetError(cbDrzave, null);
            }
            return true;
        }
        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }
        private void dgvGradovi_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var result = dgvGradovi.SelectedRows[0].DataBoundItem as Model.Gradovi;
            txtNaziv.Text = result.Naziv;
            _id = result.GradId;
            btnDodaj.Text = "Uredi";
            cbDrzave.SelectedValue = result.DrzavaId;
        }
        private async void cbDrzave_SelectedIndexChanged(object sender, EventArgs e)
        {
            var DrzavaID = int.Parse(cbDrzave.SelectedValue.ToString());
            await LoadGradovi(DrzavaID);
        }
        private async Task LoadGradovi(int DrzavaID)
        {
            var list = await _gradoviService.Get<List<Model.Gradovi>>(new GradoviSearchRequest() { DrzavaId = DrzavaID});
            dgvGradovi.AutoGenerateColumns = false;
            dgvGradovi.DataSource = list.Where(x => x.Naziv.StartsWith(txtNaziv.Text)).ToList();
        }
        private async void pbRefresh_Click(object sender, EventArgs e)
        {
            await refreshGradovi();
        }
        private async Task refreshGradovi()
        {
            _id = null;
            btnDodaj.Text = "Dodaj";
            txtNaziv.Text = string.Empty;
            cbDrzave.SelectedValue = 0;
            errorProvider.SetError(cbDrzave, null);
            errorProvider.SetError(txtNaziv, null);
            var list =  await _gradoviService.Get<List<Model.Gradovi>>(null);
            dgvGradovi.AutoGenerateColumns = false;
            dgvGradovi.DataSource = list;
        }
    }
}
