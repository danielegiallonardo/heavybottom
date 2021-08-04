using System.Collections.Generic;
using System.Globalization;
using System.Linq;
namespace System
{
    public static class StringExtensions
    {

        /// <summary>
        /// Tries to convert source to Int32
        /// </summary>
        ///  /// <param name="source">The source.</param>
        /// <param name="returnDefaultOnError">if true returns default(int) in case of errors</param>
        /// <param name="defaultValue">default returned in case of parse errors</param>
        /// <returns></returns>
        public static int? ToInt32(this string source, bool returnDefaultOnError=false, int defaultValue=default(int))
        {
            return int.TryParse(source, out int result) ? result : returnDefaultOnError ? defaultValue : null;
        }

        /// <summary>
        /// Tries to convert source to Int32
        /// </summary>
        ///  /// <param name="source">The source.</param>
        /// <param name="returnDefaultOnError">if true returns default(int) in case of errors</param>
        /// <param name="defaultValue">default returned in case of parse errors</param>
        /// <returns></returns>
        public static int? ToInt32(this string source, NumberStyles styles, IFormatProvider? formatProvider, bool returnDefaultOnError=false, int defaultValue = default(int))
        {
            return int.TryParse(source, styles, formatProvider, out int result) ? result : returnDefaultOnError ? defaultValue : null;
        }

        /// <summary>
        /// Tries to convert source to DateTime
        /// </summary>
        ///  /// <param name="source">The source.</param>
        /// <param name="returnDefaultOnError">if true returns default(int) in case of errors</param>
        /// <param name="defaultValue">default returned in case of parse errors</param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string source, bool returnDefaultOnError=false, DateTime defaultValue = default(DateTime))
        {
            return DateTime.TryParse(source, out DateTime result) ? (DateTime?)result : returnDefaultOnError ? defaultValue : null;
        }

        /// <summary>
        /// Tries to convert source to DateTime
        /// </summary>
        ///  /// <param name="source">The source.</param>
        /// <param name="returnDefaultOnError">if true returns default(int) in case of errors</param>
        /// <param name="defaultValue">default returned in case of parse errors</param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string source, DateTimeStyles style, IFormatProvider? formatProvider, bool returnDefaultOnError = false, DateTime defaultValue = default(DateTime))
        {
            return DateTime.TryParse(source, formatProvider, style, out DateTime result) ? (DateTime?)result : returnDefaultOnError ? defaultValue : null;
        }

        /// <summary>
        /// Tries to convert source to decimal
        /// </summary>
        /// <param name="source"></param>
        /// <param name="returnDefaultOnError">if true returns default(int) in case of errors</param>
        /// <param name="defaultValue">default returned in case of parse errors</param>
        /// <returns></returns>
        public static decimal? ToDecimal(this string source, bool returnDefaultOnError, decimal defaultValue = default(decimal))
        {
            return decimal.TryParse(source, out decimal result) ? result : returnDefaultOnError ? defaultValue : null;
        }

        /// <summary>
        /// Tries to convert source to decimal
        /// </summary>
        /// <param name="source"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="returnDefaultOnError">if true returns default(int) in case of errors</param>
        /// <param name="defaultValue">default returned in case of parse errors</param>
        /// <returns></returns>
        public static decimal? ToDecimal(this string source,NumberStyles style, IFormatProvider? formatProvider, bool returnDefaultOnError=false, decimal defaultValue = default(decimal))
        {
            return decimal.TryParse(source, style, formatProvider, out decimal result) ? result : returnDefaultOnError ? defaultValue : null;
        }

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
