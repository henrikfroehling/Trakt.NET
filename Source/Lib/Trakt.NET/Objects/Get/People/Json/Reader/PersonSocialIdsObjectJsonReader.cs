namespace TraktNet.Objects.Get.People.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonSocialIdsObjectJsonReader : AObjectJsonReader<ITraktPersonSocialIds>
    {
        public override async Task<ITraktPersonSocialIds> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktPersonSocialIds traktPersonSocialIds = new TraktPersonSocialIds();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_TWITTER:
                            traktPersonSocialIds.Twitter = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_FACEBOOK:
                            traktPersonSocialIds.Facebook = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_INSTAGRAM:
                            traktPersonSocialIds.Instagram = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_WIKIPEDIA:
                            traktPersonSocialIds.Wikipedia = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktPersonSocialIds;
            }

            return await Task.FromResult(default(ITraktPersonSocialIds));
        }
    }
}
