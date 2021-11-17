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
    public partial class frmPretplateDetalji : Form
    {
        private readonly APIService _pretplateServices = new APIService("Pretplate");
        private readonly APIService _klijentiServices = new APIService("Klijenti");
        private readonly APIService _kategorijeServices = new APIService("Kategorije");
        private int? _id = null;
        public frmPretplateDetalji(int? id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmPretplateDetalji_Load(object sender, EventArgs e)
        {
            await loadKategorije();
            await loadKlijenti();

            if (_id.HasValue) {
                var result = await _pretplateServices.GetById<Model.Pretplate>(_id.Value);
                cbKategorija.SelectedValue = result.KategorijaId;
                cbKlijent.SelectedValue = result.KlijentId;
                cbStatus.Checked = result.Status;
            }
        }

        private async Task loadKlijenti()
        {
            var list = await _klijentiServices.Get<List<Model.Klijenti>>(null);
            list.Insert(0, new Model.Klijenti() { KlijentId = 0, KorisnickoIme = "Odaberite klijenta"});
            cbKlijent.DisplayMember = "KorisnickoIme";
            cbKlijent.ValueMember = "KlijentID";
            cbKlijent.DataSource = list;
        }

        private async Task loadKategorije()
        {
            var list = await _kategorijeServices.Get<List<Model.Kategorije>>(null);
            list.Insert(0, new Model.Kategorije() { KategorijaId = 0, Naziv = "Odaberite kategoriju" });
            cbKategorija.DisplayMember = "Naziv";
            cbKategorija.ValueMember = "KategorijaId";
            cbKategorija.DataSource = list;
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren()) {
                var request = new PretplateUpsertRequest() {
                    Datum = DateTime.Now,
                    Status = cbStatus.Checked,
                    KategorijaId = int.Parse(cbKategorija.SelectedValue.ToString()),
                    KlijentId = int.Parse(cbKlijent.SelectedValue.ToString())
                };

                Model.Pretplate entity = null;
                if (_id.HasValue)
                    entity = await _pretplateServices.Update<Model.Pretplate>(_id.Value, request);
                
                else 
                    entity = await _pretplateServices.Insert<Model.Pretplate>(request);

                if (entity != null) 
                    MessageBox.Show("Uspješno izvršeno");

                this.Close();
            }
        }

        private void cb_Validating(object sender, CancelEventArgs e)
        {
            Validacija.Validator.ObaveznoPoljeCmb(sender as ComboBox, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }
    }
}
