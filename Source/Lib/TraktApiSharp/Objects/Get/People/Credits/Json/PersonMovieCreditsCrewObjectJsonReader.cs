namespace TraktApiSharp.Objects.Get.People.Credits.Json
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class PersonMovieCreditsCrewObjectJsonReader : IObjectJsonReader<ITraktPersonMovieCreditsCrew>
    {
        public Task<ITraktPersonMovieCreditsCrew> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktPersonMovieCreditsCrew));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktPersonMovieCreditsCrew> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktPersonMovieCreditsCrew));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktPersonMovieCreditsCrew> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktPersonMovieCreditsCrew));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var creditsMovieCrewItemsReader = new PersonMovieCreditsCrewItemArrayJsonReader();

                ITraktPersonMovieCreditsCrew movieCreditsCrew = new TraktPersonMovieCreditsCrew();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_PRODUCTION:
                            movieCreditsCrew.Production = await creditsMovieCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_ART:
                            movieCreditsCrew.Art = await creditsMovieCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_CREW:
                            movieCreditsCrew.Crew = await creditsMovieCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_COSTUME_AND_MAKE_UP:
                            movieCreditsCrew.CostumeAndMakeup = await creditsMovieCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_DIRECTING:
                            movieCreditsCrew.Directing = await creditsMovieCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_WRITING:
                            movieCreditsCrew.Writing = await creditsMovieCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_SOUND:
                            movieCreditsCrew.Sound = await creditsMovieCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_CAMERA:
                            movieCreditsCrew.Camera = await creditsMovieCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_LIGHTING:
                            movieCreditsCrew.Lighting = await creditsMovieCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_VISUAL_EFFECTS:
                            movieCreditsCrew.VisualEffects = await creditsMovieCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PERSON_MOVIE_CREDITS_CREW_PROPERTY_NAME_EDITING:
                            movieCreditsCrew.Editing = await creditsMovieCrewItemsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return movieCreditsCrew;
            }

            return await Task.FromResult(default(ITraktPersonMovieCreditsCrew));
        }
    }
}
