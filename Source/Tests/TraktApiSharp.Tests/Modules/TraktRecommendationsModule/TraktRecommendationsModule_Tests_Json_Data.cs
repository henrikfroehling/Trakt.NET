namespace TraktApiSharp.Tests.Modules.TraktRecommendationsModule
{
    using TraktApiSharp.Requests.Parameters;

    public partial class TraktRecommendationsModule_Tests
    {
        private const string MOVIE_ID = "94024";
        private const string SHOW_ID = "1390";
        private const uint LIMIT = 4U;
        private readonly TraktExtendedInfo EXTENDED_INFO = new TraktExtendedInfo { Full = true };

        private const string MOVIE_RECOMMENDATIONS_JSON =
            @"[
                {
                  ""title"": ""Blackfish"",
                  ""year"": 2013,
                  ""ids"": {
                    ""trakt"": 58,
                    ""slug"": ""blackfish-2013"",
                    ""imdb"": ""tt2545118"",
                    ""tmdb"": 158999
                  }
                },
                {
                  ""title"": ""Waiting for Superman"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 289,
                    ""slug"": ""waiting-for-superman-2010"",
                    ""imdb"": ""tt1566648"",
                    ""tmdb"": 39440
                  }
                },
                {
                  ""title"": ""Inside Job"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 329,
                    ""slug"": ""inside-job-2010"",
                    ""imdb"": ""tt1645089"",
                    ""tmdb"": 44639
                  }
                }
              ]";

        private const string SHOW_RECOMMENDATIONS_JSON =
            @"[
                {
                  ""title"": ""The Biggest Loser"",
                  ""year"": 2004,
                  ""ids"": {
                    ""trakt"": 9,
                    ""slug"": ""the-biggest-loser"",
                    ""tvdb"": 75166,
                    ""imdb"": ""tt0429318"",
                    ""tmdb"": 579,
                    ""tvrage"": null
                  }
                },
                {
                  ""title"": ""Shark Tank"",
                  ""year"": 2009,
                  ""ids"": {
                    ""trakt"": 36,
                    ""slug"": ""shark-tank"",
                    ""tvdb"": 100981,
                    ""imdb"": ""tt1442550"",
                    ""tmdb"": 30703,
                    ""tvrage"": 22610
                  }
                },
                {
                  ""title"": ""Hell's Kitchen"",
                  ""year"": 2005,
                  ""ids"": {
                    ""trakt"": 40,
                    ""slug"": ""hell-s-kitchen"",
                    ""tvdb"": 74897,
                    ""imdb"": ""tt0437005"",
                    ""tmdb"": 2370,
                    ""tvrage"": null
                  }
                }
              ]";
    }
}
