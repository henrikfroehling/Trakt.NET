namespace TraktApiSharp.Tests.Objects.Post.Responses.Json.Reader
{
    public partial class PostResponseNotFoundShowArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                },
                {
                  ""ids"": {
                    ""trakt"": 60300,
                    ""slug"": ""the-flash-2014"",
                    ""tvdb"": 279121,
                    ""imdb"": ""tt3107288"",
                    ""tmdb"": 60735,
                    ""tvrage"": 36939
                  }
                }
              ]";

        private const string JSON_NOT_VALID =
            @"[
                {
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                },
                {
                  ""id"": {
                    ""trakt"": 60300,
                    ""slug"": ""the-flash-2014"",
                    ""tvdb"": 279121,
                    ""imdb"": ""tt3107288"",
                    ""tmdb"": 60735,
                    ""tvrage"": 36939
                  }
                }
              ]";
    }
}
