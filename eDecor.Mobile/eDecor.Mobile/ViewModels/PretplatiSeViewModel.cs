using eDecor.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eDecor.Mobile.ViewModels
{
    public class PretplatiSeViewModel: BaseViewModel
    {
        public readonly APIService _kategorijeService = new APIService("Kategorije");
        public readonly APIService _pretplateService = new APIService("Pretplate");
        public readonly APIService _klijnetiService = new APIService("Klijenti");

        Model.Kategorije _selectedKategorija = null;
        public Model.Kategorije SelectedKategorija
        {
            get { return _selectedKategorija; }
            set
            {
                SetProperty(ref _selectedKategorija, value);
                if (value != null)
                {
                    PretplatiSeCommand.Execute(null);
                }
            }
        }
        public ObservableCollection<Model.Kategorije> kategorijeList { get; set; } = new ObservableCollection<Model.Kategorije>();

        public ICommand InitComand;
        public ICommand PretplatiSeCommand { get; set; }

        public PretplatiSeViewModel()
        {
            InitComand = new Command(async ()=> { await Init(); });
            PretplatiSeCommand = new Command(async ()=> { await PretplatiSe(); });
        }

        public async Task Init()
        {
            IsBusy = true;
            try
            {
                kategorijeList.Clear();
                var list = await _kategorijeService.Get<List<Model.Kategorije>>(null);
                var mojePretplateList = await _pretplateService.Get<List<Model.Pretplate>>(new PretplateSearchRequest() { KorisnickoIme = APIService.Username });
                bool nema;
                foreach (var item in list)
                {
                    nema = true;
                    foreach (var pretplata in mojePretplateList)
                        if (item.KategorijaId == pretplata.KategorijaId && pretplata.Klijent.KorisnickoIme == APIService.Username && pretplata.Status)
                            nema = false;
                    if (nema)
                        kategorijeList.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally {
                IsBusy = false;
            }
        }
        
        public async Task PretplatiSe()
        {
            try
            {
                var result = await _klijnetiService.Get<List<Model.Klijenti>>(new KlijentiSearchRequest() { KorisnickoIme = APIService.Username });
                if (result.Count != 0)
                {
                    PretplateUpsertRequest request = new PretplateUpsertRequest()
                    {
                        Datum = DateTime.Now,
                        KlijentId = result[0].KlijentId,
                        KategorijaId = SelectedKategorija.KategorijaId,
                        Status = true
                    };
                    var entity = await _pretplateService.Insert<Model.Pretplate>(request);
                    if (entity != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Obavjest", "Uspješno ste se pretplatili na " + SelectedKategorija.Naziv + "!", "Uredu");
                    }
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Prijavite se", "Uredu");
                    Application.Current.MainPage = new eDecor.Mobile.Views.PrijaviSePage();
                    return;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                await Init();
            }
        }
    }
}
