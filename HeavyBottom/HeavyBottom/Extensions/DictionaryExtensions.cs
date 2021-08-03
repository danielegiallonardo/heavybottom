namespace System.Collections.Generic
{
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Upserts the specified value under the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="values">The values.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public static void Upsert<T, S>(this IDictionary<T, S> values, T key, S value)
        {
            if (values.ContainsKey(key))
            {
                values[key] = value;
            }
            else
            {
                values.Add(key, value);
            }
        }

        /// <summary>
        /// Gets the value associate to the specified key if it exists, otherwise returns the default value for S.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="values">The values.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public static S Get<T, S>(this IDictionary<T, S> values, T key)
        {
            if (values.ContainsKey(key))
            {
                return values[key];
            }
            return default;
        }
    }
}
