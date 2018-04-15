namespace TraktApiSharp.Tests.Modules.TraktScrobbleModule
{
    public partial class TraktScrobbleModule_Tests
    {
        private const string MOVIE_START_SCROBBLE_POST_RESPONSE_JSON =
            @"{
                ""id"": 0,
                ""action"": ""start"",
                ""progress"": 1.25,
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

        private const string MOVIE_PAUSE_SCROBBLE_POST_RESPONSE_JSON =
            @"{
                ""id"": 0,
                ""action"": ""pause"",
                ""progress"": 75,
                ""sharing"": {
                  ""facebook"": false,
                  ""twitter"": false,
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

        private const string MOVIE_STOP_SCROBBLE_POST_RESPONSE_JSON =
            @"{
                ""id"": 3373536622,
                ""action"": ""scrobble"",
                ""progress"": 85,
                ""sharing"": {
                  ""facebook"": false,
                  ""twitter"": false,
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

        private const string EPISODE_START_SCROBBLE_POST_RESPONSE_JSON =
            @"{
                ""id"": 0,
                ""action"": ""start"",
                ""progress"": 10,
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

        private const string EPISODE_PAUSE_SCROBBLE_POST_RESPONSE_JSON =
            @"{
                ""id"": 0,
                ""action"": ""pause"",
                ""progress"": 75,
                ""sharing"": {
                  ""facebook"": false,
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

        private const string EPISODE_STOP_SCROBBLE_POST_RESPONSE_JSON =
            @"{
                ""id"": 3373536623,
                ""action"": ""scrobble"",
                ""progress"": 85,
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
