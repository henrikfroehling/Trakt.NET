namespace TraktApiSharp.Objects.Get.Collections.JsonReader
{
    using Basic.JsonReader;
    using Collections.Implementations;
    using Movies.JsonReader;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionMovieObjectJsonReader : IObjectJsonReader<ITraktCollectionMovie>
    {
        private const string PROPERTY_NAME_COLLECTED_AT = "collected_at";
        private const string PROPERTY_NAME_MOVIE = "movie";
        private const string PROPERTY_NAME_METADATA = "metadata";

        public Task<ITraktCollectionMovie> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktCollectionMovie));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktCollectionMovie> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktCollectionMovie));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktCollectionMovie> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCollectionMovie));

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
                        case PROPERTY_NAME_COLLECTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCollectionMovie.CollectedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_MOVIE:
                            traktCollectionMovie.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_METADATA:
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
