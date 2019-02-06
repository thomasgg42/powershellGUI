﻿namespace PsGui.Models.PowershellExecuter
    {
    /// <summary>
    /// An exception class for powershell script execution.
    /// </summary>
    public class PsExecException : PsGuiException
        {
        public PsExecException(string temp1, string temp2) : base(temp1, temp2)
            {

            }
        public PsExecException(string temp1) : base(temp1)
            {

            }
        }
    }
