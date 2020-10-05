using System;
using System.Windows.Input;

namespace KulikCSLevel3.Infrastructure.Commands.Base
{
    /// <summary>
    /// Общее описание команды для окна
    /// </summary>
    abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        bool ICommand.CanExecute(object parameter) => CanExecute(parameter);

        void ICommand.Execute(object parameter) => Execute(parameter);

        protected virtual bool CanExecute(object parameter) => true;

        protected abstract void Execute(object parameter);
    }
}
