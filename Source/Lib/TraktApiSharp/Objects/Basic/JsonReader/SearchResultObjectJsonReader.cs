namespace TraktApiSharp.Objects.Basic.JsonReader
{
    using Enums;
    using Get.Episodes.JsonReader;
    using Get.Movies.JsonReader;
    using Get.People.JsonReader;
    using Get.Shows.JsonReader;
    using Get.Users.Lists.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SearchResultObjectJsonReader : IObjectJsonReader<ITraktSearchResult>
    {
        private const string PROPERTY_NAME_TYPE = "type";
        private const string PROPERTY_NAME_SCORE = "score";
        private const string PROPERTY_NAME_MOVIE = "movie";
        private const string PROPERTY_NAME_SHOW = "show";
        private const string PROPERTY_NAME_EPISODE = "episode";
        private const string PROPERTY_NAME_PERSON = "person";
        private const string PROPERTY_NAME_LIST = "list";

        public Task<ITraktSearchResult> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktSearchResult));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktSearchResult> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktSearchResult));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktSearchResult> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktSearchResult));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new TraktMovieObjectJsonReader();
                var showObjectReader = new TraktShowObjectJsonReader();
                var episodeObjectReader = new EpisodeObjectJsonReader();
                var personObjectReader = new TraktPersonObjectJsonReader();
                var listObjectReader = new TraktListObjectJsonReader();
                ITraktSearchResult traktSearchResult = new TraktSearchResult();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TYPE:
                            traktSearchResult.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktSearchResultType>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SCORE:
                            {
                                var value = await JsonReaderHelper.ReadFloatValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktSearchResult.Score = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_MOVIE:
                            traktSearchResult.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOW:
                            traktSearchResult.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_EPISODE:
                            traktSearchResult.Episode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_PERSON:
                            traktSearchResult.Person = await personObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_LIST:
                            traktSearchResult.List = await listObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktSearchResult;
            }

            return await Task.FromResult(default(ITraktSearchResult));
        }
    }
}
