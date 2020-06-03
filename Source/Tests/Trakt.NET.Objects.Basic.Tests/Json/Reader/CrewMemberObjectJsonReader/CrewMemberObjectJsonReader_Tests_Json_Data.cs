namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class CrewMemberObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""job"": ""Director"",
                ""jobs"": [
                  ""Director""
                ],
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""job"": ""Director"",
                ""jobs"": [
                  ""Director""
                ]
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""j"": ""Director"",
                ""js"": [
                  ""Director""
                ],
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""job"": ""Director"",
                ""jobs"": [
                  ""Director""
                ],
                ""pers"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""j"": ""Director"",
                ""js"": [
                  ""Director""
                ],
                ""pers"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";
    }
}
