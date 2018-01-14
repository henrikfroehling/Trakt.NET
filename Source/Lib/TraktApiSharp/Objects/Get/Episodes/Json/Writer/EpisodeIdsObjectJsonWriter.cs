namespace TraktApiSharp.Objects.Get.Episodes.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeIdsObjectJsonWriter : AObjectJsonWriter<ITraktEpisodeIds>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktEpisodeIds obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_IDS_PROPERTY_NAME_TRAKT, cancellationToken);
            await jsonWriter.WriteValueAsync(obj.Trakt);

            if (obj.Tvdb.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_IDS_PROPERTY_NAME_TVDB, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Tvdb);
            }

            if (!string.IsNullOrEmpty(obj.Imdb))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_IDS_PROPERTY_NAME_IMDB, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Imdb, cancellationToken);
            }

            if (obj.Tmdb.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_IDS_PROPERTY_NAME_TMDB, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Tmdb);
            }

            if (obj.TvRage.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_IDS_PROPERTY_NAME_TVRAGE, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.TvRage);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
