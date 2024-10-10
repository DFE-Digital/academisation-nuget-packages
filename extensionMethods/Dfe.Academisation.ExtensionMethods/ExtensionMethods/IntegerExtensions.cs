﻿namespace Dfe.Academisation.ExtensionMethods;
/// <summary>
/// The integer extensions.
/// </summary>
#pragma warning disable S1133
[Obsolete("This package is deprecated. Please use https://github.com/DFE-Digital/rsd-core-libs instead.")]
#pragma warning restore S1133
public static class IntegerExtensions
{
    /// <summary>
    /// Returns string representing an integer value as a percentage of.
    /// </summary>
    /// <param name="part"></param>
    /// <param name="whole"></param>
    /// <returns></returns>
    public static string AsPercentageOf(this int? part, int? whole)
    {
        if (!whole.HasValue || !part.HasValue)
        {
            return "";
        }

        if (whole.Value == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(whole), "The value of the whole must be greater than zero");
        }

        return $"{100d / whole * part:F0}%";
    }
}