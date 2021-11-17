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
    public class MojeRezervacijeViewModel : BaseViewModel
    {
        private readonly APIService _rezervacijeService = new APIService("Rezervacije");
        public ObservableCollection<Model.Rezervacije> rezervacijeList { get; set; } = new ObservableCollection<Model.Rezervacije>();
        public ICommand InitCommand { get; set; }
        public MojeRezervacijeViewModel()
        {
            InitCommand = new Command(async()=>await Init());
        }
        public async Task Init()
        {
            IsBusy = true;
            try
            {
                rezervacijeList.Clear();
                var list = await _rezervacijeService.Get<List<Model.Rezervacije>>(new RezervacijeSearchRequest() { Klijent = APIService.Username });
                foreach (var item in list)
                {
                    if (item.Klijent.KorisnickoIme == APIService.Username)
                    {
                        rezervacijeList.Add(item);
                    }
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
    }
}
