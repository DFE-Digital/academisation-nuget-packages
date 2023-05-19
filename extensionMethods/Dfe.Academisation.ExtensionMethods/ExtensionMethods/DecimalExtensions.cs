using System.Globalization;

namespace Dfe.Academisation.ExtensionMethods
{
    public static class DecimalExtensions
    {
        /// <summary>
        /// Returns a decimal as a en-GB money string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="includePoundSign"></param>
        /// <returns></returns>
        public static string ToMoneyString(this decimal value, bool includePoundSign = false)
        {
            return string.Format(CultureInfo.CreateSpecificCulture("en-GB"), includePoundSign ? "{0:C2}" : "{0:F2}", value);
        }

        /// <summary>
        /// Returns a decimal as a en-GB money string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="includePoundSign"></param>
        /// <returns></returns>
        public static string ToMoneyString(this decimal? value, bool includePoundSign = false)
        {
            string format = includePoundSign ? "{0:C2}" : "{0:F2}";
            return value.HasValue ? string.Format(CultureInfo.CreateSpecificCulture("en-GB"), format, value) : string.Empty;
        }

        /// <summary>
        /// Returns a decimal value as a percentage
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToPercentage(this decimal value)
        {
            return $"{value:G0}%";
        }

        /// <summary>
        /// Returns a decimal value as a percentage
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSafeString(this decimal? value)
        {
            return value.HasValue ? value.Value.ToString("G0") : string.Empty;
        }
    }
}
