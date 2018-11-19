﻿using PowershellGUI.Models;
using System.Windows.Input;

namespace PowershellGUI.ViewModels
    {
    class ViewModel
        {
        private DirectoryReader     _DirectoryReader;
        private FileReader          _FileReader;
        private PowershellParser    _PowershellParser;
        private ComparisonConverter _ComparisonConverter;

        private ICommand _clickCommand;
        private bool     _canExecute;

        public bool CanExecute
            {
            get
                {
                return _canExecute;
                }
            set
                {
                if(_canExecute == value)
                    {
                    return;
                    }
                _canExecute = value;
                }
            }

        /// <summary>
        /// Handles the click-functionality of the Run script button
        /// </summary>
        public ICommand ClickCommand
            {
            get
                {
                // "Coalescing operator"
                //return _clickCommand ?? (_clickCommand = new CommandHandler(() => ExecutePowershellScript(), CanExecute()));
                //return _clickCommand ?? (_clickCommand = new CommandHandler(() => ExecutePowershellScript(), DirectoryReader.IsScriptSelected));
                return _clickCommand;
                }
            set
                {
                _clickCommand = value;
                }
            }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="modulePath"></param>
        public ViewModel(string modulePath)
            {
            // Run script knappen er inaktiv til et script velges
            // Tror alt som mangler er å få DirectoryReader til å endre på _canExecute
            // Nederste textbox demostrerer dette - alltid false!
            _DirectoryReader = new DirectoryReader(modulePath);
            _FileReader = new FileReader();
            _PowershellParser = new PowershellParser();
            _ComparisonConverter = new ComparisonConverter();

            _canExecute = DirectoryReader.IsScriptSelected;
            ClickCommand = new CommandHandler(ExecutePowershellScript, _canExecute);
            }

        /// <summary>
        /// Gets the DirectoryReader instance
        /// </summary>
        public DirectoryReader DirectoryReader
            {
            get
                {
                return _DirectoryReader;
                }
            }

        /// <summary>
        /// Gets the FileReader instance
        /// </summary>
        public FileReader FileReader
            {
            get
                {
                return _FileReader;
                }
            }

        /// <summary>
        /// Gets the PowershellParser instance
        /// </summary>
        public PowershellParser PowershellParser
            {
            get
                {
                return _PowershellParser;
                }
            }

        /// <summary>
        /// Gets the ComparisonConverter instance
        /// </summary>
        public ComparisonConverter ComparisonConverter
            {
            get
                {
                return _ComparisonConverter;
                }
            }


        /// <summary>
        /// Executes a Powershell script
        /// Passes data between DirectoryReader, FileReader
        /// and PowershellParser.
        /// </summary>
        public void ExecutePowershellScript()
            {
            // disse to skal trigges når drop down valg velges..
           // FileReader.FileURI = DirectoryReader.SelectedPsScript;
           // FileReader.ReadFile();


           // PowershellParser.ExecuteScript();
            }

        }
    }
