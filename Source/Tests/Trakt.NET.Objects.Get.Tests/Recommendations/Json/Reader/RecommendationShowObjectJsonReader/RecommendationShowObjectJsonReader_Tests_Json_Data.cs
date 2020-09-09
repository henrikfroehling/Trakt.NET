namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Reader
{
    public partial class RecommendationShowObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
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
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""rank"": 1,
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
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
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
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
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
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""notes"": ""Atmospheric for days.""
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""rank"": 1
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""listed_at"": ""2014-09-01T09:10:11.000Z""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""type"": ""show""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""notes"": ""Atmospheric for days.""
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
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
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
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
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""rank"": 1,
                ""la"": ""2014-09-01T09:10:11.000Z"",
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
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""show"",
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
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""no"": ""Atmospheric for days."",
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
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""show"",
                ""notes"": ""Atmospheric for days."",
                ""sh"": {
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
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""ra"": 1,
                ""la"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""show"",
                ""no"": ""Atmospheric for days."",
                ""sh"": {
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
              }";
    }
}
