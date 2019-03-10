namespace TraktNet.Objects.Get.Movies.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieObjectJsonWriter : AObjectJsonWriter<ITraktMovie>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktMovie obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.Title))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_TITLE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Title, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Year.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_YEAR, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Year, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Ids != null)
            {
                var movieIdsObjectJsonWriter = new MovieIdsObjectJsonWriter();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_IDS, cancellationToken).ConfigureAwait(false);
                await movieIdsObjectJsonWriter.WriteObjectAsync(jsonWriter, obj.Ids, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Tagline))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_TAGLINE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Tagline, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Overview))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_OVERVIEW, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Overview, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Released.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_RELEASED, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Released.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.Runtime.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_RUNTIME, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Runtime, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Trailer))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_TRAILER, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Trailer, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Homepage))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_HOMEPAGE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Homepage, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Rating.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_RATING, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Rating, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Votes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_VOTES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Votes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.UpdatedAt.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_UPDATED_AT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.UpdatedAt.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.LanguageCode))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_LANGUAGE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.LanguageCode, cancellationToken).ConfigureAwait(false);
            }

            if (obj.AvailableTranslationLanguageCodes != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_AVAILABLE_TRANSLATIONS, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteStringArrayAsync(jsonWriter, obj.AvailableTranslationLanguageCodes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Genres != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_GENRES, cancellationToken).ConfigureAwait(false);
                await JsonWriterHelper.WriteStringArrayAsync(jsonWriter, obj.Genres, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Certification))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_CERTIFICATION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Certification, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.CountryCode))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_COUNTRY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CountryCode, cancellationToken).ConfigureAwait(false);
            }

            if (obj.CommentCount.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_PROPERTY_NAME_COMMENT_COUNT, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CommentCount, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
