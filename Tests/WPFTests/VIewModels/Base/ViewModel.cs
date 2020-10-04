using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace KulikCSLevel3.VIewModels.Base
{
    abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /*
        protected virtual void OnPropertyChanged (string PropName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropName));
        }
        */
        protected virtual void OnPropertyChanged([CallerMemberName] string PropName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged();
            return true;
        }
    }
}
