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
    public class MojePretplateViewModel : BaseViewModel
    {
        public readonly APIService _kategorijeService = new APIService("Kategorije");
        public readonly APIService _pretplateService = new APIService("Pretplate");
        public readonly APIService _klijnetiService = new APIService("Klijenti");

        Model.Pretplate _selectedPretplata = null;
        public Model.Pretplate SelectedPretplata
        {
            get { return _selectedPretplata; }
            set
            {
                SetProperty(ref _selectedPretplata, value);
                if (value != null)
                {
                    UkloniPretplatuCommand.Execute(null);
                }
            }
        }
        public ObservableCollection<Model.Pretplate> kategorijeList { get; set; } = new ObservableCollection<Model.Pretplate>();

        public ICommand InitComand;
        public ICommand UkloniPretplatuCommand { get; set; }

        public MojePretplateViewModel()
        {
            InitComand = new Command(async () => { await Init(); });
            UkloniPretplatuCommand = new Command(async () => { await UkloniPretplatu(); });
        }

        public async Task Init()
        {
            IsBusy = true;
            try
            {
                kategorijeList.Clear();
                var mojePretplateList = await _pretplateService.Get<List<Model.Pretplate>>(new PretplateSearchRequest() { KorisnickoIme = APIService.Username });
                foreach (var pretplata in mojePretplateList)
                    if (pretplata.Klijent.KorisnickoIme == APIService.Username && pretplata.Status)
                        kategorijeList.Add(pretplata);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task UkloniPretplatu()
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
                        KategorijaId = SelectedPretplata.KategorijaId,
                        Status = false
                    };
                    var entity = await _pretplateService.Update<Model.Pretplate>(SelectedPretplata.PretplataId, request);
                    if (entity != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Obavjest", "Uspješno ste otkazali pretplatu na " + SelectedPretplata.Kategorija.Naziv + "!", "Uredu");
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
