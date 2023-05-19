namespace Dfe.Academisation.ExtensionMethods
{
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

            return string.Format("{0:F0}%", 100d / whole * part);
        }

        /// <summary>
        /// Converts a string into an int. Returns null if value is not parsable.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ToInt(string value)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }

            return null;
        }
    }
}
