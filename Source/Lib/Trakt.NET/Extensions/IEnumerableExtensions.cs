namespace TraktNet.Extensions
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>Provides helper methods for IAsyncEnumerables.</summary>
    public static class IEnumerableExtensions
    {
        /// <summary>Returns results from a list of tasks as they finish.</summary>
        /// <param name="source">The list of tasks to stream results from as they finish.</param>
        /// <returns>An IAsyncEnumerable of the results from the tasks.</returns>
        public static async IAsyncEnumerable<TSource> StreamFinishedTaskResultsAsync<TSource>(this List<Task<TSource>> source)
        {
            if(source is null || source.Count == 0)
                yield break;

            foreach (Task<TSource> task in source)
            {
                yield return await task.ConfigureAwait(false);
            }
        }
    }
}
