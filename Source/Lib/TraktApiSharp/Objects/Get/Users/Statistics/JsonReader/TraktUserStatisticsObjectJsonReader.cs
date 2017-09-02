namespace TraktApiSharp.Objects.Get.Users.Statistics.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktUserStatisticsObjectJsonReader : IObjectJsonReader<ITraktUserStatistics>
    {
        private const string PROPERTY_NAME_MOVIES = "movies";
        private const string PROPERTY_NAME_SHOWS = "shows";
        private const string PROPERTY_NAME_SEASONS = "seasons";
        private const string PROPERTY_NAME_EPISODES = "episodes";
        private const string PROPERTY_NAME_NETWORK = "network";
        private const string PROPERTY_NAME_RATINGS = "ratings";

        public Task<ITraktUserStatistics> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserStatistics));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserStatistics> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserStatistics));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserStatistics> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserStatistics));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var moviesStatisticsReader = new UserMoviesStatisticsObjectJsonReader();
                var showsStatisticsReader = new TraktUserShowsStatisticsObjectJsonReader();
                var seasonsStatisticsReader = new UserSeasonsStatisticsObjectJsonReader();
                var episodesStatisticsReader = new UserEpisodesStatisticsObjectJsonReader();
                var networkStatisticsReader = new UserNetworkStatisticsObjectJsonReader();
                var ratingsStatisticsReader = new UserRatingsStatisticsObjectJsonReader();

                ITraktUserStatistics userStatistics = new TraktUserStatistics();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_MOVIES:
                            userStatistics.Movies = await moviesStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOWS:
                            userStatistics.Shows = await showsStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SEASONS:
                            userStatistics.Seasons = await seasonsStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_EPISODES:
                            userStatistics.Episodes = await episodesStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_NETWORK:
                            userStatistics.Network = await networkStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_RATINGS:
                            userStatistics.Ratings = await ratingsStatisticsReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return userStatistics;
            }

            return await Task.FromResult(default(ITraktUserStatistics));
        }
    }
}
