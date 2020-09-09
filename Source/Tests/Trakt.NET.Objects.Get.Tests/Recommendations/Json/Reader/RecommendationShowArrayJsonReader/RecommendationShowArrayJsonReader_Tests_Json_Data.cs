namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Reader
{
    public partial class RecommendationShowArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
                  ""notes"": ""Atmospheric for days."",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                },
                {
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
                  ""notes"": ""Atmospheric for days."",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
                  ""notes"": ""Atmospheric for days."",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                },
                {
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
                  ""notes"": ""Atmospheric for days."",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
                  ""notes"": ""Atmospheric for days."",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                },
                {
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
                  ""notes"": ""Atmospheric for days."",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
                  ""notes"": ""Atmospheric for days."",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                },
                {
                  ""ra"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
                  ""notes"": ""Atmospheric for days."",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""ra"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
                  ""notes"": ""Atmospheric for days."",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                },
                {
                  ""rank"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
                  ""notes"": ""Atmospheric for days."",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""ra"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
                  ""notes"": ""Atmospheric for days."",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                },
                {
                  ""ra"": 1,
                  ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                  ""type"": ""show"",
                  ""notes"": ""Atmospheric for days."",
                  ""show"": {
                    ""title"": ""The Walking Dead"",
                    ""year"": 2010,
                    ""ids"": {
                      ""trakt"": 2,
                      ""slug"": ""the-walking-dead"",
                      ""tvdb"": 153021,
                      ""imdb"": ""tt1520211"",
                      ""tmdb"": 1402
                    }
                  }
                }
              ]";
    }
}
