namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsCrewItemArrayJsonReader : IArrayJsonReader<ITraktPersonShowCreditsCrewItem>
    {
        public Task<IEnumerable<ITraktPersonShowCreditsCrewItem>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktPersonShowCreditsCrewItem>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktPersonShowCreditsCrewItem>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktPersonShowCreditsCrewItem>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktPersonShowCreditsCrewItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPersonShowCreditsCrewItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var creditsCrewItemReader = new TraktPersonShowCreditsCrewItemObjectJsonReader();
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
