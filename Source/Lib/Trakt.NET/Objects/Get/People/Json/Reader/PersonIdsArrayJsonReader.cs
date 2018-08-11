namespace TraktNet.Objects.Get.People.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonIdsArrayJsonReader : AArrayJsonReader<ITraktPersonIds>
    {
        public override async Task<IEnumerable<ITraktPersonIds>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPersonIds>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var personIdsReader = new PersonIdsObjectJsonReader();
                var personIdss = new List<ITraktPersonIds>();
                ITraktPersonIds personIds = await personIdsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (personIds != null)
                {
                    personIdss.Add(personIds);
                    personIds = await personIdsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return personIdss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPersonIds>));
        }
    }
}
