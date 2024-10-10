namespace Dfe.Academisation.ExtensionMethods;
using System.Globalization;
/// <summary>
/// The decimal extensions.
/// </summary>
#pragma warning disable S1133
[Obsolete("This package is deprecated. Please use https://github.com/DFE-Digital/rsd-core-libs instead.")]
#pragma warning restore S1133
public static class DecimalExtensions
{
    /// <summary>
    /// Returns a decimal as a en-GB money string.
    /// If includePoundSign = true then a '£' will be prefixed and commas will be used as a thousands separator
    /// </summary>
    /// <param name="value"></param>
    /// <param name="includePoundSign"></param>
    /// <returns></returns>
    public static string ToMoneyString(this decimal value, bool includePoundSign = false)
    {
        return string.Format(CultureInfo.CreateSpecificCulture("en-GB"), includePoundSign ? "{0:C2}" : "{0:F2}", value);
    }

    /// <summary>
    /// Returns a decimal as a en-GB money string.
    /// If includePoundSign = true then a '£' will be prefixed and commas will be used as a thousands separator
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
    /// Applies a general format of 'G0' to a decimal and returns the result as a string
    /// If decimal is null then string.empty is returned.
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ToSafeString(this decimal? value)
    {
        return value.HasValue ? value.Value.ToString("G0") : string.Empty;
    }
}