using System;
using System.ComponentModel;

namespace FindRestOfItemsWindows.ClassHelper
{
    public class INotifyPropertyChangedTestClass : INotifyPropertyChanged
    {



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private string ageValue = String.Empty;
        public string AgeValue
        {
            get { return ageValue; }
            set
            {
                if (value != ageValue)
                {
                    ageValue = value;
                    OnPropertyChanged(nameof(AgeValue));
                }
            }
        }

    }
}
