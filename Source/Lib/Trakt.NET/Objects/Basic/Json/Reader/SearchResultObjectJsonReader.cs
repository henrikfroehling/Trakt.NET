namespace TraktNet.Objects.Basic.Json.Reader
{
    using Enums;
    using Get.Episodes.Json.Reader;
    using Get.Lists.Json.Reader;
    using Get.Movies.Json.Reader;
    using Get.People.Json.Reader;
    using Get.Shows.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class SearchResultObjectJsonReader : AObjectJsonReader<ITraktSearchResult>
    {
        public override async Task<ITraktSearchResult> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieObjectReader = new MovieObjectJsonReader();
                var showObjectReader = new ShowObjectJsonReader();
                var episodeObjectReader = new EpisodeObjectJsonReader();
                var personObjectReader = new PersonObjectJsonReader();
                var listObjectReader = new ListObjectJsonReader();
                ITraktSearchResult traktSearchResult = new TraktSearchResult();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_TYPE:
                            traktSearchResult.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktSearchResultType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SCORE:
                            {
                                var value = await JsonReaderHelper.ReadFloatValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktSearchResult.Score = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_MOVIE:
                            traktSearchResult.Movie = await movieObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            traktSearchResult.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODE:
                            traktSearchResult.Episode = await episodeObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PERSON:
                            traktSearchResult.Person = await personObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIST:
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
