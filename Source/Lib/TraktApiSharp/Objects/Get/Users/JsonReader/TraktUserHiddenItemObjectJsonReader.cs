namespace TraktApiSharp.Objects.Get.Users.JsonReader
{
    using Enums;
    using Implementations;
    using Movies.JsonReader;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Seasons.JsonReader;
    using Shows.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktUserHiddenItemObjectJsonReader : IObjectJsonReader<ITraktUserHiddenItem>
    {
        private const string PROPERTY_NAME_HIDDEN_AT = "hidden_at";
        private const string PROPERTY_NAME_TYPE = "type";
        private const string PROPERTY_NAME_MOVIE = "movie";
        private const string PROPERTY_NAME_SHOW = "show";
        private const string PROPERTY_NAME_SEASON = "season";

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
                        case PROPERTY_NAME_HIDDEN_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserHiddenItem.HiddenAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_TYPE:
                            traktUserHiddenItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktHiddenItemType>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_MOVIE:
                            traktUserHiddenItem.Movie = await movieReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOW:
                            traktUserHiddenItem.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SEASON:
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
