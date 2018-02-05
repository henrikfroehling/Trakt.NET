namespace TraktApiSharp.Objects.Get.Episodes.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class EpisodeObjectJsonWriter : AObjectJsonWriter<ITraktEpisode>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktEpisode obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.SeasonNumber.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_SEASON_NUMBER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.SeasonNumber, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_NUMBER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Title))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_TITLE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Title, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var episodeIdsObjectJsonWriter = new EpisodeIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await episodeIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            if (obj.NumberAbsolute.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_NUMBER_ABSOLUTE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.NumberAbsolute, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Overview))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_OVERVIEW, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Overview, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Runtime.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_RUNTIME, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Runtime, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Rating.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_RATING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Votes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_VOTES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Votes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.FirstAired.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_FIRST_AIRED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.FirstAired.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.UpdatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_UPDATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.UpdatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.AvailableTranslationLanguageCodes != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_AVAILABLE_TRANSLATIONS, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteStringArrayAsync(jsonWriter, obj.AvailableTranslationLanguageCodes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Translations != null)
            {
                var episodeTranslationArrayJsonWriter = new EpisodeTranslationArrayJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_TRANSLATIONS, cancellationToken).ConfigureAwait(false);
                await episodeTranslationArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Translations, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
