using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

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
        public static int? ToInt32(this string source, bool returnDefaultOnError = false, int defaultValue = default(int)) => source.ParseTo(returnDefaultOnError, defaultValue);

        /// <summary>
        /// Tries to convert source to Int32
        /// </summary>
        ///  /// <param name="source">The source.</param>
        /// <param name="returnDefaultOnError">if true returns default(int) in case of errors</param>
        /// <param name="defaultValue">default returned in case of parse errors</param>
        /// <returns></returns>
        public static int? ToInt32(this string source, NumberStyles styles, IFormatProvider? formatProvider, bool returnDefaultOnError = false, int defaultValue = default(int))
            => source.ParseTo(returnDefaultOnError, defaultValue, styles, formatProvider);

        /// <summary>
        /// Tries to convert source to DateTime
        /// </summary>
        ///  /// <param name="source">The source.</param>
        /// <param name="returnDefaultOnError">if true returns default(int) in case of errors</param>
        /// <param name="defaultValue">default returned in case of parse errors</param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string source, bool returnDefaultOnError = false, DateTime defaultValue = default(DateTime))
            => source.ParseTo(returnDefaultOnError, defaultValue);
        /// <summary>
        /// Tries to convert source to DateTime
        /// </summary>
        ///  /// <param name="source">The source.</param>
        /// <param name="returnDefaultOnError">if true returns default(int) in case of errors</param>
        /// <param name="defaultValue">default returned in case of parse errors</param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this string source, DateTimeStyles style, IFormatProvider? formatProvider, bool returnDefaultOnError = false, DateTime defaultValue = default(DateTime))
            => source.ParseTo(returnDefaultOnError, defaultValue, style, formatProvider);

        /// <summary>
        /// Tries to convert source to decimal
        /// </summary>
        /// <param name="source"></param>
        /// <param name="returnDefaultOnError">if true returns default(int) in case of errors</param>
        /// <param name="defaultValue">default returned in case of parse errors</param>
        /// <returns></returns>
        public static decimal? ToDecimal(this string source, bool returnDefaultOnError, decimal defaultValue = default(decimal))
            => source.ParseTo(returnDefaultOnError, defaultValue);

        /// <summary>
        /// Tries to convert source to decimal
        /// </summary>
        /// <param name="source"></param>
        /// <param name="style"></param>
        /// <param name="formatProvider"></param>
        /// <param name="returnDefaultOnError">if true returns default(int) in case of errors</param>
        /// <param name="defaultValue">default returned in case of parse errors</param>
        /// <returns></returns>
        public static decimal? ToDecimal(this string source, NumberStyles style, IFormatProvider? formatProvider, bool returnDefaultOnError = false, decimal defaultValue = default(decimal))
            => source.ParseTo(returnDefaultOnError, defaultValue, style, formatProvider);



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



        /// <summary>
        /// Converts the string in any struct that has TryParse method. In case of errors the method returns null 
        /// or <paramref name="defaultValue"/> depending on the value of <paramref name="returnDefaultValueOnError"/>
        /// </summary>
        /// <typeparam name="T">any struct that has TryParse method</typeparam>
        /// <param name="source">source string</param>
        /// <param name="returnDefaultValueOnError">if true the method returns <paramref name="defaultValue"/> </param>
        /// <param name="defaultValue">value returned in case of errors if <paramref name="returnDefaultValueOnError"/> is true</param>
        /// <param name="args">arguments to TryParse parameters</param>
        /// <returns>the parsed value or null|default value in case of errors</returns>
        private static T? ParseTo<T>(this string source, bool returnDefaultValueOnError = false, T defaultValue = default, params object[] args) where T : struct
        {
            T result = default(T);
            List<object> argsList = new() { source };
            argsList.AddRange(args);
            argsList.Add(result);
            var arglistarray = argsList.ToArray();
            var m = GetTryParseMethod(typeof(T), arglistarray);
            if (m == null) return null;
            return (bool)m.Invoke(null, arglistarray)
                ? (T?)(T)arglistarray[arglistarray.Length - 1]
                : returnDefaultValueOnError ? defaultValue : null;
        }

        /// <summary>
        /// Looks for a suitable TryParse method in <paramref name="t"/> using <paramref name="args"/> as parameter list
        /// </summary>
        /// <param name="t">the type</param>
        /// <param name="args">list of arguments for TryParse</param>
        private static MethodInfo? GetTryParseMethod(Type t, params object[] args)
        {
            var tps = args.Select(x => x.GetType()).ToList();
            tps[^1] = tps.Last().MakeByRefType();
            return t.GetMethod("TryParse", tps.ToArray());

        }
    }
}
