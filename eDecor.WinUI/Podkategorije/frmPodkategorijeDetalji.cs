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
    public partial class frmPodkategorijeDetalji : Form
    {
        private readonly APIService _podkategorijeService = new APIService("Podkategorije");
        private readonly APIService _kategorijeService = new APIService("Kategorije");
        private int? _id = null;
        public frmPodkategorijeDetalji(int? id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void PodkategorijaDetalji_Load(object sender, EventArgs e)
        {
            await loadKategorije();
            if (_id.HasValue) {
                var result = await _podkategorijeService.GetById<Model.Podkategorije>(_id.Value);
                    txtNaziv.Text = result.Naziv;
                    rtbOpis.Text = result.Opis;
                    cbKategorija.SelectedValue = result.KategorijaId;
            }
        }

        private async Task loadKategorije()
        {
            var list = await _kategorijeService.Get<List<Model.Kategorije>>(null);
            list.Insert(0, new Model.Kategorije() { KategorijaId = 0, Naziv = "Odaberi kategoriju" });
            cbKategorija.DisplayMember = "Naziv";
            cbKategorija.ValueMember = "KategorijaId";
            cbKategorija.DataSource = list;
        }

        private void cbKategorija_Validating(object sender, CancelEventArgs e)
        {
             Validacija.Validator.ObaveznoPoljeCmb(sender as ComboBox, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
             Validacija.Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var request = new PodkategorijeUpsertRequest() { Naziv = txtNaziv.Text, Opis = rtbOpis.Text, KategorijaId = int.Parse(cbKategorija.SelectedValue.ToString()) };
                Model.Podkategorije entity = null;
                if (_id.HasValue)
                    entity = await _podkategorijeService.Update<Model.Podkategorije>(_id.Value, request);
                else
                    entity = await _podkategorijeService.Insert<Model.Podkategorije>(request);

                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                }
                this.Close();
            }
        }
    }
}
