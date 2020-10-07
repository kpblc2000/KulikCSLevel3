using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace KulikCSLevel3.Infrastructure.ValidationRules
{
    public class RegExValidationRule : ValidationRule
    {

        private Regex _rx;

        public string Pattern
        {
            get => _rx?.ToString();
            set => _rx = string.IsNullOrEmpty(value) ? null : new Regex(value);
        }

        public bool AllowNull { get; set; }

        public string ErrorMessage { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value is null)
                return AllowNull ? ValidationResult.ValidResult : new ValidationResult(false, ErrorMessage ?? "Отсутствует ссылка на строку");
            if (_rx is null)
                return ValidationResult.ValidResult;
            if (!(value is string str))
                str = value.ToString();

            return _rx.IsMatch(str) ? ValidationResult.ValidResult : new ValidationResult(false, ErrorMessage ?? $"Строка не удовлетворяет маске {Pattern}");

            //return ValidationResult.ValidResult;
            //return ValidationResult(false, "Ошибка валидации");
        }
    }
}
