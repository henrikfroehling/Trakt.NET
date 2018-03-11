namespace TraktApiSharp.Objects.Get.People.Credits.Json.Reader
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
