namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Post.Responses.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktUserCustomListItemsPostResponseNotFoundGroupObjectJsonReader : IObjectJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup>
    {
        private const string PROPERTY_NAME_MOVIES = "movies";
        private const string PROPERTY_NAME_SHOWS = "shows";
        private const string PROPERTY_NAME_SEASONS = "seasons";
        private const string PROPERTY_NAME_EPISODES = "episodes";
        private const string PROPERTY_NAME_PEOPLE = "people";

        public Task<ITraktUserCustomListItemsPostResponseNotFoundGroup> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserCustomListItemsPostResponseNotFoundGroup));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserCustomListItemsPostResponseNotFoundGroup> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserCustomListItemsPostResponseNotFoundGroup));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserCustomListItemsPostResponseNotFoundGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserCustomListItemsPostResponseNotFoundGroup));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var notFoundMoviesReader = new PostResponseNotFoundMovieArrayJsonReader();
                var notFoundShowsReader = new TraktPostResponseNotFoundShowArrayJsonReader();
                var notFoundSeasonsReader = new TraktPostResponseNotFoundSeasonArrayJsonReader();
                var notFoundEpisodesReader = new PostResponseNotFoundEpisodeArrayJsonReader();
                var notFoundPeopleReader = new TraktPostResponseNotFoundPersonArrayJsonReader();
                ITraktUserCustomListItemsPostResponseNotFoundGroup customListItemsPostResponseNotFoundGroup = new TraktUserCustomListItemsPostResponseNotFoundGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_MOVIES:
                            customListItemsPostResponseNotFoundGroup.Movies = await notFoundMoviesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOWS:
                            customListItemsPostResponseNotFoundGroup.Shows = await notFoundShowsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SEASONS:
                            customListItemsPostResponseNotFoundGroup.Seasons = await notFoundSeasonsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_EPISODES:
                            customListItemsPostResponseNotFoundGroup.Episodes = await notFoundEpisodesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_PEOPLE:
                            customListItemsPostResponseNotFoundGroup.People = await notFoundPeopleReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPostResponseNotFoundGroup;
            }

            return await Task.FromResult(default(ITraktUserCustomListItemsPostResponseNotFoundGroup));
        }
    }
}
