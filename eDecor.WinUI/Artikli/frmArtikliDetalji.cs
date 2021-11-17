using eDecor.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eDecor.WinUI.Artikli
{
    public partial class frmArtikliDetalji : Form
    {
        private readonly APIService _artikliService = new APIService("Artikli");
        private readonly APIService _kategorijeService = new APIService("Kategorije");
        private readonly APIService _podkategorijeService = new APIService("Podkategorije");
        private int? _id = null;
        private int? podkategorijaId = null;
        private byte[] slikaTemp;

        public frmArtikliDetalji(int? id)
        {
            InitializeComponent();
            _id = id;
        }
        private async void frmArtikliDetalji_Load(object sender, EventArgs e)
        {
            await loadPodategorije();
            await loadKategorije();

            if (_id.HasValue)
            {
                var result = await _artikliService.GetById<Model.Artikli>(_id.Value);
                txtNaziv.Text = result.Naziv;
                rtbOpis.Text = result.Opis;
                cbKategorija.SelectedValue = result.KategorijaId;
                podkategorijaId = result.PodkategorijaId;
                numCijena.Value = result.Cijena;
                cbStatus.Checked = result.Status;
                slikaTemp = result.Slika;

                if (result.Slika.Length != 0)
                {
                    pbSlika.Image = Image.FromStream(new MemoryStream(result.Slika));
                }
            }
        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
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

        private async Task loadPodategorije()
        {
            var list = await _podkategorijeService.Get<List<Model.Podkategorije>>(null);
            list.Insert(0, new Model.Podkategorije() { PodkategorijaId = 0, Naziv = "Odaberi podkategoriju" });

            cbPodkategorija.DisplayMember = "Naziv";
            cbPodkategorija.ValueMember = "PodkategorijaId";
            cbPodkategorija.DataSource = list;
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog.FileName;
                txtSlika.Text = fileName;
                Image image = Image.FromFile(fileName);
                pbSlika.Image = image;
            }
        }
       
        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren()) {

                var request = new ArtikliUpsertRequest()
                {
                   Naziv = txtNaziv.Text,
                   Opis = rtbOpis.Text,
                   Cijena = numCijena.Value,
                   Status = cbStatus.Checked,
                   KategorijaId = int.Parse(cbKategorija.SelectedValue.ToString()),
                   PodkategorijaId = int.Parse(cbPodkategorija.SelectedValue.ToString())
                };

                if (txtSlika.Text != string.Empty)//Slika
                {
                    var file = File.ReadAllBytes(txtSlika.Text);
                    request.Slika = file;
                }
                else
                {
                    request.Slika = slikaTemp;
                }

                Model.Artikli entity = null;
                if (_id.HasValue)
                {
                    entity = await _artikliService.Update<Model.Artikli>(_id.Value, request);
                }
                else
                {
                    entity = await _artikliService.Insert<Model.Artikli>(request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                }
                this.Close();
            }
        }
        
        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            Validacija.Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }

        private void cb_Validating(object sender, CancelEventArgs e)
        {
            Validacija.Validator.ObaveznoPoljeCmb(sender as ComboBox, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }

        private void numCijena_Validating(object sender, CancelEventArgs e)
        {
            Validacija.Validator.ObaveznoPoljeNumeric(sender as NumericUpDown, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }

        private async void cbKategorija_SelectedIndexChanged(object sender, EventArgs e)
        {
            int kategorijaId = int.Parse(cbKategorija.SelectedValue.ToString());
            if (kategorijaId != 0)
            {
                var list = await _podkategorijeService.Get<List<Model.Podkategorije>>(new PodkategorijeSearchRequest() { KategorijaID = kategorijaId });
                list.Insert(0, new Model.Podkategorije() { PodkategorijaId = 0, Naziv = "Odaberi podkategoriju" });

                cbPodkategorija.DisplayMember = "Naziv";
                cbPodkategorija.ValueMember = "PodkategorijaId";
                cbPodkategorija.DataSource = list;

                lblPodkategorija.Visible = true;
                cbPodkategorija.Visible = true;

                if (podkategorijaId.HasValue) {
                    cbPodkategorija.SelectedValue = podkategorijaId.Value;
                }
            }
            else
            {
                cbPodkategorija.SelectedValue = 0;
                lblPodkategorija.Visible = false;
                cbPodkategorija.Visible = false;
            }
        }
    }
}
