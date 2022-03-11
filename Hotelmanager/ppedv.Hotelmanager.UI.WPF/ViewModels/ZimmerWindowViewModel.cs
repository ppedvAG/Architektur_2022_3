using ppedv.Hotelmanager.Logic;
using ppedv.Hotelmanager.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;

namespace ppedv.Hotelmanager.UI.WPF.ViewModels
{
    public class ZimmerWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnProperty(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public ObservableCollection<Zimmer> ZimmerList { get; set; }

        private Zimmer selectedZimmer;
        public Zimmer SelectedZimmer
        {
            get => selectedZimmer;
            set
            {
                selectedZimmer = value;
                OnProperty(nameof(SelectedZimmer));
                OnProperty(nameof(ZimmerInfo));
                OnProperty(""); //update all
            }
        }

        Core core = new Core(new Data.EfCore.EfUnitOfWork());

        public string ZimmerInfo { get => $"Anzahl: {DateTime.Now:T}"; }

        public ICommand NewCommand { get; set; }

        public ZimmerWindowViewModel()
        {
            ZimmerList = new ObservableCollection<Zimmer>(core.UnitOfWork.GetRepository<Zimmer>().Query().ToList());
            NewCommand = new NewCommand(() =>
            {
                var nz = new Zimmer();
                nz.Nummer = "NEU";
                ZimmerList.Add(nz); 
            });
        }

    }

    public class NewCommand : ICommand
    {
        private readonly Action action;

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            action.Invoke();
        }

        public NewCommand(Action action)
        {
            this.action = action;
        }
    }
}
