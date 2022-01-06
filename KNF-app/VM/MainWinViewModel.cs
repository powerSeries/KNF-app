using KNF_app.Models;
using KNF_app.Utils;
using Microsoft.VisualStudio.PlatformUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private int _selectKeyIndex;
        private string _listOfOpenStrings;
        private string _selectedKey;
        private string _scaleResult;
        
        private ObservableCollection<string> _allScales;
        private Utility utility;
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

        public ObservableCollection<string> AllScales
        {
            get => _allScales;
            set
            {
                _allScales = value;
                OnPropertyChanged("AllScales");
            }
        }

        public string SelectedKey
        {
            get => _selectedKey;
            set
            {
                _selectedKey = value;
                ChangeKey();
                OnPropertyChanged("SelectedKey");
            }

        }

        public int SelectKeyIndex
        {
            get => _selectKeyIndex;
            set
            {
                _selectKeyIndex = value;
                OnPropertyChanged("SelectKeyIndex");
            }
        }

        public string ScaleResult
        {
            get => _scaleResult;
            set
            {
                _scaleResult = value;
                OnPropertyChanged("ScaleResult");
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
            Initialize();
        }

        #region Public methods

        #endregion

        #region Private methods
        private void Initialize()
        {
            utility = new Utility();

            AllScales = new ObservableCollection<string>(utility.ALL_MAJOR_SCALES);
        }


        private void SetInstrument()
        {
            List<string> temp = ListOfOpenStrings.Split(',').ToList();

            Instrument instru = new Instrument(MaxFret, temp);
        }

        private void ChangeKey()
        {
            Models.Key key = new Models.Key(SelectedKey);
            string temp = "";
            foreach(var item in key.Scale)
            {
                temp += item + ", ";
            }

            ScaleResult = temp;
        }
        #endregion
    }
}
