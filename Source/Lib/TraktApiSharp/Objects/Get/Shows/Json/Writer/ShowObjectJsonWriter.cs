namespace TraktApiSharp.Objects.Get.Shows.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json.Writer;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowObjectJsonWriter : AObjectJsonWriter<ITraktShow>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktShow obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Title))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_TITLE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Title, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Year.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_YEAR, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Year, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var showIdsObjectJsonWriter = new ShowIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await showIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Overview))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_OVERVIEW, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Overview, cancellationToken).ConfigureAwait(false);
            }

            if (obj.FirstAired.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_FIRST_AIRED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.FirstAired.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Airs != null)
            {
                var showAirsObjectJsonWriter = new ShowAirsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_AIRS, cancellationToken).ConfigureAwait(false);
                await showAirsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Airs, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Runtime.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_RUNTIME, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Runtime, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Certification))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_CERTIFICATION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Certification, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Network))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_NETWORK, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Network, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.CountryCode))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_COUNTRY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CountryCode, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Trailer))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_TRAILER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Trailer, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Homepage))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_HOMEPAGE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Homepage, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Status != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_STATUS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Status.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Rating.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_RATING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Votes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_VOTES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Votes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.UpdatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_UPDATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.UpdatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.LanguageCode))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_LANGUAGE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.LanguageCode, cancellationToken).ConfigureAwait(false);
            }

            if (obj.AvailableTranslationLanguageCodes != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_AVAILABLE_TRANSLATIONS, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteStringArrayAsync(jsonWriter, obj.AvailableTranslationLanguageCodes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Genres != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_GENRES, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteStringArrayAsync(jsonWriter, obj.Genres, cancellationToken).ConfigureAwait(false);
            }

            if (obj.AiredEpisodes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_AIRED_EPISODES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.AiredEpisodes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var seasonArrayJsonWriter = new SeasonArrayJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SHOW_PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await seasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
