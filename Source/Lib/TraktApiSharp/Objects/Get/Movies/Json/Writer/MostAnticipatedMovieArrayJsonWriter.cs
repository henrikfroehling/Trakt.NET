namespace TraktApiSharp.Objects.Get.Movies.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostAnticipatedMovieArrayJsonWriter : AArrayJsonWriter<ITraktMostAnticipatedMovie>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktMostAnticipatedMovie> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var mostAnticipatedMovieObjectJsonWriter = new MostAnticipatedMovieObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktMostAnticipatedMovie traktMostAnticipatedMovie in objects)
                writerTasks.Add(mostAnticipatedMovieObjectJsonWriter.WriteObjectAsync(jsonWriter, traktMostAnticipatedMovie, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
