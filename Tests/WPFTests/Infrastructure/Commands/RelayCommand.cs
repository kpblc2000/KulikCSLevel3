using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTests.Infrastructure.Commands.Base;

namespace WPFTests.Infrastructure.Commands
{
    class RelayCommand : Command
    {

        // Действие, которое должна выполнить команда
        private readonly Action<object> _exec;

        // Функция, которая определяет возможность выполнения команды
        private readonly Func<object, bool> _canExec;

        /// <summary>
        /// Создание объекта универсальной команды с возможностью передачи параметров
        /// </summary>
        /// <param name="Execute">Функция, которая определяет возможность выполнения команды</param>
        /// <param name="CanExecute">Действие, которое должна выполнить команда</param>
        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _exec = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _canExec = CanExecute;
        }

        protected override bool CanExecute(object Parameter)
        {
            return _canExec?.Invoke(Parameter) ?? true;
        }

        protected override void Execute(object Parameter)
        {
            _exec(Parameter);
        }
    }
}
