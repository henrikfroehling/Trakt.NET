namespace TraktNet.Objects.Get.People.Credits.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonMovieCreditsCastItemArrayJsonReader : AArrayJsonReader<ITraktPersonMovieCreditsCastItem>
    {
        public override async Task<IEnumerable<ITraktPersonMovieCreditsCastItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
