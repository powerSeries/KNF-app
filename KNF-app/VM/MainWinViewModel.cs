using KNF_app.Models;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KNF_app.VM 
{
    public class MainWinViewModel : INotifyPropertyChanged
    {
        #region Private variables
        private int _maxFret;
        private string _listOfOpenStrings;
        #endregion

        #region Public property
        public int MaxFret
        {
            get => _maxFret;
            set
            {
                _maxFret = value;
                OnPropertyChanged("MaxFret");
            }
        }

        public string ListOfOpenStrings
        {
            get => _listOfOpenStrings;
            set 
            {
                _listOfOpenStrings = value;
                OnPropertyChanged("ListOfOpenStrings");
            }
        }
        #endregion

        #region Commands
        public ICommand SetInstrumentCommand
        {
            get { return new DelegateCommand(SetInstrument); }
        }
        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null)
                handler(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        public MainWinViewModel()
        { 

        }

        private void SetInstrument()
        {
            List<string> temp = ListOfOpenStrings.Split(',').ToList();

            Instrument instru = new Instrument(MaxFret, temp);
        }
    }
}
