namespace TraktApiSharp.Objects.Get.Users.Lists.Json
{
    using Enums;
    using Episodes.Json;
    using Implementations;
    using Movies.Json;
    using Newtonsoft.Json;
    using Objects.Json;
    using People.Json;
    using Seasons.Json;
    using Shows.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListItemObjectJsonReader : IObjectJsonReader<ITraktListItem>
    {
        public Task<ITraktListItem> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktListItem));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktListItem> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktListItem));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktListItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktListItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieReader = new MovieObjectJsonReader();
                var showReader = new ShowObjectJsonReader();
                var seasonReader = new SeasonObjectJsonReader();
                var episodeReader = new EpisodeObjectJsonReader();
                var personReader = new PersonObjectJsonReader();

                ITraktListItem traktListItem = new TraktListItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.LIST_ITEM_PROPERTY_NAME_RANK:
                            traktListItem.Rank = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.LIST_ITEM_PROPERTY_NAME_LISTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktListItem.ListedAt = value.Second;

                                break;
                            }
                        case JsonProperties.LIST_ITEM_PROPERTY_NAME_TYPE:
                            traktListItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktListItemType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.LIST_ITEM_PROPERTY_NAME_MOVIE:
                            traktListItem.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.LIST_ITEM_PROPERTY_NAME_SHOW:
                            traktListItem.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.LIST_ITEM_PROPERTY_NAME_SEASON:
                            traktListItem.Season = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.LIST_ITEM_PROPERTY_NAME_EPISODE:
                            traktListItem.Episode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.LIST_ITEM_PROPERTY_NAME_PERSON:
                            traktListItem.Person = await personReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktListItem;
            }

            return await Task.FromResult(default(ITraktListItem));
        }
    }
}
