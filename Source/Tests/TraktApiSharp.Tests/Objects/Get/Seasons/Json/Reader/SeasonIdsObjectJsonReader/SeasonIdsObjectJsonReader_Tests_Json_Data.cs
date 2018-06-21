namespace TraktNet.Tests.Objects.Get.Seasons.Json.Reader
{
    public partial class SeasonIdsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""trakt"": 61430,
                ""tvdb"": 279121,
                ""tmdb"": 60523,
                ""tvrage"": 36939
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""tvdb"": 279121,
                ""tmdb"": 60523,
                ""tvrage"": 36939
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""trakt"": 61430,
                ""tmdb"": 60523,
                ""tvrage"": 36939
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""trakt"": 61430,
                ""tvdb"": 279121,
                ""tvrage"": 36939
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""trakt"": 61430,
                ""tvdb"": 279121,
                ""tmdb"": 60523
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""trakt"": 61430
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""tvdb"": 279121
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""tmdb"": 60523
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""tvrage"": 36939
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tr"": 61430,
                ""tvdb"": 279121,
                ""tmdb"": 60523,
                ""tvrage"": 36939
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""trakt"": 61430,
                ""tv"": 279121,
                ""tmdb"": 60523,
                ""tvrage"": 36939
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""trakt"": 61430,
                ""tvdb"": 279121,
                ""tm"": 60523,
                ""tvrage"": 36939
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""trakt"": 61430,
                ""tvdb"": 279121,
                ""tmdb"": 60523,
                ""tvr"": 36939
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""tr"": 61430,
                ""tv"": 279121,
                ""tm"": 60523,
                ""tvr"": 36939
              }";
    }
}
