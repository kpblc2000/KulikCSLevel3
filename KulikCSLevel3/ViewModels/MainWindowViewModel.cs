using KulikCSLevel3.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KulikCSLevel3.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Кулик : Рассылка почты";
        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }
    }
}
