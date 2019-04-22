namespace TraktNet.Objects.Tests.Post.Responses.Json.Reader
{
    public partial class PostResponseNotFoundEpisodeArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""ids"": {
                    ""trakt"": 73640,
                    ""tvdb"": 3254641,
                    ""imdb"": ""tt1480055"",
                    ""tmdb"": 63056,
                    ""tvrage"": 1065008299
                  }
                },
                {
                  ""ids"": {
                    ""trakt"": 73641,
                    ""tvdb"": 3436411,
                    ""imdb"": ""tt1668746"",
                    ""tmdb"": 63057,
                    ""tvrage"": 1065023912
                  }
                }
              ]";

        private const string JSON_NOT_VALID =
            @"[
                {
                  ""ids"": {
                    ""trakt"": 73640,
                    ""tvdb"": 3254641,
                    ""imdb"": ""tt1480055"",
                    ""tmdb"": 63056,
                    ""tvrage"": 1065008299
                  }
                },
                {
                  ""id"": {
                    ""trakt"": 73641,
                    ""tvdb"": 3436411,
                    ""imdb"": ""tt1668746"",
                    ""tmdb"": 63057,
                    ""tvrage"": 1065023912
                  }
                }
              ]";
    }
}
