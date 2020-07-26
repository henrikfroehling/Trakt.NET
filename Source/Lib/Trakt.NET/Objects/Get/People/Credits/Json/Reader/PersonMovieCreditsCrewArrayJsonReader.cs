namespace TraktNet.Objects.Get.People.Credits.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonMovieCreditsCrewArrayJsonReader : ArrayJsonReader<ITraktPersonMovieCreditsCrew>
    {
        public override async Task<IEnumerable<ITraktPersonMovieCreditsCrew>> ReadArrayAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(IEnumerable<ITraktPersonMovieCreditsCrew>));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartArray)
            {
                var personMovieCreditsCrewReader = new PersonMovieCreditsCrewObjectJsonReader();
                var personMovieCreditsCrews = new List<ITraktPersonMovieCreditsCrew>();
                ITraktPersonMovieCreditsCrew personMovieCreditsCrew = await personMovieCreditsCrewReader.ReadObjectAsync(jsonReader, cancellationToken);

                while (personMovieCreditsCrew != null)
                {
                    personMovieCreditsCrews.Add(personMovieCreditsCrew);
                    personMovieCreditsCrew = await personMovieCreditsCrewReader.ReadObjectAsync(jsonReader, cancellationToken);
                }

                return personMovieCreditsCrews;
            }

            return await Task.FromResult(default(IEnumerable<ITraktPersonMovieCreditsCrew>));
        }
    }
}
