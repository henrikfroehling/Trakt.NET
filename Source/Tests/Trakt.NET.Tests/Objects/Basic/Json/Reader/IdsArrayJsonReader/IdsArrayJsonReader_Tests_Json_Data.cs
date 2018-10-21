namespace TraktNet.Tests.Objects.Basic.Json.Reader.IdsArrayJsonReader
{
    public partial class IdsArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = "[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                {
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""tr"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""trakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                {
                  ""traaakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""tr"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                },
                {
                  ""traaakt"": 1390,
                  ""slug"": ""game-of-thrones"",
                  ""tvdb"": 121361,
                  ""imdb"": ""tt0944947"",
                  ""tmdb"": 1399,
                  ""tvrage"": 24493
                }
              ]";
    }
}
