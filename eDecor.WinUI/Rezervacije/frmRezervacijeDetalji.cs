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
    public partial class frmRezervacijeDetalji : Form
    {
        private readonly APIService _artikliService = new APIService("Artikli");
        private readonly APIService _rezervacijeService = new APIService("Rezervacije");
        private int? _id = null;
        public frmRezervacijeDetalji(int? id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmRezervacijeDetalji_Load(object sender, EventArgs e)
        {
            var list = await _artikliService.Get<List<Model.Artikli>>(null);
            clbArtikli.DataSource = list;

            if (_id.HasValue)
            {
                var rezervacija = await _rezervacijeService.GetById<Model.Rezervacije>(_id);
                
                foreach (var item in rezervacija.RezervacijeArtikli)
                {
                    for (int i = 0; i < clbArtikli.Items.Count; i++)
                    {
                        Model.Artikli trenutni = (Model.Artikli)clbArtikli.Items[i];
                        if (trenutni.ArtikalId == item.ArtikalId)
                        {
                            clbArtikli.SetItemCheckState(i, CheckState.Checked);
                        }
                    }
                }
            }
        }

        private void cmbDalje_Click(object sender, EventArgs e)
        {
            var listartikli = clbArtikli.CheckedItems.Cast<Model.Artikli>().Select(x =>x.ArtikalId).ToList();
            if (listartikli.Count > 0)
            {
                frmRezervacijeDalje frm = new frmRezervacijeDalje(listartikli, _id);
                frm.Show();
            }
            else { 
            MessageBox.Show("Odabarite željene artikle");
            }
        }
    }
}
