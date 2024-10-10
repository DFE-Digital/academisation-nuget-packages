namespace Dfe.Academisation.ExtensionMethods;
/// <summary>
/// The object extensions.
/// </summary>
#pragma warning disable S1133
[Obsolete("This package is deprecated. Please use https://github.com/DFE-Digital/rsd-core-libs instead.")]
#pragma warning restore S1133
public static class ObjectExtensions
{
    /// <summary>
    /// Returns to string from an object if the instance is not null. Returns default if the object isnull
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="default"></param>
    /// <returns></returns>
    public static string? ToStringOrDefault(this object? obj, string? @default = null)
    {
        return obj?.ToString() ?? @default;
    }
}