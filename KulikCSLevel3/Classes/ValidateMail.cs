using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/// <summary>
/// Алексей Кулик kpblc2000@yandex.ru
/// C# Уровень 3 урок1.
/// </summary>
namespace KulikCSLevel3
{
    /// <summary>
    /// Проверка валидности e-mail адреса
    /// </summary>
    public static class ValidateMail
    {
        /// <summary>
        /// Проверяет валидность e-mail адреса по одному из самых простых праквил.
        /// </summary>
        /// <param name="MailToCheck">Строка проверяемого email адреса</param>
        /// <returns>true, если <paramref name="MailToCheck"/> возможен и корректен</returns>
        public static bool EMailCorrect(string MailToCheck)
        {
            Regex rx = new Regex(@"(.+)@(.+)(.)(.+)");
            return rx.Match(MailToCheck).Success;
        }
    }
}
