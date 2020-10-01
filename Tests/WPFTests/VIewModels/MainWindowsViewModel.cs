using System;
using System.Timers;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using WPFTests.Infrastructure.Commands;
using WPFTests.VIewModels.Base;

namespace WPFTests.VIewModels
{
    class MainWindowsViewModel : ViewModel
    {
        private string _title = "test window";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
            /*
            set
            {
                if (_title == value) return;
                _title = value;
                // OnPropertyChanged(nameof(Title));
                OnPropertyChanged();
            }
            */
        }

        private bool _timerEnabled = true;
        public bool TimerEnabled
        {
            get => _timerEnabled;
            set
            {
                if (!Set(ref _timerEnabled, value)) return;
                _timer.Enabled = value;
            }
        }

        private readonly Timer _timer;

        public DateTime CurrentTime => DateTime.Now;

        public MainWindowsViewModel()
        {
            _timer = new Timer(100);
            _timer.Elapsed += OnTimerElapsed;
            _timer.AutoReset = true;
            _timer.Enabled = true;

        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            OnPropertyChanged(nameof(CurrentTime));
        }

        // ПОпытка работы с командами

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

    }
}
