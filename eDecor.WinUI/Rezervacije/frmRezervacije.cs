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

namespace eDecor.WinUI.Rezervacije
{
    public partial class frmRezervacije : Form
    {
        private readonly APIService _rezervacijeService = new APIService("Rezervacije");
        private readonly APIService _artikliService = new APIService("Artikli");
        public frmRezervacije()
        {
            InitializeComponent();
        }

        private async void frmRezervacije_Load(object sender, EventArgs e)
        {
            var list = await _rezervacijeService.Get<List<Model.Rezervacije>>(null);
            foreach (var x in list) {
                foreach (var y in x.RezervacijeArtikli) {
                    x.Artikli += y.Artikal + " ";
                }
            }

            dgvRezervacije.AutoGenerateColumns = false;
            dgvRezervacije.DataSource = list;
        }

        private void dgvPretplate_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = int.Parse(dgvRezervacije.SelectedRows[0].Cells[0].Value.ToString());
            frmRezervacijeDetalji frm = new frmRezervacijeDetalji(id);
            frm.ShowDialog();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var list = await _rezervacijeService.Get<List<Model.Rezervacije>>(new RezervacijeSearchRequest() { Grad = txtGrad.Text, Klijent = txtKlijent.Text});
            foreach (var x in list)
            {
                foreach (var y in x.RezervacijeArtikli)
                {
                    x.Artikli += y.Artikal + " ";
                }
            }

            dgvRezervacije.AutoGenerateColumns = false;
            dgvRezervacije.DataSource = list;
        }
    }
}
