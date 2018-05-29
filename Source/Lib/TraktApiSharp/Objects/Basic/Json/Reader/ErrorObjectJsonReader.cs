namespace TraktApiSharp.Objects.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ErrorObjectJsonReader : AObjectJsonReader<ITraktError>
    {
        public override async Task<ITraktError> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktError));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktError traktError = new TraktError();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.ERROR_PROPERTY_NAME_ERROR:
                            traktError.Error = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.ERROR_PROPERTY_NAME_ERROR_DESCRIPTION:
                            traktError.Description = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktError;
            }

            return await Task.FromResult(default(ITraktError));
        }
    }
}
