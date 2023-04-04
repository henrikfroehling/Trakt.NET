namespace TraktNet.Objects.Get.Movies.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class AMovieObjectJsonReader<TMovieObjectType> : AObjectJsonReader<TMovieObjectType> where TMovieObjectType : ITraktMovie
    {
        public override async Task<TMovieObjectType> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                TMovieObjectType movie = CreateMovieObject();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();
                    await ReadPropertyAsync(jsonReader, movie, propertyName, cancellationToken);
                }

                return movie;
            }

            return await Task.FromResult(default(TMovieObjectType));
        }

        protected virtual async Task ReadPropertyAsync(JsonTextReader jsonReader, TMovieObjectType movie, string propertyName, CancellationToken cancellationToken = default)
        {
            switch (propertyName)
            {
                case JsonProperties.PROPERTY_NAME_TITLE:
                    movie.Title = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_YEAR:
                    movie.Year = await jsonReader.ReadAsInt32Async(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_IDS:
                    var idsObjectReader = new MovieIdsObjectJsonReader();
                    movie.Ids = await idsObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_TAGLINE:
                    movie.Tagline = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_OVERVIEW:
                    movie.Overview = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_RELEASED:
                    {
                        var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                        if (value.First)
                            movie.Released = value.Second;

                        break;
                    }
                case JsonProperties.PROPERTY_NAME_RUNTIME:
                    movie.Runtime = await jsonReader.ReadAsInt32Async(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_TRAILER:
                    movie.Trailer = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_HOMEPAGE:
                    movie.Homepage = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_RATING:
                    movie.Rating = (float?)await jsonReader.ReadAsDoubleAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_VOTES:
                    movie.Votes = await jsonReader.ReadAsInt32Async(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_UPDATED_AT:
                    {
                        var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                        if (value.First)
                            movie.UpdatedAt = value.Second;

                        break;
                    }
                case JsonProperties.PROPERTY_NAME_LANGUAGE:
                    movie.LanguageCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_AVAILABLE_TRANSLATIONS:
                    movie.AvailableTranslationLanguageCodes = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_GENRES:
                    movie.Genres = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_CERTIFICATION:
                    movie.Certification = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_COUNTRY:
                    movie.CountryCode = await jsonReader.ReadAsStringAsync(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_COMMENT_COUNT:
                    movie.CommentCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_STATUS:
                    movie.Status = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMovieStatus>(jsonReader, cancellationToken);
                    break;
                default:
                    await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                    break;
            }
        }

        protected abstract TMovieObjectType CreateMovieObject();
    }
}
