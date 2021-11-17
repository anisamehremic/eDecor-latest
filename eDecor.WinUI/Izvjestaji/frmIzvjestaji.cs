using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDecor.WinUI.Izvjestaji
{
    public partial class frmIzvjestaji : Form
    {
        private readonly APIService _kategorijeService = new APIService("Kategorije");
        private readonly APIService _artikliService = new APIService("Artikli");
        public frmIzvjestaji()
        {
            InitializeComponent();
        }

        private async void frmIzvjestaji_Load(object sender, EventArgs e)
        {
            var list = await _kategorijeService.Get<List<Model.Kategorije>>(null);
            list.Insert(0, new Model.Kategorije() { KategorijaId = 0, Naziv = "Odaberi kategoiju" });
            cbKategorije.DisplayMember = "Naziv";
            cbKategorije.ValueMember = "KategorijaId";
            cbKategorije.DataSource = list;
            
            var list1 = await _artikliService.Get<List<Model.Artikli>>(null);
            list1.Insert(0, new Model.Artikli() { KategorijaId = 0, Naziv = "Odaberi artikal" });
            cmbArtikli.DisplayMember = "Naziv";
            cmbArtikli.ValueMember = "ArtikalId";
            cmbArtikli.DataSource = list1;
        }

        private void cbKategorije_Validating(object sender, CancelEventArgs e)
        {
            Validacija.Validator.ObaveznoPoljeCmb(sender as ComboBox, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            if (ValidateChildren()) {
                if (dtpDatumOd.Value.Date >= dtpDatumDo.Value.Date)
                {
                    MessageBox.Show("Datumi nisu ispravno uneseni!");
                    return;
                }
                if (dtpDatumDo.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show("Krajnji datum ne može biti veći od današnjeg!");
                    return;
                }

                var id = int.Parse(cbKategorije.SelectedValue.ToString());
                frmIzvjestajiDetalji frm = new frmIzvjestajiDetalji(id, dtpDatumOd.Value, dtpDatumDo.Value);
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbArtikli.SelectedValue!=null)
            {
                if (dtp2od.Value.Date >= dtp2do.Value.Date)
                {
                    MessageBox.Show("Datumi nisu ispravno uneseni!");
                    return;
                }
                if (dtp2do.Value.Date > DateTime.Now.Date)
                {
                    MessageBox.Show("Krajnji datum ne može biti veći od današnjeg!");
                    return;
                }

                var id = int.Parse(cmbArtikli.SelectedValue.ToString());
                frmIzvjestajiDetalji frm = new frmIzvjestajiDetalji(id, dtp2od.Value, dtp2do.Value, false);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Odaberite kategoriju");
            }
        }
    }
}
