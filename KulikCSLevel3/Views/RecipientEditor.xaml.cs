using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KulikCSLevel3.Views
{
    /// <summary>
    /// Логика взаимодействия для RecipientEditor.xaml
    /// </summary>
    public partial class RecipientEditor : UserControl
    {
        public RecipientEditor() => InitializeComponent();

        private void OnDataValidationError(object? SourceObject, ValidationErrorEventArgs E)
        {
            Control ctrl = E.OriginalSource as Control;
            if (ctrl != null)
            {
                if (E.Action == ValidationErrorEventAction.Added)
                    ctrl.ToolTip = E.Error.ErrorContent.ToString();
                else
                    ctrl.ClearValue(ToolTipProperty);
            }
        }
    }
}
