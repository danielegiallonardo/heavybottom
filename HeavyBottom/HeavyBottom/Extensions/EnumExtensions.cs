namespace System
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts a string to its corresponding enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns></returns>
        /// <exception cref="NotSupportedException">
        /// TResult must be an Enum
        /// or
        /// The value '" + value + "' does not match a valid enum name or description.
        /// </exception>
        public static T ToEnum<T>(this string value, bool ignoreCase = true)
        {
            if (!typeof(T).IsEnum)
                throw new NotSupportedException("TResult must be an Enum");
            else if (Enum.IsDefined(typeof(T), value))
                return (T)Enum.Parse(typeof(T), value, ignoreCase);

            throw new NotSupportedException("The value '" + value + "' does not match a valid enum name.");
        }

        /// <summary>
        /// Tries to convert a string to its corresponding enum value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <param name="enumValue">The enum value.</param>
        /// <param name="ignoreCase">if set to <c>true</c> [ignore case].</param>
        /// <returns></returns>
        public static bool TryToEnum<T>(this string value, out T enumValue, bool ignoreCase = true)
        {
            bool result = false;
            enumValue = default(T);
            try
            {
                enumValue = value.ToEnum<T>(ignoreCase);
                result = true;
            }
            catch
            {
            }

            return result;
        }
    }
}