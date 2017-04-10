namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    public partial class ITraktShowIdsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""trakt"": 1390,
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""tmdb"": 1399,
                ""tvrage"": 24493
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tvrage"": 24493
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""trakt"": 1390
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""slug"": ""game-of-thrones""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""tvdb"": 121361
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""imdb"": ""tt0944947""
              }";

        private const string JSON_INCOMPLETE_11 =
            @"{
                ""tmdb"": 1399
              }";

        private const string JSON_INCOMPLETE_12 =
            @"{
                ""tvrage"": 24493
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tr"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""trakt"": 1390,
                ""sl"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tv"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""im"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tvrage"": 24493
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tm"": 1399,
                ""tvrage"": 24493
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""trakt"": 1390,
                ""slug"": ""game-of-thrones"",
                ""tvdb"": 121361,
                ""imdb"": ""tt0944947"",
                ""tmdb"": 1399,
                ""tv"": 24493
              }";

        private const string JSON_NOT_VALID_7 =
            @"{
                ""tr"": 1390,
                ""sl"": ""game-of-thrones"",
                ""tv"": 121361,
                ""im"": ""tt0944947"",
                ""tm"": 1399,
                ""tvr"": 24493
              }";
    }
}
