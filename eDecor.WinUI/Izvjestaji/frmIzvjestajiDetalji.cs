using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eDecor.Model.Requests;
using Microsoft.Reporting.WinForms;

namespace eDecor.WinUI.Izvjestaji
{
    public partial class frmIzvjestajiDetalji : Form
    {
        private readonly APIService _kategorijeService = new APIService("Kategorije");
        private readonly APIService _rezercacijeService = new APIService("Rezervacije");
        private readonly APIService _artikliService = new APIService("Artikli");
        private int _id;
        
        private DateTime _od { get; set; }
        private DateTime _do { get; set; }

        private bool _kategorija { get; set; }
        public frmIzvjestajiDetalji(int id, DateTime Od, DateTime Do, bool kategorija=true)
        {
            InitializeComponent();
            _id = id;
            
            _od = Od;
            _do = Do;
            _kategorija = kategorija;
        }

        private async void frmIzvjestajiDetalji_Load(object sender, EventArgs e)
        {
            try
            {
                if (_kategorija)
                {
                    var result = await _kategorijeService.GetById<Model.Kategorije>(_id);
                    ReportParameterCollection rpc = new ReportParameterCollection();
                    rpc.Add(new ReportParameter("KategorijaNaziv", result.Naziv.ToLower()));
                    rpc.Add(new ReportParameter("Datum", DateTime.Now.ToString("dd.MM.yyyy")));

                    rpc.Add(new ReportParameter("DatumOd", _od.ToString("dd.MM.yyyy")));
                    rpc.Add(new ReportParameter("DatumDo", _do.ToString("dd.MM.yyyy")));

                    var rezervacijelist = (await _rezercacijeService.Get<List<Model.Rezervacije>>(null)).Where(x => x.DatumKreiranja.Date >= _od.Date && x.DatumKreiranja.Date <= _do.Date).ToList();
                    dsArtikli.tblArtikliDataTable tbl = new dsArtikli.tblArtikliDataTable();
                    int rb = 1;
                    double suma = 0;
                    foreach (var rezervacija in rezervacijelist)
                    {
                        var list = rezervacija.RezervacijeArtikli.Where(x => x.Artikal.KategorijaId == _id).ToList();
                        foreach (var item in list)
                        {
                            dsArtikli.tblArtikliRow row = tbl.NewtblArtikliRow();
                            row.Rb = rb.ToString();
                            rb++;
                            row.Naziv = item.Artikal.Naziv;
                            row.Kolicina = item.Kolicina.ToString() + " kom";
                            row.Cijena = item.Artikal.Cijena.ToString() + " KM";
                            row.Ukupno = item.Artikal.Cijena * item.Kolicina + " KM";
                            suma += (double)(item.Artikal.Cijena * item.Kolicina);
                            tbl.Rows.Add(row);
                        }
                    }

                    rpc.Add(new ReportParameter("Rezervacije", (rb - 1).ToString()));
                    rpc.Add(new ReportParameter("Suma", suma + " KM"));

                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "Artikli";
                    rds.Value = tbl;


                    reportViewer1.LocalReport.SetParameters(rpc);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    this.reportViewer1.RefreshReport();
                }
                else
                {
                    var result = await _artikliService.GetById<Model.Artikli>(_id);
                    ReportParameterCollection rpc = new ReportParameterCollection();
                    rpc.Add(new ReportParameter("KategorijaNaziv", result.Naziv.ToLower()));
                    rpc.Add(new ReportParameter("Datum", DateTime.Now.ToString("dd.MM.yyyy")));

                    rpc.Add(new ReportParameter("DatumOd", _od.ToString("dd.MM.yyyy")));
                    rpc.Add(new ReportParameter("DatumDo", _do.ToString("dd.MM.yyyy")));

                    var rezervacijelist = (await _rezercacijeService.Get<List<Model.Rezervacije>>(null)).Where(x => x.DatumKreiranja.Date >= _od.Date && x.DatumKreiranja.Date <= _do.Date).ToList();
                    dsArtikli.tblArtikliDataTable tbl = new dsArtikli.tblArtikliDataTable();
                    int rb = 1;
                    double suma = 0;
                    foreach (var rezervacija in rezervacijelist)
                    {
                        var list = rezervacija.RezervacijeArtikli.Where(x => x.Artikal.ArtikalId == _id).ToList();
                        foreach (var item in list)
                        {
                            dsArtikli.tblArtikliRow row = tbl.NewtblArtikliRow();
                            row.Rb = rb.ToString();
                            rb++;
                            row.Naziv = item.Artikal.Naziv;
                            row.Kolicina = item.Kolicina.ToString() + " kom";
                            row.Cijena = item.Artikal.Cijena.ToString() + " KM";
                            row.Ukupno = item.Artikal.Cijena * item.Kolicina + " KM";
                            suma += (double)(item.Artikal.Cijena * item.Kolicina);
                            tbl.Rows.Add(row);
                        }
                    }

                    rpc.Add(new ReportParameter("Rezervacije", (rb - 1).ToString()));
                    rpc.Add(new ReportParameter("Suma", suma + " KM"));

                    ReportDataSource rds = new ReportDataSource();
                    rds.Name = "Artikli";
                    rds.Value = tbl;


                    reportViewer1.LocalReport.SetParameters(rpc);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    this.reportViewer1.RefreshReport();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Dogodila se greška! Izvještaj nije moguće kreirati.");
            }
        }
    }
}
