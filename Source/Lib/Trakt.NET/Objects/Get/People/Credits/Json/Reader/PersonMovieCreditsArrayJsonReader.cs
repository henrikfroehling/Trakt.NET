namespace TraktNet.Objects.Get.People.Credits.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonMovieCreditsArrayJsonReader : AArrayJsonReader<ITraktPersonMovieCredits>
    {
        public override async Task<IEnumerable<ITraktPersonMovieCredits>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPersonMovieCredits>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var personMovieCreditsReader = new PersonMovieCreditsObjectJsonReader();
                var personMovieCreditss = new List<ITraktPersonMovieCredits>();
                ITraktPersonMovieCredits personMovieCredits = await personMovieCreditsReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (personMovieCredits != null)
                {
                    personMovieCreditss.Add(personMovieCredits);
                    personMovieCredits = await personMovieCreditsReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return personMovieCreditss;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPersonMovieCredits>));
        }
    }
}
