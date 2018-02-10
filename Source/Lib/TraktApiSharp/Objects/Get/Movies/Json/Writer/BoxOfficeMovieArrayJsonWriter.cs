namespace TraktApiSharp.Objects.Get.Movies.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class BoxOfficeMovieArrayJsonWriter : AArrayJsonWriter<ITraktBoxOfficeMovie>
    {
        public override async Task WriteArrayAsync(JsonTextWriter jsonWriter, IEnumerable<ITraktBoxOfficeMovie> objects, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            var boxOfficeMovieObjectJsonWriter = new BoxOfficeMovieObjectJsonWriter();
            var writerTasks = new List<Task>();
            await jsonWriter.WriteStartArrayAsync(cancellationToken).ConfigureAwait(false);

            foreach (ITraktBoxOfficeMovie traktBoxOfficeMovie in objects)
                writerTasks.Add(boxOfficeMovieObjectJsonWriter.WriteObjectAsync(jsonWriter, traktBoxOfficeMovie, cancellationToken));

            await Task.WhenAll(writerTasks).ConfigureAwait(false);
            await jsonWriter.WriteEndArrayAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
