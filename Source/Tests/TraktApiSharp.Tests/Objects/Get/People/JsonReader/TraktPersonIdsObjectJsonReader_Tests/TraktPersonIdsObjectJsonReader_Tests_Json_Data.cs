namespace TraktApiSharp.Tests.Objects.Get.People.JsonReader
{
    public partial class TraktPersonIdsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""trakt"": 297737,
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tvrage"": 1797
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""trakt"": 297737
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""slug"": ""bryan-cranston""
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""imdb"": ""nm0186505""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""tmdb"": 17419
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""tvrage"": 1797
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tr"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""trakt"": 297737,
                ""sl"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""im"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tm"": 17419,
                ""tvrage"": 1797
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""trakt"": 297737,
                ""slug"": ""bryan-cranston"",
                ""imdb"": ""nm0186505"",
                ""tmdb"": 17419,
                ""tvr"": 1797
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""tr"": 297737,
                ""sl"": ""bryan-cranston"",
                ""im"": ""nm0186505"",
                ""tm"": 17419,
                ""tvr"": 1797
              }";
    }
}
