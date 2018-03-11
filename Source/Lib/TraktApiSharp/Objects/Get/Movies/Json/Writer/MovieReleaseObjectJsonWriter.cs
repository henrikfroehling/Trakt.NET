namespace TraktApiSharp.Objects.Get.Movies.Json.Writer
{
    using Extensions;
    using Newtonsoft.Json;
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieReleaseObjectJsonWriter : AObjectJsonWriter<ITraktMovieRelease>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktMovieRelease obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (!string.IsNullOrEmpty(obj.CountryCode))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_RELEASE_PROPERTY_NAME_COUNTRY, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.CountryCode, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Certification))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_RELEASE_PROPERTY_NAME_CERTIFICATION, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Certification, cancellationToken).ConfigureAwait(false);
            }

            if (obj.ReleaseDate.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_RELEASE_PROPERTY_NAME_RELEASE_DATE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ReleaseDate.Value.ToTraktLongDateTimeString(), cancellationToken).ConfigureAwait(false);
            }

            if (obj.ReleaseType != null)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_RELEASE_PROPERTY_NAME_RELEASE_TYPE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.ReleaseType.ObjectName, cancellationToken).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(obj.Note))
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.MOVIE_RELEASE_PROPERTY_NAME_NOTE, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Note, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
