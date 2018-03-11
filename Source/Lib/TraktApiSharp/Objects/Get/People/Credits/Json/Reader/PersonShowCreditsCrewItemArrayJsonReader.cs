namespace TraktApiSharp.Objects.Get.People.Credits.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsCrewItemArrayJsonReader : AArrayJsonReader<ITraktPersonShowCreditsCrewItem>
    {
        public override async Task<IEnumerable<ITraktPersonShowCreditsCrewItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPersonShowCreditsCrewItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var creditsCrewItemReader = new PersonShowCreditsCrewItemObjectJsonReader();
                //var creditsCrewItemReadingTasks = new List<Task<ITraktPersonShowCreditsCrewItem>>();
                var creditsCrewItems = new List<ITraktPersonShowCreditsCrewItem>();

                //creditsCrewItemReadingTasks.Add(creditsCrewItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktPersonShowCreditsCrewItem creditsCrewItem = await creditsCrewItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (creditsCrewItem != null)
                {
                    creditsCrewItems.Add(creditsCrewItem);
                    //creditsCrewItemReadingTasks.Add(creditsCrewItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                    creditsCrewItem = await creditsCrewItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCreditsCrewItems = await Task.WhenAll(creditsCrewItemReadingTasks);
                //return (IEnumerable<ITraktPersonShowCreditsCrewItem>)readCreditsCrewItems.GetEnumerator();
                return creditsCrewItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPersonShowCreditsCrewItem>));
        }
    }
}
