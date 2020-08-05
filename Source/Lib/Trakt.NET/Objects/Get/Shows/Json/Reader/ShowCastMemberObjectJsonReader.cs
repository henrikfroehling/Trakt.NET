namespace TraktNet.Objects.Get.Shows.Json.Reader
{
    using Get.People.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ShowCastMemberObjectJsonReader : AObjectJsonReader<ITraktShowCastMember>
    {
        public override async Task<ITraktShowCastMember> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktShowCastMember));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var personReader = new PersonObjectJsonReader();
                ITraktShowCastMember traktShowCastMember = new TraktShowCastMember();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_CHARACTERS:
                            traktShowCastMember.Characters = await JsonReaderHelper.ReadStringArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODE_COUNT:
                            {
                                var value = await JsonReaderHelper.ReadIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktShowCastMember.EpisodeCount = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_PERSON:
                            traktShowCastMember.Person = await personReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktShowCastMember;
            }

            return await Task.FromResult(default(ITraktShowCastMember));
        }
    }
}
