using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using KulikCSLevel3.Infrastructure.Commands.Base;

namespace KulikCSLevel3.Infrastructure.Commands
{
    class CloseWindowCommand : Command
    {
        protected override void Execute(object Parameter)
        {
            var win = Parameter as Window;
            if (win is null)
                win = Application.Current.Windows.Cast<Window>().FirstOrDefault(x => x.IsFocused);
            if (win is null)
                win = Application.Current.Windows.Cast<Window>().FirstOrDefault(x => x.IsActive);

            win?.Close();
        }
    }
}
