namespace TraktNet.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>Provides helper methods for IAsyncEnumerables.</summary>
    public static class IAsyncEnumerableExtensions
    {
        /// <summary>Converts the given IAsyncEnumberable to a list and returns that list.</summary>
        /// <param name="source">The IAsyncEnumerable to convert to a list</param>
        /// <param name="cancellationToken">
        /// Propagates notification that the request should be canceled.<para/>
        /// If provided, the exception <see cref="OperationCanceledException" /> should be catched.
        /// </param>
        /// <returns>A list of TSource instances.</returns>
        public static async Task<List<TSource>> ToListAsync<TSource>(this IAsyncEnumerable<TSource>  source, CancellationToken cancellationToken = default)
        {
            if (source is null)
                return default;

            List<TSource> list = new List<TSource>();
            await foreach (TSource value in source.WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                list.Add(value);
            }

            return list;
        }
    }
}
