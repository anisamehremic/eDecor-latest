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

namespace eDecor.WinUI.Ocjene
{
    public partial class frmOcjene : Form
    {
        private readonly APIService _ocjeneService = new APIService("Ocjene");
        public frmOcjene()
        {
            InitializeComponent();
        }

        private void dgvOcjene_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private async void frmOcjene_Load(object sender, EventArgs e)
        {
            loadOcjene();

            var list = await _ocjeneService.Get<List<Model.Ocjene>>(null);
            dgvOcjene.AutoGenerateColumns = false;
            dgvOcjene.DataSource = list;
        }

        private void loadOcjene()
        {
            var list = new List<string>();
            for (int i = 1; i <= 5; i++) {
                list.Add(i.ToString());
            }
            list.Insert(0, "Odaberi ocjenu");
            cbOcjene.DataSource = list;
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var list = await _ocjeneService.Get<List<Model.Ocjene>>(new OcjeneSearchRequest() { Ocjena = cbOcjene.SelectedIndex, Artikal = txtArtikal.Text });//index zato sto smo poredali for petljom, nije id...
            dgvOcjene.AutoGenerateColumns = false;
            dgvOcjene.DataSource = list;
        }

    }
}
