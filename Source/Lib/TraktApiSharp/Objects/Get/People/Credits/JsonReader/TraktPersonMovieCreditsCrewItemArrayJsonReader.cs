namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktPersonMovieCreditsCrewItemArrayJsonReader : ITraktArrayJsonReader<ITraktPersonMovieCreditsCrewItem>
    {
        public Task<IEnumerable<ITraktPersonMovieCreditsCrewItem>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktPersonMovieCreditsCrewItem>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktPersonMovieCreditsCrewItem>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktPersonMovieCreditsCrewItem>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktPersonMovieCreditsCrewItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPersonMovieCreditsCrewItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var creditsCrewItemReader = new TraktPersonMovieCreditsCrewItemObjectJsonReader();
                //var creditsCrewItemReadingTasks = new List<Task<ITraktPersonMovieCreditsCrewItem>>();
                var creditsCrewItems = new List<ITraktPersonMovieCreditsCrewItem>();

                //creditsCrewItemReadingTasks.Add(creditsCrewItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktPersonMovieCreditsCrewItem creditsCrewItem = await creditsCrewItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (creditsCrewItem != null)
                {
                    creditsCrewItems.Add(creditsCrewItem);
                    //creditsCrewItemReadingTasks.Add(creditsCrewItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                    creditsCrewItem = await creditsCrewItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCreditsCrewItems = await Task.WhenAll(creditsCrewItemReadingTasks);
                //return (IEnumerable<ITraktPersonMovieCreditsCrewItem>)readCreditsCrewItems.GetEnumerator();
                return creditsCrewItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPersonMovieCreditsCrewItem>));
        }
    }
}
