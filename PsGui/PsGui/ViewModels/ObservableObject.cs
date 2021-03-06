﻿using System.ComponentModel;

namespace PsGui.ViewModels
{
    /// <summary>
    /// Implements INotifyPropertyChanged allowing
    /// child-classes to propagate events.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the event
        /// </summary>
        /// <param name="name">Name of the property which is changed</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}