namespace TraktNet.Objects.Basic.Tests.Json.Reader
{
    public partial class CastMemberObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""character"": ""Joe Brody"",
                ""characters"": [
                  ""Joe Brody""
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
                ""character"": ""Joe Brody"",
                ""characters"": [
                  ""Joe Brody""
                ],
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""ch"": ""Joe Brody"",
                ""chs"": [
                  ""Joe Brody""
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
                ""character"": ""Joe Brody"",
                ""characters"": [
                  ""Joe Brody""
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
                ""ch"": ""Joe Brody"",
                ""chs"": [
                  ""Joe Brody""
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
