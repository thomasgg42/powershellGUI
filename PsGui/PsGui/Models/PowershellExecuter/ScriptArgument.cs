﻿namespace PsGui.Models.PowershellExecuter
{
    /// <summary>
    /// A base class for each of the argument types made by the 
    /// user input for the powershell script.
    /// Inheritance is used to be able to separate different types
    /// of script argument into different WPF Controls in the view
    /// by the use of CompositeCollection and multiple ObservableCollections.
    /// a friendly name. 
    /// </summary>
    public class ScriptArgument
    {
        private ArgumentChecker inputCheck;
        private string _inputKey;
        private string _inputDescription;
        private string _inputType;
        private string _inputValue;
        private bool _isEnabled;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="key"></param>
        /// <param name="description"></param>
        /// <param name="type"></param>
        public ScriptArgument(string key, string description, string type)
        {
            inputCheck = new ArgumentChecker();
            _inputKey = key;
            _inputDescription = description;
            _inputType = type;
            _isEnabled = true;
            ClearUserInput();
        }

        /// <summary>
        ///  Removes leading and trailing spaces from the input
        ///  and returns it.
        /// </summary>
        private string TrimInput(string input)
        {
            return input.Trim();
        }

        /// <summary>
        /// Checks input format based on the stored input type.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        protected bool IsInputOk(string input)
        {
            bool inputOk = false;
            switch (_inputType)
            {
                case "string": inputOk = inputCheck.IsString(input);    break;
                case "int": inputOk = inputCheck.IsInt(input);          break;
                case "bool": inputOk = inputCheck.IsBool(input);        break;
                case "username": inputOk = inputCheck.IsString(input);  break;
                case "password": inputOk = inputCheck.IsString(input);  break;
                case "multiline": inputOk = inputCheck.IsString(input); break;
                case "checkbox": inputOk = inputCheck.IsBool(input);    break;
                case "radiobutton": inputOk = inputCheck.IsBool(input); break;
                default: PsGuiException.WriteErrorToScreen("Script file header error: Unknown variable type '" + _inputType + "'"); break;
            }
            return inputOk;
        }

        /// <summary>
        /// Decodes a Base64 encoded string and returns
        /// the plain string.
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        protected string Base64Decode(string base64EncodedData)
        {
            byte[] base64EncodedBytes;
            try
            {
                base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            }
            catch (System.Exception e)
            {
                return "";
            }

            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Sets or gets the script argument's variable name.
        /// </summary>
        public string InputKey
        {
            get
            {
                return _inputKey;
            }
            set
            {
                _inputKey = value;
            }
        }

        /// <summary>
        /// Sets or gets the script argument's description.
        /// </summary>
        public string InputDescription
        {
            get
            {
                return _inputDescription;
            }
            set
            {
                _inputDescription = value;
            }
        }

        /// <summary>
        /// Sets or gets the script argument's type.
        /// </summary>
        public string InputType
        {
            get
            {
                return _inputType;
            }
            set
            {
                _inputType = value;
            }
        }

        /// <summary>
        /// Sets or gets the script argument's value.
        /// </summary>
        public string InputValue
        {
            get
            {
                return _inputValue;
            }
            set
            {
                if (IsInputOk(value))
                {
                    _inputValue = value;
                }
            }
        }

        /// <summary>
        /// Sets or gets the script arguments' lock status.
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
            }
        }

        /// <summary>
        /// Returns true if a script argument contains information.
        /// </summary>
        /// <returns></returns>
        public bool HasNoInput()
        {
            if (_inputValue.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Clears input from the user in the object.
        /// </summary>
        public void ClearUserInput()
        {
            _inputValue = "";
        }
    }
}
