namespace TraktApiSharp.Objects.Basic.Json.Reader
{
    using Get.People.Json.Reader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CrewMemberObjectJsonReader : AObjectJsonReader<ITraktCrewMember>
    {
        public override async Task<ITraktCrewMember> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCrewMember));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var personReader = new PersonObjectJsonReader();
                ITraktCrewMember traktCrewMember = new TraktCrewMember();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.CREW_MEMBER_PROPERTY_NAME_JOB:
                            traktCrewMember.Job = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.CREW_MEMBER_PROPERTY_NAME_PERSON:
                            traktCrewMember.Person = await personReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktCrewMember;
            }

            return await Task.FromResult(default(ITraktCrewMember));
        }
    }
}
