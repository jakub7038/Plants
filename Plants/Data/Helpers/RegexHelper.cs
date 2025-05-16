using System.Globalization;
using System.Text.RegularExpressions;

namespace Plants.Helpers
{
    public static class RegexHelper
    {
        private static readonly Regex DecimalNumberRegex = new(@"^-?\d+(\.\d+)?$", RegexOptions.Compiled);

        public static bool IsValidTemperatureValue(string input)
        {
            return DecimalNumberRegex.IsMatch(input)
                && double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out var value)
                && value >= -50 && value <= 100;
        }

        public static bool IsValidHumidityValue(string input)
        {
            return DecimalNumberRegex.IsMatch(input)
                && double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out var value)
                && value >= 5 && value <= 100;
        }

        public static string CombineTemperature(string min, string max)
        {
            return $"[{min}, {max}]°C";
        }

        public static string CombineHumidity(string min, string max)
        {
            return $"[{min}, {max}]%";
        }
    }
}
