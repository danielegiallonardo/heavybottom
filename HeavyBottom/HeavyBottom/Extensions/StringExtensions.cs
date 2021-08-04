using System.Globalization;
namespace System
{
    public static class StringExtensions
    {
        
        public static int? ToInt32(this string source, bool returnDefaultOnError=false)
        {
            if (int.TryParse(source,out int result))
                return result;
            return returnDefaultOnError?default(int):null;

        }

        public static int? ToInt32(this string source, NumberStyles styles, IFormatProvider? formatProvider, bool returnDefaultOnError)
        {
            if (int.TryParse(source,styles,formatProvider,out int result))
                return result;
            return returnDefaultOnError?default(int):null;
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
