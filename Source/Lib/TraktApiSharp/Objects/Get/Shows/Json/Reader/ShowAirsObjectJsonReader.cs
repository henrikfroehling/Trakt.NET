namespace TraktApiSharp.Objects.Get.Shows.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowAirsObjectJsonReader : AObjectJsonReader<ITraktShowAirs>
    {
        public override async Task<ITraktShowAirs> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktShowAirs));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktShowAirs traktShowAirs = new TraktShowAirs();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.SHOW_AIRS_PROPERTY_NAME_DAY:
                            traktShowAirs.Day = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_AIRS_PROPERTY_NAME_TIME:
                            traktShowAirs.Time = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.SHOW_AIRS_PROPERTY_NAME_TIMEZONE:
                            traktShowAirs.TimeZoneId = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktShowAirs;
            }

            return await Task.FromResult(default(ITraktShowAirs));
        }
    }
}
