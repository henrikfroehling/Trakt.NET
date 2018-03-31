namespace TraktApiSharp.Tests.Modules.TraktCheckinsModule
{
    public partial class TraktCheckinsModule_Tests
    {
        private const string MOVIE_CHECKIN_POST_RESPONSE_JSON =
            @"{
                ""id"": 3373536619,
                ""watched_at"": ""2014-08-06T01:11:37.953Z"",
                ""sharing"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""tumblr"": false
                },
                ""movie"": {
                  ""title"": ""Guardians of the Galaxy"",
                  ""year"": 2014,
                  ""ids"": {
                    ""trakt"": 28,
                    ""slug"": ""guardians-of-the-galaxy-2014"",
                    ""imdb"": ""tt2015381"",
                    ""tmdb"": 118340
                  }
                }
              }";

        private const string EPISODE_CHECKIN_POST_RESPONSE_JSON =
            @"{
                ""id"": 3373536620,
                ""watched_at"": ""2014-08-06T06:54:36.859Z"",
                ""sharing"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""tumblr"": false
                },
                ""episode"": {
                  ""season"": 1,
                  ""number"": 1,
                  ""title"": ""Pilot"",
                  ""ids"": {
                    ""trakt"": 16,
                    ""tvdb"": 349232,
                    ""imdb"": ""tt0959621"",
                    ""tmdb"": 62085,
                    ""tvrage"": 637041
                  }
                },
                ""show"": {
                  ""title"": ""Breaking Bad"",
                  ""year"": 2008,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""breaking-bad"",
                    ""tvdb"": 81189,
                    ""imdb"": ""tt0903747"",
                    ""tmdb"": 1396,
                    ""tvrage"": 18164
                  }
                }
              }";
    }
}
