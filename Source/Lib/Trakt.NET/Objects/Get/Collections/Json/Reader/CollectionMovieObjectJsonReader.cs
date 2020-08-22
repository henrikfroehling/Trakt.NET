namespace TraktNet.Objects.Get.Collections.Json.Reader
{
    using Basic.Json.Reader;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionMovieObjectJsonReader : AObjectJsonReader<ITraktCollectionMovie>
    {
        public override async Task<ITraktCollectionMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();
                var metadataObjectReader = new MetadataObjectJsonReader();

                ITraktCollectionMovie traktCollectionMovie = new TraktCollectionMovie();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_COLLECTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCollectionMovie.CollectedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCollectionMovie.UpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            traktCollectionMovie.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_METADATA:
                            traktCollectionMovie.Metadata = await metadataObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktCollectionMovie;
            }

            return await Task.FromResult(default(ITraktCollectionMovie));
        }
    }
}
