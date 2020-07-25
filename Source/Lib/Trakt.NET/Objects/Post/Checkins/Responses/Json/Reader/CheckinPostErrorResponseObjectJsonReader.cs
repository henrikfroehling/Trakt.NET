namespace TraktNet.Objects.Post.Checkins.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CheckinPostErrorResponseObjectJsonReader : AObjectJsonReader<ITraktCheckinPostErrorResponse>
    {
        public override async Task<ITraktCheckinPostErrorResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCheckinPostErrorResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktCheckinPostErrorResponse checkinErrorResponse = new TraktCheckinPostErrorResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_EXPIRES_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    checkinErrorResponse.ExpiresAt = value.Second;

                                break;
                            }
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return checkinErrorResponse;
            }

            return await Task.FromResult(default(ITraktCheckinPostErrorResponse));
        }
    }
}
