namespace TraktNet.Objects.Get.Shows.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowIdsObjectJsonWriter : AObjectJsonWriter<ITraktShowIds>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktShowIds obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_IDS_PROPERTY_NAME_TRAKT, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteValueAsync(obj.Trakt).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Slug))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_IDS_PROPERTY_NAME_SLUG, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Slug, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Tvdb.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_IDS_PROPERTY_NAME_TVDB, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Tvdb).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Imdb))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_IDS_PROPERTY_NAME_IMDB, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Imdb, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Tmdb.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_IDS_PROPERTY_NAME_TMDB, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Tmdb).ConfigureAwait(false);
            }

            if (obj.TvRage.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_IDS_PROPERTY_NAME_TVRAGE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.TvRage).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
