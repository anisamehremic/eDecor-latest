using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDecor.WinUI.Popusti
{
    public partial class frmPopusti : Form
    {
        private readonly APIService _popustiServices = new APIService("Popusti");

        public frmPopusti()
        {
            InitializeComponent();
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)//napraviti statusstring
        {
            var list = await _popustiServices.Get<List<Model.Popusti>>(null);
            dgvPopusti.AutoGenerateColumns = false;
            dgvPopusti.DataSource = list.Where(x=>x.Kod.StartsWith(txtKod.Text)).ToList();
        }

        private async void frmPopusti_Load(object sender, EventArgs e)
        {
            var list = await _popustiServices.Get<List<Model.Popusti>>(null);
            dgvPopusti.AutoGenerateColumns = false;
            dgvPopusti.DataSource = list;
        }

        private void dgvPopusti_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var id = int.Parse(dgvPopusti.SelectedRows[0].Cells[0].Value.ToString());
            frmPopustiDetaji frm = new frmPopustiDetaji(id);
            frm.ShowDialog();
        }
    }
}
