namespace TraktNet.Objects.Get.People.Credits.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsCrewArrayJsonReader : AArrayJsonReader<ITraktPersonShowCreditsCrew>
    {
        public override async Task<IEnumerable<ITraktPersonShowCreditsCrew>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPersonShowCreditsCrew>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var personShowCreditsCrewReader = new PersonShowCreditsCrewObjectJsonReader();
                var personShowCreditsCrews = new List<ITraktPersonShowCreditsCrew>();
                ITraktPersonShowCreditsCrew personShowCreditsCrew = await personShowCreditsCrewReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (personShowCreditsCrew != null)
                {
                    personShowCreditsCrews.Add(personShowCreditsCrew);
                    personShowCreditsCrew = await personShowCreditsCrewReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return personShowCreditsCrews;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPersonShowCreditsCrew>));
        }
    }
}
