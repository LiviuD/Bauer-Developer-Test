using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bauer.Developer.Test.RestaurantGuide.Domain.ValidationAttributes
{
    public class AustralianPhoneNumber : DataTypeAttribute
    {
        private static Regex _regex = CreateRegEx();
        public AustralianPhoneNumber() : base(DataType.PhoneNumber) {
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string valueAsString = value as string;
            valueAsString = valueAsString.Replace(" ", String.Empty);
            return valueAsString != null 
                && valueAsString.Length > 8 
                && _regex.Match(valueAsString).Length > 0
                && valueAsString.Count(x => x=='(') == valueAsString.Count(x => x == ')')/*the oopen paranthesis matches the closing ones, the rest is taken care by the regex*/;
        }

        private static Regex CreateRegEx()
        {
            const string pattern = @"^\({0,1}((0|\+61|61){0,1}(2|4|3|7|8)){1}\){0,1}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{2}(\ |-){0,1}[0-9]{1}(\ |-){0,1}[0-9]{3,}$";
            const RegexOptions options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

            // Set explicit regex match timeout, sufficient enough for phone parsing
            // Unless the global REGEX_DEFAULT_MATCH_TIMEOUT is already set
            TimeSpan matchTimeout = TimeSpan.FromSeconds(2);

            try
            {
                if (AppDomain.CurrentDomain.GetData("REGEX_DEFAULT_MATCH_TIMEOUT") == null)
                {
                    return new Regex(pattern, options, matchTimeout);
                }
            }
            catch
            {
                // Fallback on error
            }

            // Legacy fallback (without explicit match timeout)
            return new Regex(pattern, options);
        }
    }
}
