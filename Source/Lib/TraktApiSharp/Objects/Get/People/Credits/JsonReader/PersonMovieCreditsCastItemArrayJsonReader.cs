namespace TraktApiSharp.Objects.Get.People.Credits.JsonReader
{
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonMovieCreditsCastItemArrayJsonReader : IArrayJsonReader<ITraktPersonMovieCreditsCastItem>
    {
        public Task<IEnumerable<ITraktPersonMovieCreditsCastItem>> ReadArrayAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(IEnumerable<ITraktPersonMovieCreditsCastItem>));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public Task<IEnumerable<ITraktPersonMovieCreditsCastItem>> ReadArrayAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(IEnumerable<ITraktPersonMovieCreditsCastItem>));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadArrayAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<IEnumerable<ITraktPersonMovieCreditsCastItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPersonMovieCreditsCastItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var creditsCastItemReader = new PersonMovieCreditsCastItemObjectJsonReader();
                //var creditsCastItemReadingTasks = new List<Task<ITraktPersonMovieCreditsCastItem>>();
                var creditsCastItems = new List<ITraktPersonMovieCreditsCastItem>();

                //creditsCastItemReadingTasks.Add(creditsCastItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                ITraktPersonMovieCreditsCastItem creditsCastItem = await creditsCastItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (creditsCastItem != null)
                {
                    creditsCastItems.Add(creditsCastItem);
                    //creditsCastItemReadingTasks.Add(creditsCastItemReader.ReadObjectAsync(jsonReader, cancellationToken));
                    creditsCastItem = await creditsCastItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                //var readCreditsCastItems = await Task.WhenAll(creditsCastItemReadingTasks);
                //return (IEnumerable<ITraktPersonMovieCreditsCastItem>)readCreditsCastItems.GetEnumerator();
                return creditsCastItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPersonMovieCreditsCastItem>));
        }
    }
}
