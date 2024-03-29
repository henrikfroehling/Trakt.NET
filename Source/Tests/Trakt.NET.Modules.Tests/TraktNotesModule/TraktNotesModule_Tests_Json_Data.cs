namespace TraktNet.Modules.Tests.TraktNotesModule
{
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Movies;
    using TraktNet.Objects.Get.People;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Shows;

    public partial class TraktNotesModule_Tests
    {
        private const string MOVIE_NOTES = "Watch this in IMAX!";

        private const string SHOW_NOTES = "Welcome to Pollos Hermanos!";

        private const string SEASON_NOTES = "Hello Gus.";

        private const string EPISODE_NOTES = "I am the danger!";

        private const string PERSON_NOTES = "Every movie they direct is a masterpiece.";

        private const string HISTORY_ITEM_NOTES = "Saw this in Dolby Cinema!";

        private const ulong HISTORY_ID = 43453489;

        private readonly ITraktMovie MOVIE = new TraktMovie
        {
            Title = "Guardians of the Galaxy",
            Year = 2014,
            Ids = new TraktMovieIds
            {
                Trakt = 28,
                Slug = "guardians-of-the-galaxy-2014",
                Imdb = "tt2015381",
                Tmdb = 118340
            }
        };

        private readonly ITraktShow SHOW = new TraktShow
        {
            Title = "Breaking Bad",
            Ids = new TraktShowIds
            {
                Trakt = 1,
                Slug = "breaking-bad"
            }
        };

        private readonly ITraktSeason SEASON = new TraktSeason
        {
            Ids = new TraktSeasonIds
            {
                Trakt = 16
            }
        };

        private readonly ITraktEpisode EPISODE = new TraktEpisode
        {
            Ids = new TraktEpisodeIds
            {
                Trakt = 16
            }
        };

        private readonly ITraktPerson PERSON = new TraktPerson
        {
            Ids = new TraktPersonIds
            {
                Trakt = 16
            }
        };

        private const string NOTE_POST_RESPONSE_JSON =
            @"{
                ""id"": 190,
                ""notes"": ""Watch this in IMAX!"",
                ""privacy"": ""private"",
                ""spoiler"": false,
                ""created_at"": ""2023-09-12T20:10:18.000Z"",
                ""updated_at"": ""2023-09-12T20:10:56.000Z"",
                ""user"": {
                  ""username"": ""justin"",
                  ""private"": false,
                  ""name"": ""Justin Nemeth"",
                  ""vip"": true,
                  ""vip_ep"": false,
                  ""ids"": {
                    ""slug"": ""justin""
                  }
                }
              }";
    }
}
