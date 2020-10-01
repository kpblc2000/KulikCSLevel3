using KulikCSLevel3.VIewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KulikCSLevel3.VIewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _title = "test window";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }
    }
}
