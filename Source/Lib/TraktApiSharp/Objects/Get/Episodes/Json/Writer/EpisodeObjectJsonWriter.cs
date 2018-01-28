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

            await jsonWriter.WriteStartObjectAsync(cancellationToken);

            if (obj.SeasonNumber.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_SEASON_NUMBER, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.SeasonNumber, cancellationToken);
            }

            if (obj.Number.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_NUMBER, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Number, cancellationToken);
            }

            if (!string.IsNullOrEmpty(obj.Title))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_TITLE, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Title, cancellationToken);
            }

            if (obj.Ids != null)
            {
                var episodeIdsObjectJsonWriter = new EpisodeIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_IDS, cancellationToken);
                await episodeIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken);
            }

            if (obj.NumberAbsolute.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_NUMBER_ABSOLUTE, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.NumberAbsolute, cancellationToken);
            }

            if (!string.IsNullOrEmpty(obj.Overview))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_OVERVIEW, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Overview, cancellationToken);
            }

            if (obj.Runtime.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_RUNTIME, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Runtime, cancellationToken);
            }

            if (obj.Rating.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_RATING, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken);
            }

            if (obj.Votes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_VOTES, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.Votes, cancellationToken);
            }

            if (obj.FirstAired.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_FIRST_AIRED, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.FirstAired.Value.ToTraktLongDateTimeString(), cancellationToken);
            }

            if (obj.UpdatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_UPDATED_AT, cancellationToken);
                await jsonWriter.WriteValueAsync(obj.UpdatedAt.Value.ToTraktLongDateTimeString(), cancellationToken);
            }

            if (obj.AvailableTranslationLanguageCodes != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_AVAILABLE_TRANSLATIONS, cancellationToken);
                await JsonWriterHelper.WriteStringArrayAsync(jsonWriter, obj.AvailableTranslationLanguageCodes, cancellationToken);
            }

            if (obj.Translations != null)
            {
                var episodeTranslationArrayJsonWriter = new EpisodeTranslationArrayJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.EPISODE_PROPERTY_NAME_TRANSLATIONS, cancellationToken);
                await episodeTranslationArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Translations, cancellationToken);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken);
        }
    }
}
