using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GoldenButton.Models
{
    public class BaseModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Property Changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// On property changed definition
        /// </summary>
        /// <param name="propertyName">The property to be changed</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /// <summary>
        /// Generic on property changed event
        /// </summary>
        /// <typeparam name="T">The type of property that is being chabnged</typeparam>
        /// <param name="backingField">The private backing member that is being monitored</param>
        /// <param name="value">The value to change the private backing member to</param>
        /// <param name="propertyName">The property name used to register the property event, often blank</param>
        /// <returns></returns>
        protected virtual bool OnPropertyChanged<T>(ref T backingField, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingField, value))
                return false;

            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
