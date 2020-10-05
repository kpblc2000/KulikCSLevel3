using KulikCSLevel3.ViewModels.Base;

namespace KulikCSLevel3.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _title = "Кулик : Рассылка";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

    }
}
