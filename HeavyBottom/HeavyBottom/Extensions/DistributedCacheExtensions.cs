using System;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Extensions.Caching.Distributed
{
    public static class DistributedCacheExtensions
    {
        /// <summary>
        /// Gets a value with the given key or, if not found, stores the value obtained executing the specified Func.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="options">The options.</param>
        /// <param name="token">The cancellation token.</param>
        /// <returns></returns>
        public static async Task<byte[]> GetOrSetAsync(this IDistributedCache cache, string key, Func<Task<byte[]>> value, DistributedCacheEntryOptions options = null, CancellationToken token = default)
        {
            byte[] result = await cache.GetAsync(key, token);
            if (result == null)
            {
                result = await value();

                if (result != null)
                {
                    await cache.SetAsync(key, result, options, token);
                }
            }
            return result;
        }

        /// <summary>
        /// Gets a string with the given key or, if not found, stores the string obtained executing the specified Func.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <param name="options">The options.</param>
        /// <param name="token">The token.</param>
        /// <returns></returns>
        public static async Task<string> GetOrSetStringAsync(this IDistributedCache cache, string key, Func<Task<string>> value, DistributedCacheEntryOptions options = null, CancellationToken token = default)
        {
            string result = await cache.GetStringAsync(key, token);
            if (result == null)
            {
                result = await value();

                if (result != null)
                {
                    await cache.SetStringAsync(key, result, options, token);
                }
            }
            return result;
        }
    }
}
