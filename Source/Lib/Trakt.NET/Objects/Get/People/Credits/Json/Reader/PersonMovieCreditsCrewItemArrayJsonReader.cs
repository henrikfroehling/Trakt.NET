namespace TraktNet.Objects.Get.People.Credits.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonMovieCreditsCrewItemArrayJsonReader : AArrayJsonReader<ITraktPersonMovieCreditsCrewItem>
    {
        public override async Task<IEnumerable<ITraktPersonMovieCreditsCrewItem>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPersonMovieCreditsCrewItem>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var creditsCrewItemReader = new PersonMovieCreditsCrewItemObjectJsonReader();
                var creditsCrewItems = new List<ITraktPersonMovieCreditsCrewItem>();
                ITraktPersonMovieCreditsCrewItem creditsCrewItem = await creditsCrewItemReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (creditsCrewItem != null)
                {
                    creditsCrewItems.Add(creditsCrewItem);
                    creditsCrewItem = await creditsCrewItemReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return creditsCrewItems;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPersonMovieCreditsCrewItem>));
        }
    }
}
