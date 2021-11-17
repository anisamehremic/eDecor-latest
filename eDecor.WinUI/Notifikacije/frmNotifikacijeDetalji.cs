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

namespace eDecor.WinUI.Notifikacije
{
    public partial class frmNotifikacijeDetalji : Form
    {
        private readonly APIService _notifikacijeService = new APIService("Notifikacije");
        private readonly APIService _klijentiService = new APIService("Klijenti");
        private readonly APIService _korisnciService = new APIService("Korisnici");
        private int? _id = null;
        private byte[] slikaTemp;

        public frmNotifikacijeDetalji(int? id)
        {
            InitializeComponent();
            _id = id;
        }

        private async void frmNotifikacijeDetalji_Load(object sender, EventArgs e)
        {
            await loadKlijenti();
            if (_id.HasValue) { 
                var result = await _notifikacijeService.GetById<Model.Notifikacije>(_id.Value);
                txtNaziv.Text = result.Naziv;
                rtbSadrzaj.Text = result.Sadrzaj;
                cbKlijent.SelectedValue = result.KlijentId??0;
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

        private async Task loadKlijenti()
        {
            var list = await _klijentiService.Get<List<Model.Klijenti>>(null);
            list.Insert(0, new Model.Klijenti() { KlijentId = 0, KorisnickoIme = "Odaberite klijenta (Opcijonalno)" });
            cbKlijent.ValueMember = "KlijentId";
            cbKlijent.DisplayMember = "KorisnickoIme";
            cbKlijent.DataSource = list;
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var list = await _korisnciService.Get<List<Model.Korisnici>>(new KorisniciSearchRequest() { KorisnickoIme = APIService.Username });
                var request = new NotifikacijeUpsertRequest()
                {
                    DatumSlanja = DateTime.Now,
                    Status = true,
                    Naziv = txtNaziv.Text,
                    Sadrzaj = rtbSadrzaj.Text,
                    KorisnikId = list.FirstOrDefault().KorisnikId
                };

                if (int.Parse(cbKlijent.SelectedValue.ToString()) == 0)
                    request.KlijentId = null;
                else
                    request.KlijentId = int.Parse(cbKlijent.SelectedValue.ToString());

                if (txtSlika.Text != string.Empty)//Slika
                {
                    var file = File.ReadAllBytes(txtSlika.Text);
                    request.Slika = file;
                }
                else
                {
                    request.Slika = slikaTemp;
                }

                Model.Notifikacije entity = null;
                if (_id.HasValue)
                {
                    entity = await _notifikacijeService.Update<Model.Notifikacije>(_id.Value, request);
                }
                else { 
                    entity = await _notifikacijeService.Insert<Model.Notifikacije>(request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                }
                this.Close();
            }
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

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            Validacija.Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }

        private void rtbSadrzaj_Validating(object sender, CancelEventArgs e)
        {
            Validacija.Validator.ObaveznoPoljeRtxt(sender as RichTextBox, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }
    }
}
