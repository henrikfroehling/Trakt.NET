namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecentlyUpdatedShowObjectJsonReader : AObjectJsonReader<ITraktRecentlyUpdatedShow>
    {
        public override async Task<ITraktRecentlyUpdatedShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktRecentlyUpdatedShow));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ShowObjectJsonReader();
                ITraktRecentlyUpdatedShow traktRecentlyUpdatedShow = new TraktRecentlyUpdatedShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktRecentlyUpdatedShow.RecentlyUpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            traktRecentlyUpdatedShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktRecentlyUpdatedShow;
            }

            return await Task.FromResult(default(ITraktRecentlyUpdatedShow));
        }
    }
}
