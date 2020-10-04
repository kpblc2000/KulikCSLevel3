using Microsoft.Extensions.DependencyInjection;

namespace KulikCSLevel3.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
