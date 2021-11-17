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
    public partial class frmRezervacijeDalje : Form
    {
        private readonly APIService _rezervacijeService = new APIService("Rezervacije");
        private readonly APIService _artikliService = new APIService("Artikli");
        private readonly APIService _gradoviService = new APIService("Gradovi");
        private readonly APIService _popustiService = new APIService("Popusti");
        private readonly APIService _klijentiService = new APIService("Klijenti");
        private readonly APIService _korisniciService = new APIService("Korisnici");
        private List<int> _listartikli = new List<int>();
        private List<int> _listkloicnia = new List<int>();
        private int? _id = null; 

        public frmRezervacijeDalje(List<int> listartikli, int? id)
        {
            InitializeComponent();
            _listartikli = listartikli;
            foreach (var item in _listartikli) {
                _listkloicnia.Add(1);
            }
            _id = id;
        }

        private async void frmRezervacijeDalje_Load(object sender, EventArgs e)
        {
            await loadGradovi();
            await loadPopusti();
            await loadKlijenti();

            if (_id.HasValue)
            {
                var rezervacija = await _rezervacijeService.GetById<Model.Rezervacije>(_id.Value);
                foreach (var artikal in _listartikli)
                {
                    foreach (var item in rezervacija.RezervacijeArtikli)
                    {
                        if (item.ArtikalId == artikal)
                        {
                            _listkloicnia[_listartikli.IndexOf(artikal)] = item.Kolicina;
                        }
                    }
                }
                cbGrad.SelectedValue = rezervacija.GradId;
                cbPopust.SelectedValue = rezervacija.PopustId??0;
                cbKlijent.SelectedValue = rezervacija.KlijentId??0;
                txtAdresa.Text = rezervacija.Adresa;
                rtbNapomena.Text = rezervacija.Napomena;
                cbStatus.Checked = rezervacija.Status;
            }

            List<Model.Artikli> artikli = new List<Model.Artikli>();
            double suma = 0;
            foreach (var item in _listartikli)
            {
                var result = await _artikliService.GetById<Model.Artikli>(item);
                artikli.Add(result);
                suma += double.Parse(result.Cijena.ToString()) * _listkloicnia[_listartikli.IndexOf(item)];
            }
            txtCijena.Text = suma.ToString();

            artikli.Insert(0, new Model.Artikli() { ArtikalId = 0, Naziv = "Odaberi artikal" });
            cbArtikli.ValueMember = "ArtikalId";
            cbArtikli.DisplayMember = "ToString()";
            cbArtikli.DataSource = artikli;
        }

        private async Task loadKlijenti()
        {
            var list = await _klijentiService.Get<List<Model.Klijenti>>(null);
            list.Insert(0, new Model.Klijenti() { KlijentId = 0, KorisnickoIme = "Odaberite klijenita" });

            cbKlijent.DisplayMember = "KorisnickoIme";
            cbKlijent.ValueMember = "KlijentId";
            cbKlijent.DataSource = list;
        }

        private async Task loadPopusti()
        {
            var list = await _popustiService.Get<List<Model.Popusti>>(null);
            list.Insert(0, new Model.Popusti() { PopustId = 0, Popust = 0 });

            cbPopust.DisplayMember = "ToString()";
            cbPopust.ValueMember = "PopustId";
            cbPopust.DataSource = list;
        }

        private async Task loadGradovi()
        {
            var list = await _gradoviService.Get<List<Model.Gradovi>>(null);
            list.Insert(0, new Model.Gradovi() { GradId = 0, Naziv = "Odaberite grad" });

            cbGrad.DisplayMember = "Naziv";
            cbGrad.ValueMember = "GradId";
            cbGrad.DataSource = list;
        }

        private int id = 0;
        private void cbArtikli_SelectedIndexChanged(object sender, EventArgs e)
        {
            id = int.Parse(cbArtikli.SelectedValue.ToString());
            if (id != 0)
            {
                nubKolicina.Value = _listkloicnia[_listartikli.IndexOf(id)];
            }
            else{
                nubKolicina.Value = 1;
            }
        }

        private async void nubKolicina_ValueChanged(object sender, EventArgs e)
        {
            if (id != 0) {
                var result = await _artikliService.GetById<Model.Artikli>(id);
                var suma = double.Parse(txtCijena.Text);
                if (_listkloicnia[_listartikli.IndexOf(id)] < int.Parse(nubKolicina.Value.ToString()))
                {
                    txtCijena.Text = (suma + double.Parse(result.Cijena.ToString())).ToString();
                }
                else if(_listkloicnia[_listartikli.IndexOf(id)] > int.Parse(nubKolicina.Value.ToString()))
                {
                    txtCijena.Text = (suma - double.Parse(result.Cijena.ToString())).ToString();
                }
                _listkloicnia[_listartikli.IndexOf(id)] = int.Parse(nubKolicina.Value.ToString());

            }
        }

        private async void btnSpremi_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var korisnik = await _korisniciService.Get<List<Model.Korisnici>>(new KorisniciSearchRequest() { KorisnickoIme = APIService.Username });
                var request = new RezervacijeUpsertRequest() { Adresa = txtAdresa.Text, DatumKreiranja = DateTime.Now, Napomena = rtbNapomena.Text, Status = cbStatus.Checked, KorisnikId = korisnik.FirstOrDefault().KorisnikId, GradId = int.Parse(cbGrad.SelectedValue.ToString()), Placeno = true, IznosAvansnogPlacanje = 0 };
                if (int.Parse(cbKlijent.SelectedValue.ToString()) != 0)
                {
                    request.KlijentId = int.Parse(cbKlijent.SelectedValue.ToString());
                }
                if (int.Parse(cbPopust.SelectedValue.ToString()) != 0)
                {
                    request.PopustId = int.Parse(cbPopust.SelectedValue.ToString());
                }

                request.Artikli = new List<Model.RezervacijeArtikli>();
                for (int i = 0; i < _listartikli.Count; i++)
                {
                    request.Artikli.Add(new Model.RezervacijeArtikli() { ArtikalId = _listartikli[i], Kolicina = _listkloicnia[i] });
                }


                Model.Rezervacije entity = null;
                if (_id.HasValue)
                {
                    entity = await _rezervacijeService.Update<Model.Rezervacije>(_id.Value, request);
                }
                else
                {
                    entity = await _rezervacijeService.Insert<Model.Rezervacije>(request);
                }

                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                }
                this.Close();
            }
        }

        private void cbGrad_Validating(object sender, CancelEventArgs e)
        {
            Validacija.Validator.ObaveznoPoljeCmb(sender as ComboBox, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }

        private void txtAdresa_Validating(object sender, CancelEventArgs e)
        {
            Validacija.Validator.ObaveznoPoljeTxt(sender as TextBox, e, errorProvider, Properties.Resources.ObaveznoPolje);
        }
    }
}
