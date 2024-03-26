using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mind.Infrastructure.Utils
{
    public static class ConverterUtils
    {
        private static readonly Regex PasswordMatchRegex = new Regex(
            @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&.])[A-Za-z\d@$!%*#?&.]{6,30}$",
            RegexOptions.Compiled);

        public static bool IsPasswordValid(string password)
            => PasswordMatchRegex.IsMatch(password);
    }
}