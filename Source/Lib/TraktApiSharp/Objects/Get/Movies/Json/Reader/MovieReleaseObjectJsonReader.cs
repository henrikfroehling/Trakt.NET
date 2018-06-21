namespace TraktNet.Objects.Get.Movies.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MovieReleaseObjectJsonReader : AObjectJsonReader<ITraktMovieRelease>
    {
        public override async Task<ITraktMovieRelease> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktMovieRelease));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktMovieRelease traktMovieRelease = new TraktMovieRelease();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.MOVIE_RELEASE_PROPERTY_NAME_COUNTRY:
                            traktMovieRelease.CountryCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.MOVIE_RELEASE_PROPERTY_NAME_CERTIFICATION:
                            traktMovieRelease.Certification = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.MOVIE_RELEASE_PROPERTY_NAME_RELEASE_DATE:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktMovieRelease.ReleaseDate = value.Second;

                                break;
                            }
                        case JsonProperties.MOVIE_RELEASE_PROPERTY_NAME_RELEASE_TYPE:
                            traktMovieRelease.ReleaseType = await JsonReaderHelper.ReadEnumerationValueAsync<TraktReleaseType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.MOVIE_RELEASE_PROPERTY_NAME_NOTE:
                            traktMovieRelease.Note = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktMovieRelease;
            }

            return await Task.FromResult(default(ITraktMovieRelease));
        }
    }
}
