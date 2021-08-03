namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the specified source or the alternative if the source IsNullOrWhitespace.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="alternative">The alternative.</param>
        /// <returns></returns>
        public static string Or(this string source, string alternative)
            => !string.IsNullOrWhiteSpace(source)
                ? source
                : alternative;

        /// <summary>
        /// Returns the specified source or throws the alternative exception if the source IsNullOrWhitespace.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="alternativeException">The alternative exception.</param>
        /// <returns></returns>
        public static string Or(this string source, Exception alternativeException)
            => !string.IsNullOrWhiteSpace(source)
                ? source
                : throw alternativeException;
    }
}
