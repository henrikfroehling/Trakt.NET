namespace TraktNet.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RateLimitInfoObjectJsonReader : AObjectJsonReader<ITraktRateLimitInfo>
    {
        public override async Task<ITraktRateLimitInfo> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktRateLimitInfo traktRateLimitInfo = new TraktRateLimitInfo();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_NAME:
                            traktRateLimitInfo.Name = await jsonReader.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_PERIOD:
                            traktRateLimitInfo.Period = await jsonReader.ReadAsInt32Async(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIMIT:
                            traktRateLimitInfo.Limit = await jsonReader.ReadAsInt32Async(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_REMAINING:
                            traktRateLimitInfo.Remaining = await jsonReader.ReadAsInt32Async(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_UNTIL:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken).ConfigureAwait(false);

                                if (value.First)
                                    traktRateLimitInfo.Until = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }

                return traktRateLimitInfo;
            }

            return await Task.FromResult(default(ITraktRateLimitInfo));
        }
    }
}
