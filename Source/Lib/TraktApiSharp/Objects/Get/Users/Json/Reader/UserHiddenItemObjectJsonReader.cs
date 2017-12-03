namespace TraktApiSharp.Objects.Get.Users.Json.Reader
{
    using Enums;
    using Implementations;
    using Movies.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using Seasons.Json.Reader;
    using Shows.Json.Reader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemObjectJsonReader : IObjectJsonReader<ITraktUserHiddenItem>
    {
        public Task<ITraktUserHiddenItem> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserHiddenItem));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserHiddenItem> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserHiddenItem));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserHiddenItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserHiddenItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieReader = new MovieObjectJsonReader();
                var showReader = new ShowObjectJsonReader();
                var seasonReader = new SeasonObjectJsonReader();
                ITraktUserHiddenItem traktUserHiddenItem = new TraktUserHiddenItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_HIDDEN_ITEM_PROPERTY_NAME_HIDDEN_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserHiddenItem.HiddenAt = value.Second;

                                break;
                            }
                        case JsonProperties.USER_HIDDEN_ITEM_PROPERTY_NAME_TYPE:
                            traktUserHiddenItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktHiddenItemType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_HIDDEN_ITEM_PROPERTY_NAME_MOVIE:
                            traktUserHiddenItem.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_HIDDEN_ITEM_PROPERTY_NAME_SHOW:
                            traktUserHiddenItem.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_HIDDEN_ITEM_PROPERTY_NAME_SEASON:
                            traktUserHiddenItem.Season = await seasonReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktUserHiddenItem;
            }

            return await Task.FromResult(default(ITraktUserHiddenItem));
        }
    }
}
