﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsGui.Models.PowershellExecuter
    {
    public class PsGuiException : Exception
        {
        public PsGuiException(string temp)
            {
            System.Windows.MessageBox.Show(temp);
            }
        }
    }
