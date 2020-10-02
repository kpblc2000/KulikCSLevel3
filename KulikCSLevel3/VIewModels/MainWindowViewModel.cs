using KulikCSLevel3.Infrastructure.Commands;
using KulikCSLevel3.VIewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        // Попытка работы с командами
        /*
        private ICommand _ShowDlgCmd;

        public ICommand ShowDialogCommand
        {
            get
            {
                if (_ShowDlgCmd is null)
                {
                    _ShowDlgCmd = new RelayCommand(OnShowDialogCommandExecute);
                }
                return _ShowDlgCmd;
            }
        }

        private void OnShowDialogCommandExecute(object obj)
        {
            MessageBox.Show("Hi");
        }
        */

        /*
        private ICommand _TabScheduleActivate;

        public ICommand TabSceduleActivateCommand
        {
            get
            {
                if (_TabScheduleActivate is null)
                {
                    _TabScheduleActivate = new RelayCommand(OnTabSceduleActivateCommandExecute);
                }
                return _TabScheduleActivate;
            }
        }

        private void OnTabSceduleActivateCommandExecute(object o)
        {
            
        }
        */

    }
}
