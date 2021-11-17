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

namespace eDecor.WinUI.Notifikacije
{
    public partial class frmNotifikacije : Form
    {
        private readonly APIService _notifikacijeService = new APIService("Notifikacije");
        public frmNotifikacije()
        {
            InitializeComponent();
        }

        private async void frmNotifikacije_Load(object sender, EventArgs e)
        {
            var list = await _notifikacijeService.Get<List<Model.Notifikacije>>(null);
            dgvNotifikacije.AutoGenerateColumns = false;
            dgvNotifikacije.DataSource = list;
        }

        private async void txt_KeyUp(object sender, KeyEventArgs e)
        {
            var list = await _notifikacijeService.Get<List<Model.Notifikacije>>(new NotifikacijeSearchRequest() { Naziv = txtNaziv.Text, Klijent = txtKlijent.Text, Korisnik = txtKorisnik.Text });
            dgvNotifikacije.AutoGenerateColumns = false;
            dgvNotifikacije.DataSource = list;
        }

        private void dgvNotifikacije_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = int.Parse(dgvNotifikacije.SelectedRows[0].Cells[0].Value.ToString());
            frmNotifikacijeDetalji frm = new frmNotifikacijeDetalji(id);
            frm.ShowDialog();
        }
    }
}
