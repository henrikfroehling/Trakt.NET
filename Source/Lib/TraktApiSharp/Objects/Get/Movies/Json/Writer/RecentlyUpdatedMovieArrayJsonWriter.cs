namespace TraktApiSharp.Objects.Get.Movies.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecentlyUpdatedMovieArrayJsonWriter : AArrayJsonWriter<ITraktRecentlyUpdatedMovie>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktRecentlyUpdatedMovie> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var recentlyUpdatedMovieObjectJsonWriter = new RecentlyUpdatedMovieObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktRecentlyUpdatedMovie traktRecentlyUpdatedMovie in objects)
                writerTasks.Add(recentlyUpdatedMovieObjectJsonWriter.WriteObjectAsync(jsonWriter, traktRecentlyUpdatedMovie, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
