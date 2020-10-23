namespace TraktNet.Objects.Get.Movies.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MostPWCMovieObjectJsonWriter : AObjectJsonWriter<ITraktMostPWCMovie>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktMostPWCMovie obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.WatcherCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_WATCHER_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.WatcherCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.PlayCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_PLAY_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.PlayCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CollectedCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_COLLECTED_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CollectedCount, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Movie != null)
            {
                var movieObjectJsonWriter = new MovieObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIE, cancellationToken).ConfigureAwait(false);
                await movieObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Movie, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
