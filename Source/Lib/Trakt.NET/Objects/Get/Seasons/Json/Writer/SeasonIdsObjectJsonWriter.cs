namespace TraktNet.Objects.Get.Seasons.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SeasonIdsObjectJsonWriter : AObjectJsonWriter<ITraktSeasonIds>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktSeasonIds obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TRAKT, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Trakt).ConfigureAwait(false);

            if (obj.Tvdb.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TVDB, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Tvdb).ConfigureAwait(false);
            }

            if (obj.Tmdb.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TMDB, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Tmdb).ConfigureAwait(false);
            }

            if (obj.TvRage.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_TVRAGE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.TvRage).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
