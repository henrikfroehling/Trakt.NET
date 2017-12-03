namespace TraktApiSharp.Tests.Objects.Get.Episodes.Json.Reader
{
    public partial class EpisodeIdsObjectJsonReader_Tests
    {
        private const string JSON_COMPLETE =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""trakt"": 73640,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tvrage"": 1065008299
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""trakt"": 73640
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""tvdb"": 3254641
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""imdb"": ""tt1480055""
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""tmdb"": 63056
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""tvrage"": 1065008299
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""tr"": 73640,
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""trakt"": 73640,
                ""tv"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""im"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tm"": 63056,
                ""tvrage"": 1065008299
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""trakt"": 73640,
                ""tvdb"": 3254641,
                ""imdb"": ""tt1480055"",
                ""tmdb"": 63056,
                ""tvr"": 1065008299
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""tr"": 73640,
                ""tv"": 3254641,
                ""im"": ""tt1480055"",
                ""tm"": 63056,
                ""tvr"": 1065008299
              }";
    }
}
