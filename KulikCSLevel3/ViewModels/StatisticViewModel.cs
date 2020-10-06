using KulikCSLevel3.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace KulikCSLevel3.ViewModels
{
    class StatisticViewModel : ViewModel
    {
        private int _SendMessagesCount;
        public int SendMessagesCount
        {
            get => _SendMessagesCount;
            private set => Set(ref _SendMessagesCount, value);
        }

        public void MessageSended() => SendMessagesCount++;
    }
}
