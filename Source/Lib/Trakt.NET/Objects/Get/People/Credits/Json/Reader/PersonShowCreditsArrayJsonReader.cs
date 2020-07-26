namespace TraktNet.Objects.Get.People.Credits.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsArrayJsonReader : ArrayJsonReader<ITraktPersonShowCredits>
    {
        public override async Task<IEnumerable<ITraktPersonShowCredits>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPersonShowCredits>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var personShowCreditsReader = new PersonShowCreditsObjectJsonReader();
                var personShowCreditss = new List<ITraktPersonShowCredits>();
                ITraktPersonShowCredits personShowCredits = await personShowCreditsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (personShowCredits != null)
                {
                    personShowCreditss.Add(personShowCredits);
                    personShowCredits = await personShowCreditsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return personShowCreditss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPersonShowCredits>));
        }
    }
}
