namespace TraktNet.Objects.Get.People.Credits.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonShowCreditsCastItemArrayJsonReader : AArrayJsonReader<ITraktPersonShowCreditsCastItem>
    {
        public override async Task<IEnumerable<ITraktPersonShowCreditsCastItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPersonShowCreditsCastItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var creditsCastItemReader = new PersonShowCreditsCastItemObjectJsonReader();
                var creditsCastItems = new List<ITraktPersonShowCreditsCastItem>();
                ITraktPersonShowCreditsCastItem creditsCastItem = await creditsCastItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (creditsCastItem != null)
                {
                    creditsCastItems.Add(creditsCastItem);
                    creditsCastItem = await creditsCastItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return creditsCastItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPersonShowCreditsCastItem>));
        }
    }
}
