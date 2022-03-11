using Microsoft.Extensions.DependencyInjection;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using ppedv.Hotelmanager.Contracts;
using ppedv.Hotelmanager.Logic;
using ppedv.Hotelmanager.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ppedv.Hotelmanager.UI.WPF.ViewModels
{

    public class ZimmerWindowViewModel : ObservableObject
    {

        public ObservableCollection<Zimmer> ZimmerList { get; set; }
        //public ObservableCollection<ZimmerViewModeL> ZimmerList { get; set; } //todo

        private Zimmer selectedZimmer;
        public Zimmer SelectedZimmer
        {
            get => selectedZimmer;
            set
            {
                SetProperty(ref selectedZimmer, value);
                OnPropertyChanged(nameof(ZimmerInfo));
            }
        }

        //Core core = new Core(new Data.EfCore.EfUnitOfWork());
        Core core = null;
        private bool controlsEnabled = true;

        public string ZimmerInfo { get => $"Anzahl: {DateTime.Now:T}"; }

        public AsyncRelayCommand NewCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ZimmerWindowViewModel()
        {
            core = new Core(App.Current.Services.GetService<IUnitOfWork>());
            ZimmerList = new ObservableCollection<Zimmer>(core.UnitOfWork.GetRepository<Zimmer>().Query().ToList());
            NewCommand = new AsyncRelayCommand(CreateNewZimmer, () => ControlsEnabled);
            SaveCommand = new RelayCommand(() => core.UnitOfWork.SaveAll(), () => ControlsEnabled);
            DeleteCommand = new RelayCommand(() =>
            {
                Thread.Sleep(5000);

                if (SelectedZimmer != null)
                {

                    core.UnitOfWork.ZimmerRepository.Delete(SelectedZimmer);
                    ZimmerList.Remove(SelectedZimmer);
                }
            });

        }

        public bool ControlsEnabled
        {
            get => controlsEnabled; set
            {
                controlsEnabled = value;
                NewCommand.NotifyCanExecuteChanged();
            }
        }
        private async Task CreateNewZimmer()
        {
            ControlsEnabled = false;

            //Thread.Sleep(5000);
            await Task.Delay(5000);
            var nz = new Zimmer();
            nz.Nummer = "NEU";
            ZimmerList.Add(nz);
            core.UnitOfWork.ZimmerRepository.Add(nz);
            ControlsEnabled = true;

        }
    }
}
