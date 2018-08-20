namespace TraktNet.Objects.Get.People.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonArrayJsonReader : AArrayJsonReader<ITraktPerson>
    {
        public override async Task<IEnumerable<ITraktPerson>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPerson>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var personReader = new PersonObjectJsonReader();
                var persons = new List<ITraktPerson>();
                ITraktPerson person = await personReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (person != null)
                {
                    persons.Add(person);
                    person = await personReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return persons;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPerson>));
        }
    }
}
