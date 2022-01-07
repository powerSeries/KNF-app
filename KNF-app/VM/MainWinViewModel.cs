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
        private bool _displayTabs;
        private string _displayTabsResult;

        private Utility utility;
        private ObservableCollection<string> _allScales;
        private ObservableCollection<string> _listOfAllKeyNotes;
        private ObservableCollection<string> _listOfAllNotes;

        private Instrument instrument;
        private Models.Key key;
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

        public bool DisplayTabs
        {
            get => _displayTabs;
            set
            {
                _displayTabs = value;
                ChangeToTab();
                OnPropertyChanged("DisplayTabs");
            }
        }

        public string DisplayTabsResult
        {
            get => _displayTabsResult;
            set
            {
                _displayTabsResult = value;
                OnPropertyChanged("DisplayTabsResult");
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

        public ObservableCollection<string> ListOfAllKeyNotes
        {
            get => _listOfAllKeyNotes;
            set
            {
                _listOfAllKeyNotes = value;
                OnPropertyChanged("ListOfAllKeyNotes");
            }
        }

        public ObservableCollection<string> ListOfAllNotes
        {
            get => _listOfAllNotes;
            set
            {
                _listOfAllNotes = value;
                OnPropertyChanged("ListOfAllNotes");
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

        public ICommand SetInstrumentKeyCommand
        {
            get { return new DelegateCommand(SetInstrumentKey); }
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

            DisplayTabsResult = "Note Mode";
        }


        private void SetInstrument()
        {
            List<string> temp = ListOfOpenStrings.Split(',').ToList();

            instrument = new Instrument(MaxFret, temp);

            ListOfAllNotes = new ObservableCollection<string>();

            for (int i = 0; i < instrument.ListOfAllNotes.Count; i++)
            {
                ListOfAllNotes.Add(StringBuilder(instrument.ListOfAllNotes[i].Notes.AllNotes));
            }

            OnPropertyChanged("ListOfAllNotes");
        }

        private void SetInstrumentKey()
        {
            instrument.CurrentKey = key;

            if(instrument.CurrentKey == null)
            {
                MessageBox.Show("Please select a valid Key");
                return;
            }
            else if(instrument == null)
            {
                MessageBox.Show("Please create a valid instrument.");
                return;
            }

            instrument.KeyNoteFinder();

            ListOfAllKeyNotes = new ObservableCollection<string>();
            UpdateListOfKeyNotes(instrument.ListOfAllNotes, DisplayTabs);
            OnPropertyChanged("ListOfAllKeyNotes");
        }

        private void ChangeToTab()
        {
            if(DisplayTabs)
            {
                DisplayTabsResult = "Tab Mode";
            }
            else
            {
                DisplayTabsResult = "Note Mode";
            }
        }

        private void UpdateListOfKeyNotes(List<OpenStrings> data, bool IsTab)
        {
            ChangeToTab();
            ListOfAllKeyNotes = new ObservableCollection<string>();
            OnPropertyChanged("ListOfAllKeyNotes");

            if(IsTab)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    ListOfAllKeyNotes.Add(StringBuilder(data[i].Notes.AllKeyNotes_Tab));
                }
                
                return;
            }
            else
            {
                for (int i = 0; i < instrument.ListOfAllNotes.Count; i++)
                {
                    ListOfAllKeyNotes.Add(StringBuilder(data[i].Notes.AllKeyNotes));
                }
                
                return;
            }
        }

        private void ChangeKey()
        {
            key = new Models.Key(SelectedKey);
                      
            string temp = "";
            foreach(var item in key.Scale)
            {
                temp += item + ", ";
            }

            ScaleResult = temp;
        }

        private string StringBuilder(List<string> data)
        {
            string temp = "";
            temp += "[";

            foreach(var item in data)
            {
                temp += item + ", ";
            }
            temp += "]";

            return temp;
        }
        #endregion
    }
}
