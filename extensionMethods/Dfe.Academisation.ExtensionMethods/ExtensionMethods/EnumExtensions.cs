using System.ComponentModel;
using System.Reflection;

namespace Dfe.Academisation.ExtensionMethods
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Returns the description associated with an Enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToDescription<T>(this T source)
        {
            if (source == null) return string.Empty;

            string description = source.ToString();

            if (string.IsNullOrWhiteSpace(description)) return string.Empty;

            FieldInfo fi = source.GetType().GetField(description);

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi?.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            return attributes is { Length: > 0 }
                ? attributes[0].Description
                : description;
        }
    }
}
