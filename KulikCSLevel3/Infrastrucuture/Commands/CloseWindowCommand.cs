using KulikCSLevel3.Infrastrucuture.Commands.Base;
using System.Linq;
using System.Windows;

namespace KulikCSLevel3.Infrastrucuture.Commands
{
    class CloseWindowCommand : Command

    {
        protected override void Execute(object parameter)
        {
            var window = parameter as Window;
            if (window is null)
                window = Application.Current.Windows
                    .Cast<Window>()
                    .FirstOrDefault(w => w.IsFocused);
            if (window is null)
                window = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(w => w.IsActive);
            window?.Close();
        }
    }
}
