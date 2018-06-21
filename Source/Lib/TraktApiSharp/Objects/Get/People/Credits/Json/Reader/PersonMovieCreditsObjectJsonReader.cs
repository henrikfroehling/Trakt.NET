namespace TraktNet.Objects.Get.People.Credits.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonMovieCreditsObjectJsonReader : AObjectJsonReader<ITraktPersonMovieCredits>
    {
        public override async Task<ITraktPersonMovieCredits> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktPersonMovieCredits));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieCreditsCastReader = new PersonMovieCreditsCastItemArrayJsonReader();
                var movieCreditsCrewReader = new PersonMovieCreditsCrewObjectJsonReader();

                ITraktPersonMovieCredits movieCredits = new TraktPersonMovieCredits();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PERSON_MOVIE_CREDITS_PROPERTY_NAME_CAST:
                            movieCredits.Cast = await movieCreditsCastReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_MOVIE_CREDITS_PROPERTY_NAME_CREW:
                            movieCredits.Crew = await movieCreditsCrewReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return movieCredits;
            }

            return await Task.FromResult(default(ITraktPersonMovieCredits));
        }
    }
}
