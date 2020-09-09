namespace TraktNet.Objects.Get.Tests.Recommendations.Json.Reader
{
    public partial class RecommendationMovieObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""rank"": 1,
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack.""
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
                ""type"": ""movie""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack.""
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ra"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""rank"": 1,
                ""la"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""no"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""movie"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""movie"",
                ""notes"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""mov"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""ra"": 1,
                ""la"": ""2014-09-01T09:10:11.000Z"",
                ""ty"": ""movie"",
                ""no"": ""Daft Punk really knocks it out of the park on the soundtrack."",
                ""mov"": {
                  ""title"": ""TRON: Legacy"",
                  ""year"": 2010,
                  ""ids"": {
                    ""trakt"": 1,
                    ""slug"": ""tron-legacy-2010"",
                    ""imdb"": ""tt1104001"",
                    ""tmdb"": 20526
                  }
                }
              }";
    }
}
