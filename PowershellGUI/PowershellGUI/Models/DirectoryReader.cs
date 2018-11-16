﻿using System.Collections.ObjectModel;

namespace PowershellGUI.Models
    {

    enum RadioButtons
        {
        ActiveDirectory,
        Exchange,
        Skype
        }

    class DirectoryReader : ObservableObject
        {
        private string _modulePath;
        private ObservableCollection<string> directoryBrowser; // trenge kanskje ObservableCollection<string> 
        private RadioButtons _activeButton;

        /// <summary>
        /// Returns the selected Powershell script's filepath
        /// </summary>
        public string SelectedPsScript { get; private set; }

        /// <summary>
        /// Updates the directory browser to match the 
        /// selected category.
        /// </summary>
        private void UpdateDirectoryBrowser()
            {
            // @SIMEN
            // funksjonen har som mål å fylle directoryBrowser med powershellscriptene som kan velges

            // if/else dårlig mtp økning av antall kategorier i fremtiden
            // modulePath skal lede til topp-dir hvor AD/Exchange/Skype ligger
            directoryBrowser.Clear();

            /*
            if (_activeButton == RadioButtons.ActiveDirectory)
                {
                directoryBrowser.Add("ad valgt");
                }
            else if (_activeButton == RadioButtons.Exchange)
                {
                directoryBrowser.Add("exchange valgt");
                }
            else
                {
                directoryBrowser.Add("noe annet");
                }

            */
            OnPropertyChanged("DirectoryBrowser");
            }

        /// <summary>
        /// Constructor
        /// </summary>
        public DirectoryReader(string modulePath)
            {
            _modulePath       = modulePath;
            _activeButton     = RadioButtons.ActiveDirectory;
            directoryBrowser = new ObservableCollection<string>();
            //UpdateDirectoryBrowser();
            TmpUpdateDirectoryBrowser(); // for testing
            }

        /// <summary>
        /// Gets or sets the directoryPath to the directory to read
        /// </summary>
        public ObservableCollection<string> DirectoryBrowser
            {
            get
                {
                return directoryBrowser;
                }
            set
                {
                directoryBrowser = value;
                OnPropertyChanged("DirectoryBrowser");
                }
            }

        /// <summary>
        /// Gets or sets the current active radio button
        /// @see ComparisonConverter for Enum -> boolean transition
        /// </summary>
        public RadioButtons ActiveButton
            {
            get
                {
                return _activeButton;
                }
            set
                {
                _activeButton = value;
                OnPropertyChanged("ActiveButton");
                UpdateDirectoryBrowser();
                }
            }


        /// <summary>
        /// Used for testing to build other functions
        /// </summary>
        public void TmpUpdateDirectoryBrowser()
            {
            directoryBrowser.Clear();
            SelectedPsScript = _modulePath + "\\Active Directory\\psfile1.txt";
            DirectoryBrowser.Add(SelectedPsScript);
            OnPropertyChanged("DirectoryBrowser");
            }
        }
    }
