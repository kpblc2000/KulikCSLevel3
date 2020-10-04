using KulikCSLevel3.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace KulikCSLevel3.Infrastructure.Commands
{
    class ShowDialogCommand : Command
    {
        private ICommand _ShowDialogCommand;

        protected override void Execute(object parameter)
        {
            string msg = parameter as string ?? "Hi You";
            MessageBox.Show(msg, "Сообщение");
        }
    }
}
