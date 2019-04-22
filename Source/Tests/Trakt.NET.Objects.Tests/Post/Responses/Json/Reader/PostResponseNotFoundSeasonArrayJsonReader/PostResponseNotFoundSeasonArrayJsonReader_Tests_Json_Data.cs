namespace TraktNet.Objects.Tests.Post.Responses.Json.Reader
{
    public partial class PostResponseNotFoundSeasonArrayJsonReader_Tests
    {
        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                },
                {
                  ""ids"": {
                    ""trakt"": 61431,
                    ""tvdb"": 578373,
                    ""tmdb"": 60524,
                    ""tvrage"": 36940
                  }
                }
              ]";

        private const string JSON_NOT_VALID =
            @"[
                {
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                },
                {
                  ""id"": {
                    ""trakt"": 61431,
                    ""tvdb"": 578373,
                    ""tmdb"": 60524,
                    ""tvrage"": 36940
                  }
                }
              ]";
    }
}
