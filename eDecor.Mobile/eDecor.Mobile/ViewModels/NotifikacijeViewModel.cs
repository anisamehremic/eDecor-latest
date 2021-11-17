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
    public class NotifikacijeViewModel : BaseViewModel
    {
        public readonly APIService _notifikacijeService = new APIService("Notifikacije");
        public readonly APIService _klijnetiService = new APIService("Klijenti");

        Model.Notifikacije _selectedNotifikacija = null;
        public Model.Notifikacije SelectedNotifikacija
        {
            get { return _selectedNotifikacija; }
            set
            {
                SetProperty(ref _selectedNotifikacija, value);
                if (value != null)
                {
                    PregledajNotifikacijuCommand.Execute(null);
                }
            }
        }
        public ObservableCollection<Model.Notifikacije> notifikacijeList { get; set; } = new ObservableCollection<Model.Notifikacije>();
        public ObservableCollection<Model.Notifikacije> pregledaneNotifikacijeList { get; set; } = new ObservableCollection<Model.Notifikacije>();

        //public ICommand InitComand { get; set; }
        public ICommand PregledajNotifikacijuCommand { get; set; }

        public NotifikacijeViewModel()
        {
            //InitComand = new Command(async () => { await Init(); });
            PregledajNotifikacijuCommand = new Command(async () => { await PregledajNotifikaciu(); });
        }

        public async Task Init()
        {
            IsBusy = true;
            try
            {
                notifikacijeList.Clear();
                pregledaneNotifikacijeList.Clear();
                var mojeNotifikacije = await _notifikacijeService.Get<List<Model.Notifikacije>>(new NotifikacijeSearchRequest() { Klijent = APIService.Username });
                foreach (var notifikacija in mojeNotifikacije)
                    if (notifikacija.Klijent.KorisnickoIme == APIService.Username && notifikacija.Status) {
                        notifikacijeList.Add(notifikacija);
                    }
                    else if (notifikacija.Klijent.KorisnickoIme == APIService.Username && notifikacija.Status == false) {
                        pregledaneNotifikacijeList.Add(notifikacija);
                    }
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

        private async Task PregledajNotifikaciu()
        {
            try
            {
                NotifikacijeUpsertRequest request = new NotifikacijeUpsertRequest()
                {
                    Naziv = SelectedNotifikacija.Naziv,
                    Sadrzaj = SelectedNotifikacija.Sadrzaj,
                    Slika = SelectedNotifikacija.Slika,
                    DatumSlanja = SelectedNotifikacija.DatumSlanja,
                    KlijentId = SelectedNotifikacija.KlijentId,
                    KorisnikId = SelectedNotifikacija.KorisnikId,
                    Status = !SelectedNotifikacija.Status
                };
                var entity = await _notifikacijeService.Update<Model.Pretplate>(SelectedNotifikacija.NotifikacijaId, request);
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
