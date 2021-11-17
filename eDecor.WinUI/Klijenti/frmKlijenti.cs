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

namespace eDecor.WinUI.Klijenti
{
    public partial class frmKlijenti : Form
    {
        private readonly APIService _klijentiService = new APIService("Klijenti");

        public frmKlijenti()
        {
            InitializeComponent();
        }

        private async void frmKlijenti_Load(object sender, EventArgs e)
        {
            var list = await _klijentiService.Get<List<Model.Klijenti>>(null);
            dgvKlijenti.AutoGenerateColumns = false;
            dgvKlijenti.DataSource = list;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var list = await _klijentiService.Get<List<Model.Klijenti>>(new KlijentiSearchRequest()
            {
                Ime = txtIme.Text,
                Prezime = txtPrezime.Text,
                KorisnickoIme = txtKorisnickoIme.Text
            });
            dgvKlijenti.AutoGenerateColumns = false;
            dgvKlijenti.DataSource = list;
        }

        private void dgvKlijenti_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = int.Parse(dgvKlijenti.SelectedRows[0].Cells[0].Value.ToString());
            frmKlijentiDetalji frm = new frmKlijentiDetalji(id);
            frm.ShowDialog();
        }
    }
}
