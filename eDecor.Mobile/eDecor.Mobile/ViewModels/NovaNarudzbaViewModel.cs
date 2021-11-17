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
    public class NovaNarudzbaViewModel : BaseViewModel
    {
        string _naslov = string.Empty;
        public string Naslov
        {
            get { return _naslov; }
            set { SetProperty(ref _naslov, value); }
        }

        Model.Kategorije _selectedKategorija = null;
        public Model.Kategorije SelectedKategorija
        {
            get { return _selectedKategorija; }
            set
            {
                SetProperty(ref _selectedKategorija, value);
                if (value != null)
                {
                    LoadPodkategorijeCommand.Execute(null);
                }
            }
        }
        Model.Podkategorije _selectedPodkategorija = null;
        public Model.Podkategorije SelectedPodkategorija
        {
            get { return _selectedPodkategorija; }
            set
            {
                SetProperty(ref _selectedPodkategorija, value);
            }
        }

        private readonly APIService _klijentiService = new APIService("Klijenti");
        private readonly APIService _preporukeService = new APIService("Preporuke");
        private readonly APIService _artikliService = new APIService("Artikli");
        private readonly APIService _kategorijeService = new APIService("Kategorije");
        private readonly APIService _podkategorijeService = new APIService("Podkategorije");

        public ObservableCollection<Model.Artikli> artikliList { get; set; } = new ObservableCollection<Model.Artikli>();
        public ObservableCollection<Model.Kategorije> kategorijeList { get; set; } = new ObservableCollection<Model.Kategorije>();
        public ObservableCollection<Model.Podkategorije> podkategorijeList { get; set; } = new ObservableCollection<Model.Podkategorije>();

        public ICommand LoadPodkategorijeCommand { get; set; }

        public NovaNarudzbaViewModel()
        {
            LoadPodkategorijeCommand = new Command(async () => await LoadPodategorije());
        }
        public async Task Init()
        {
            IsBusy = true;
            try
            {
                int kategorija, podkategorija;
                if (SelectedPodkategorija == null)
                    podkategorija = 0;
                else
                    podkategorija = SelectedPodkategorija.PodkategorijaId;
                if (SelectedKategorija == null)
                    kategorija = 0;
                else
                    kategorija = SelectedKategorija.KategorijaId;
                
                artikliList.Clear();
                if (kategorija == 0 && podkategorija == 0)
                {
                    var result = await _klijentiService.Get<List<Model.Klijenti>>(new KlijentiSearchRequest() { KorisnickoIme = APIService.Username });
                    Naslov = "PREPORUČUJEMO:";
                    var list = await _preporukeService.Get<List<Model.Artikli>>(new PreporukeSearchRequest() { KorisnickoIme = result[0].KorisnickoIme});//dohvatiti iz sistema preporuke
                    list.ForEach(x => artikliList.Add(x));
                }
                else
                {
                    if(kategorija != 0 && podkategorija != 0)
                        Naslov = $" {SelectedKategorija.Naziv.ToUpper()} {SelectedPodkategorija.Naziv.ToUpper()}";
                    else if (kategorija != 0)
                        Naslov = $" {SelectedKategorija.Naziv.ToUpper()}";
                    else if (podkategorija != 0)
                        Naslov = $" {SelectedPodkategorija.Naziv.ToUpper()}";
                    Naslov +=":";

                    var list = await _artikliService.Get<List<Model.Artikli>>(new ArtikliSearchRequest() { KategorijaID = kategorija, PodkategorijaID = podkategorija });
                    list.ForEach(x => artikliList.Add(x));
                }
                await LoadKategorije();
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

        public async Task LoadKategorije()
        {
            try
            {
                if (kategorijeList.Count == 0)
                {
                    var list = await _kategorijeService.Get<List<Model.Kategorije>>(null);
                    kategorijeList.Add(new Model.Kategorije() { KategorijaId = 0, Naziv = "Sve kategorije" });
                    foreach (var item in list)
                        kategorijeList.Add(item);
                    SelectedKategorija = kategorijeList[0];
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "Uredu");
            }
        }
        public async Task LoadPodategorije()
        {
            try
            {
                podkategorijeList.Clear();
                if (SelectedKategorija != null)
                {
                    var list = await _podkategorijeService.Get<List<Model.Podkategorije>>(new PodkategorijeSearchRequest() { KategorijaID = SelectedKategorija.KategorijaId });
                    podkategorijeList.Clear();
                    podkategorijeList.Add(new Model.Podkategorije() { PodkategorijaId = 0, Naziv = "Sve podkategorije" });
                    list.ForEach(x => podkategorijeList.Add(x));
                    SelectedPodkategorija = podkategorijeList[0];
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Greška", ex.Message, "Uredu");
            }
        }

    }
}
