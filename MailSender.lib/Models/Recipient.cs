using System;
using System.ComponentModel;
using WpfMailSender.Models.Base;

namespace KulikCSLevel3.Models
{
    public class Recipient : Person, IDataErrorInfo
    {
        public string Description { get; set; }

        string IDataErrorInfo.this[string PropertyName]
        {
            get
            {
                switch (PropertyName)
                {
                    case nameof(Name):
                        var name = Name;

                        if (name=="" || name is null)
                            return "Имя не может быть пустой строкой";
                        if (name == "QWE")
                            return $"Имя не может быть {name}";
                        if (name.Length > 25)
                            return "Имя слишком длинное, таких не бывает";
                        return null;

                    case nameof(Address):
                        return null;

                    default:
                        return null;

                }
            }
        }

        string IDataErrorInfo.Error { get; } = null;
    }
}
