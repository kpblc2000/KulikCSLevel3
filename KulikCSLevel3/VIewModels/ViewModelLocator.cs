using Microsoft.Extensions.DependencyInjection;

namespace KulikCSLevel3.VIewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();

    }
}
