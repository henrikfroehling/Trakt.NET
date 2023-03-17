namespace TraktNet.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>Provides helper methods for IAsyncEnumerables.</summary>
    public static class IAsyncEnumerableExtensions
    {
        /// <summary>Converts the given string to a string, in which only the first letter is capitalized.</summary>
        /// <param name="source">The string, in which only the first letter should be capitalized.</param>
        /// <returns>A string, in which only the first letter is capitalized.</returns>
        /// <exception cref="ArgumentException">Thrown, if the given string is null or empty.</exception>
        public static async Task<List<TSource>> ToListAsync<TSource>(this IAsyncEnumerable<TSource>  source)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));

            var list = new List<TSource>();
            await foreach (TSource value in source)
            {
                list.Add(value);
            }

            return list;
        }
    }
}
