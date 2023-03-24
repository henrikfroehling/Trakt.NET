namespace TraktNet.Extensions
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    /// <summary>Provides helper methods for IAsyncEnumerables.</summary>
    public static class IEnumerableExtensions
    {
        /// <summary>Returns results from a list of tasks as they finish.</summary>
        /// <param name="source">The list of tasks to stream results from as they finish</param>
        /// <returns>An IAsyncEnumerable of the results from the tasks.</returns>
        public static async IAsyncEnumerable<TSource> StreamFinishedTaskResultsAsync<TSource>(this List<Task<TSource>> source)
        {
            if(source is null || source.Count == 0)
                yield break;

            while (source.Any())
            {
                Task<TSource> finishedTask = await Task.WhenAny(source).ConfigureAwait(false);
                source.Remove(finishedTask);
                yield return await finishedTask;

            }
        }

        /// <summary>Returns results from an IEnumerable of tasks as they finish.</summary>
        /// <param name="source">The collection of tasks to stream results from as they finish</param>
        /// <returns>An IAsyncEnumerable of the results from the tasks.</returns>
        public static async IAsyncEnumerable<TSource> StreamFinishedTaskResultsAsync<TSource>(this IEnumerable<Task<TSource>> source)
        {
            await foreach(TSource value in StreamFinishedTaskResultsAsync(source.ToList()).ConfigureAwait(false))
            {
                yield return value;
            }
        }
    }
}
