using System;
using System.Text;

namespace Server.Services
{
    internal class CurrencyConverterService : ICurrencyConverterService
    {
        public string ConvertValue(string input)
        {
            int separatorPosition = input.IndexOf(',');
            string result;
            if (separatorPosition >= 0)
            {
                result = ConvertIntegerPart(input.Substring(0, separatorPosition));
                result += ConvertFractionPart(input.Substring(separatorPosition + 1));
            }
            else
            {
                result = ConvertIntegerPart(input);
            }
            return result;
        }

        private static string[] GROUPS = new string[]
        {
            "",
            "thousand ",
            "million ",
            "bilion "
        };

        private static string ConvertFractionPart(string input)
        {
            if (string.IsNullOrEmpty(input) || input == "0" || input == "00")
            {
                return "";
            }
            var value = int.Parse(input);
            value = input.Length < 2 ? value * 10 : value;
            return $" and {ConvertHundreds(value)}cent{(value > 1 ? "s" : "")}";
        }

        private static string ConvertIntegerPart(string input)
        {
            if (input == "0")
            {
                return "zero dollars";
            }

            string result = "";
            int groupId = 0;
            for (int i = input.Length; i > 0; i -= 3, groupId++)
            {
                if (groupId > GROUPS.Length)
                {
                    throw new ServiceException("Too bit value");
                }

                int start = Math.Max(0, i - 3);
                int value = int.Parse(input.Substring(start, i - start));
                string subResult = ConvertHundreds(value);
                if (!string.IsNullOrEmpty(subResult))
                {
                    result = $"{subResult}{GROUPS[groupId]}{result}";
                }
            }
            return result + (result == "one " ? "dollar" : "dollars");
        }

        private static string[] INTEGERS = new string[]
        {
            "",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eigth",
            "nine",
            "ten",
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fiveteen",
            "sixteen",
            "eigthteen",
            "ninteen",
        };

        private static string[] TENS = new string[]
        {
            "",
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety",
        };

        private static string ConvertHundreds(int value)
        {
            StringBuilder sb = new StringBuilder();

            if (value >= 100)
            {
                sb.Append(INTEGERS[value / 100]).Append(" hundred ");
                value = value % 100;
            }

            bool appendDash = false;
            if (value > 19)
            {
                appendDash = true;
                sb.Append(TENS[value / 10 - 1]);
                value = value - value / 10 * 10;
            }

            if (value > 0)
            {
                if (sb.Length > 0)
                {
                    sb.Append(appendDash && value < 10 ? '-' : ' ');
                }
                sb.Append(INTEGERS[value]).Append(" ");
            }

            return sb.ToString();
        }
    }
}
